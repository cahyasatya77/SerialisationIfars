Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Imports Oracle.ManagedDataAccess.Client
Imports QRCoder
Public Class Agregasi
    'koneksi tcp client scanner omron
    Dim stream As NetworkStream
    Dim ipAddress As String
    Dim ipPort As String
    Dim clientIp As TcpClient
    'membuat urutan kode karton
    Dim urutan As String
    Dim hitung As Long
    'menghitung jumlah data input dengan kode_tersier null
    Dim jml As Integer
    'Data input form
    Dim kd_produk As String
    Dim nie As String
    Dim batch As String
    Dim ed As String
    Dim isi_karton As Integer
    'Print dokumen
    Dim WithEvents printDoc As New Printing.PrintDocument()
    'koneksi dengan PLC OMRON
    Public TX As String
    Public FCS As String
    Public RXD As String

    Private Sub GetFCS()
        'This will calculate the FCS value for the communications
        Dim L As Integer
        Dim A As String
        Dim TJ As String
        L = Len(TX)
        A = 0
        For J = 1 To L
            TJ = Mid$(TX, J, 1)
            A = Asc(TJ) Xor A
        Next J
        FCS = Hex$(A)
        If Len(FCS) = 1 Then FCS = "0" + FCS
    End Sub

    Private Sub communicate()
        'This will communicate to the Omron PLC
        Dim BufferTX As String
        Dim fcs_rxd As String
        Try
            RXD = ""
            BufferTX = TX + FCS + "*" + Chr(13)
            'Send the information out the serial port
            SerialPort1.Write(BufferTX)
            'Sleep for 50 msec so the information can be sent on the port
            System.Threading.Thread.Sleep(50)
            'Set the timeout for the serial port at 100 msec
            SerialPort1.ReadTimeout = 100
            'Read up to the carriage return
            RXD = (SerialPort1.ReadTo(Chr(13)))
        Catch ex As Exception
            'If an error occurs then indicate communicate error
            RXD = "Communicate Error"
        End Try
        'Get the FCS or the returned information
        fcs_rxd = RXD.Substring(RXD.Length - 3, 2)
        If RXD.Substring(0, 1) = "@" Then
            TX = RXD.Substring(0, RXD.Length - 3)
        ElseIf RXD.Substring(2, 1) = "@" Then
            TX = RXD.Substring(2, RXD.Length - 5)
            RXD = RXD.Substring(2, RXD.Length - 1)
        End If
        'Check the FCS of the return information. if they are not the same then an error has occurred.
        Call GetFCS()
        If FCS <> fcs_rxd Then
            RXD = "Communicate Error"
        End If
    End Sub

    Sub TrialBacaTableOracle()
        Call KoneksiOracle()
        cmdOracle = connOracle.CreateCommand
        cmdOracle.CommandText = "SELECT INVENTORY_ITEM_ID FROM MTL_SYSTEM_ITEMS_B WHERE INVENTORY_ITEM_ID = :ID AND ORGANIZATION_ID = 87"
        cmdOracle.CommandType = CommandType.Text
        Dim ID As OracleParameter
        ID = New OracleParameter("ID", 17)
        cmdOracle.Parameters.Clear()
        cmdOracle.Parameters.Add(ID)

        rdOracle = cmdOracle.ExecuteReader
        If rdOracle.Read Then
            MessageBox.Show(rdOracle.Item("INVENTORY_ITEM_ID"))
        End If

        rdOracle.Close()
        rdOracle.Dispose()
        connOracle.Close()
    End Sub

    Sub comboBoxBatch()
        Try
            Call KoneksiOracle()
            'Dim str As String
            cmbBatch.Items.Clear()

            cmdOracle = connOracle.CreateCommand
            cmdOracle.CommandText = "select DECODE(GBH.BATCH_STATUS,1,'Pending','WIP') BATCH_STATUS
                    ,substr(msib.SEGMENT1,3) SEGMENT1
                    ,MLN.LOT_NUMBER
                    ,TO_CHAR(MLN.EXPIRATION_DATE,'DD-MON-RRRR') EXPIRATION_DATE
                FROM gme_material_details gmd
                    ,gme_batch_header gbh
                    ,mtl_system_items_b msib
                    ,mtl_system_items_b msi
                    ,mtl_lot_numbers mln
               WHERE line_type = 1
                 and gbh.batch_id = gmd.BATCH_ID
                 and gmd.INVENTORY_ITEM_ID = msib.INVENTORY_ITEM_ID
                 and gmd.ORGANIZATION_ID = msib.ORGANIZATION_ID
                 and msib.ORGANIZATION_ID = msi.ORGANIZATION_ID
                 and substr(msib.SEGMENT1,3) = substr(msi.SEGMENT1,3)
                 and substr(msi.SEGMENT1,1,2) in ('FG','BP')
                 AND GBH.BATCH_STATUS IN (1,2)
                 AND MSI.INVENTORY_ITEM_ID = MLN.INVENTORY_ITEM_ID
                 AND GMD.ORGANIZATION_ID = MLN.ORGANIZATION_ID
                 AND GBH.ATTRIBUTE1 = MLN.LOT_NUMBER
                 AND (SELECT MIN(GBH1.BATCH_NO)
                        FROM gme_material_details gmd1
                            ,gme_batch_header gbh1
                            ,mtl_system_items_b msib1
                       WHERE GMD1.LINE_TYPE = 1
                         and gbh1.batch_id = gmd1.BATCH_ID
                         and gmd1.INVENTORY_ITEM_ID = msib1.INVENTORY_ITEM_ID
                         and gmd1.ORGANIZATION_ID = msib1.ORGANIZATION_ID
                         AND GBH1.BATCH_STATUS IN (1,2)
                         AND SUBSTR(MSIB1.SEGMENT1,3) = SUBSTR(MSIB.SEGMENT1,3)
                         AND GBH1.ATTRIBUTE1 = GBH.ATTRIBUTE1) = GBH.BATCH_NO
                 AND LENGTH(GBH.ATTRIBUTE1) = 5
                 AND substr(msib.SEGMENT1,3) =:SEGMENT1
               ORDER BY substr(msib.SEGMENT1,3)
                    ,MLN.EXPIRATION_DATE"
            cmdOracle.CommandType = CommandType.Text
            Dim segment1 As OracleParameter
            'kd_produk = "DSYUS213"
            segment1 = New OracleParameter("SEGMENT1", kd_produk)
            cmdOracle.Parameters.Clear()
            cmdOracle.Parameters.Add(segment1)

            rdOracle = cmdOracle.ExecuteReader

            If rdOracle.HasRows Then
                Do While rdOracle.Read
                    cmbBatch.Items.Add(rdOracle("LOT_NUMBER"))
                Loop
            End If

            rdOracle.Close()
            rdOracle.Dispose()
            connOracle.Close()
        Catch ex As Exception
            MsgBox("Request timeout.", MsgBoxStyle.Information)
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub expiredDate()
        Call KoneksiOracle()
        cmdOracle = connOracle.CreateCommand
        cmdOracle.CommandText = "select DECODE(GBH.BATCH_STATUS,1,'Pending','WIP') BATCH_STATUS
                    ,substr(msib.SEGMENT1,3) SEGMENT1
                    ,MLN.LOT_NUMBER
                    ,TO_CHAR(MLN.EXPIRATION_DATE,'YYMMDD') EXPIRATION_DATE
                FROM gme_material_details gmd
                    ,gme_batch_header gbh
                    ,mtl_system_items_b msib
                    ,mtl_system_items_b msi
                    ,mtl_lot_numbers mln
               WHERE line_type = 1
                 and gbh.batch_id = gmd.BATCH_ID
                 and gmd.INVENTORY_ITEM_ID = msib.INVENTORY_ITEM_ID
                 and gmd.ORGANIZATION_ID = msib.ORGANIZATION_ID
                 and msib.ORGANIZATION_ID = msi.ORGANIZATION_ID
                 and substr(msib.SEGMENT1,3) = substr(msi.SEGMENT1,3)
                 and substr(msi.SEGMENT1,1,2) in ('FG','BP')
                 AND GBH.BATCH_STATUS IN (1,2)
                 AND MSI.INVENTORY_ITEM_ID = MLN.INVENTORY_ITEM_ID
                 AND GMD.ORGANIZATION_ID = MLN.ORGANIZATION_ID
                 AND GBH.ATTRIBUTE1 = MLN.LOT_NUMBER
                 AND (SELECT MIN(GBH1.BATCH_NO)
                        FROM gme_material_details gmd1
                            ,gme_batch_header gbh1
                            ,mtl_system_items_b msib1
                       WHERE GMD1.LINE_TYPE = 1
                         and gbh1.batch_id = gmd1.BATCH_ID
                         and gmd1.INVENTORY_ITEM_ID = msib1.INVENTORY_ITEM_ID
                         and gmd1.ORGANIZATION_ID = msib1.ORGANIZATION_ID
                         AND GBH1.BATCH_STATUS IN (1,2)
                         AND SUBSTR(MSIB1.SEGMENT1,3) = SUBSTR(MSIB.SEGMENT1,3)
                         AND GBH1.ATTRIBUTE1 = GBH.ATTRIBUTE1) = GBH.BATCH_NO
                 AND LENGTH(GBH.ATTRIBUTE1) = 5 -- 20190406
                 AND substr(msib.SEGMENT1,3) =:SEGMENT1
                 AND MLN.LOT_NUMBER =:NO_BATCH
               ORDER BY substr(msib.SEGMENT1,3)
                    ,MLN.EXPIRATION_DATE"
        cmdOracle.CommandType = CommandType.Text
        Dim segment1, no_batch As OracleParameter
        segment1 = New OracleParameter("SEGMENT1", kd_produk)
        no_batch = New OracleParameter("NO_BATCH", batch)
        cmdOracle.Parameters.Clear()
        cmdOracle.Parameters.Add(segment1)
        cmdOracle.Parameters.Add(no_batch)

        rdOracle = cmdOracle.ExecuteReader
        If rdOracle.Read Then
            ed = rdOracle.Item("EXPIRATION_DATE")
        End If
        rdOracle.Close()
        rdOracle.Dispose()
        connOracle.Dispose()
    End Sub

    Sub isiKarton()
        Call KoneksiOracle()
        cmdOracle = connOracle.CreateCommand
        cmdOracle.CommandText = "SELECT MSIB.SEGMENT1, SUBSTR(MSIB.SEGMENT1,3) KODE, MUC.CONVERSION_RATE
                ,MSIB.PRIMARY_UNIT_OF_MEASURE
                ,CASE WHEN UPPER(MSIB.DESCRIPTION) LIKE '%AMPLOP%'
                      THEN TRIM(SUBSTR(MSIB.DESCRIPTION,INSTR(UPPER(MSIB.DESCRIPTION),'AMPLOP')-3,9))
                      WHEN UPPER(MSIB.DESCRIPTION) LIKE '%BLISTER%' AND MSIB.SEGMENT1 != 'FGTAPRE233'
                      THEN TRIM(SUBSTR(MSIB.DESCRIPTION,INSTR(UPPER(MSIB.DESCRIPTION),'BLISTER')-3,10))
                      WHEN UPPER(MSIB.DESCRIPTION) LIKE '%STRIP%' AND MSIB.SEGMENT1 != 'FGTFFLO325'
                      THEN TRIM(SUBSTR(MSIB.DESCRIPTION,INSTR(UPPER(MSIB.DESCRIPTION),'STRIP')-3,8))
                      WHEN UPPER(MSIB.DESCRIPTION) LIKE '%TUBE%' OR UPPER(MSIB.DESCRIPTION) LIKE '%BOTOL%'
                      THEN TRIM(SUBSTR(MSIB.DESCRIPTION,INSTR(MSIB.DESCRIPTION,'@')+1))
                      WHEN MSIB.SEGMENT1 = 'FGTFFLO325' THEN '10 strip'
                      WHEN MSIB.SEGMENT1 = 'FGTAPRE233' THEN '10 blister'
                      ELSE NULL
                  END KEMASAN
                 FROM MTL_SYSTEM_ITEMS_B MSIB, MTL_UOM_CONVERSIONS MUC
                WHERE 1=1
                AND MUC.INVENTORY_ITEM_ID = MSIB.INVENTORY_ITEM_ID
                AND MSIB.ORGANIZATION_ID = 83
                AND SUBSTR(MSIB.SEGMENT1,1,2) in ('FG','BP')
                AND MUC.UOM_CODE = 'CRT'
                AND SUBSTR(MSIB.SEGMENT1,3) =:SEGMENT1"
        cmdOracle.CommandType = CommandType.Text
        Dim segment1 As OracleParameter
        segment1 = New OracleParameter("SEGMENT1", kd_produk)
        cmdOracle.Parameters.Clear()
        cmdOracle.Parameters.Add(segment1)

        rdOracle = cmdOracle.ExecuteReader
        If rdOracle.Read Then
            isi_karton = rdOracle.Item("CONVERSION_RATE")
        End If

        rdOracle.Close()
        rdOracle.Dispose()
        connOracle.Close()
    End Sub

    Sub countDataTable()
        Try
            Call KoneksiSerialisasi()
            Dim str As String
            str = "SELECT kode FROM scanner_omron WHERE kode_tersier IS NULL"
            cmd = New MySqlCommand(str, conn)
            da = New MySqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "scanner_omron")

            jml = ds.Tables("scanner_omron").Rows.Count
            Console.WriteLine(jml)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub generateCode()
        Try
            Call KoneksiSerialisasi()
            Dim str As String
            str = "SELECT kode_tersier FROM scanner_omron WHERE kode_tersier IS NOT NULL ORDER BY kode_tersier DESC"
            cmd = New MySqlCommand(str, conn)
            da = New MySqlDataAdapter(cmd)
            ds = New DataSet
            rd = cmd.ExecuteReader
            Dim no_nie, no_batch, tgl_ed As String
            no_nie = txtNIE.Text
            no_batch = cmbBatch.Text
            tgl_ed = txtExpiredDate.Text
            Dim tanggal, kodeKarton As String
            tanggal = "KT" + Format(Date.Now, "yyyyMMdd")
            kodeKarton = "(90)" + no_nie + "(10)" + no_batch + "(17)" + tgl_ed + "(21)" + tanggal

            If rd.Read Then
                rd.Close()
                'rd.Dispose()
                str = "SELECT kode_tersier FROM scanner_omron WHERE LEFT(kode_tersier, @len_tersier) = @tersier ORDER BY kode_tersier DESC LIMIT 1"
                cmd = New MySqlCommand(str, conn)
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@tersier", MySqlDbType.String).Value = kodeKarton
                cmd.Parameters.AddWithValue("@len_tersier", Len(kodeKarton))
                rd = cmd.ExecuteReader
                If rd.Read Then
                    Dim jajal, data1, angka, data2, nomor_awal As String
                    jajal = rd!kode_tersier
                    nomor_awal = jajal.Substring(0, 52)
                    angka = Len(jajal.Substring(0, 52))
                    data1 = jajal.Substring(angka)
                    data2 = data1 + 1
                    urutan = nomor_awal + Mid("0000", 1, 4 - data2.Length) & data2
                    rd.Close()

                Else
                    rd.Close()
                    urutan = kodeKarton & "0001"
                End If
            Else
                rd.Close()
                urutan = kodeKarton & "0001"
            End If
        Catch ex As Exception
            Console.WriteLine("Error generate kode")
        End Try
    End Sub

    Sub tampilDataComboBox()
        Call KoneksiProductManagement()
        Dim str As String
        str = "SELECT CONCAT(p.kd_produk, ' - ',p.nama_produk) AS produk FROM tbl_produk p 
                JOIN tbl_nie n ON p.kd_produk = n.kd_produk GROUP BY p.kd_produk"
        cmd = New MySqlCommand(str, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                cmbProduk.Items.Add(rd("produk"))
            Loop
        End If
        rd.Close()
        rd.Dispose()
        conn.Close()
    End Sub

    Private Sub Agregasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilDataComboBox()
    End Sub

    Private Sub cmbProduk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduk.SelectedIndexChanged
        Dim kd_produk_awal As String
        If cmbProduk.Text.Substring(0, 2) = "FG" Then
            kd_produk = cmbProduk.Text.Substring(2, 8)
            kd_produk_awal = cmbProduk.Text.Substring(0, 10)
            Console.WriteLine(kd_produk)
        Else
            kd_produk = cmbProduk.Text.Substring(0, 8)
            kd_produk_awal = cmbProduk.Text.Substring(0, 8)
            Console.WriteLine(kd_produk)
        End If
        Call KoneksiProductManagement()
        Dim str As String
        str = "SELECT p.nama_produk, n.nomor_nie FROM tbl_produk p JOIN tbl_nie n ON p.kd_produk = n.kd_produk WHERE p.kd_produk = @kd_produk GROUP BY p.kd_produk"
        cmd = New MySqlCommand(str, conn)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@kd_produk", kd_produk_awal)
        rd = cmd.ExecuteReader
        If rd.Read Then
            txtNIE.Text = rd.Item("nomor_nie")
            txtNamaProduk.Text = rd.Item("nama_produk")
            Console.WriteLine("Success")
            rd.Close()
            rd.Dispose()
            conn.Close()
            cmbBatch.Items.Clear()
            Call comboBoxBatch()
            txtExpiredDate.Clear()
            txtJmlDus.Clear()
        Else
            Console.WriteLine("Error")
        End If
        rd.Close()
        rd.Dispose()
        conn.Close()
        'Call comboBoxBatch()

    End Sub

    Private Sub cmbBatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatch.SelectedIndexChanged
        If cmbProduk.Text.Substring(0, 2) = "FG" Then
            kd_produk = cmbProduk.Text.Substring(2, 8)
        Else
            kd_produk = cmbProduk.Text.Substring(0, 8)
        End If
        batch = cmbBatch.Text
        Call expiredDate()
        txtExpiredDate.Text = ed
        Call isiKarton()
        txtJmlDus.Text = isi_karton
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If (txtNIE.Text = "" Or txtExpiredDate.Text = "") Then
            MsgBox("Please insert form table", MsgBoxStyle.Information)
        Else
            Try
                ipAddress = "192.168.250.2"
                ipPort = "2050"
                clientIp = New TcpClient
                clientIp.Connect(ipAddress, ipPort)

                If clientIp.Connected = True Then
                    stream = clientIp.GetStream
                    lblDataScanner.Text = "Server scanner telah terhubung."
                    lblDataScanner.BackColor = Color.Green
                    btnStart.Enabled = False
                    btnStop.Enabled = True
                    cmbProduk.Enabled = False
                    cmbBatch.Enabled = False
                    txtJmlDus.Enabled = False
                    Timer1.Start()
                    If SerialPort1.IsOpen = False Then
                        SerialPort1.Open()
                    End If
                    TX = "@00KSCIO 010000"
                    Call GetFCS()
                    Call communicate()
                    If RXD.Substring(5, 2) = "00" Then
                        lblKonveyor.BackColor = Color.Green
                        lblKonveyor.Text = "RUNNING"
                        Console.WriteLine("Conveyor Running")
                    End If
                    SerialPort1.Close()
                End If
            Catch ex As Exception
                MsgBox("Error Koneksi", MsgBoxStyle.Information)
                Console.WriteLine("Error koenksi  : ", ex.Message)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If clientIp.Available > 0 Then
            Dim responseData As [String] = String.Empty
            Dim data(clientIp.Available - 1) As Byte

            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            lblDataScanner.Text = responseData.Substring(0, 51)
            lblDataScanner.BackColor = Color.Green

            'set data insert form
            nie = txtNIE.Text
            batch = cmbBatch.Text
            ed = txtExpiredDate.Text
            isi_karton = txtJmlDus.Text

            Try
                Call KoneksiSerialisasi()
                Dim str As String
                str = "SELECT kode FROM data_print WHERE kode = @kode"
                cmd = New MySqlCommand(str, conn)
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@kode", MySqlDbType.String).Value = responseData.Substring(0, 51)
                Console.WriteLine(responseData.Substring(0, 51))
                'cmd.CommandTimeout = 1200
                rd = cmd.ExecuteReader

                If rd.HasRows Then
                    rd.Close()
                    'rd.Dispose()
                    str = "INSERT INTO scanner_omron (kode, nie, batch, expired_date) VALUES (@data, @nie, @batch, @expired_date)"
                    cmd = New MySqlCommand(str, conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@data", MySqlDbType.String).Value = responseData.Substring(0, 51)
                    cmd.Parameters.Add("@nie", MySqlDbType.String).Value = nie
                    cmd.Parameters.Add("@batch", MySqlDbType.String).Value = batch
                    cmd.Parameters.Add("@expired_date", MySqlDbType.String).Value = ed

                    Try
                        If cmd.ExecuteNonQuery >= 1 Then
                            lblHasil.Text = "SUCCESS"
                            lblHasil.BackColor = Color.Green

                            Call countDataTable()
                            If jml = isi_karton Then
                                urutan = Nothing
                                Call generateCode()
                                Console.WriteLine(urutan)
                                str = "UPDATE scanner_omron SET kode_tersier = @tersier WHERE kode_tersier IS NULL"
                                cmd = New MySqlCommand(str, conn)
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@tersier", MySqlDbType.String).Value = urutan

                                Try
                                    If cmd.ExecuteNonQuery >= 1 Then
                                        Timer1.Stop()
                                        clientIp.GetStream.Close()
                                        rd.Close()
                                        rd.Dispose()
                                        conn.Close()
                                        lblDataScanner.Text = "Silahkan validasi kode Qr karton"
                                        lblDataScanner.BackColor = Color.Gray
                                        txtKarton.Enabled = True
                                        btnKarton.Enabled = True
                                        Console.WriteLine("Berhasil update kode tersier")

                                        'print kode qr karton
                                        Dim gen As New QRCodeGenerator
                                        Dim dataQr = gen.CreateQrCode(urutan, QRCodeGenerator.ECCLevel.Q)
                                        Dim codeQrKarton As New QRCode(dataQr)
                                        PictureBox1.Image = codeQrKarton.GetGraphic(3)

                                        printDoc.Print()

                                        'stop conveyor
                                        If SerialPort1.IsOpen = False Then
                                            SerialPort1.Open()
                                        End If
                                        TX = "@00KRCIO 010000"
                                        Call GetFCS()
                                        Call communicate()
                                        If RXD.Substring(5, 2) = "00" Then
                                            lblKonveyor.BackColor = Color.Red
                                            lblKonveyor.Text = "STOP"
                                            Console.WriteLine("Conveyor stop.")
                                        End If
                                        SerialPort1.Close()

                                    End If
                                Catch ex As Exception
                                    Console.WriteLine("Gagal Update kode tersier")
                                End Try
                            End If
                        Else
                            Console.WriteLine("Errpr Insert")
                            lblHasil.BackColor = Color.Red
                            lblHasil.Text = "NOT FOUND"
                        End If
                    Catch ex As Exception
                        Console.WriteLine("Duplicate")
                        lblHasil.BackColor = Color.Orange
                        lblHasil.Text = "DUPLICATE"
                    End Try
                Else
                    rd.Close()
                    rd.Dispose()
                    lblHasil.BackColor = Color.Red
                    lblHasil.Text = "NOT FOUND"
                End If
            Catch ex As Exception
                lblHasil.BackColor = Color.Red
                lblHasil.Text = "NOTFOUND"
                Console.WriteLine("ERROR : kode tidak ada dalam database")
            End Try
        End If
    End Sub

    Private Sub PrintImage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        e.Graphics.DrawImage(PictureBox1.Image, e.MarginBounds.Left, e.MarginBounds.Top)
    End Sub

    Private Sub btnKarton_Click(sender As Object, e As EventArgs) Handles btnKarton.Click
        If txtKarton.Text = "" Then
            MsgBox("Silahkan scan kode karton", MsgBoxStyle.Information)
        Else
            Dim kodeKarton As String
            kodeKarton = txtKarton.Text

            Call KoneksiSerialisasi()
            Dim str As String
            str = "SELECT kode_tersier FROM scanner_omron WHERE kode_tersier = @kode_tersier"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@kode_tersier", kodeKarton)
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                MsgBox("Scan dus berhasil.", MsgBoxStyle.Information)
                rd.Close()
                rd.Dispose()
                conn.Close()
                'set picture clear
                PictureBox1.Image = Nothing

                Try
                    'connection tcp omron
                    ipAddress = "192.168.250.2"
                    ipPort = "2050"
                    clientIp = New TcpClient
                    clientIp.Connect(ipAddress, ipPort)

                    If clientIp.Connected = True Then
                        stream = clientIp.GetStream
                        lblDataScanner.Text = "Server scanner telah terhubung."
                        lblDataScanner.BackColor = Color.Green
                        txtKarton.Text = ""
                        txtKarton.Enabled = False
                        btnKarton.Enabled = False
                        PictureBox1.Image = Nothing
                        Timer1.Start()
                        If SerialPort1.IsOpen = False Then
                            SerialPort1.Open()
                        End If
                        TX = "@00KSCIO 010000"
                        Call GetFCS()
                        Call communicate()
                        If RXD.Substring(5, 2) = "00" Then
                            lblKonveyor.BackColor = Color.Green
                            lblKonveyor.Text = "Running"
                        End If
                        SerialPort1.Close()
                    End If
                Catch ex As Exception
                    MsgBox("ERROR", MsgBoxStyle.Information)
                    Console.WriteLine("Error connection : ", ex.Message)
                End Try
            Else
                MsgBox("Data Qr Karton tidak ditemukan", MsgBoxStyle.Information)
                rd.Close()
                rd.Dispose()
                conn.Close()

            End If
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        ipAddress = "192.168.250.2"
        ipPort = "2050"
        clientIp = New TcpClient
        clientIp.Connect(ipAddress, ipPort)

        If clientIp.Connected = True Then
            stream = clientIp.GetStream
            clientIp.GetStream.Close()
            Timer1.Stop()
            lblDataScanner.Text = "Silahkan koneksikan dengan server scanner"
            lblDataScanner.BackColor = Color.Silver
            cmbProduk.Enabled = True
            cmbBatch.Enabled = True
            txtJmlDus.Enabled = True
            btnStart.Enabled = True
            btnStop.Enabled = False
            txtKarton.Enabled = False
            btnKarton.Enabled = False
            PictureBox1.Image = Nothing
            If SerialPort1.IsOpen = False Then
                SerialPort1.Open()
            End If
            TX = "@00KRCIO 010000"
            Call GetFCS()
            Call communicate()
            If RXD.Substring(5, 2) = "00" Then
                lblKonveyor.BackColor = Color.Red
                lblKonveyor.Text = "STOP"
            End If
            SerialPort1.Close()
        End If
    End Sub

    Private Sub TimerPLC_Tick(sender As Object, e As EventArgs) Handles TimerPLC.Tick
        TimerPLC.Enabled = False
        'Display current date and time
        Waktu.Text = System.DateTime.Now
        TimerPLC.Enabled = True

    End Sub
End Class