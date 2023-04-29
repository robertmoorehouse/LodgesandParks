
Partial Class propertyMap
    Inherits findavillaparks.ui.basepage.BasePage
    Public intZoomLevel As Integer
    Public Lon As Decimal
    Public Lat As Decimal
    Public map_text As String
    Public thisPropRef As String

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        intZoomLevel = 15
        If Request("ZoomLevel") <> "" And IsNumeric(Request("ZoomLevel")) = True Then
            intZoomLevel = Request("ZoomLevel")
        End If

        thisPropRef = Request.QueryString("ref")
       
        If thisPropRef Is Nothing Or thisPropRef = "" Then
            Response.Redirect("default.aspx")
        End If

        Dim objUse = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))
        If objUse Is Nothing Then
            Response.Redirect("webserviceerror.aspx?page=propertyMap:" & Request.QueryString("ref") & ":" & Request.QueryString("productFilter") & "&errCode=add&errText==webservice-nothing")
        End If
        Dim metatag As String = ""
        Try
            metatag = Replace(objUse(0).Title, ";", " ") & objUse(0).Seo1
        Catch ex As Exception

        End Try

        loadHeaders(metatag)

        Lon = objUse(0).Lon
        Lat = objUse(0).Lat
        map_text = objUse(0).title
        lblownerref.Text = objUse(0).owner_ref
        litTitle.Text = Replace(objUse(0).Title, ";", "<br />")
        Dim prodFilter As String = ""
        prodFilter = Request.QueryString("productFilter")
        If prodFilter = "" Then
            If IsNumeric(Request.QueryString("ref")) Then
                prodFilter = "VR"
            Else
                prodFilter = "HH"
            End If
        End If
        Select Case prodFilter
            Case "HH"
                lnkPrice.NavigateUrl = "~/propertyPrice.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkSummary.NavigateUrl = "~/propertyDetails.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkEnquiry.NavigateUrl = "~/propertyEnquiry.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkReviews.NavigateUrl = "~/propertyReviews.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                'lnkMaps.NavigateUrl = "http://www.hoseasons.co.uk/ProductLocation.aspx?sitecode=" & lblownerref.Text & "&classcode=" & Request.QueryString("ref") & "&bid=97&aid=CD48&opt=lodgedisplaydetails-location"
                lnkMaps.NavigateUrl = "/takemethere.aspx?ref=" & Request.QueryString("ref") & "&sitecode=" & lblownerref.Text & "&productFilter=HH&land=location"
                lnkMaps.Target = "_blank"
                'lnkPhotos.NavigateUrl = "http://www.hoseasons.co.uk/ProductSite.aspx?sitecode=" & lblownerref.Text & "&classcode=" & Request.QueryString("ref") & "&bid=97&aid=CD48&opt=lodgedisplaydetails-photos"
                lnkPhotos.NavigateUrl = "/takemethere.aspx?ref=" & Request.QueryString("ref") & "&sitecode=" & lblownerref.Text & "&productFilter=HH&land=photos"
                lnkPhotos.Target = "_blank"
                'lnkFullDetails.NavigateUrl = "http://www.hoseasons.co.uk/productSite.aspx?sitecode=" & lblownerref.Text & "&ClassCode=" & Request.QueryString("ref") & "&bid=97&aid=CD48&opt=lodgedisplayfull-details"
                lnkFullDetails.NavigateUrl = "/takemethere.aspx?ref=" & Request.QueryString("ref") & "&sitecode=" & lblownerref.Text & "&productFilter=HH&land=advert"
                lnkFullDetails.Visible = True
                lnkFullDetails.Target = "_blank"
            Case "VR"
                lnkSummary.NavigateUrl = "~/propertyDetails.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkPrice.NavigateUrl = "~/propertyPrice.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkEnquiry.NavigateUrl = "~/propertyEnquiry.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkReviews.NavigateUrl = "~/propertyReviews.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkMaps.NavigateUrl = "~/propertyMap.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkPhotos.NavigateUrl = "~/propertyPhotos.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                'lnkFullDetails.NavigateUrl = "http://www.rentalsystems.com/advert_summary.asp?ref=" & Request.QueryString("ref") & "&rag=35465G&rcam=finda-villa&sag=&sc="
                lnkFullDetails.NavigateUrl = "/takemethere.aspx?ref=" & Request.QueryString("ref") & "&productFilter=VR&land=advert"
                lnkFullDetails.Visible = True
                lnkFullDetails.Target = "_blank"
            Case Else
                lnkSummary.NavigateUrl = "~/propertyDetails.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkPrice.NavigateUrl = "~/propertyPrice.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkEnquiry.NavigateUrl = "~/propertyEnquiry.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkReviews.NavigateUrl = "~/propertyReviews.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkMaps.NavigateUrl = "~/propertyMap.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
                lnkPhotos.NavigateUrl = "~/propertyPhotos.aspx?ref=" & Request.QueryString("ref") & "&productFilter=" & Request.QueryString("productFilter")
        End Select
    End Sub
    Sub loadHeaders(ByVal SEO As String)
        Dim Header As HtmlHead = CType(Page.Master.FindControl("Head1"), HtmlHead)
        Dim pageheadertext As Literal
        pageheadertext = Page.Master.FindControl("pageheadertext")
        Dim a As HtmlMeta = Header.FindControl("metaDesc")
        a.Content = SEO

        Select Case bll.productfilter
            Case "villa"
                Header.Title = SEO
                pageheadertext.Text = SEO & ", all our Villas are easy to book and pay by credit card."
            Case "cottage"
                Header.Title = SEO
                pageheadertext.Text = SEO & ", all our Cottages are easy to book and pay by credit card."
            Case "boat"
                Header.Title = SEO
                pageheadertext.Text = SEO & ", all our Boats are easy to book and pay by credit card."
            Case "lodge"
                Header.Title = SEO
                pageheadertext.Text = SEO & ", all our Lodges and Parks are easy to book and pay by credit card."
            Case Else
                Header.Title = SEO
                pageheadertext.Text = SEO & ", all our properties are easy to book and pay by credit card."
        End Select
    End Sub
End Class
