Imports MySql.Data.MySqlClient
Imports Oracle.ManagedDataAccess.Client
Module ModuleKoneksi
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public str As String
    'oracle
    Public connOracle As OracleConnection
    Public cmdOracle As OracleCommand
    Public rdOracle As OracleDataReader

    Sub KoneksiSerialisasi()
        Try
            Dim str As String = "Server=localhost;username=root;password=;database=validation"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub KoneksiProductManagement()
        Try
            Dim str As String = "Server=localhost;username=root;password=;database=coba_product_management_2"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub KoneksiOracle()
        Try
            Dim oradb As String = "Data Source=192.168.2.4:1528/DEV;User Id=APPS;Password=apps"
            connOracle = New OracleConnection(oradb)
            If connOracle.State = ConnectionState.Closed Then
                connOracle.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
