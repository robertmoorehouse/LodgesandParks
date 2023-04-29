<%@Application Language="VB"%>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.SQLClient" %>
<%@Import Namespace="System.Web" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Dim errID As Long
        Dim objErr As Exception = Server.GetLastError()
        Dim err As String = "SesssionID:" & HttpContext.Current.Session.SessionID & _
                            System.Environment.NewLine & _
                            "App_Error:" & _
                            System.Environment.NewLine & _
                            "URL: " & Request.Url.ToString() & _
                            System.Environment.NewLine & _
                            "Message: " & objErr.Message.ToString() & _
                            System.Environment.NewLine & _
                            "TargetSite: " & objErr.TargetSite.ToString() & _
                            System.Environment.NewLine & _
                            "StackTrace:" & objErr.StackTrace.ToString()

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("BaseConnectionString").ToString)
        Dim cmdObj As New SqlCommand("dev_log_new_error2", conn)
        cmdObj.CommandType = Data.CommandType.StoredProcedure
        cmdObj.Parameters.Add("@ErrLocation", Data.SqlDbType.VarChar, 255)
        cmdObj.Parameters.Add("@ErrNumber", Data.SqlDbType.VarChar, 20)
        cmdObj.Parameters.Add("@ErrDescription", Data.SqlDbType.Text)
        cmdObj.Parameters.Add("@UserIP", Data.SqlDbType.VarChar, 20)
        cmdObj.Parameters.Add("@ReferURL", Data.SqlDbType.VarChar, 255)
        cmdObj.Parameters.Add("@UserBrowser", Data.SqlDbType.VarChar, 255)
        cmdObj.Parameters.Add("@DomainID", Data.SqlDbType.Int)
        cmdObj.Parameters.Add("@ErrID", Data.SqlDbType.Int).Direction = ParameterDirection.Output
        Dim erroloc As String = Replace(Left("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") & HttpContext.Current.Request.ServerVariables("SCRIPT_NAME") & "?" & HttpContext.Current.Request.ServerVariables("QUERY_STRING"), 255), "--", "", 1, -1, 1)
        cmdObj.Parameters("@ErrLocation").Value = erroloc
        cmdObj.Parameters("@ErrNumber").Value = 0
        cmdObj.Parameters("@ErrDescription").Value = Replace(err, "--", "", 1, -1, 1)
        cmdObj.Parameters("@UserIP").Value = Left(HttpContext.Current.Request.ServerVariables("REMOTE_HOST"), 20)
        cmdObj.Parameters("@ReferURL").Value = Left(HttpContext.Current.Request.ServerVariables("HTTP_REFERER"), 255)
        cmdObj.Parameters("@UserBrowser").Value = Left(HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), 255)
        Dim domID
        Select Case LCase(Replace(HttpContext.Current.Request.ServerVariables("SERVER_NAME"), "www.", ""))
            Case "villacompare.com"
                domID = 1
            Case "finda-villa.co.uk"
                domID = 2
            Case "zonchi.com"
                domID = 3
            Case "zonchi.co.uk"
                domID = 4
            Case "lodgesandparks.co.uk"
                domID = 5
            Case "boatingoffers.co.uk"
                domID = 6
            Case "cottageoffers.com"
                domID = 7
            Case "lodgesandparks.com"
                domID = 8
            Case Else
                domID = 99
        End Select
        
        cmdObj.Parameters("@DomainID").Value = domID
        conn.Open()
        cmdObj.ExecuteNonQuery()
        errID = cmdObj.Parameters("@ErrID").Value
        'errID = 0
        conn.Close()
        conn.Dispose()
        
        Server.ClearError()
        Session("errortext") = objErr.Message.ToString()
        Response.Redirect("/webserviceerror.aspx?errCode=" & CStr(errID) & "&errText=session")
        'Response.Write("We are Sorry but an error has occured and the process cannot continue.<br /><br />Our engineers have been informed and the issue will be examined shortly.")
        'Response.Write("<br /><br />" & "If you wish to report this error, please quote the error identification code shown below.<br /><br />")
        'Response.Write("ERROR ID: " & CStr(errID))
        'Response.Write("<br /><br />" & "ERROR MESSAGE: " & objErr.Message.ToString())
        'Response.Write("<br /><br />" & "The Grapple (UK) Development Team")
        'Response.Write("<br />" & "errors@grappleuk.com")
        

        'Response.End()
                
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Session("iframecount") = 1
        Session("1stppc") = "yes"
        Session("keyword") = ""
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>