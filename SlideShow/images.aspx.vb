
Partial Class SlideShow_images
    Inherits findavillaparks.ui.basepage.BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call LoadPhotos()

    End Sub

    Sub LoadPhotos()

        Dim thisPropRef As String = Request.QueryString("propref")
        Dim objUse
        If thisPropRef Is Nothing Or thisPropRef = "" Then
            Response.Redirect("default.aspx")
        End If

        objUse = bll.GetPropertyDetails(thisPropRef)

        Dim picCount As Integer = 0
        Dim propRef As String
        propRef = Request("PropRef")
        If objUse(0).PropImages.Length = 0 Then

        Else
            Response.Write("<?xml version=""1.0"" encoding=""UTF-8"" ?>")
            Response.Write("<gallery>")
            Response.Write("<album id='Property " & propRef & "' description='Property Advert Pictures' lgPath='' startHere='true'>")
            For picCount = 0 To objUse(0).PropImages.Length - 1
                Response.Write("<img src='" & objUse(0).PropImages(picCount).ImageUrl & "'  caption='" & objUse(0).PropImages(picCount).ImageCaption & "'/>")
            Next
            Response.Write("</album>")
            Response.Write("</gallery>")
        End If
    End Sub
End Class
