Public Class SettingPLC
    Public TX As String
    Public FCS As String
    Public RXD As String
    Public NDAS As String

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        'Display current date and time
        Waktu.Text = System.DateTime.Now
        'Open the serial port
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00RD00000010"
        Call GetFCS()
        Call communicate()
        SerialPort1.Close()
        If RXD.Substring(5, 2) = "00" Then
            lblReadDM.Text = RXD.Substring(7, 4)
        End If
        'look status PLC omron and open again connection serial port
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00MS"
        Call GetFCS()
        Call communicate()
        Dim rdStatus As String
        rdStatus = TX + FCS + "*"
        If rdStatus = "@00MS00000856*" Then
            btnMonitor.BackColor = Color.Green
            btnProgram.BackColor = Color.Empty
            btnRun.BackColor = Color.Empty
        End If
        If rdStatus = "@00MS00030855*" Then
            btnMonitor.BackColor = Color.Empty
            btnProgram.BackColor = Color.Green
            btnRun.BackColor = Color.Empty
        End If
        If rdStatus = "@00MS00020854*" Then
            btnMonitor.BackColor = Color.Empty
            btnProgram.BackColor = Color.Empty
            btnRun.BackColor = Color.Green
        End If
        SerialPort1.Close()
        Timer1.Enabled = True
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00KSCIO 010000"
        Call GetFCS()
        Call communicate()
        If RXD.Substring(5, 2) = "00" Then
            lblKonveyor.BackColor = Color.Green
            lblKonveyor.Text = "Running"
            btnStart.BackColor = Color.Green
            btnStop.BackColor = Color.Empty
        End If
        SerialPort1.Close()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00KRCIO 010000"
        Call GetFCS()
        Call communicate()
        If RXD.Substring(5, 2) = "00" Then
            lblKonveyor.BackColor = Color.Red
            lblKonveyor.Text = "STOP"
            btnStart.BackColor = Color.Empty
            btnStop.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnMonitor_Click(sender As Object, e As EventArgs) Handles btnMonitor.Click
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00SC00"
        Call GetFCS()
        Call communicate()
        If RXD.Substring(5, 2) = "00" Then
            Console.WriteLine("Connection PLC mintoring")
        End If
        SerialPort1.Close()
    End Sub

    Private Sub btnProgram_Click(sender As Object, e As EventArgs) Handles btnProgram.Click
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00SC02"
        Call GetFCS()
        Call communicate()
        If RXD.Substring(5, 2) = "00" Then
            Console.WriteLine("Connection PLC programing")
        End If
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If SerialPort1.IsOpen = False Then
            SerialPort1.Open()
        End If
        TX = "@00SC03"
        Call GetFCS()
        Call communicate()
        If RXD.Substring(5, 2) Then
            Console.WriteLine("Connection PLC running")
        End If
    End Sub
End Class