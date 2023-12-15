Imports System.Data.SqlClient
Module Functions
    Public Function ExecuteQueryBarter(strSQL As String) As DataSet
        Dim ds As New DataSet
        'Dim cn As New SqlConnection(My.Settings.conn)
        Dim cn As New SqlConnection(My.Settings.connBarter)
        Dim cmd As New SqlCommand(strSQL)
        Dim da As New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 1800
        'cmd.CommandTimeout = 30

        Try
            cmd.Connection = cn
            cn.Open()
            da.Fill(ds)
        Catch ex As Exception
            ds = Nothing
        End Try
        cn.Close()
        cn = Nothing
        Return ds
    End Function

    Public Function ExecuteQueryNAV(strSQL As String) As DataSet
        Dim ds As New DataSet
        'Dim cn As New SqlConnection(My.Settings.conn)
        Dim cn As New SqlConnection(My.Settings.connNAV)
        Dim cmd As New SqlCommand(strSQL)
        Dim da As New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 1800
        'cmd.CommandTimeout = 30

        Try
            cmd.Connection = cn
            cn.Open()
            da.Fill(ds)
        Catch ex As Exception
            ds = Nothing
        End Try
        cn.Close()
        cn = Nothing
        Return ds
    End Function
End Module
