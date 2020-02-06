Public Class MenuUtama
    Private Sub DatabaseConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseConnectionToolStripMenuItem.Click
        DatabaseConnection.Show()
        DatabaseConnection.MdiParent = Me
    End Sub

    Private Sub AgregasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregasiToolStripMenuItem.Click
        Agregasi.Show()
        Agregasi.MdiParent = Me
    End Sub

    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Agregasi.Show()
        Agregasi.MdiParent = Me
        'MsgBox("user login : " & LoginInfo.UserID, MsgBoxStyle.Information)
    End Sub

    Private Sub PLCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PLCToolStripMenuItem.Click
        SettingPLC.Show()
        SettingPLC.MdiParent = Me
    End Sub

    Private Sub timerMenuUtama_Tick(sender As Object, e As EventArgs) Handles timerMenuUtama.Tick
        'Display Date Time in aplication
        lblTime.Text = Format(System.DateTime.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub
End Class
