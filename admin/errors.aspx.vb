Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Xml
Imports System.Xml.Xsl
Partial Class admin_errors
    Inherits System.Web.UI.Page
    Private ConnString As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' get the connection string from web.config, or default if not found
        ConnString = ConfigurationManager.ConnectionStrings("BaseConnectionString").ToString()

        Dim SQLconn As New SqlConnection(ConnString)
        SQLconn.Open()
        Dim DS As New DataSet()
        Dim DSloc As New DataSet()
        Dim SQL As String
        Dim SQLA As SqlDataAdapter

        ' Download All Content

        SQL = "SELECT top 100 * from dev_error_log order by errID desc;"

        SQLA = New SqlDataAdapter(SQL, SQLconn)
        SQLA.Fill(DS, "TheContent")
        GridView1.DataSource = DS
        GridView1.DataBind()
        SQLconn.Close()


    End Sub
End Class
