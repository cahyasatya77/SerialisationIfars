Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Call KoneksiSerialisasi()
            Dim str As String
            str = "SELECT * FROM user WHERE username = @username AND password = @password"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@username", MySqlDbType.String).Value = txtUsername.Text
            cmd.Parameters.Add("@password", MySqlDbType.String).Value = txtPassword.Text
            da = New MySqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "user")
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                rd.Close()
                rd.Dispose()
                MsgBox("Login Berhasil, Selamat datang " & ds.Tables(0).Rows(0).Item(1) & ".", MsgBoxStyle.Information)
                LoginInfo.UserID = ds.Tables(0).Rows(0).Item(0)
                MenuUtama.Visible = True
                MenuUtama.Enabled = True
                Me.Hide()
            Else
                rd.Close()
                MsgBox("Username dan Password salah !!", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class