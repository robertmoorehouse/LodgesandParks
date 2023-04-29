Imports System.Data
Imports System.Data.SqlClient
Imports BLL
Imports datacollections
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.IO
Imports emailer
Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Partial Class login
    Inherits findavillaparks.ui.basepage.BasePage
    Dim datacollections As New datacollections
    'Dim DALWebservices As New webservicecalls
    Dim strConnectionString As String
    Dim strFConnectionString As String
    Dim oConn As Data.SqlClient.SqlConnection
    Dim MessageText As String
    Dim userNumber As Integer = 0
    Dim checkuser As Boolean

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("BaseConnectionString").ToString
        strFConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("funds4meConnectionString").ToString

        If Request.Form("username") > "" Then
            checkusername(False)
        ElseIf Session("username") > "" Then
            step1.Visible = False
            Step4.Visible = True
            step1bluetab.CssClass = "first_tab"
            step2bluetab.CssClass = "first_tab_selected"
            login.Visible = False
        Else
            step1.Visible = True
            Step4.Visible = False
            step1bluetab.CssClass = "first_tab_selected"
            step2bluetab.CssClass = "tabs"
            login.Visible = True
        End If

    End Sub

    Private Sub checkusername(ByRef checkuser As Boolean)
        oConn = New SqlClient.SqlConnection
        oConn.ConnectionString = strFConnectionString
        oConn.Open()

        Dim returnuser As Integer
        Dim txtusername As String
        Dim txtpassword As String

        If Request.Form("username") > "" Then
            txtusername = Request.Form("username")
            txtpassword = Request.Form("password")
        Else
            txtusername = username.Text.ToString
            txtpassword = password.Text.ToString
        End If


        Dim SQLUser As New SqlCommand("owner_login_check", oConn)
        SQLUser.CommandType = CommandType.StoredProcedure
        SQLUser.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = Replace(txtusername, "--", "", 1, -1, 1)
        SQLUser.Parameters.Add(New SqlParameter("@password", SqlDbType.VarChar, 15, ParameterDirection.Input)).Value = Replace(txtpassword, "--", "", 1, -1, 1)

        SQLUser.Parameters.Add("@owner_ref", SqlDbType.Int, 1)
        SQLUser.Parameters("@owner_ref").Direction = ParameterDirection.Output

        SQLUser.Parameters.Add("@RETURN_VALUE", System.Data.SqlDbType.Int, 1)
        SQLUser.Parameters("@RETURN_VALUE").Direction = System.Data.ParameterDirection.ReturnValue

        Try
            SQLUser.ExecuteNonQuery()
            returnuser = SQLUser.Parameters("@RETURN_VALUE").Value
        Catch ex As Exception
            returnuser = 0
        Finally
            SQLUser.Dispose()
        End Try

        If returnuser = 0 Then checkuser = True Else checkuser = False
        If checkuser = True Then
            Session("username") = txtusername
            step1.Visible = False
            Step4.Visible = True
            step1bluetab.Text = txtusername
            step1bluetab.CssClass = "first_tab"
            step2bluetab.CssClass = "first_tab_selected"
            login.Visible = False
            'lblStep1.CssClass = "greytext"
            'lblStep4.CssClass = "redtext"
        Else
            step1.Visible = True
            Step4.Visible = False
            step1bluetab.CssClass = "first_tab_selected"
            step2bluetab.CssClass = "tabs"
            login.Visible = True
            'lblStep1.CssClass = "redtext"
            'lblStep4.CssClass = "greytext"
        End If
    End Sub


    Protected Sub panel3Continue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles panel3Continue.Click
        checkusername(False)
    End Sub
End Class
