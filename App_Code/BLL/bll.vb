Imports Microsoft.VisualBasic
Imports System.Web.HttpContext

Public Class bll
    Public Function GetPropertyAvailability(ByVal PropertyRef As String)

        Dim searchresult As New getdata
        Return searchresult.GetPropertyAvailability(PropertyRef)

    End Function
    Public Function GetPropertyDetails(ByVal PropertyRef As String, ByVal website As String)

        Dim searchresult As New getdata
        Return searchresult.GetPropertyDetails(PropertyRef, website)

    End Function
    Public Function getlowestlocationforpropref(ByVal prop_ref As String, ByVal productFilter As String)

        Dim searchresult As New getdata
        Return searchresult.getlowestlocationforpropref(prop_ref, productFilter)

    End Function
    Public Function GetRefBySitecode(ByVal sitecode As String, ByVal productFilter As String)

        Dim searchresult As New getdata
        Return searchresult.GetRefBySitecode(sitecode, productFilter)

    End Function
    Public Function GetPropertyReviews(ByVal PropertyRef As String, ByVal propertycountry As String, ByVal propertytitle As String, ByVal website As String)

        Dim searchresult As New getdata
        Return searchresult.GetPropertyReviews(PropertyRef, propertycountry, propertytitle, website)

    End Function
    Public Function GetSearchResults(ByVal useLocation As String, ByVal website As String, ByVal productFilter As String, ByVal keyword As String, Optional ByVal propRefs As String = "")

        Dim searchresult As New getdata
        Return searchresult.GetSearchResults(useLocation, website, productFilter, keyword, propRefs)

    End Function
    Public Function GetLocations(ByVal parentRef As String, ByVal thiswebsite As String, ByVal datafilter As String)

        Dim searchresult As New getdata
        Return searchresult.GetLocations(parentRef, thiswebsite, datafilter)

    End Function

    Public Function GetAllLocations(ByVal cat_ref As Integer, ByVal cat_description As String, ByVal datafilter As String)

        Dim searchresult As New getdata
        Return searchresult.GetAllLocations(cat_ref, cat_description, datafilter)

    End Function
    Public Function GetParentLocations(ByVal parentRef As Integer)

        Dim searchresult As New getdata
        'Return searchresult.GetParentLocations(parentRef)

    End Function
    Public Function GetSlideShow(ByVal PropertyRef As String, ByVal website As String)

        Dim searchresult As New getdata
        Dim dsMainImages As New Data.DataSet
        Dim sXML As String
        Dim sXML2 As String
        Dim sTempURL As String
        Dim subUrl As String = ""
        Try
            If IsNothing(Current.Cache.Item("SlideShow" & PropertyRef)) Then
                Dim objUse = searchresult.GetPropertyDetails(PropertyRef, website)
                sXML2 = ""
                sXML = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                sXML &= "<gallery>"
                Select Case website
                    Case "VR"
                        sXML &= "<album id='Property " & PropertyRef & "' description='Property Advert Pictures' lgPath='http://www.rentalsystems.com/data/images/" & PropertyRef & "/' startHere='true'>"
                    Case "HH"
                        Select Case LCase(objUse(0).propType)
                            Case "lodge"
                                subUrl = "UKParks"
                            Case "boat"
                                subUrl = "UKBoats"
                            Case "cottage"
                                subUrl = "UKCottages"
                            Case Else
                                subUrl = "UKParks"
                        End Select
                        sXML &= "<album id='Property " & PropertyRef & "' description='Property Advert Pictures' lgPath='http://images.hoseasons.co.uk/images/ProductImages/" & subUrl & "/' startHere='true'>"
                End Select
                Dim picCount As Integer
                For picCount = 0 To objUse(0).PropImages.Length - 1
                    sTempURL = stripURL(objUse(0).PropImages(picCount).ImageUrl)
                    If sTempURL > "" Then
                        sXML2 &= "<img src='" & sTempURL & "'  caption='" & objUse(0).PropImages(picCount).ImageCaption & "'/>"
                    End If
                Next
                sXML &= sXML2
                sXML &= "</album>"
                sXML &= "</gallery>"
                Current.Cache.Add("SlideShow" & PropertyRef, sXML, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
            End If
        Catch ex As Exception
            'Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("SlideShow" & PropertyRef)

    End Function
    Public Function stripURL(ByVal url)
        ' Strip rest of URL as flash doesnt want it
        Dim urlPos
        urlPos = InStrRev(url, "/")
        url = Right(url, Len(url) - urlPos)
        stripURL = url
    End Function
    Public Function SaveReviews(ByVal thisPropRef As String, ByVal first_name As String, ByVal last_name As String, _
        ByVal email_address As String, ByVal booking_ref As String, ByVal val_for_money As Integer, ByVal met_expectations As Integer, _
        ByVal would_rec As Integer, ByVal overall_rating As Integer, ByVal submitted_date As DateTime, ByVal review_text As String, _
        ByVal star_rating As Integer, ByVal town_from As String, ByVal review_approved As String, _
        ByVal prop_country As String, ByVal prop_title As String, ByVal website As String) As String

        Dim ReviewSaved As New getdata
        Return ReviewSaved.SavePropertyReviews(thisPropRef, first_name, last_name, email_address, booking_ref, val_for_money, met_expectations, _
                            would_rec, overall_rating, FormatDateTime(submitted_date, DateFormat.ShortDate), review_text, _
                            star_rating, town_from, 0, prop_country, prop_title, website)

    End Function
    Public Function thiswebsite() As String
        Select Case Replace(HttpContext.Current.Request.ServerVariables("SERVER_NAME"), "www.", "")
            Case "finda-villa.com", "finda-villa.co.uk"
                thiswebsite = "finda-villa"
            Case "zonchi.com", "zonchi.co.uk"
                thiswebsite = "finda-villa"
            Case "lodgesandparks.com", "lodgesandparks.co.uk"
                thiswebsite = "lodgesandparks"
            Case "boatingoffers.co.uk"
                thiswebsite = "boats"
            Case Else
                thiswebsite = "finda-villa"
                thiswebsite = "lodgesandparks"
        End Select
    End Function
    Public Function productfilter() As String
        Select Case Replace(HttpContext.Current.Request.ServerVariables("SERVER_NAME"), "www.", "")
            Case "finda-villa.com", "finda-villa.co.uk", "bookvillas.co.uk"
                productfilter = "villa"
            Case "zonchi.com", "zonchi.co.uk", "clicknstay.co.uk", "finda-holiday.com"
                productfilter = ""
            Case "lodgesandparks.com", "lodgesandparks.co.uk"
                productfilter = "lodge"
            Case "boating4u.co.uk", "boatingoffers.co.uk"
                productfilter = "boat"
            Case "cottageoffers.com", "finda-cottage.co.uk", "finda-cottage.com"
                productfilter = "cottage"
            Case "finda-hotel.net"
                productfilter = "hotel"
            Case "finda-bedandbreakfast.co.uk", "finda-bedandbreakfast.com"
                productfilter = "bb"
            Case "holidayrentalsystems.com", "freebookingcalendar.com"
                productfilter = ""
            Case Else
                productfilter = "villa"
                productfilter = "lodge"
        End Select
    End Function
    Public Function getareacodes() As String
        getareacodes = ""
        Dim loccnt As Integer = 0
        Dim useit As String = HttpContext.Current.Request.QueryString("useit")
        If useit = Nothing Then
            Dim sitecode As String = ""
            sitecode = HttpContext.Current.Request.QueryString("sitecode")
            If sitecode > "" Then
                Dim tempref As String
                Dim a As Array
                tempref = GetRefBySitecode(sitecode, HttpContext.Current.Request.QueryString("productFilter"))
                a = Split(tempref, ",")
                tempref = a(0)
                tempref = Replace(tempref, "'", "")
                useit = getlowestlocationforpropref(tempref, HttpContext.Current.Request.QueryString("productFilter"))
            End If
        End If
        Dim findregion As String = "" & HttpContext.Current.Request.QueryString("SubRegion")
        findregion = Replace(findregion, "_", " ")
        Dim resultslist
        If IsNumeric(useit) Then
            resultslist = GetAllLocations(useit, "", productfilter())
        Else

            If findregion = "" Then
                findregion = HttpContext.Current.Request.QueryString("Region")
                findregion = Replace(findregion, "_", " ")
                If findregion = "" Then
                    findregion = useit
                End If
                resultslist = GetAllLocations(-1, findregion, productfilter())
            Else
                resultslist = GetAllLocations(-1, findregion, productfilter())
                Try
                    If resultslist Is Nothing Then
                        findregion = HttpContext.Current.Request.QueryString("Region")
                        findregion = Replace(findregion, "_", " ")
                        resultslist = GetAllLocations(-1, findregion, productfilter())
                    End If
                Catch ex As Exception
                    findregion = HttpContext.Current.Request.QueryString("Region")
                    findregion = Replace(findregion, "_", " ")
                    resultslist = GetAllLocations(-1, findregion, productfilter())
                End Try
            End If
            If resultslist Is Nothing Then
                findregion = useit
                resultslist = GetAllLocations(-1, findregion, productfilter())
            End If

        End If
        Try
            loccnt = CType(resultslist.childlocations, ICollection).Count()
            For loccnt = 0 To loccnt - 1
                If getareacodes > "" Then
                    getareacodes += ","
                End If
                getareacodes += resultslist.childlocations(loccnt).locationRef.ToString
            Next
        Catch ex As Exception
            getareacodes = Nothing
        End Try

        Try

        Catch ex As Exception

        End Try
    End Function
    Public Function intproductfilter() As Integer
        Select Case productfilter()
            Case "apartment"
                intproductfilter = 1
            Case "boat"
                intproductfilter = 2
            Case "cabin"
                intproductfilter = 3
            Case "castle"
                intproductfilter = 4
            Case "chateau"
                intproductfilter = 5
            Case "cottage"
                intproductfilter = 6
            Case "country house"
                intproductfilter = 7
            Case "farm house"
                intproductfilter = 8
            Case "finca"
                intproductfilter = 9
            Case "gite"
                intproductfilter = 10
            Case "home"
                intproductfilter = 11
            Case "house"
                intproductfilter = 12
            Case "lodge"
                intproductfilter = 13
            Case "penthouse"
                intproductfilter = 14
            Case "room"
                intproductfilter = 15
            Case "ski chalet"
                intproductfilter = 16
            Case "villa"
                intproductfilter = 17
            Case "village house"
                intproductfilter = 18
        End Select
    End Function

    Public Function GetCurrentPageName()
        Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As New System.IO.FileInfo(sPath)
        Dim Filename As String = oInfo.Name.ToString

        Return Filename
    End Function

    Public Sub setNoCahche()
        HttpContext.Current.Response.CacheControl = "no-cache"
        HttpContext.Current.Response.AddHeader("Pragma", "no-cache")
        HttpContext.Current.Response.Expires = -1
    End Sub

    Public Function toHoursMins(ByVal timeToConvert) As String

        'returns minute value timeToConvert as string in hours and minutes

        Dim timeHours, timeMins

        timeHours = Int(timeToConvert / 60)
        timeMins = timeToConvert - (60 * timeHours)

        toHoursMins = timeHours & "hrs " & timeMins & "mins"

    End Function

    Function toAbrevDate(ByVal thisDate, ByVal dayInc) As String

        'returns the supplied date in abbreviated form
        ' if dayInc is true also puts the weekday at the start of the string

        Dim dateString
        dateString = "" 'clear the string
        If dayInc Then
            dateString = WeekdayName(Weekday(thisDate), 1) & ", "
        End If
        dateString = dateString & Day(thisDate) & " " & MonthName(Month(thisDate), 1) & " " & Year(thisDate)
        toAbrevDate = dateString

    End Function

    Function toFullDate(ByVal thisDate, ByVal dayInc) As String

        'returns the supplied date in abbreviated form
        ' if dayInc is true also puts the weekday at the start of the string

        Dim dateString
        dateString = "" 'clear the string
        If dayInc Then
            dateString = WeekdayName(Weekday(thisDate)) & ", "
        End If
        dateString = dateString & Day(thisDate) & " " & MonthName(Month(thisDate)) & " " & Year(thisDate)
        toFullDate = dateString

    End Function

    Function toMonth(ByVal thisMonth) As String

        'returns month name of supplied month

        toMonth = MonthName(thisMonth, 1)

    End Function

    Public Sub textOut(ByVal text, ByVal textDecorStart, ByVal textDecorEnd)

        'outputs text string to output stream as html

        Dim length
        Dim lastPos
        Dim curPos
        Dim nextString

        length = Len(text) 'last char position in string

        If length <= 0 Or text Is Nothing Then
            Exit Sub 'no string to check
        End If

        lastPos = 1
        curPos = 0

        HttpContext.Current.Response.Write(textDecorStart)

        Do While curPos < length
            curPos = InStr(lastPos, text, vbCrLf, vbBinaryCompare)
            If curPos <> lastPos Then 'not a blank line
                If curPos = 0 Then
                    curPos = length 'no more CrLf's
                End If
                nextString = Mid(text, lastPos, curPos - lastPos + 1)
                HttpContext.Current.Response.Write(HttpContext.Current.Server.HtmlEncode(nextString))
                If curPos < (length - 1) Then
                    HttpContext.Current.Response.Write("<br>")
                End If
                curPos = curPos + 2
                lastPos = curPos
            Else 'output blank line
                If curPos < length - 1 Then 'leave out the last CrLf
                    HttpContext.Current.Response.Write("<br>")
                End If
                curPos = curPos + 2
                lastPos = curPos
            End If
        Loop

        HttpContext.Current.Response.Write(textDecorEnd)

    End Sub

    Public Function textToHtml(ByVal text) As String

        'returns the supplied string in HTML code

        Dim length
        Dim lastPos
        Dim curPos
        Dim nextString
        Dim htmlString

        length = Len(text) 'last char position in string
        htmlString = ""
        textToHtml = ""

        If length <= 0 Or text Is Nothing Then
            Exit Function 'no string to check
        End If

        lastPos = 1
        curPos = 0

        Do While curPos < length
            curPos = InStr(lastPos, text, vbCrLf, vbBinaryCompare)
            If curPos <> lastPos Then 'not a blank line
                If curPos = 0 Then
                    curPos = length 'no more CrLf's
                End If
                nextString = Mid(text, lastPos, curPos - lastPos + 1)
                htmlString = htmlString & HttpContext.Current.Server.HtmlEncode(nextString)
                If curPos < (length - 1) Then
                    htmlString = htmlString & "<br>"
                End If
                curPos = curPos + 2
                lastPos = curPos
            Else 'output blank line
                If curPos < length - 1 Then 'leave out the last CrLf
                    htmlString = htmlString & "<br>"
                End If
                curPos = curPos + 2
                lastPos = curPos
            End If
        Loop

        textToHtml = htmlString

    End Function

    Public Function textToTextArea(ByVal startString) As String

        'returns string as javascript code to put it into a text area

        Dim quot
        quot = Chr(34)

        If startString Is Nothing Or startString = "" Then
            textToTextArea = ""
            Exit Function
        End If

        textToTextArea = Replace(startString, quot, quot & " + '" & quot & "' + " & quot)
        textToTextArea = Replace(textToTextArea, vbCrLf, quot & " + String.fromCharCode(13,10) + " & quot)

    End Function
End Class
