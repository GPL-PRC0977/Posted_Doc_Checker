Public Class posteddoc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") = "" Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        Session("user") = ""
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Try
            Dim cmd As String
            Dim ds As New DataSet

            Dim word As String = txt_search.Text
            Dim wordArr As String() = word.Split("-")
            Dim result As String = wordArr(1)

            'If checkDocument() = False Then
            '    MsgBox("This document number is not exist or invalid format." & vbCrLf & vbCrLf & "Date and time of checking" & vbCrLf & "Date: " & Date.Now.ToShortDateString & "" & vbCrLf & "Time: " & DateAndTime.Now.ToShortTimeString & "", vbInformation, "System Message")
            'Else
            cmd = "SELECT top 1 a.[Source No_]
                        ,(select top 1 [Name] from [" & result & "$Location] where [Code] = a.[Location Code] and [Name] <> '') as [Location Code]
                        ,(select top 1 [Name] from [" & result & "$Location] where [Code] = a.[Destination No_] and [Name] <> '') as [Destination No_]
                        ,a.[Shipment Date]
                        ,a.[Posting Date]
                        ,a.[Whse_ Shipment No_]
                     FROM [Primer_Prod2-16-14].[dbo].[" & result & "$Posted Whse_ Shipment Line] as a where [Source No_] = '" & txt_search.Text & "'"
            ds = ExecuteQueryNAV(cmd)

            If ds.Tables(0).Rows.Count > 0 Then
                gv.DataSource = ds.Tables(0)
                gv.DataBind()

                Dim date1 As Date = Format(ds.Tables(0).Rows(0)("Posting Date"), "MM/dd/yyyy")
                Dim date2 As Date = Format(Date.Now, "MM/dd/yyyy")
                Dim datePosted As String
                datePosted = DateDiff(DateInterval.Day, date1, date2)

                If date1 >= date2 Then
                    lbl_message.Text = "<label style='color:red'>This document was just posted today and will reflect tomorrow.</label>"
                Else
                    lbl_message.Text = "<label style='color:green;'>Document successfully found.</label> </br> If still not reflecting in your Barter MMS, Please screenshot this message below and email <a href = 'mailto: support.ict@primergrp.com'>ICT Support.</a>"
                End If

            Else
                If checkDocument() = True Then
                    lbl_message.Text = "This document number is pending to warehouse. Please coordinate to your warehouse contact person." & "<p></p><p>Date and time of checking</p>" & "Date: <label style='color:green;'>" & Date.Now.ToShortDateString & "</label>" & "</br>Time: <label style='color:green;'>" & DateAndTime.Now.ToShortTimeString & "</label>"
                Else
                    lbl_message.Text = "Document not found!"
                End If
                gv.DataSource = Nothing
                gv.DataBind()
            End If


        Catch ex As Exception
            lbl_message.Text = ex.Message
        End Try
    End Sub

    Public Function checkDocument() As Boolean
        Dim cmd As String
        Dim ds As New DataSet

        Try
            cmd = "select distinct * from (SELECT [Document No_] FROM [Primer_Prod2-16-14].[dbo].[KIDC$Transfer Line]
                         union all
                         SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[PGII$Transfer Line]
                         union all
                         SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[CSI$Transfer Line]
                         union all
                         SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[LTS$Transfer Line]
	                     union all
	                     SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[UTCI$Transfer Line]
	                     union all
                         SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[PKCI$Transfer Line]
                         union all
                        SELECT distinct [Document No_] FROM [Primer_Prod2-16-14].[dbo].[KSC$Transfer Line]) as a where [Document No_] = '" & Replace(txt_search.Text, "'", "") & "'"
            ds = ExecuteQueryNAV(cmd)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class