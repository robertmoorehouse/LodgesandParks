Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.HttpContext

Public Class DALBookingCalendar

    Private Function ConnectionString() As String
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("freebookingcalendarConnectionString").ConnectionString.ToString
        Return ConnectionString
    End Function

    Public Function DALLogin(ByVal email As String, ByVal password As String) As Boolean

        Dim objRow As Data.DataRowView
        Dim BookingCalendarConnectionString As String = ConnectionString()
        Try
            DALLogin = False
            Dim oConn As Data.SqlClient.SqlConnection
            oConn = New SqlClient.SqlConnection
            oConn.ConnectionString = BookingCalendarConnectionString
            oConn.Open()
            Dim SQLTerms As New SqlCommand("loginUser", oConn)
            SQLTerms.CommandType = CommandType.StoredProcedure
            SQLTerms.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = email
            SQLTerms.Parameters.Add(New SqlParameter("@password", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = password
            SQLTerms.ExecuteNonQuery()
            Dim dsReviews As New DataSet("dsloginUser")
            Dim daReviews As New SqlDataAdapter()
            Dim dvReviews As New DataView
            daReviews.SelectCommand = SQLTerms
            daReviews.Fill(dsReviews)
            dvReviews = New DataView(dsReviews.Tables(0))
            HttpContext.Current.Session("userID") = ""
            HttpContext.Current.Session("userGUID") = ""

            Try
                '*Add the values
                HttpContext.Current.Session("userID") = objRow(0)("userID")
                HttpContext.Current.Session("userGUID") = objRow(0)("guid")
                DALLogin = True
            Catch ex As Exception

            End Try

        Catch
            DALLogin = False
        End Try
    End Function
End Class
