Imports bll

Partial Class PopularLocations
    Inherits System.Web.UI.UserControl
    Public bll As New bll


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case bll.productfilter
            Case "villa"
                villatext.Visible = True
            Case "cottage"
                cottagetext.Visible = True
            Case "boat"
                boattext.Visible = True
            Case "lodge"
                lodgetext.Visible = True
            Case Else
                villatext.Visible = True
        End Select
    End Sub
End Class
