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


Partial Class join
    Inherits findavillaparks.ui.basepage.BasePage
    Dim datacollections As New datacollections
    'Dim DALWebservices As New webservicecalls
    Dim strConnectionString As String
    Dim strFConnectionString As String
    Dim oConn As Data.SqlClient.SqlConnection
    Dim MessageText As String
    Dim userNumber As Integer = 0


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("BaseConnectionString").ToString
        strFConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("funds4meConnectionString").ToString
        If Not Page.IsPostBack Then

            Dim agentCode As String = ""
            Dim agentLetter As String = ""
            Dim agentRef As String = ""

            type.Text = "r"
            join_type.Text = 4
            preload.Text = CInt(0 + Request.QueryString("pl"))

            titles.DataSource = datacollections.GetPersonalTitles()
            titles.DataBind()

            country.DataSource = datacollections.GetCountriesOfTheWorld()
            country.DataBind()
            country.SelectedValue = "United Kingdom"
            setStep1Live()
        End If
    End Sub

    Protected Sub panel1Continue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles panel1Continue.Click
        setStep2Live()
    End Sub
    Protected Sub panel2Continue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles panel2Continue.Click
        setStep3Live()
    End Sub
    Protected Sub panel3Continue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles panel3Continue.Click
        Dim checkuser As Boolean = False

        checkusername(checkuser)
        If checkuser = False Then
            lblUsernameUsed.ForeColor = Drawing.Color.Red
            lblUsernameUsed.Text = "Sorry this usename is taken please select another"
        Else
            setStep4Live()
            lblMembership.Text = userNumber.ToString
            lblUsername.Text = username.Text.ToString
        End If

    End Sub

    Protected Sub step1bluetab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles step1bluetab.Click
        setStep1Live()
    End Sub

    Protected Sub step2bluetab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles step2bluetab.Click
        setStep2Live()
    End Sub

    Protected Sub step3bluetab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles step3bluetab.Click
        setStep3Live()
    End Sub

    Private Sub setStep1Live()
        step1.Visible = True
        Step2.Visible = False
        Step3.Visible = False
        Step4.Visible = False
        step1bluetab.CssClass = "first_tab_selected"
        step2bluetab.CssClass = "tabs"
        step3bluetab.CssClass = "tabs"
        lblStep1.CssClass = "redtext"
        lblStep2.CssClass = "greytext"
        lblStep3.CssClass = "greytext"
        lblStep4.CssClass = "greytext"
    End Sub
    Private Sub setStep2Live()
        step1.Visible = False
        Step2.Visible = True
        Step3.Visible = False
        Step4.Visible = False
        step2bluetab.CssClass = "first_tab_selected"
        step1bluetab.CssClass = "first_tab"
        step3bluetab.CssClass = "tabs"
        lblStep1.CssClass = "greytext"
        lblStep2.CssClass = "redtext"
        lblStep3.CssClass = "greytext"
        lblStep4.CssClass = "greytext"
    End Sub

    Private Sub setStep3Live()
        If Page.IsValid Then
            step1.Visible = False
            Step2.Visible = False
            Step3.Visible = True
            Step4.Visible = False
            step3bluetab.CssClass = "first_tab_selected"
            step2bluetab.CssClass = "tabs"
            step1bluetab.CssClass = "first_tab"
            lblStep1.CssClass = "greytext"
            lblStep2.CssClass = "greytext"
            lblStep3.CssClass = "redtext"
            lblStep4.CssClass = "greytext"
            If email.Text > "" Then
                username.Text = email.Text
            End If

        End If


    End Sub

    Private Sub setStep4Live()


        newMember()

        step1.Visible = False
        Step2.Visible = False
        Step3.Visible = False
        Step4.Visible = True
        step1bluetab.CssClass = "tabs"
        step2bluetab.CssClass = "tabs"
        step3bluetab.CssClass = "tabs"
        lblStep1.CssClass = "greytext"
        lblStep2.CssClass = "greytext"
        lblStep3.CssClass = "greytext"
        lblStep4.CssClass = "redtext"
    End Sub

    Private Sub checkusername(ByRef checkuser As Boolean)
        oConn = New SqlClient.SqlConnection
        oConn.ConnectionString = strFConnectionString
        oConn.Open()

        Dim returnuser As Integer

        Dim SQLUser As New SqlCommand("owner_login_check", oConn)
        SQLUser.CommandType = CommandType.StoredProcedure
        SQLUser.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = Replace(email.Text.ToString, "--", "", 1, -1, 1)
        SQLUser.Parameters.Add(New SqlParameter("@password", SqlDbType.VarChar, 15, ParameterDirection.Input)).Value = Replace(password.Text.ToString, "--", "", 1, -1, 1)

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

        If returnuser = 1 Then checkuser = True Else checkuser = False

    End Sub

    Private Sub newMember()

        Dim codeLetter As String = ""
        Dim activationCode As Integer = 0
        Dim Success As Boolean = True
        Dim AgentRef As Integer = 0
        Dim AgentCode As String = ""
        Dim AgentLetter As String = ""
        Dim agentName As String = ""
        Dim agentTradingName As String = ""
        Dim agentEmail As String = ""
        Dim failedon As String = ""

        Dim thissite As String = Replace(HttpContext.Current.Request.ServerVariables("SERVER_NAME"), "www.", "")

        SaveMemberDetails(codeLetter, userNumber, activationCode, Success)
       
        If Success Then
            MessageText = "<form action=""http://www." & thissite & "/login.aspx"" method=""post"" name=""login"">" & vbCrLf & _
            "<p class=""verdana10"">Dear " & titles.SelectedValue.ToString & " " & surname.Text.ToString & ",</p>" & vbCrLf & _
            "<p class=""verdana10"">Thank you for joining " & thissite & ". Your account details are :-</p>" & vbCrLf & _
            "<p class=""verdana10""><b>Username = </b>" & email.Text.ToString & "<br>" & vbCrLf & _
            "<b>Password = </b>" & Request.Form("password_1") & "</p>" & vbCrLf & _
            "<p class=""verdana10"">To use your account, simply <input type=""submit"" name=""click here"" value=""click here""> to automatically connect to the web site and view your account.</p>" & vbCrLf & _
            "<p class=""verdana10"">We look forward to seeing you earn money from your holiday bookings or adding your own properties to our list!</p>" & _
            "<p class=""verdana10"">If your computer does not allow you to click the link above please type this address into your browser and log in using your username and password...</p>" & _
            "<p class=""verdana10""></p>" & _
            "http://www." & thissite & "/login.aspx" & _
            "<p>&nbsp;</p>The Grapple (UK) Team" & vbCrLf & _
            "<input name=""username"" type=""hidden"" value=""" & Trim(email.Text.ToString) & """>" & vbCrLf & _
            "<input name=""password"" type=""hidden"" value=""" & password.Text.ToString & """>" & vbCrLf & _
            "</form>"

            Sendemail(email.Text.ToString, "robert@funds4me.co.uk", "", "your account details", MessageText)
        End If


    End Sub


    Private Sub SaveMemberDetails(ByRef codeLetter As String, ByRef userNumber As Integer, ByRef activationCode As String, ByRef Success As Boolean)

        activationCode = CInt(Rnd() * 10000)

        oConn = New SqlClient.SqlConnection
        oConn.ConnectionString = strFConnectionString
        oConn.Open()

        Dim SQLMember As New SqlCommand("add_member_details", oConn)
        SQLMember.CommandType = CommandType.StoredProcedure
        Try
            With SQLMember
                .Parameters.Add(New SqlParameter("@firstname", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(firstname.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@surname", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(surname.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(email.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@password", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(password.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@relation", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(hearaboutother.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@heard_of_via", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(hearabout.SelectedValue.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address1", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(Address1.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address2", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(Address2.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address_town", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(town.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address_county", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(county.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address_country", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(country.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@address_postcode", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(postcode.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@telephone", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(telephonenumber.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@title", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = Replace(titles.SelectedValue.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@trading_name", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Replace(tradingname.Text.ToString, "--", "", 1, -1, 1)
                .Parameters.Add(New SqlParameter("@ipaddress", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Request.ServerVariables("REMOTE_ADDR").ToString

                .Parameters.Add("@owner_ref", SqlDbType.Int, 1)
                .Parameters("@owner_ref").Direction = ParameterDirection.Output

                .ExecuteNonQuery()

                userNumber = .Parameters("@owner_ref").Value

            End With

        Catch ex As Exception
            Success = False
        Finally
            SQLMember.Dispose()
        End Try


    End Sub

   

    Private Sub Sendemail(ByVal toEmail As String, ByVal fromEmail As String, ByVal bccEmail As String, ByVal subject As String, ByVal message As String)
        Dim emailer As New emailer
        emailer.sendmail(fromEmail, "html", "normal", subject, message, toEmail, bccEmail)
    End Sub


End Class

