
Partial Class propertyReviews
    Inherits findavillaparks.ui.basepage.BasePage
    Public property_title As String = ""
    Public property_country As String = ""
    Dim ref As String = ""
    Dim productFilter As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            property_title = HttpContext.Current.Cache.Item("property_country" & Request.QueryString("ref"))
            property_country = HttpContext.Current.Cache.Item("property_title" & Request.QueryString("ref"))
        Catch ex As Exception

        End Try
        ref = Replace(Request.QueryString("ref"), "'", "")
        productFilter = Request.QueryString("productFilter")

        If productFilter = "" Then
            If IsNumeric(ref) Then
                productFilter = "VR"
            Else
                productFilter = "HH"
            End If
        End If

        Dim objProp

        objProp = bll.GetPropertyDetails(ref, productFilter)
        If objProp Is Nothing Then
            Response.Redirect("webserviceerror.aspx?page=propertyReviews:" & Request.QueryString("ref") & ":" & Request.QueryString("productFilter") & "&errCode=add&errText==webservice-nothing")
        End If
        Dim metatag As String = ""
        Try
            metatag = Replace(objProp(0).Title, ";", " ") & objProp(0).Seo1
        Catch ex As Exception

        End Try
        loadHeaders(metatag)

        lblownerref.Text = objProp(0).owner_ref
        litTitle.Text = Replace(objProp(0).Title, ";", "<br />")

        Select Case productFilter
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

        Dim thisPropRef As String = ref
        Dim objUse
        Try
            If thisPropRef Is Nothing Or thisPropRef = "" Then
                Response.Redirect("default.aspx")
            End If

            objUse = bll.GetPropertyReviews(thisPropRef, property_country, property_title, productFilter)

            Try
                If objUse.reviews Is Nothing Or objUse.reviews.length = 0 Then
                    pnlReviews.Visible = False
                    pnlReviewAdd.Visible = True
                    pnlReviewFirst.Visible = True
                End If
            Catch ex As Exception
                pnlReviews.Visible = False
                pnlReviewAdd.Visible = True
                pnlReviewFirst.Visible = True
            End Try


            Dim linkCount As Integer = 0
            For linkCount = 0 To objUse.reviews.Length - 1

                If linkCount > 0 Then lblReviews.Text &= "<br /><br />"


                lblReviews.Text &= "<span class=""main_text_bold"">"
                lblReviews.Text &= objUse.reviews(linkCount).by.ToString & " from " & objUse.reviews(linkCount).from.ToString
                lblReviews.Text &= "</strong> (" & FormatDateTime(objUse.reviews(linkCount).ReviewDate.ToString, DateFormat.ShortDate) & ")</span><br />"
                lblReviews.Text &= "<img src=""Images/Stars/" & objUse.reviews(linkCount).StarRating.ToString & "_star.gif"" /><br />"

                lblReviews.Text &= "<i>""" & objUse.reviews(linkCount).Article.ToString & """</i>"
                lblReviews.Text &= "<br /><br />"

            Next
            pnlReviews.Visible = True
        Catch ex As Exception
            lblReviews.Text = "<span class=""main_text""><div align=""center"">No reviews have been submitted for this property.</div></span>"
        End Try

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

    Sub addReview(ByVal sender As Object, ByVal e As System.EventArgs)

        pnlReviews.Visible = False

        pnlReviewAdd.Visible = True

    End Sub

    Sub submitReview(ByVal sender As Object, ByVal e As System.EventArgs)

        pnlReviews.Visible = False
        pnlReviewAdd.Visible = False
        pnlSuccess.Visible = True
        Dim star_rating As Integer
        Dim saveresult As String
        Dim website As String = Request.ServerVariables("SERVER_NAME")

        star_rating = CInt(ddlValForMoney.SelectedValue) + CInt(ddlExpectations.SelectedValue) + CInt(ddlRec.SelectedValue) + CInt(ddlOverall.SelectedValue)

        'Response.Write("<!--:" & ref & "|" & txtFirstName.Text.ToString & "|" & txtLastName.Text.ToString & "|" & txtEmail.Text.ToString & "|" & txtBookingRef.Text.ToString & "|" & ddlValForMoney.SelectedValue & "|" & ddlExpectations.SelectedValue & "|" & _
        '                    ddlRec.SelectedValue & "|" & ddlOverall.SelectedValue & "|" & FormatDateTime(Now(), DateFormat.ShortDate) & "|" & txtReview.Text.ToString & "|" & _
        '                    star_rating & "|" & txtHomeTown.Text.ToString & "|0|" & property_country & "|" & property_title & "|" & website & ":-->")
        'Response.End()
        saveresult = bll.SaveReviews(ref, txtFirstName.Text.ToString, txtLastName.Text.ToString, txtEmail.Text.ToString, txtBookingRef.Text.ToString, ddlValForMoney.SelectedValue, ddlExpectations.SelectedValue, _
                            ddlRec.SelectedValue, ddlOverall.SelectedValue, FormatDateTime(Now(), DateFormat.ShortDate), txtReview.Text.ToString, _
                            star_rating, txtHomeTown.Text.ToString, 0, property_country, property_title, website)
    End Sub

       
End Class
