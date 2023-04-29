Imports bll

Partial Class _Default
    Inherits findavillaparks.ui.basepage.BasePage

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Dim Header As HtmlHead = CType(Page.Master.FindControl("Head1"), HtmlHead)
        Select Case bll.productfilter
            Case "villa"
                villatext.Visible = True
                Header.Title = "Private villas, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/villa.htm")
            Case "cottage"
                cottagetext.Visible = True
                Header.Title = "holiday Cottages rental in England, Scotland, Wales, Ireland, Europe and the world."
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/cottage.htm")
            Case "boat"
                boattext.Visible = True
                Header.Title = "boating holidays in England, Scotland, wales and Europe, Boat rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/boat.htm")
            Case "lodge"
                lodgetext.Visible = True
                Header.Title = "Lodge and park holidays, Caravan park holidays, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/lodge.htm")
            Case Else
                villatext.Visible = True
                Header.Title = "Private villas, holiday homes, holiday rentals - online booking made easy"
                'sitemaps.Text = GetHtmlPageSource("http://www.lodgesandparks.co.uk/holiday-rentals/villa.htm")
        End Select

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
