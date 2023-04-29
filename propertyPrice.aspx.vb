Imports system.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.IO

Partial Class propertyPrice
    Inherits findavillaparks.ui.basepage.BasePage
    Public thisPropRef As String
    Public currency As String

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        thisPropRef = Request.QueryString("ref")
        If thisPropRef Is Nothing Or thisPropRef = "" Then
            Response.Redirect("default.aspx")
        End If

        Dim objProp
        objProp = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))
        If objProp Is Nothing Then
            Response.Redirect("webserviceerror.aspx?page=propertyPrice:" & Request.QueryString("ref") & ":" & Request.QueryString("productFilter") & "&errCode=add&errText==webservice-nothing")
        End If
        Dim metatag As String = ""
        Try
            metatag = Replace(objProp(0).Title, ";", " ") & objProp(0).Seo1
        Catch ex As Exception

        End Try

        loadHeaders(metatag)

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
                HHprices.Visible = True
                prices.Visible = False
                HyperLink1.NavigateUrl = "http://www.hoseasons.co.uk/productSite.aspx?ClassCode=" & Request.QueryString("ref") & "&bid=97&aid=CD48&opt=lodgedisplayfull-details"
            Case "VR"
                HHprices.Visible = False
                prices.Visible = True


                Dim objUse

                objUse = bll.GetPropertyAvailability(thisPropRef)


                lblownerref.Text = objProp(0).owner_ref
                litTitle.Text = Replace(objProp(0).Title, ";", "<br />")
                If objUse Is Nothing Then
                    Response.Redirect("default.aspx")
                End If

                Dim max_people As Integer = objProp(0).sleeps.ToString
                Session("lastdayval") = "0"
                Dim cntr As Integer = 1
                For cntr = 2 To max_people
                    extra_people.Items.Add(cntr)
                Next
                currency = objUse.currency
                cal_curr.Text = objUse.currency

                rpCalendars.DataSource = objUse.propertyavailabilities
                rpCalendars.DataBind()
            Case Else
                Response.Redirect("default.aspx")
        End Select
        'http://www.rentalsystems.com/advert_price_check.asp?ref=19708&start=25/11/2007&end=02/12/2007&ps=7&dscode=&rag=35465G&rcam=finda-villa&sag=&sc=

        
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
    Protected Sub rpCalendars_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpCalendars.ItemDataBound

        If e.Item.ItemType = DataControlRowType.Header Or e.Item.ItemType = DataControlRowType.Footer Then

        Else

            Dim intMon As Integer = e.Item.DataItem.intMonth
            Dim intYear As Integer = e.Item.DataItem.intYear
            Dim curDate As DateTime = "01" & "/" & Month(Now) & "/" & Year(Now)
            Dim datadate As DateTime = "01" & "/" & intMon & "/" & intYear
            Dim datedif As Integer = DateDiff(DateInterval.Month, curDate, datadate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek)
            Dim addcontrol As Literal
            Dim tabledata As String = ""

            tabledata = "<table class=""arial8Black"">"
            tabledata &= "<tr height=""18"" bgcolor=""Silver"">"
            tabledata &= "<td width=""120"" colspan=""7"" align=""center"" valign=""middle"" class=""Verdarna10Blue"">" & MonthName(intMon) & " " & intYear
            tabledata &= "</td>"
            tabledata &= "</tr>"
            tabledata &= "<tr>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">S</td>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">M</td>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">T</td>"

            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">W</td>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">T</td>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">F</td>"
            tabledata &= "<td align=""center"" class=""Verdarna10Blue"" width=""20"" height=""16"" valign=""bottom"">S</td>"
            tabledata &= "</tr>"
            tabledata &= "<tr>"
            tabledata &= "<td height=""1"" align=""MIDDLE"" colspan=""7"" ><img src=""images/1x1_spacer.gif"" height=""1"" width=""140"" border=""0"" /></td>"

            tabledata &= "</tr>"
            Dim today As Date
            Dim daycount As Integer
            If datedif = 0 Then
                today = New Date(Now.Year, Now.Month, Now.Day)
                daycount = Day(Now)
            Else
                today = New Date(intYear, CInt(intMon), 1)
                daycount = 0
            End If

            Dim currentDate As Date = New Date(intYear, CInt(intMon), 1)
            Dim days() As String = New String() {"S", "M", "T", "W", "T", "F", "S"}

            Dim numDays As Integer = Date.DaysInMonth(intYear, intMon)
            Dim index, position As Integer
            Dim returnData As String = ""
            Dim offset As Integer = currentDate.DayOfWeek()

            Dim monthavailability As Array = Split(e.Item.DataItem.MonthAvailability, ",")
            Dim monthprice As Array = Split(e.Item.DataItem.MonthPricing, ",")

            Dim b1, b2, b3, a1, a2, a3, j1, j2, u1, u2, u3, u4
            b1 = " background='/images/newcalendar/calhtml/green-red.gif' " ' green to red " bgcolor='#FFFF00' "
            b2 = " bgcolor='#FF0000'  " ' solid red
            b3 = " background='/images/newcalendar/calhtml/red-green.gif' " ' red to green " bgcolor='#EECC22' "
            a1 = " background='/images/newcalendar/calhtml/green-blue.gif' " ' green to blue " bgcolor='#FFFF00' "
            a2 = " bgcolor='#0000CC' " ' ' solid blue
            a3 = " background='/images/newcalendar/calhtml/blue-green.gif' " ' blue to green " bgcolor='#EECC22' "
            j1 = " background='/images/newcalendar/calhtml/blue-red.gif' "  ' join between avail end and booking start
            j2 = " background='/images/newcalendar/calhtml/red-blue.gif' "  ' join between booking end and avial start
            u1 = " background='/images/newcalendar/calhtml/grey-blue.gif' " ' join between no prices and unavailable
            u2 = " background='/images/newcalendar/calhtml/blue-grey.gif' " ' join between  unavailable and no prices 
            u3 = " background='/images/newcalendar/calhtml/grey-red.gif' " ' join between no prices and booking
            u4 = " background='/images/newcalendar/calhtml/red-grey.gif' " ' join between  booking and no prices 
            Dim usebg As String = ""
            Dim lastval As Integer
            Dim thisval As Integer
            Dim nextval As Integer

            position = 0
            For index = 1 - offset To numDays
                If position Mod 7 = 0 Then
                    tabledata &= "<tr>"
                End If
                If index < 1 Then
                    tabledata &= "<td></td>"
                Else
                    If index <= daycount Then
                        tabledata &= "<td bgcolor='#888888' width='15'  height='16'><div align='center' ><font color='#FFFFFF'><strong>" & (index).ToString() & "</strong></font></div></td>"
                    Else
                        If index - daycount = 1 Then
                            lastval = Session("lastdayval")
                            If monthavailability(index - 1) = 0 Then
                                usebg = " bgcolor='#009933' "
                            Else
                                usebg = " bgcolor='#FF0000' "
                            End If
                        Else
                            lastval = monthavailability(index - 2)
                        End If
                        thisval = monthavailability(index - 1)
                        Try
                            nextval = monthavailability(index)
                        Catch ex As Exception
                            nextval = monthavailability(index - 1)
                            Session("lastdayval") = thisval
                        End Try
                        If lastval = 0 And thisval = 1 Then
                            usebg = " background='images/newcalendar/calhtml/green-red.gif' "
                        End If
                        If lastval = 1 And thisval = 1 Then
                            usebg = " bgcolor='#FF0000' "
                        End If
                        If lastval = 0 And thisval = 0 Then
                            usebg = " bgcolor='#009933' "
                        End If
                        If thisval = 0 And lastval = 1 Then
                            usebg = " background='images/newcalendar/calhtml/red-green.gif' "
                        End If

                        tabledata &= "<td  width='15'  height='16' align='center' " & usebg & "><div align='center' ><a href=""javascript:pickdate('" & (index).ToString() & "/" & intMon & "/" & intYear & "','" & (index).ToString() & "','" & intMon & "','" & intYear & "',2,2,'')"" onmouseover=""temp_prices('" & monthprice(index - 1) & "')"" onmouseout=""temp_prices(' ')"" title='Weekly Price: " & monthprice(index - 1) & " " & currency & "' class='calendara'><font color='#FFFFFF'><strong>" & (index).ToString() & "</strong></font></a></div></td>"
                    End If

                End If

                position += 1
                If position Mod 7 = 0 Then tabledata &= "</tr>"
            Next

            If position Mod 7 <> 0 Then
                For index = 1 To 7 - (position Mod 7)
                    tabledata &= "<td></td>"
                Next
                tabledata &= "</tr>"
            End If
            tabledata &= "</table>"

            Select Case datedif
                Case 0
                    addcontrol = e.Item.FindControl("calendarData1")
                    tabledata = tabledata & "</td>"
                Case 3, 6, 9
                    addcontrol = e.Item.FindControl("calendarData1")
                    tabledata = "<tr><td valign=""top"">" & tabledata
                    tabledata = tabledata & "</td>"
                Case 12
                    addcontrol = e.Item.FindControl("calendarData1")
                    tabledata = "<tr><td valign=""top"">" & tabledata
                    tabledata = tabledata & "</td><td></td><td></td></tr>"
                Case 1, 4, 7, 10
                    addcontrol = e.Item.FindControl("calendarData2")
                    tabledata = "<td valign=""top"">" & tabledata
                    tabledata = tabledata & "</td>"
                Case 2, 5, 8, 11
                    addcontrol = e.Item.FindControl("calendarData3")
                    tabledata = "<td valign=""top"">" & tabledata
                    tabledata = tabledata & "</td></tr>"
            End Select

            addcontrol.Text = tabledata
        End If

    End Sub

    Protected Sub complete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles complete.Click
        Dim currentdate As DateTime
        Dim frmDate As DateTime
        Dim toDate As DateTime
        warning.Text = ""
        currentdate = Now()
        Try
            frmDate = day1.Text & "/" & month1.Text & "/" & year1.Text
            Dim rdurl As String
            Try
                If frmDate < currentdate Then
                    warning.Text = "Please select a from date"
                Else
                    toDate = day2.Text & "/" & month2.Text & "/" & year2.Text
                    If toDate < frmDate Then
                        toDate = DateAdd(DateInterval.Day, 7, frmDate)
                    End If
                    rdurl = "http://www.rentalsystems.com/advert_price_check.asp?ref=" & thisPropRef & "&start=" & frmDate & "&end=" & toDate & "&ps=7&dscode=" & dscode.Text & "&rag=35465G&rcam=finda-villa&sag=&sc="
                    'warning.Text = rdurl
                    Response.Redirect(rdurl)
                End If
            Catch ex As Exception
                toDate = DateAdd(DateInterval.Day, 7, frmDate)
            End Try
        Catch ex As Exception
            warning.Text = "Please select a from date"
        End Try
        warning.Visible = True
    End Sub
End Class
