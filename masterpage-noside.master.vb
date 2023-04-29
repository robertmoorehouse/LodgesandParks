Imports bll
Partial Class masterpage_noside
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim controlID As Integer = 0
        Dim locationText As String = ""
        
        Dim Header As HtmlHead = CType(Page.Master.FindControl("Head1"), HtmlHead)
        SetP3Pheaders(Header)
        Dim bll As New bll
        Select Case bll.productfilter
            Case "lodge"
                sitemap.NavigateUrl = "holiday-rentals/lodges-parks-caravans.htm"
            Case "villa"
                sitemap.NavigateUrl = "holiday-rentals/holiday-villas.htm"
            Case "boat"
                sitemap.NavigateUrl = "holiday-rentals/holiday-boats.htm"
            Case "cottage"
                sitemap.NavigateUrl = "holiday-rentals/holiday-cottages.htm"
        End Select
    End Sub

    Public Sub SetP3Pheaders(ByRef Header)

        Dim metaValue As New HtmlMeta
        metaValue.Name = "policyref"
        metaValue.Content = "http://www.grappleuk.com/w3c/p3p.xml"" , CP=""CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"""
        Header.Controls.AddAt(1, metaValue)
        metaValue.Name = "CP"
        metaValue.Content = "CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"
        Header.Controls.AddAt(2, metaValue)

    End Sub
End Class

