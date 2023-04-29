Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports bll
Namespace findavillaparks.ui.basepage
    Public Class BasePage
        Inherits System.Web.UI.Page

        Public cph1 As ContentPlaceHolder
        Public cph2 As ContentPlaceHolder
        Public useLocation As String = ""
        Public bll As New bll

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Try
                cph1 = DirectCast(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                cph2 = DirectCast(Master.FindControl("ContentPlaceHolder2"), ContentPlaceHolder)
            Catch ex As Exception

            End Try

        End Sub

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            Select Case Replace(HttpContext.Current.Request.ServerVariables("SERVER_NAME"), "www.", "")
                Case "villacompare.com", "finda-villa.co.uk"
                    Page.Theme = "finda-villa"
                Case "zonchi.com", "zonchi.co.uk"
                    Page.Theme = "zonchi"
                Case "lodgesandparks.com", "lodgesandparks.co.uk"
                    Page.Theme = "lodgesandparks"
                Case "cottageoffers.com"
                    Page.Theme = "cottages"
                Case "boatingoffers.co.uk"
                    Page.Theme = "boats"
                Case "holidayrentalsystems.com", "freebookingcalendar.com"
                    Page.Theme = "calendar"
                Case Else
                    Page.Theme = "finda-villa"
                    Page.Theme = "lodgesandparks"
            End Select
        End Sub
    End Class


End Namespace

