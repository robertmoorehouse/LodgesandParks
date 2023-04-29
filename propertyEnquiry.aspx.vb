
Partial Class propertyEnquiry
    Inherits findavillaparks.ui.basepage.BasePage

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If RadioButtonList1.SelectedValue = "optNew" Then
            Response.Redirect("http://www.rentalsystems.com/NewOwner/join_member.asp?rag=35465G&rcam=fvlogin")
        Else
            Dim usernumber As String
            usernumber = txtUserID.Text
            If IsNumeric(usernumber) Then
                Response.Redirect("http://www.rentalsystems.com/NewOwner/logon_memberEnterPassword.asp?rag=35465G&rcam=fvlogin&owner_ref=" & usernumber.ToString)
            Else
                lblWarning.Visible = True
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim property_title, property_country
            property_title = HttpContext.Current.Cache.Item("property_country" & Request.QueryString("ref"))
            property_country = HttpContext.Current.Cache.Item("property_title" & Request.QueryString("ref"))
        Catch ex As Exception

        End Try

        Select Case Request.QueryString("productFilter")
            Case "HH"
                HHEnquire.Visible = True
                Enquire.Visible = False
                HyperLink1.NavigateUrl = "http://www.hoseasons.co.uk/productSite.aspx?ClassCode=" & Request.QueryString("ref") & "&bid=97&aid=CD48&opt=lodgedisplayfull-details"
            Case "VR"
                HHEnquire.Visible = False
                Enquire.Visible = True


                Dim objProp

                objProp = bll.GetPropertyDetails(Request.QueryString("ref"), Request.QueryString("productFilter"))
                If objProp Is Nothing Then
                    Response.Redirect("webserviceerror.aspx?page=propertyEnquiry:" & Request.QueryString("ref") & ":" & Request.QueryString("productFilter") & "&errCode=add&errText==webservice-nothing")
                End If
                Dim metatag As String = ""
                Try
                    metatag = Replace(objProp(0).Title, ";", " ") & objProp(0).Seo1

                Catch ex As Exception

                End Try
                loadHeaders(metatag)

                lblownerref.Text = objProp(0).owner_ref
                litTitle.Text = Replace(objProp(0).Title, ";", "<br />")
        End Select

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
