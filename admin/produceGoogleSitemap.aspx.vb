Imports DALProductBrowser
Imports System.Xml
Imports System.IO


Partial Class Admin_produceGoogleSitemap
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lodgesandparks()
        villa()
        cottage()
        boat()

    End Sub

    Private Sub lodgesandparks()
      
        Dim PB = New DALProductBrowser("lp")
        Dim flatXML As XmlDocument = PB.GetFlatXML()
        Dim rawresults As String = ""
        Dim partpath As String = ""
        Try
            partpath = Server.MapPath("/")
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        Catch ex As Exception
            partpath = "d:/TiFWWW/finda-villa"
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        End Try

        Dim XMLstring As String = Regex.Replace(rawresults, "><", ">" & Environment.NewLine & "<")

        XMLstring = Regex.Replace(XMLstring, "\$\$dateplaceholder\$\$", Format(Today, "yyyy-MM-dd"))

        Try
            Dim oWrite As System.IO.StreamWriter
            oWrite = IO.File.CreateText(partpath & "sitemaps\GoogleSitemap-lodgesandparks.xml")
            oWrite.WriteLine(XMLstring)
            oWrite.Close()
            Response.Write("<h3>Google Sitemap deployed to<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-lodgesandparks.xml" & "</font></h3>")
            Response.Write("<h4>Click <a href=""..\sitemaps\GoogleSitemap-lodgesandparks.xml"">here</a> to see the generated XML sitemap.</h4>")
            Response.Write("<h4>Click <a href=""default.aspx"">here</a> to return to admin.</h4>")

        Catch ex As Exception
            Response.Write("<h2>Error Writing<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-lodgesandparks.xml" & ex.ToString & "</font></h2>")
        End Try



    End Sub

    Private Sub villa()
        Dim PB = New DALProductBrowser("villa")
        Dim flatXML As XmlDocument = PB.GetFlatXML()
        Dim rawresults As String = ""
        Dim partpath As String = ""
        Try
            partpath = Server.MapPath("/")
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        Catch ex As Exception
            partpath = "d:/TiFWWW/finda-villa"
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        End Try

        Dim XMLstring As String = Regex.Replace(rawresults, "><", ">" & Environment.NewLine & "<")

        XMLstring = Regex.Replace(XMLstring, "\$\$dateplaceholder\$\$", Format(Today, "yyyy-MM-dd"))

        Try
            Dim oWrite As System.IO.StreamWriter
            oWrite = IO.File.CreateText(partpath & "sitemaps\GoogleSitemap-villas.xml")
            oWrite.WriteLine(XMLstring)
            oWrite.Close()
            Response.Write("<h3>Google Sitemap deployed to<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-villas.xml" & "</font></h3>")
            Response.Write("<h4>Click <a href=""..\sitemaps\GoogleSitemap-villas.xml"">here</a> to see the generated XML sitemap.</h4>")
            Response.Write("<h4>Click <a href=""default.aspx"">here</a> to return to admin.</h4>")

        Catch ex As Exception
            Response.Write("<h2>Error Writing<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-villas.xml" & ex.ToString & "</font></h2>")
        End Try

    End Sub

    Private Sub cottage()
        Dim PB = New DALProductBrowser("cottage")
        Dim flatXML As XmlDocument = PB.GetFlatXML()
        Dim rawresults As String = ""
        Dim partpath As String = ""
        Try
            partpath = Server.MapPath("/")
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        Catch ex As Exception
            partpath = "d:/TiFWWW/finda-villa"
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        End Try

        Dim XMLstring As String = Regex.Replace(rawresults, "><", ">" & Environment.NewLine & "<")

        XMLstring = Regex.Replace(XMLstring, "\$\$dateplaceholder\$\$", Format(Today, "yyyy-MM-dd"))

        Try
            Dim oWrite As System.IO.StreamWriter
            oWrite = IO.File.CreateText(partpath & "sitemaps\GoogleSitemap-cottage.xml")
            oWrite.WriteLine(XMLstring)
            oWrite.Close()
            Response.Write("<h3>Google Sitemap deployed to<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-cottage.xml" & "</font></h3>")
            Response.Write("<h4>Click <a href=""..\sitemaps\GoogleSitemap-cottage.xml"">here</a> to see the generated XML sitemap.</h4>")
            Response.Write("<h4>Click <a href=""default.aspx"">here</a> to return to admin.</h4>")

        Catch ex As Exception
            Response.Write("<h2>Error Writing<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-cottage.xml" & ex.ToString & "</font></h2>")
        End Try

        
    End Sub

    Private Sub boat()
        Dim PB = New DALProductBrowser("boat")
        Dim flatXML As XmlDocument = PB.GetFlatXML()
        Dim rawresults As String = ""
        Dim partpath As String = ""
        Try
            partpath = Server.MapPath("/")
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        Catch ex As Exception
            partpath = "d:/TiFWWW/finda-villa"
            rawresults = PB.XSLtransform(flatXML, partpath & "/App_Code/XSLT/GoogleSitemap.xslt")
        End Try

        Dim XMLstring As String = Regex.Replace(rawresults, "><", ">" & Environment.NewLine & "<")

        XMLstring = Regex.Replace(XMLstring, "\$\$dateplaceholder\$\$", Format(Today, "yyyy-MM-dd"))

        Try
            Dim oWrite As System.IO.StreamWriter
            oWrite = IO.File.CreateText(partpath & "sitemaps\GoogleSitemap-boat.xml")
            oWrite.WriteLine(XMLstring)
            oWrite.Close()
            Response.Write("<h3>Google Sitemap deployed to<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-boat.xml" & "</font></h3>")
            Response.Write("<h4>Click <a href=""..\sitemaps\GoogleSitemap-boat.xml"">here</a> to see the generated XML sitemap.</h4>")
            Response.Write("<h4>Click <a href=""default.aspx"">here</a> to return to admin.</h4>")

        Catch ex As Exception
            Response.Write("<h2>Error Writing<BR><font color=blue>" & partpath & "sitemaps\GoogleSitemap-boat.xml" & ex.ToString & "</font></h2>")
        End Try

    End Sub

End Class
