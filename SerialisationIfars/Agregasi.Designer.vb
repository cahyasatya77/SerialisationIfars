<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Agregasi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbBatch = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNamaProduk = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNIE = New System.Windows.Forms.TextBox()
        Me.txtJmlDus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtExpiredDate = New System.Windows.Forms.TextBox()
        Me.cmbProduk = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblDataScanner = New System.Windows.Forms.Label()
        Me.lblHasil = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnKarton = New System.Windows.Forms.Button()
        Me.txtKarton = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(6, 32)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(125, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbBatch)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNamaProduk)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNIE)
        Me.GroupBox1.Controls.Add(Me.txtJmlDus)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtExpiredDate)
        Me.GroupBox1.Controls.Add(Me.cmbProduk)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 198)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Produk"
        '
        'cmbBatch
        '
        Me.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBatch.FormattingEnabled = True
        Me.cmbBatch.Location = New System.Drawing.Point(125, 109)
        Me.cmbBatch.Name = "cmbBatch"
        Me.cmbBatch.Size = New System.Drawing.Size(121, 21)
        Me.cmbBatch.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Kode Produk :"
        '
        'txtNamaProduk
        '
        Me.txtNamaProduk.Enabled = False
        Me.txtNamaProduk.Location = New System.Drawing.Point(125, 56)
        Me.txtNamaProduk.Name = "txtNamaProduk"
        Me.txtNamaProduk.Size = New System.Drawing.Size(268, 20)
        Me.txtNamaProduk.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "NIE :"
        '
        'txtNIE
        '
        Me.txtNIE.Enabled = False
        Me.txtNIE.Location = New System.Drawing.Point(125, 82)
        Me.txtNIE.Name = "txtNIE"
        Me.txtNIE.Size = New System.Drawing.Size(268, 20)
        Me.txtNIE.TabIndex = 15
        '
        'txtJmlDus
        '
        Me.txtJmlDus.Location = New System.Drawing.Point(125, 162)
        Me.txtJmlDus.Name = "txtJmlDus"
        Me.txtJmlDus.Size = New System.Drawing.Size(100, 20)
        Me.txtJmlDus.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Jumlah dus :"
        '
        'txtExpiredDate
        '
        Me.txtExpiredDate.Enabled = False
        Me.txtExpiredDate.Location = New System.Drawing.Point(125, 136)
        Me.txtExpiredDate.Name = "txtExpiredDate"
        Me.txtExpiredDate.Size = New System.Drawing.Size(100, 20)
        Me.txtExpiredDate.TabIndex = 12
        '
        'cmbProduk
        '
        Me.cmbProduk.FormattingEnabled = True
        Me.cmbProduk.Location = New System.Drawing.Point(125, 29)
        Me.cmbProduk.Name = "cmbProduk"
        Me.cmbProduk.Size = New System.Drawing.Size(363, 21)
        Me.cmbProduk.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Expired Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Batch :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nama Produk :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnStop)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Location = New System.Drawing.Point(594, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(137, 152)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(7, 62)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(124, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDataScanner)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 265)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(540, 85)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Hasil Scan"
        '
        'lblDataScanner
        '
        Me.lblDataScanner.AutoSize = True
        Me.lblDataScanner.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblDataScanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataScanner.Location = New System.Drawing.Point(13, 33)
        Me.lblDataScanner.Name = "lblDataScanner"
        Me.lblDataScanner.Size = New System.Drawing.Size(380, 24)
        Me.lblDataScanner.TabIndex = 0
        Me.lblDataScanner.Text = "Silahkan koneksikan dengan server scanner"
        '
        'lblHasil
        '
        Me.lblHasil.AutoSize = True
        Me.lblHasil.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblHasil.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasil.Location = New System.Drawing.Point(25, 371)
        Me.lblHasil.Name = "lblHasil"
        Me.lblHasil.Size = New System.Drawing.Size(177, 31)
        Me.lblHasil.TabIndex = 10
        Me.lblHasil.Text = "NOT FOUND"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnKarton)
        Me.GroupBox4.Controls.Add(Me.txtKarton)
        Me.GroupBox4.Location = New System.Drawing.Point(365, 371)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(366, 92)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Scan QR Karton"
        '
        'btnKarton
        '
        Me.btnKarton.Enabled = False
        Me.btnKarton.Location = New System.Drawing.Point(272, 54)
        Me.btnKarton.Name = "btnKarton"
        Me.btnKarton.Size = New System.Drawing.Size(75, 23)
        Me.btnKarton.TabIndex = 1
        Me.btnKarton.Text = "Running"
        Me.btnKarton.UseVisualStyleBackColor = True
        '
        'txtKarton
        '
        Me.txtKarton.Enabled = False
        Me.txtKarton.Location = New System.Drawing.Point(18, 28)
        Me.txtKarton.Name = "txtKarton"
        Me.txtKarton.Size = New System.Drawing.Size(329, 20)
        Me.txtKarton.TabIndex = 0
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(594, 225)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Agregasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 497)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblHasil)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Agregasi"
        Me.Text = "Agregasi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtExpiredDate As TextBox
    Friend WithEvents cmbProduk As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtJmlDus As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnStop As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblDataScanner As Label
    Friend WithEvents lblHasil As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnKarton As Button
    Friend WithEvents txtKarton As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNIE As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNamaProduk As TextBox
    Friend WithEvents cmbBatch As ComboBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
End Class
