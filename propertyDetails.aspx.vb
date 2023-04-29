Imports system.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.IO

Partial Class propertyDetails
    Inherits findavillaparks.ui.basepage.BasePage
    Public SlideshowPath As String
    Public thisPropRef As String
    Public sCurrency As String
    Public reviewCount As Integer
    Dim facCount As Integer = 0
    Dim currency As String = ""
    Dim prop_summary As New DataSet
    Dim bandb_summary As New DataSet
    Public propertyinfo
    Public property_title As String = ""
    Public property_country As String = ""
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        thisPropRef = Replace(Request.QueryString("ref"), "'", "") '& "22107"
        Dim SiteCode As String = ""
        SiteCode = Request.QueryString("sitecode")
        If SiteCode > "" Then
            Response.Redirect("results.aspx?sitecode=" & Request.QueryString("sitecode") & "&productFilter=" & Request.QueryString("productFilter"))
        End If
        If thisPropRef Is Nothing Or thisPropRef = "" Then
            Response.Redirect("default.aspx")
        End If

        If Not Page.IsPostBack Then

            lblPropRef.Text = thisPropRef

            Call LoadPropertyData()
            Call LoadFacilities()
            LoadReviews()
            LoadPageSummary()

            SlideshowPath = "Slideshow.aspx?ref=" & lblPropRef.Text & "&productFilter=" & Request.QueryString("productFilter")

            lnkPhotos.NavigateUrl = "/propertyPhotos.aspx?ref=" & lblPropRef.Text & "&productFilter=" & Request.QueryString("productFilter")
            imgPhotos.ImageUrl = "http://www.rentalsystems.com/data/images/" & lblPropRef.Text & "/" & lblPropRef.Text & "_1.jpg"
            imgFlash.ImageUrl = "images/flashLogo.gif"

        End If


        If Page.IsPostBack Then
            SlideshowPath = "Slideshow.aspx?ref=" & lblPropRef.Text & "&productFilter=" & Request.QueryString("productFilter")
        End If

        Session("redo") = "no"
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
    Sub LoadPropertyData()
        
        Dim objUse = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))
        If objUse Is Nothing Then
            Response.Redirect("webserviceerror.aspx?page=propertyDetails:" & Request.QueryString("ref") & ":" & Request.QueryString("productFilter") & "&errCode=add&errText==webservice-nothing")
        End If
        Dim metatag As String = ""
        Try
            metatag = Replace(objUse(0).Title, ";", " ") & objUse(0).Seo1
        Catch ex As Exception

        End Try
        loadHeaders(metatag)

        lblownerref.Text = objUse(0).owner_ref
        litTitle.Text = Replace(objUse(0).Title, ";", "<br />")
        lblDescriptionTitle.Text = objUse(0).PropType & " details"
        'lblRoomsTitle.Text = "Rooms at this " & objUse(0).PropType
        lblFacilitiesTitle.Text = "Facilities near this " & objUse(0).PropType

        Dim desc As Integer
        'If objUse(0).summary > "" Then
        'lblDescription.Text &= "<strong>About this property</strong><br />"
        'lblDescription.Text &= objUse(0).summary & "<br />"
        'End If
        For desc = 0 To objUse(0).Descriptions.length - 1
            If objUse(0).Descriptions(desc).Title <> "" Then lblDescription.Text &= "<strong>" & objUse(0).Descriptions(desc).Title & "</strong><br />"
            If objUse(0).Descriptions(desc).Paragraph <> "" Then lblDescription.Text &= objUse(0).Descriptions(desc).Paragraph & "<br /><br />"
        Next
        Dim locations As String = ""
        Dim country As String = ""
        For Each item As Object In objUse(0).Locations
            If item.parentID.ToString <> "0" Then
                country = item.LocationDescription.ToString
                locations += item.LocationDescription.ToString & " > "
            Else
                locations += item.LocationDescription.ToString
                'locations = Replace(locations, country & " > ", "")
            End If

        Next
        'Dim pageheadertext As Literal = Master.FindControl("pageheadertext")
        'pageheadertext.Text = locations.ToString
        lblTown.Text = objUse(0).Locations(0).LocationDescription.ToString
        lblCountry.Text = country
        property_country = country
        HttpContext.Current.Cache.Add("property_country" & thisPropRef, property_country, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
        property_title = objUse(0).title
        HttpContext.Current.Cache.Add("property_title" & thisPropRef, property_title, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
        lblSleeps.Text = objUse(0).Sleeps

        'If objUse(0).AccomGroup = 2 Then
        'lblPriceRange.Text = Left(objUse(0).PropCurrency, InStr(objUse(0).PropCurrency, " ") - 1) & FormatNumber(objUse(0).MinPrice, 0) & " pppn"
        'lblSleepsTitle.Text = "Rooms:"
        'Else
        lblPriceRange.Text = objUse(0).PriceRange 'Left(objUse(0).Currency, InStr(objUse(0).Currency, " ") - 1) & FormatNumber(objUse(0).MinPrice, 0) & " p/w"
        lblCurrency.Text = objUse(0).Currency
        lblSleepsTitle.Text = "Sleeps:"
        'End If

        currency = Left(objUse(0).Currency, InStr(objUse(0).Currency, " ") - 1)

        lblAccommodation.Text = objUse(0).PropType
        'If objUse(0).PropRating > 0 Then
        'pnlRating.Visible = True
        'imgRating.ImageUrl = "Images/Stars/" & objUse(0).PropRating & "_star.gif"
        'End If



    End Sub

    Sub LoadFacilities()

        Dim objUse = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))

        'Facilities nearby
        Dim thisHtml As String = ""
        If objUse(0).website = "HH" Then

            lblFacilitieshead.Text = ""
            If objUse(0).features Is Nothing Then
                thisHtml = ""
            Else
                thisHtml &= "<div class=""adverts_content_all"">" & vbCrLf
                thisHtml &= "<span class=""small_text_bold"">" & Replace(objUse(0).features, "  ", "<br />") & "</span>" & vbCrLf
                thisHtml &= "</div>" & vbCrLf
            End If
        Else

            thisHtml &= CheckFacility(objUse(0).beach, "Beach")
            thisHtml &= CheckFacility(objUse(0).swimming, "Swimming")
            thisHtml &= CheckFacility(objUse(0).sailing, "Sailing")
            'thisHtml &= CheckFacility(objUse(0).waterskiing, "Water skiing")
            'thisHtml &= CheckFacility(objUse(0).boathire, "Boat hire")
            'thisHtml &= CheckFacility(objUse(0).windsurfing, "Wind surfing")
            'thisHtml &= CheckFacility(objUse(0).fishing, "Fishing")
            thisHtml &= CheckFacility(objUse(0).climbing, "Climbing")
            'thisHtml &= CheckFacility(objUse(0).flying, "Flying")
            thisHtml &= CheckFacility(objUse(0).walking, "Walking")
            thisHtml &= CheckFacility(objUse(0).cycling, "Cycling")
            'thisHtml &= CheckFacility(objUse(0).mountainbiking, "Mountain biking")
            thisHtml &= CheckFacility(objUse(0).horseriding, "Horse riding")
            thisHtml &= CheckFacility(objUse(0).skiing, "Skiing")
            thisHtml &= CheckFacility(objUse(0).golf, "Golf")
            thisHtml &= CheckFacility(objUse(0).tennis, "Tennis")
            'thisHtml &= CheckFacility(objUse(0).sportscenter, "Sports centre")
            'thisHtml &= CheckFacility(objUse(0).scuba, "Scuba")
            'thisHtml &= CheckFacility(objUse(0).historic, "Historic site")
            'thisHtml &= CheckFacility(objUse(0).museum, "Museum")
            'thisHtml &= CheckFacility(objUse(0).zoo, "Zoo")
            'thisHtml &= CheckFacility(objUse(0).theatre_cinema, "Cinema")
            'thisHtml &= CheckFacility(objUse(0).shopping, "Shops")
            'thisHtml &= CheckFacility(objUse(0).food_shop, "Food shops")
            'thisHtml &= CheckFacility(objUse(0).themepark, "Themepark")
            'thisHtml &= CheckFacility(objUse(0).restaurant, "Resturants")
            'thisHtml &= CheckFacility(objUse(0).shopping, "Shops")
            thisHtml &= CheckFacility(objUse(0).AirportDistance, objUse(0).Airport & " Airport")
            thisHtml &= "</div>"
        End If
        lblFacilities.Text = thisHtml

        If thisHtml = "" Then
            Me.FacilitiesPanel.Visible = False
        Else
            Me.FacilitiesPanel.Visible = True
        End If

    End Sub
    Function CheckFacility(ByVal val, ByVal text)

        Dim thisHtml As String = ""
        Dim sTimePeriod As String = " <em>minutes</em>"
        If IsNumeric(val) Then
            If val <> 99 Then

                If facCount = 0 Then
                    thisHtml &= "<div class=""adverts_content_all"">" & vbCrLf
                ElseIf facCount Mod 2 = 0 Then
                    thisHtml &= "</div>" & vbCrLf
                    thisHtml &= "<div class=""adverts_content_all"">" & vbCrLf
                End If

                thisHtml &= "<div class=""adverts_data_beds_left"">" & vbCrLf
                thisHtml &= "<span class=""small_text_bold"">" & text & ":</span>" & vbCrLf
                thisHtml &= "</div>" & vbCrLf
                thisHtml &= "<div class=""adverts_data_beds_right"">" & vbCrLf
                thisHtml &= "<span class=""small_text"">" & vbCrLf
                If val = 15 Then
                    thisHtml &= "15" & sTimePeriod & vbCrLf
                ElseIf val = 45 Then
                    thisHtml &= "45" & sTimePeriod & vbCrLf
                ElseIf val = 0 Then
                    thisHtml &= "on-site" & vbCrLf
                End If
                thisHtml &= "</span>" & vbCrLf
                thisHtml &= "</div>" & vbCrLf

                facCount = facCount + 1

            End If
        Else
            If LCase(val) <> "none" Then

                If facCount = 0 Then
                    thisHtml &= "<div class=""adverts_content_all"">" & vbCrLf
                ElseIf facCount Mod 2 = 0 Then
                    thisHtml &= "</div>" & vbCrLf
                    thisHtml &= "<div class=""adverts_content_all"">" & vbCrLf
                End If

                thisHtml &= "<div class=""adverts_data_beds_left"">" & vbCrLf
                thisHtml &= "<span class=""small_text_bold"">" & text & ":</span>" & vbCrLf
                thisHtml &= "</div>" & vbCrLf
                thisHtml &= "<div class=""adverts_data_beds_right"">" & vbCrLf
                thisHtml &= "<span class=""small_text"">" & vbCrLf

                thisHtml &= val & vbCrLf

                thisHtml &= "</span>" & vbCrLf
                thisHtml &= "</div>" & vbCrLf

                facCount = facCount + 1

            End If
        End If

        Return thisHtml

    End Function


    Public Sub LoadReviews()
        Dim strXML
        
        strXML = bll.GetPropertyReviews(thisPropRef, property_country, property_title, Request.QueryString("productFilter"))
        Try
            If strXML.reviews Is Nothing Then
                Me.lblreview.Visible = True
                Me.reviewimg.Visible = False
                ReviewsPanel.Visible = True
                Me.lblreview.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"
                Me.ReviewsTitleLabel.Text = "Reviews"
                Me.ReviewsTextLabel.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"
            Else
                If strXML.reviews.length = 0 Then
                    Me.lblreview.Visible = True
                    Me.reviewimg.Visible = False
                    ReviewsPanel.Visible = True
                    Me.lblreview.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"
                    Me.ReviewsTitleLabel.Text = "Reviews"

                    Me.ReviewsTextLabel.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"

                Else
                    reviewCount = strXML.reviews.length
                    ReviewsPanel.Visible = True

                    Me.ReviewsTitleLabel.Text = "Reviews"

                    Me.ReviewsTextLabel.Text = "<b>" + strXML.reviews(0).by.ToString + " says:</b> ""<em>" + strXML.reviews(0).article.ToString + "</em>""<br />"
                    Me.ReviewsTextLabel.Text &= "<br /><a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here for more reviews"">Click here for more reviews</a>"

                    Dim linkCount As Integer
                    linkCount = Int((strXML.reviews.Length) * Rnd())
                    Dim article As String = strXML.reviews(linkCount).article.ToString
                    article = Left(article, 150) + ".....""""<br/> see the Reviews tab for more.<br/>"
                    Me.lblreview.Text = "<b>" + strXML.reviews(linkCount).by.ToString + " says:</b> ""<em>" + article.ToString + "</em><br />"
                    Me.reviewimg.ImageUrl = "Images/Stars/" & strXML.reviews(linkCount).StarRating.ToString & "_star.gif"
                    Me.reviewimg.AlternateText = "the reviewer has rated the property with a score of " & strXML.reviews(linkCount).StarRating.ToString & " out of 10."
                    Me.reviewimg.ToolTip = "the reviewer has rated the property with a score of " & strXML.reviews(linkCount).StarRating.ToString & " out of 10."

                End If
            End If
        Catch ex As Exception
            Me.lblreview.Visible = True
            Me.reviewimg.Visible = False
            ReviewsPanel.Visible = True
            Me.lblreview.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"
            Me.ReviewsTitleLabel.Text = "Reviews"
            Me.ReviewsTextLabel.Text = "<a href=""propertyReviews.aspx?ref=" & thisPropRef & "&productFilter=" & Request.QueryString("productFilter") & """ title=""Click here to add a review""><b>Review this accommodation</b></a><br/>Be the first to add a review of this property and add to our 14000+ reviews helping people choose the right holiday.<br />"

        End Try

        strXML = Nothing
    End Sub

    Public Sub LoadPageSummary()


        Dim objUse = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))

        Me.PropSummaryPanel.Visible = True

        Me.PropSummaryTitleLabel.Text = ""
        Me.PropSummaryTextLabel.Text = ""

        'Dim prop_town As String = objUse(0).add_town
        'Dim prop_country As String = objUse(0).add_country
        Dim prop_type As String = objUse(0).proptype
        'Dim prop_accommodation As String = objUse(0).accommodation
        Dim prop_sleep As String = objUse(0).sleeps
        Dim prop_min_price As String = objUse(0).minprice
        Dim prop_max_price As String = objUse(0).maxprice
        Dim prop_total_reviews As String = reviewCount.ToString
        'Dim prop_star_rating As String
        'If Not objUse(0).reviews_stars") Is DBNull.Value Then
        ' prop_star_rating = objUse(0).reviews_stars
        'Else
        'prop_star_rating = " "
        'End If
        'Dim prop_advert_type As String = objUse(0).advert_type"
        'Dim prop_advert_num_props As String = objUse(0).num_props

        'Dim prop_para1_title As String = objUse(0).para1_title
        'Dim prop_para2_title As String = objUse(0).para2_title
        'Dim prop_para3_title As String = objUse(0).para3_title
        'Dim prop_para1_text As String = objUse(0).para1_text
        'prop_para1_text += Replace(prop_para1_text & "&nbsp;", vbCrLf, "<br />")
        'Dim prop_para2_text As String = objUse(0).para1_text
        'prop_para2_text += Replace(prop_para2_text & "&nbsp;", vbCrLf, "<br />")
        'Dim prop_para3_text As String = objUse(0).para1_text
        'prop_para3_text += Replace(prop_para3_text & "&nbsp;", vbCrLf, "<br />")

        Dim prop_extra As String
        If objUse(0).extra > "" Then
            prop_extra = objUse(0).extra
        Else
            prop_extra = ""
        End If
        Dim prop_double_beds As String
        If objUse(0).doublebeds > 0 Then
            prop_double_beds = objUse(0).doublebeds
        Else
            prop_double_beds = "0"
        End If
        Dim prop_twin_beds As String
        If objUse(0).twinbeds > 0 Then
            prop_twin_beds = objUse(0).twinbeds
        Else
            prop_twin_beds = "0"
        End If
        Dim prop_single_beds As String
        If objUse(0).singlebeds > 0 Then
            prop_single_beds = objUse(0).singlebeds
        Else
            prop_single_beds = "0"
        End If
        Dim prop_cots As String
        If objUse(0).cots > 0 Then
            prop_cots = objUse(0).cots
        Else
            prop_cots = "0"
        End If
        Dim prop_ensuite As String
        'If Not objUse(0).ensuite") Is DBNull.Value Then
        'prop_ensuite = objUse(0).ensuite
        'Else
        prop_ensuite = "0"
        'End If
        'Dim prop_sofa_beds As String = "0"
        'If Not objUse(0).sofa_beds") Is DBNull.Value Then
        '    prop_sofa_beds = objUse(0).sofa_beds
        'End If
        'Dim prop_double_sofa_beds As String = "0"
        'If Not objUse(0).dbl_sofa_beds") Is DBNull.Value Then
        '    prop_double_sofa_beds = objUse(0).dbl_sofa_beds
        'End If
        'Dim prop_double_bunks As String = "0"
        'If Not objUse(0).dbl_bunks") Is DBNull.Value Then
        '    prop_double_bunks = objUse(0).dbl_bunks
        'End If
        'Dim prop_sofa_beds_location As String = ""
        'If Not objUse(0).sofa_beds_location") Is DBNull.Value Then
        '    prop_sofa_beds_location = objUse(0).sofa_beds_location
        'End If
        'Dim prop_double_sofa_beds_location As String = ""
        'If Not objUse(0).dbl_sofa_beds_location") Is DBNull.Value Then
        '    prop_double_sofa_beds_location = objUse(0).dbl_sofa_beds_location
        'End If
        'Dim prop_double_bunks_location As String = ""
        'If Not objUse(0).dbl_bunks_location") Is DBNull.Value Then
        '    prop_double_bunks_location = objUse(0).dbl_bunks_location
        'End If
        Dim prop_linen_provided As Boolean = False
        prop_linen_provided = objUse(0).linenprovided
        
        Me.PropSummaryTitleLabel.Text = "<strong>Further information about this " + lblTown.Text & " " & prop_type & " rental</strong><br />"
        Me.PropSummaryTextLabel.Text = prop_extra & "<br /><br />"

        Me.PropSummaryTextLabel.Text += "<strong>Inside this " + lblTown.Text & " " & prop_type & "</strong><br /><br />"
        Me.PropSummaryTextLabel.Text += "<font color=""#FF0000"">Sleeping:</font><br />The " & prop_type & " comprises "
        Dim total As Integer = 0
        total = CType(prop_double_beds, Integer) + CType(prop_twin_beds, Integer) + CType(prop_single_beds, Integer)
        Me.PropSummaryTextLabel.Text &= total & " bedrooms in total; "


        Dim bed_flag As Boolean = False
        If prop_double_beds > 0 Then
            Me.PropSummaryTextLabel.Text &= prop_double_beds & " double"
            bed_flag = True
        End If

        If prop_twin_beds > 0 Then
            If bed_flag = True Then
                Me.PropSummaryTextLabel.Text &= ","
            End If
            bed_flag = True
            Me.PropSummaryTextLabel.Text &= prop_twin_beds & " twin"
        End If

        If prop_single_beds > 0 Then
            If bed_flag = True Then
                Me.PropSummaryTextLabel.Text &= ","
            End If
            bed_flag = True
            Me.PropSummaryTextLabel.Text &= prop_single_beds & " single"
        End If

        If prop_cots > 0 Then
            Me.PropSummaryTextLabel.Text &= " and "
            If prop_cots = 1 Then
                Me.PropSummaryTextLabel.Text &= " a cot"
            Else
                Me.PropSummaryTextLabel.Text &= prop_cots & " cots"
            End If
        End If

        If prop_ensuite > 0 Then
            Me.PropSummaryTextLabel.Text &= ", " & prop_ensuite & " of the bedrooms with en-suite facilities"
        End If

        bed_flag = False

        'If prop_sofa_beds > 0 Or prop_double_sofa_beds > 0 Or prop_double_bunks > 0 Then
        '    Me.PropSummaryTextLabel.Text &= ". The property also has "

        '    If prop_sofa_beds > 0 Then
        '        bed_flag = True
        '        If prop_sofa_beds = 1 Then
        '            Me.PropSummaryTextLabel.Text &= "a single sofa bed"
        '        Else
        '            Me.PropSummaryTextLabel.Text &= "single sofa beds"
        '        End If
        '        If Trim(prop_sofa_beds_location) <> "" Then
        '            Me.PropSummaryTextLabel.Text &= " located in the " & Trim(prop_sofa_beds_location)
        '        End If
        '    End If

        '    If prop_double_sofa_beds > 0 Then
        '        If bed_flag = True Then
        '            Me.PropSummaryTextLabel.Text &= ","
        '        End If
        '        If prop_double_sofa_beds = 1 Then
        '            Me.PropSummaryTextLabel.Text &= " a double sofa bed"
        '        Else
        '            Me.PropSummaryTextLabel.Text &= " double sofa beds"
        '        End If
        '        If Trim(prop_double_sofa_beds_location) <> "" Then
        '            Me.PropSummaryTextLabel.Text &= " located in the " & Trim(prop_double_sofa_beds_location)
        '        End If
        '    End If

        '    If prop_double_bunks > 0 Then
        '        If bed_flag = True Then
        '            Me.PropSummaryTextLabel.Text &= ","
        '        End If
        '        If prop_double_bunks = 1 Then
        '            Me.PropSummaryTextLabel.Text &= " a double bunk bed"
        '        Else
        '            Me.PropSummaryTextLabel.Text &= " double bunk beds"
        '        End If
        '        If Trim(prop_double_bunks_location) <> "" Then
        '            Me.PropSummaryTextLabel.Text &= " located in the " & Trim(prop_double_bunks_location)
        '        End If
        '    End If
        'End If

        Me.PropSummaryTextLabel.Text &= ". This room gives up to " + prop_sleep + " people."
        If prop_linen_provided Then
            Me.PropSummaryTextLabel.Text &= " Bed linen and towels are provided for your use."
        End If
        Me.PropSummaryTextLabel.Text &= "<br /><br /><font color=""#FF0000"">General:</font><br />"

        Dim prop_bathrooms As String = objUse(0).bathrooms
        Me.PropSummaryTextLabel.Text &= prop_type & " has " & prop_bathrooms & " bathrooms "

        'Dim prop_wcs As Integer = objUse(0).wcs
        'If prop_wcs > 0 Then
        '    Me.PropSummaryTextLabel.Text &= " and " & prop_wcs & " WCs "
        'End If
        Me.PropSummaryTextLabel.Text &= "for your party's use."

        Dim prop_air_condition As Boolean = objUse(0).airconditioning
        If prop_air_condition Then
            Me.PropSummaryTextLabel.Text &= " Air-conditioning keeps the " & prop_type & " cool."
        End If

        Dim prop_central_heating As Boolean = objUse(0).centralheating
        If prop_central_heating Then
            Me.PropSummaryTextLabel.Text &= " Central heating keeps you snug and warm."
        End If

        'Dim prop_sauna As Boolean = objUse(0).sauna
        'If prop_sauna Then
        '    Me.PropSummaryTextLabel.Text &= " The " & prop_type & " has a sauna."
        'End If

        Me.PropSummaryTextLabel.Text &= "<br /><br /><font color=""#FF0000"">Entertainment:</font><br/>"

        Dim entertainment_flag As Boolean = False
        Dim comma_flag As Boolean = False
        Dim prop_tv As Boolean = objUse(0).tv
        Dim prop_home_cinema As Boolean = False 'objUse(0).home_cinema
        Dim prop_video As Boolean = False 'objUse(0).video
        Dim prop_dvd As Boolean = False 'objUse(0).dvd
        Dim prop_satellite As Boolean = objUse(0).satellite
        If prop_tv Or prop_home_cinema Or prop_video Or prop_dvd Or prop_satellite Then
            Me.PropSummaryTextLabel.Text &= "The " & prop_type & " has "
            If prop_tv Then
                Me.PropSummaryTextLabel.Text &= "television"
                entertainment_flag = True
            End If
            If prop_home_cinema Then
                entertainment_flag = True
                Me.PropSummaryTextLabel.Text &= " and home cinema"
                If prop_video Or prop_dvd Or prop_satellite Then
                    Me.PropSummaryTextLabel.Text &= " with"
                End If
                If prop_video Then
                    Me.PropSummaryTextLabel.Text &= " video"
                    comma_flag = True
                End If
                If prop_dvd Then
                    If comma_flag Then
                        Me.PropSummaryTextLabel.Text &= ", "
                    End If
                    Me.PropSummaryTextLabel.Text &= " dvd"
                    comma_flag = True
                End If
                If prop_satellite Then
                    If comma_flag = True Then
                        Me.PropSummaryTextLabel.Text &= ", "
                    End If
                    Me.PropSummaryTextLabel.Text &= " satellite or cable"
                End If
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        Dim prop_cassette As Boolean = False 'objUse(0).cassette
        Dim prop_vinyl As Boolean = False 'objUse(0).vinyl
        Dim prop_cd As Boolean = False 'objUse(0).cd
        Dim prop_radio As Boolean = False 'objUse(0).radio
        comma_flag = False

        If prop_cassette Or prop_vinyl Or prop_cd Or prop_radio Then
            entertainment_flag = True
            Me.PropSummaryTextLabel.Text &= " The music system will play"
            If prop_cassette Then
                Me.PropSummaryTextLabel.Text &= " cassettes"
                comma_flag = True
            End If
            If prop_vinyl Then
                If comma_flag = True Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " vinyl"
            End If
            If prop_radio Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " radio"
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        Dim prop_computer As Boolean = False 'objUse(0).computer
        Dim prop_internet As Boolean = objUse(0).internet
        Dim prop_tel_in As Boolean = objUse(0).telephone
        Dim prop_tel_out As Boolean = False 'objUse(0).telephone_out
        If prop_computer Then
            entertainment_flag = True
            Me.PropSummaryTextLabel.Text &= "<br />A computer"
            If prop_internet Then
                Me.PropSummaryTextLabel.Text &= " with Internet connection"
            End If
            Me.PropSummaryTextLabel.Text &= " is also available for your use."
        End If

        If prop_tel_in Or prop_tel_out Then
            entertainment_flag = True
            If prop_tel_out Then
                Me.PropSummaryTextLabel.Text &= " If you need to keep in contact there is a telephone for incoming and outgoing calls"
            Else
                Me.PropSummaryTextLabel.Text &= " If you need to keep in contact there is a telephone for incoming calls only"
            End If
            Dim prop_fax As Boolean = False 'objUse(0).fax
            If prop_fax Then
                Me.PropSummaryTextLabel.Text &= " and a fax machine"
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        Dim prop_home_gym As Boolean = False 'objUse(0).home_gym
        Dim prop_snooker_table As Boolean = False 'objUse(0).snooker_pool_table
        Dim prop_table_tennis As Boolean = False 'objUse(0).table_tennis
        comma_flag = False

        If prop_home_gym Or prop_snooker_table Or prop_table_tennis Then
            entertainment_flag = True
            Me.PropSummaryTextLabel.Text &= " Recreational activities available with the " & prop_type & " include"
            If prop_home_gym Then
                Me.PropSummaryTextLabel.Text &= " a home gym"
                comma_flag = True
            End If
            If prop_snooker_table Then
                If comma_flag = True Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a snooker/pool table"
                comma_flag = True
            End If
            If prop_table_tennis Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " table tennis"
                comma_flag = True
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        If entertainment_flag = False Then
            Me.PropSummaryTextLabel.Text &= "...nothing was specified."
        End If

        Me.PropSummaryTextLabel.Text &= "<br /><br /><font color=""#FF0000"">Eating &amp; Living:</font><br />"
        Dim prop_living_seating As Integer = 0 'objUse(0).living_seating
        Dim prop_dining_seating As Integer = 0 'objUse(0).dining_seating

        If prop_living_seating > 0 Or prop_dining_seating > 0 Then
            Me.PropSummaryTextLabel.Text &= "There is room for"
            If prop_living_seating > 0 Then
                Me.PropSummaryTextLabel.Text &= " " & prop_living_seating.ToString() & " in the living room"
                If prop_dining_seating > 0 Then
                    Me.PropSummaryTextLabel.Text &= " and"
                End If
            End If
            If prop_dining_seating > 0 Then
                Me.PropSummaryTextLabel.Text &= " " & prop_dining_seating.ToString() & " in the dining room"
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        Dim prop_open_fire As Boolean = objUse(0).openfire
        If prop_open_fire Then
            Me.PropSummaryTextLabel.Text &= " The open fire can be used to create a comfortable atmosphere."
        End If

        Dim prop_cooker As Boolean = objUse(0).cooker
        Dim prop_oven As Boolean = False 'objUse(0).oven
        Dim prop_microwave As Boolean = objUse(0).microwave
        Dim prop_fridge As Boolean = objUse(0).fridge
        Dim prop_freezer As Boolean = objUse(0).freezer
        Dim prop_kettle As Boolean = False 'objUse(0).kettle
        Dim prop_toaster As Boolean = False 'objUse(0).toaster
        comma_flag = False

        If prop_cooker Or prop_oven Or prop_microwave Or prop_fridge Or prop_freezer Or prop_kettle Or prop_toaster Then
            Me.PropSummaryTextLabel.Text &= " To prepare food you will find"
            If prop_cooker Then
                Me.PropSummaryTextLabel.Text &= " a cooker"
                comma_flag = True
            End If
            If prop_oven Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " an oven"
                comma_flag = True
            End If
            If prop_microwave Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a microwave"
                comma_flag = True
            End If
            If prop_fridge Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a fridge"
                comma_flag = True
            End If
            If prop_freezer Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a freezer"
                comma_flag = True
            End If
            If prop_kettle Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a kettle"
                comma_flag = True
            End If
            If prop_toaster Then
                If comma_flag Then
                    Me.PropSummaryTextLabel.Text &= ", "
                End If
                Me.PropSummaryTextLabel.Text &= " a toaster"
                comma_flag = True
            End If
            Me.PropSummaryTextLabel.Text &= "."
        End If

        Dim prop_dish_washer As Boolean = False 'objUse(0).dish_washer
        Dim prop_washing_machine As Boolean = False 'objUse(0).washing_machine
        Dim prop_clothes_drier As Boolean = False 'objUse(0).clothes_drier
        Dim prop_iron As Boolean = False 'objUse(0).iron
        comma_flag = False

        Me.PropSummaryText2Label.Text = ""
        If prop_dish_washer Or prop_washing_machine Or prop_clothes_drier Or prop_iron Then
            Me.PropSummaryText2Label.Text &= " You will also find"
            If prop_dish_washer Then
                Me.PropSummaryText2Label.Text &= " a dish washer"
                comma_flag = True
            End If
            If prop_washing_machine Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " a washing machine"
                comma_flag = True
            End If
            If prop_clothes_drier Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " a clothes drier"
                comma_flag = True
            End If
            If prop_iron Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " an iron and ironing board"
                comma_flag = True
            End If
            Me.PropSummaryText2Label.Text &= "."
        End If

        Dim prop_cutlery As Boolean = False 'objUse(0).cutlery
        Dim prop_crockery As Boolean = False 'objUse(0).crockery
        Dim prop_glassware As Boolean = False 'objUse(0).glassware
        Dim prop_pots As Boolean = False 'objUse(0).pots
        comma_flag = False

        If prop_cutlery Or prop_crockery Or prop_glassware Or prop_pots Then
            Me.PropSummaryText2Label.Text &= " The owner has also provided"
            If prop_cutlery Then
                Me.PropSummaryText2Label.Text &= " cutlery"
                comma_flag = True
            End If
            If prop_crockery Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " crockery"
                comma_flag = True
            End If
            If prop_glassware Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " glassware"
                comma_flag = True
            End If
            If prop_pots Then
                If comma_flag Then
                    Me.PropSummaryText2Label.Text &= ", "
                End If
                Me.PropSummaryText2Label.Text &= " cooking utensils"
                comma_flag = True
            End If
            Me.PropSummaryText2Label.Text &= "."
        End If

        If comma_flag = False Then
            Me.PropSummaryText2Label.Text &= "...nothing was specified."
        End If

        Me.PropSummaryText2Label.Text &= "<br /><br /><font color=""#FF0000"">Further Information:</font><br />"

        Me.PropSummaryText2Label.Text &= "<table><tr><td><strong>Smoking:</strong></td> "
        Dim prop_non_smoking As Boolean = objUse(0).nonesmoking
        If prop_non_smoking Then
            Me.PropSummaryText2Label.Text &= "<td>This is a non-smoking " & prop_type & ".</td>"
        Else
            Me.PropSummaryText2Label.Text &= "<td>Smoking is allowed in this " + prop_type + ".</td>"
        End If
        Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        Me.PropSummaryText2Label.Text &= "<tr><td><strong>Pets:</strong></td>"
        Dim prop_pets As Boolean = objUse(0).pets
        Dim prop_petsexplain As String = ""
        'If Not objUse(0).petsexplain") Is DBNull.Value Then
        '    prop_petsexplain = objUse(0).petsexplain
        '    prop_petsexplain = Replace(prop_petsexplain & "&nbsp;", vbCrLf, "<br />")
        'End If
        If prop_pets Then
            Me.PropSummaryText2Label.Text &= "<td>Pets are not welcome.</td>"
        Else
            Me.PropSummaryText2Label.Text &= "<td>Pets are welcome. " & prop_petsexplain & "</td>"
        End If
        Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        'Me.PropSummaryText2Label.Text &= "<tr><td><strong>Wheelchairs:</strong></td>"
        'Dim prop_wheelchairs As Boolean = objUse(0).wheelchairs")
        'Dim prop_wheelchairsexplain As String = ""
        'If Not objUse(0).wheelchairsexplain") Is DBNull.Value Then
        '    prop_wheelchairsexplain = objUse(0).wheelchairsexplain")
        '    prop_wheelchairsexplain = Replace(prop_wheelchairsexplain & "&nbsp;", vbCrLf, "<br />")
        'End If
        'If prop_wheelchairs Then
        '    Me.PropSummaryText2Label.Text &= "<td>Property is not suitable for wheelchairs.</td>"
        'Else
        '    Me.PropSummaryText2Label.Text &= "<td>Property is suitable for wheelchairs. " & prop_wheelchairsexplain & "</td>"
        'End If
        'Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        'Me.PropSummaryText2Label.Text &= "<tr><td><strong>Babies:</strong></td>"
        'Dim prop_babies As Boolean = objUse(0).babies")
        'If prop_babies Then
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for babies.</td>"
        'Else
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for babies.</td>"
        'End If
        'Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        'Me.PropSummaryText2Label.Text &= "<tr><td><strong>Children:</strong></td>"
        'Dim prop_children As Boolean = objUse(0).children")
        'If prop_children Then
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for children.</td>"
        'Else
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for children.</td>"
        'End If
        'Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        'Me.PropSummaryText2Label.Text &= "<tr><td><strong>Elderly:</strong></td>"
        'Dim prop_elderly As Boolean = objUse(0).elderly")
        'If prop_elderly Then
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for the elderly.</td>"
        'Else
        '    Me.PropSummaryText2Label.Text &= "<td>Propery is not suitable for the elderly.</td>"
        'End If
        'Me.PropSummaryText2Label.Text &= "</tr><tr><td colspan=""2"">&nbsp;</td></tr>"

        Me.PropSummaryText2Label.Text &= "<tr><td><strong>Swimming Pool:</strong></td>"
        Dim prop_communal_pool As Boolean = objUse(0).sharedpool
        Dim prop_private_pool As Boolean = objUse(0).privatepool
        Dim pool_aspect As String = False 'objUse(0).pool_aspect
        Dim pool_text As String = ""
        If prop_private_pool Then
            pool_text = "<td>A private "
            If pool_aspect <> "select aspect" Then
                pool_text &= pool_aspect
            End If
            pool_text &= " swimming pool.</td>"
        End If
        If prop_communal_pool And Not prop_private_pool Then
            pool_text &= "<td>Access to a shared "
            If pool_aspect <> "select aspect" Then
                pool_text &= pool_aspect
            End If
            pool_text &= " swimming pool.</td>"
        End If
        If pool_text > "" Then
            Me.PropSummaryText2Label.Text &= pool_text & "</tr></table>"
        Else
            Me.PropSummaryText2Label.Text &= "<td>No</td>" & "</tr></table>"
        End If


    End Sub
End Class
