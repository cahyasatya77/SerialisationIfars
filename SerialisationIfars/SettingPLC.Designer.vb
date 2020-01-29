<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingPLC
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
        Me.Waktu = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblKonveyor = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnProgram = New System.Windows.Forms.Button()
        Me.btnMonitor = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblReadDM = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Waktu
        '
        Me.Waktu.AutoSize = True
        Me.Waktu.Location = New System.Drawing.Point(36, 35)
        Me.Waktu.Name = "Waktu"
        Me.Waktu.Size = New System.Drawing.Size(64, 13)
        Me.Waktu.TabIndex = 0
        Me.Waktu.Text = "Date / Time"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Aquamarine
        Me.GroupBox1.Controls.Add(Me.lblKonveyor)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(212, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(132, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Konveyor"
        '
        'lblKonveyor
        '
        Me.lblKonveyor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKonveyor.BackColor = System.Drawing.Color.Red
        Me.lblKonveyor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKonveyor.Location = New System.Drawing.Point(7, 27)
        Me.lblKonveyor.Name = "lblKonveyor"
        Me.lblKonveyor.Size = New System.Drawing.Size(116, 20)
        Me.lblKonveyor.TabIndex = 2
        Me.lblKonveyor.Text = "STOP"
        Me.lblKonveyor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Red
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(68, 62)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(55, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "STOP"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Transparent
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(7, 62)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(55, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SerialPort1
        '
        Me.SerialPort1.DataBits = 7
        Me.SerialPort1.Parity = System.IO.Ports.Parity.Even
        Me.SerialPort1.PortName = "COM3"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Aquamarine
        Me.GroupBox2.Controls.Add(Me.btnRun)
        Me.GroupBox2.Controls.Add(Me.btnProgram)
        Me.GroupBox2.Controls.Add(Me.btnMonitor)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(39, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 144)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Status PLC"
        '
        'btnRun
        '
        Me.btnRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRun.Location = New System.Drawing.Point(11, 91)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(108, 27)
        Me.btnRun.TabIndex = 4
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnProgram
        '
        Me.btnProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProgram.Location = New System.Drawing.Point(11, 58)
        Me.btnProgram.Name = "btnProgram"
        Me.btnProgram.Size = New System.Drawing.Size(108, 27)
        Me.btnProgram.TabIndex = 3
        Me.btnProgram.Text = "Program"
        Me.btnProgram.UseVisualStyleBackColor = True
        '
        'btnMonitor
        '
        Me.btnMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMonitor.Location = New System.Drawing.Point(11, 25)
        Me.btnMonitor.Name = "btnMonitor"
        Me.btnMonitor.Size = New System.Drawing.Size(108, 27)
        Me.btnMonitor.TabIndex = 2
        Me.btnMonitor.Text = "Monitor"
        Me.btnMonitor.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Aquamarine
        Me.GroupBox3.Controls.Add(Me.lblReadDM)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(39, 276)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 100)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Counter Encoder"
        '
        'lblReadDM
        '
        Me.lblReadDM.AutoSize = True
        Me.lblReadDM.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblReadDM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReadDM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadDM.Location = New System.Drawing.Point(150, 25)
        Me.lblReadDM.Name = "lblReadDM"
        Me.lblReadDM.Size = New System.Drawing.Size(52, 26)
        Me.lblReadDM.TabIndex = 1
        Me.lblReadDM.Text = "0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Read Value"
        '
        'SettingPLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ClientSize = New System.Drawing.Size(381, 450)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Waktu)
        Me.Name = "SettingPLC"
        Me.Text = "Setting PLC"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Waktu As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblKonveyor As Label
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnMonitor As Button
    Friend WithEvents btnRun As Button
    Friend WithEvents btnProgram As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblReadDM As Label
    Friend WithEvents Label1 As Label
End Class
