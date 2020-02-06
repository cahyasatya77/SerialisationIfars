<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AgregasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KoneksiDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.timerMenuUtama = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregasiToolStripMenuItem, Me.KoneksiDatabaseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(656, 45)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AgregasiToolStripMenuItem
        '
        Me.AgregasiToolStripMenuItem.Checked = True
        Me.AgregasiToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AgregasiToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AgregasiToolStripMenuItem.Name = "AgregasiToolStripMenuItem"
        Me.AgregasiToolStripMenuItem.Size = New System.Drawing.Size(74, 41)
        Me.AgregasiToolStripMenuItem.Text = "Agregasi"
        '
        'KoneksiDatabaseToolStripMenuItem
        '
        Me.KoneksiDatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseConnectionToolStripMenuItem, Me.PLCToolStripMenuItem})
        Me.KoneksiDatabaseToolStripMenuItem.Name = "KoneksiDatabaseToolStripMenuItem"
        Me.KoneksiDatabaseToolStripMenuItem.Size = New System.Drawing.Size(64, 41)
        Me.KoneksiDatabaseToolStripMenuItem.Text = "Setting"
        '
        'DatabaseConnectionToolStripMenuItem
        '
        Me.DatabaseConnectionToolStripMenuItem.Name = "DatabaseConnectionToolStripMenuItem"
        Me.DatabaseConnectionToolStripMenuItem.Size = New System.Drawing.Size(209, 24)
        Me.DatabaseConnectionToolStripMenuItem.Text = "Database Connection"
        '
        'PLCToolStripMenuItem
        '
        Me.PLCToolStripMenuItem.Name = "PLCToolStripMenuItem"
        Me.PLCToolStripMenuItem.Size = New System.Drawing.Size(209, 24)
        Me.PLCToolStripMenuItem.Text = "PLC"
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(435, 330)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(209, 32)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "Date / Time"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerMenuUtama
        '
        Me.timerMenuUtama.Enabled = True
        '
        'MenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 371)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuUtama"
        Me.Text = "Menu Utama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents KoneksiDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PLCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTime As Label
    Friend WithEvents timerMenuUtama As Timer
End Class
