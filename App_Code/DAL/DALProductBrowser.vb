Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Imports System.Xml.Xsl


Public Class DALProductBrowser

    Private ConnString As String
    Public ResultsTable As DataTable
    Public RowsReturned As Int32 = -1

    Public Sub New(ByVal website As String)

        Try

            ' get the connection string from web.config, or default if not found
            ConnString = ConfigurationManager.ConnectionStrings("BaseConnectionString").ToString()

            Dim SQLconn As New SqlConnection(ConnString)
            SQLconn.Open()
            Dim DS As New DataSet()
            Dim DSloc As New Dataset()
            Dim SQL As String
            Dim SQLlocs As String
            Dim SQLA As SqlDataAdapter

            ' Download All Content
            Select Case website
                Case "villa"
                    SQL = "SELECT 'http://www.villacompare.com/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'villa') UNION SELECT 'http://www.villacompare.com/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'villa') UNION SELECT 'http://www.villacompare.com/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(villa_prop_count AS varchar(75)) AS Expr3, CAST(villa_prop_count AS varchar(50)) AS Expr4 FROM locations WHERE (villa_prop_count > 0)"
                Case "lp"
                    SQL = "SELECT 'http://www.lodgesandparks.com/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'lodge') OR (prop_contents.prop_type = 'park') UNION SELECT 'http://www.lodgesandparks.com/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'lodge') OR (prop_contents.prop_type = 'park') UNION SELECT 'http://www.lodgesandparks.com/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(lp_prop_count AS varchar(75)) AS Expr3, CAST(lp_prop_count AS varchar(50)) AS Expr4 FROM         locations WHERE     (lp_prop_count > 0)"
                Case "boat"
                    SQL = "SELECT 'http://www.boatingoffers.co.uk/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'boat') UNION SELECT 'http://www.boatingoffers.co.uk/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'boat') UNION SELECT 'http://www.boatingoffers.co.uk/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(boat_prop_count AS varchar(75)) AS Expr3, CAST(boat_prop_count AS varchar(50)) AS Expr4 FROM locations WHERE (boat_prop_count > 0)"
                Case "cottage"
                    SQL = "SELECT 'http://www.cottageoffers.com/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'cottage') UNION SELECT 'http://www.cottageoffers.com/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'cottage') UNION SELECT 'http://www.cottageoffers.com/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(cottage_prop_count AS varchar(75)) AS Expr3, CAST(cottage_prop_count AS varchar(50)) AS Expr4 FROM locations WHERE (cottage_prop_count > 0)"
                Case "hotel"
                    SQL = "SELECT 'http://www.villacompare.com/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'hotel') UNION SELECT 'http://www.villacompare.com/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'hotel') UNION SELECT 'http://www.lodgesandparks.com/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(villa_prop_count AS varchar(75)) AS Expr3, CAST(villa_prop_count AS varchar(50)) AS Expr4 FROM locations WHERE (villa_prop_count > 0)"
                Case "bb"
                    SQL = "SELECT 'http://www.villacompare.com/propertyReviews.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'bb') UNION SELECT 'http://www.villacompare.com/propertyDetails.aspx?ref=' + prop_contents.prop_ref + '&productFilter=' + prop_contents.website + '&title=' + prop_details.title AS Expr1, prop_contents.prop_type AS Expr2, prop_details.title AS Expr4, prop_contents.website AS Expr3 FROM prop_contents INNER JOIN prop_details ON prop_contents.prop_ref = prop_details.prop_ref WHERE (prop_contents.prop_type = 'bb') UNION SELECT 'http://www.lodgesandparks.com/results.aspx?useit=' + CAST(cat_ref AS varchar(50)) + '&location=' + cat_description AS Expr1, cat_description AS Expr2, CAST(villa_prop_count AS varchar(75)) AS Expr3, CAST(villa_prop_count AS varchar(50)) AS Expr4 FROM locations WHERE (villa_prop_count > 0)"
            End Select
            SQLA = New SqlDataAdapter(SQL, SQLconn)
            SQLA.Fill(DS, "TheContent")

            SQLconn.Close()







            ResultsTable = DS.Tables("TheContent")
            RowsReturned = DS.Tables("TheContent").Rows.Count

        Catch ex2 As Exception
        End Try

    End Sub

    Public Function GetFlatXML() As XmlDocument
        Dim retXML As New XmlDocument()
        Try
            Dim XMLstringBuilder As New StringBuilder()
            XMLstringBuilder.Append("<Products>" & Environment.NewLine)
            For i As Int16 = 0 To ResultsTable.Rows.Count - 1
                Dim tempRow As DataRow = ResultsTable.Rows(i)
                XMLstringBuilder.Append("  <Product>" & Environment.NewLine)
                XMLstringBuilder.Append("     <ref>" & escape(tempRow(0).ToString) & "</ref>" & Environment.NewLine)
                XMLstringBuilder.Append("     <HolidayType>" & escape(tempRow(1).ToString) & "</HolidayType>" & Environment.NewLine)
                XMLstringBuilder.Append("     <Name>" & escape(tempRow(2).ToString) & "</Name>" & Environment.NewLine)
                XMLstringBuilder.Append("     <productFilter>" & escape(tempRow(3).ToString) & "</productFilter>" & Environment.NewLine)
                XMLstringBuilder.Append("  </Product>" & Environment.NewLine)
            Next
            XMLstringBuilder.Append("</Products>" & Environment.NewLine)
            Dim XML As String = XMLstringBuilder.ToString()
            retXML.LoadXml(XML)
            Return retXML
        Catch ex As Exception
            retXML = New XmlDocument()
            Return retXML
        End Try
    End Function

    Public Function escape(ByVal instr As String) As String
        instr = Regex.Replace(instr, "\&", "&amp;")
        instr = Regex.Replace(instr, "\'", "&apos;")
        instr = Regex.Replace(instr, "\""", "&quot;")
        instr = Regex.Replace(instr, "\>", "&gt;")
        instr = Regex.Replace(instr, "\<", "&lt;")
        Return instr
    End Function

    Public Function XSLtransform(ByVal inXML As XmlDocument, ByVal inXSLT As String) As String
        Dim outString As String = ""
        Try
            Dim xsltProcessor = New XslCompiledTransform()
            xsltProcessor.Load(inXSLT)
            Dim stream As New System.IO.MemoryStream
            xsltProcessor.Transform(inXML, Nothing, stream)
            stream.Flush()
            stream.Position = 0
            Dim SR As New System.IO.StreamReader(stream)
            outString = SR.ReadToEnd
        Catch ex As Exception
            'outString = "                                        " & ex.Message
        End Try
        Try
            outString = outString.Substring(38)
        Catch ex As Exception
        End Try
        Return outString
    End Function

End Class


