Imports Microsoft.VisualBasic
'Imports DALBookingCalendar

Public Class BLLBookingCalendar
    Public Function Login(ByVal email As String, ByVal password As String) As Boolean
        Dim dbc As New DALBookingCalendar
        Login = dbc.DALLogin(email, password)

    End Function
End Class
