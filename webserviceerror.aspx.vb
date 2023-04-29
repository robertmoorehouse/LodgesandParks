Imports bll
Imports System.Data
Imports System.Data.SqlClient


Partial Class _webserviceerror
    Inherits findavillaparks.ui.basepage.BasePage

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Dim Header As HtmlHead = CType(Page.Master.FindControl("Head1"), HtmlHead)
        Select Case bll.productfilter
            Case "villa"
                Header.Title = "Private villas, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/villa.htm")
            Case "cottage"
                Header.Title = "holiday Cottages rental in England, Scotland, Wales, Ireland, Europe and the world."
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/cottage.htm")
            Case "boat"
                Header.Title = "boating holidays in England, Scotland, wales and Europe, Boat rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/boat.htm")
            Case "lodge"
                Header.Title = "Lodge and park holidays, Caravan park holidays, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/lodge.htm")
            Case Else
                Header.Title = "Private villas, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/villa.htm")
        End Select

        Dim serrorcode As String = ""
        Dim slblBrowser As String = ""
        Dim slblPage As String = ""
        Dim slblTime As String = ""
        Dim serrormessage As String = ""
        Dim referpage As String = Left(HttpContext.Current.Request.ServerVariables("HTTP_REFERER"), 255)
        slblBrowser = Left(HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), 255)
        slblTime = Now()
        slblPage = Request.QueryString("page")
        serrormessage = Request.QueryString("errText")
        If serrormessage = "session" Then
            serrormessage = Session("errortext")
        End If
        serrorcode = Request.QueryString("errCode")
        If serrorcode = "" Then
            serrorcode = "add"
            Dim url As String
            url = Request.ServerVariables("QUERY_STRING")
            If InStr(url, "404;") Then
                serrormessage = "Page not found"
                referpage = Replace(url, "404;", "", 1, -1, 1)
                referpage = Replace(referpage, ":80", "", 1, -1, 1)
                slblPage = Right(Replace(referpage, "http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") & "/", "", 1, -1, 1), 255)
            Else
                If serrormessage = "" Then
                    serrormessage = "Unknown Error"
                End If
                slblPage = Left(HttpContext.Current.Request.ServerVariables("HTTP_REFERER"), 255)
            End If

        End If

        If serrorcode = "add" Then

            Dim errID As Long

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

            cmdObj.Parameters("@ErrLocation").Value = Replace(slblPage, "--", "", 1, -1, 1)
            cmdObj.Parameters("@ErrNumber").Value = 0
            cmdObj.Parameters("@ErrDescription").Value = Replace(serrormessage, "--", "", 1, -1, 1)
            cmdObj.Parameters("@UserIP").Value = Left(HttpContext.Current.Request.ServerVariables("REMOTE_HOST"), 20)
            cmdObj.Parameters("@ReferURL").Value = Replace(referpage, "--", "", 1, -1, 1)
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
                Case "lodgesandparks.com"
                    domID = 5
                Case "boatingoffers.co.uk"
                    domID = 6
                Case "cottageoffers.com"
                    domID = 7
                Case "lodgesandparks.co.uk"
                    domID = 8
                Case Else
                    domID = 99
            End Select
            cmdObj.Parameters("@DomainID").Value = domID
            conn.Open()
            If Left(HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), 255) = "Mediapartners-Google" Then
            Else
                cmdObj.ExecuteNonQuery()
                errID = cmdObj.Parameters("@ErrID").Value
            End If
            conn.Close()
            conn.Dispose()
            serrorcode = CStr(errID)
        End If

        errMessge.Text = serrormessage
        lblBrowser.Text = slblBrowser
        lblPage.Text = slblPage
        lblTime.Text = slblTime
        errCode.Text = serrorcode

    End Sub
    Function GetHtmlPageSource(ByVal url As String) As String
        Dim st As System.IO.Stream
        Dim sr As System.IO.StreamReader
        Try
            '// make a Web request
            Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(url)
            '// get the response and read from the result stream
            Dim resp As System.Net.WebResponse = req.GetResponse
            st = resp.GetResponseStream
            sr = New System.IO.StreamReader(st)
            '// read all the text in it
            Return sr.ReadToEnd
        Catch ex As Exception
            Return ""
        Finally
            '// always close readers and streams
            Try
                sr.Close()
                st.Close()
            Catch ex As Exception

            End Try

        End Try
    End Function
End Class
