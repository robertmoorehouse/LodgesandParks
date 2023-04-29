Imports bll
Partial Class _Slideshow
    Inherits System.Web.UI.Page

    Function getImagesForFlash(ByVal propRef As String, ByVal productFilter As String)
        Dim bll As New bll
        getImagesForFlash = bll.GetSlideShow(propRef, productFilter)
        If getImagesForFlash Is Nothing Then
            getImagesForFlash = ""
        End If
    End Function



End Class
