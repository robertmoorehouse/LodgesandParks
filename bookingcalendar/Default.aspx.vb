Imports bll

Partial Class bookingcalendar_Default
    Inherits findavillaparks.ui.basepage.BasePage

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim bbc As New BLLBookingCalendar
        Dim success As Boolean
        success = bbc.Login(txtEmail.ToString, txtPassword.ToString)
        If success Then
            Session("loggedin") = True
            lblError.Text = "combination found"
        Else
            lblError.Text = "Sorry the Email Password combination was not found"
        End If
    End Sub
End Class
