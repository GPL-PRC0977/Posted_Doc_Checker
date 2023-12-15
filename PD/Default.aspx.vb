Public Class _Default
    Inherits Page
    Dim cmd As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        Try
            If Replace(txt_uname.Text, "'", "") = "" Or Replace(txt_pwd.Text, "'", "") = "" Then
                lbl_err.Visible = True
                lbl_err.Text = "Please input username and password!"
                Exit Try
            Else
                lbl_err.Visible = False
            End If

            Dim ds As New DataSet
            cmd = "select * from SystemUser where loginName = '" & Replace(txt_uname.Text, "'", "") & "' and [Password] = '" & Replace(txt_pwd.Text, "'", "") & "'"
            ds = ExecuteQueryBarter(cmd)
            If ds.Tables(0).Rows.Count > 0 Then
                Session("user") = ds.Tables(0).Rows(0)("Name")
                Response.Redirect("posteddoc.aspx")
            Else
                lbl_err.Visible = True
                lbl_err.Text = "Invalid username/password!"
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class