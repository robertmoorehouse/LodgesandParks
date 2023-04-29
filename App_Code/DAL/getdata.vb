Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Imports System.Data
Imports System.Data.SqlClient

Public Class getdata
    Private ExpiryTime As String = System.Configuration.ConfigurationManager.AppSettings("CacheExpiryTime").ToString
    Private AvailabilityExpiryTime As String = System.Configuration.ConfigurationManager.AppSettings("CacheExpiryTimeAvailability").ToString
    Public property_title As String = ""
    Public property_country As String = ""

    Public Function GetSearchResults(ByVal areacode As String, ByVal website As String, ByVal productFilter As String, ByVal keyword As String, Optional ByVal PropRefs As String = "")
        Try
            If IsNothing(Current.Cache.Item("searchResult" & areacode & productFilter & website & PropRefs)) Then
                PropRefs = Replace(PropRefs, "''", "','")
                Dim strXML
                'Dim wsservice As New VR_VillaSearch.villa_search
                'strXML = wsservice.VillaSearchV2("35465G", "", "", 0, areacode, 0, 0, 0, False, 0, 0, 0, 1, 500, False, "", "", 0, 0)
                Dim intPropType As Integer
                Select Case productFilter
                    Case "apartment"
                        intPropType = 1
                    Case "boat"
                        intPropType = 2
                    Case "cabin"
                        intPropType = 3
                    Case "castle"
                        intPropType = 4
                    Case "chateau"
                        intPropType = 5
                    Case "cottage"
                        intPropType = 6
                    Case "country house"
                        intPropType = 7
                    Case "farm house"
                        intPropType = 8
                    Case "finca"
                        intPropType = 9
                    Case "gite"
                        intPropType = 10
                    Case "home"
                        intPropType = 11
                    Case "house"
                        intPropType = 12
                    Case "lodge"
                        intPropType = 13
                    Case "penthouse"
                        intPropType = 14
                    Case "room"
                        intPropType = 15
                    Case "ski chalet"
                        intPropType = 16
                    Case "villa"
                        intPropType = 17
                    Case "village house"
                        intPropType = 18
                    Case Else
                        intPropType = 0
                End Select

                Dim wsgrapple As New WSGrappleUK.zonchiholidays

                Dim attempscnt As Integer = 0
                Do While attempscnt < 10
                    'HttpContext.Current.Response.Write("<!--:|" & "|" & PropRefs & "|" & intPropType & "|" & areacode & "|0|0|0|1|1000|False|||0|" & website & "|" & keyword & ":-->")
                    'HttpContext.Current.Response.End()
                    strXML = wsgrapple.GetSearchResults("", PropRefs, intPropType, areacode, 0, 0, 0, 1, 1000, False, "", "", 0, website, keyword)
                    If strXML Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop

                Try
                    If strXML.Villas Is Nothing Then
                    Else
                        Current.Cache.Add("searchResult" & areacode & productFilter & website & PropRefs, strXML.Villas, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=GetSearchResults&page=DAL")
                End Try
                wsgrapple = Nothing

            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("searchResult" & areacode & productFilter & website & PropRefs)
    End Function

    Public Function GetPropertyReviews(ByVal thisPropRef As String, ByVal prop_country As String, ByVal prop_title As String, ByVal website As String)
        thisPropRef = Replace(thisPropRef, "'", "")
        Try
            validateweb(website, thisPropRef)
            If IsNothing(Current.Cache.Item("thisPropRef" & thisPropRef & "reviews")) Then
                Dim strXMLgrapple
                Dim wsgrapple As New WSGrappleUK.zonchiholidays
                Dim attempscnt As Integer = 0
                Do While attempscnt < 10
                    strXMLgrapple = wsgrapple.GetPropertyReviews(thisPropRef, website)
                    If strXMLgrapple Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop
                Try
                    If strXMLgrapple Is Nothing Then
                    Else
                        Current.Cache.Add("thisPropRef" & thisPropRef & "reviews", strXMLgrapple, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=GetPropertyReviews&page=DAL")
                End Try
                wsgrapple = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("thisPropRef" & thisPropRef & "reviews")
    End Function

    Public Function GetPropertyDetails(ByVal thisPropRef As String, ByVal website As String)
        thisPropRef = Replace(thisPropRef, "'", "")
        Try
            validateweb(website, thisPropRef)
            If IsNothing(Current.Cache.Item("thisPropRef" & thisPropRef & website & "details")) Then

                Dim wsgrapple As New WSGrappleUK.zonchiholidays

                Dim attempscnt As Integer = 0
                Dim strXML
                'Dim wsservice As New VR_VillaSearch.villa_search
                'strXML = wsservice.VillaSearchV2("35465G", "", thisPropRef, 0, "", 0, 0, 0, False, 0, 0, 0, 1, 500, False, "", "", 0, 0)
                Do While attempscnt < 10
                    strXML = wsgrapple.GetALLPropertyDetails(thisPropRef, website)
                    If strXML.Villas Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop
                Try
                    If strXML.Villas Is Nothing Then
                    Else
                        Current.Cache.Add("thisPropRef" & thisPropRef & website & "details", strXML.Villas, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=GetPropertyDetails&page=DAL")
                End Try
                wsgrapple = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("thisPropRef" & thisPropRef & website & "details")
    End Function

    Public Function GetPropertyAvailability(ByVal thisPropRef As String)
        thisPropRef = Replace(thisPropRef, "'", "")
        Try
            'validateweb(website, thisPropRef)
            If IsNothing(Current.Cache.Item("thisPropRef" & thisPropRef & "availability")) Then

                Dim strXML
                Dim wsservice As New VR_VillaSearch.villa_search
                Dim attempscnt As Integer = 0
                Do While attempscnt < 10
                    strXML = wsservice.GetPropertyAvailability(thisPropRef, 1)
                    If strXML Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop
                Try
                    If strXML Is Nothing Then
                    Else
                        Current.Cache.Add("thisPropRef" & thisPropRef & "availability", strXML, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=GetPropertyAvailability&page=DAL")
                End Try
                wsservice = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("thisPropRef" & thisPropRef & "availability")
    End Function
    Public Function GetRefBySitecode(ByVal sitecode As String, ByVal productFilter As String) As String
        Try
            If IsNothing(Current.Cache.Item("sitecode" & sitecode & productFilter)) Then

                Dim wsgrapple As New WSGrappleUK.zonchiholidays
                Dim strXML As String
                Dim attempscnt As Integer = 0
                Do While attempscnt < 10
                    strXML = wsgrapple.GetRefBySitecode(sitecode, productFilter)
                    If strXML Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop
                Try
                    If strXML Is Nothing Then
                    Else
                        Current.Cache.Add("sitecode" & sitecode & productFilter, strXML, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=GetRefBySitecode&page=DAL")
                End Try
                wsgrapple = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("sitecode" & sitecode & productFilter)
    End Function
    Public Function GetLocations(ByVal parentRef As Integer, ByVal thiswebsite As String, ByVal datafilter As String)
        Try
            'If IsNothing(Current.Cache.Item("Locations" & parentRef & thiswebsite & datafilter)) Then

            Dim objSearchService As New WSGrappleUK.zonchiholidays 'SearchService.Search
            Dim objSearchQuery As New WSGrappleUK.ChildLocation '.childLocations

            objSearchQuery = objSearchService.GetLocations(parentRef, thiswebsite, datafilter)
            If objSearchQuery.ChildLocations Is Nothing Then
                'Current.Response.Write("empty")
                'Current.Response.End()
            Else
                Current.Cache.Add("Locations" & parentRef & thiswebsite & datafilter, objSearchQuery, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
            End If
            objSearchService = Nothing
            objSearchQuery = Nothing

            'End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("Locations" & parentRef & thiswebsite & datafilter)
    End Function
    Public Function GetAllLocations(ByVal cat_ref As Integer, ByVal cat_description As String, ByVal productfilter As String)
        Try
            If IsNothing(Current.Cache.Item("Locations" & cat_ref & cat_description & productfilter)) Then

                Dim objSearchService As New WSGrappleUK.zonchiholidays 'SearchService.Search
                Dim objSearchQuery As New WSGrappleUK.ChildLocation '.childLocations

                If cat_ref = -1 Then
                    objSearchQuery = objSearchService.GetAllLocationsfromDescription(cat_description, productfilter)
                Else
                    objSearchQuery = objSearchService.GetAllLocationsfromCatref(cat_ref, productfilter)
                End If

                If objSearchQuery.ChildLocations Is Nothing Then
                Else
                    Current.Cache.Add("Locations" & cat_ref & cat_description & productfilter, objSearchQuery, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                End If
                objSearchService = Nothing
                objSearchQuery = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("Locations" & cat_ref & cat_description & productfilter)
    End Function
    Public Function getlowestlocationforpropref(ByVal prop_ref As String, ByVal productfilter As String)
        Try
            If IsNothing(Current.Cache.Item("propLocation" & prop_ref & productfilter)) Then

                Dim wsgrapple As New WSGrappleUK.zonchiholidays
                Dim strXML As String
                Dim attempscnt As Integer = 0
                Do While attempscnt < 10
                    strXML = wsgrapple.getlowestlocationforpropref(prop_ref, productfilter)
                    If strXML Is Nothing Then
                        attempscnt += 1
                    Else
                        attempscnt = 11
                    End If
                Loop
                Try
                    If strXML Is Nothing Then
                    Else
                        Current.Cache.Add("propLocation" & prop_ref & productfilter, strXML, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)
                    End If
                Catch ex As Exception
                    HttpContext.Current.Response.Redirect("webserviceerror.aspx?errCode=add&errText=getlowestlocationforpropref&page=DAL")
                End Try
                wsgrapple = Nothing
            End If
        Catch ex As Exception
            Dim str As String = ex.ToString
            'Current.Response.Write(str)
            'Current.Response.End()
        End Try
        Return Current.Cache.Item("propLocation" & prop_ref & productfilter)
    End Function
    Public Function SavePropertyReviews(ByVal thisPropRef As String, ByVal first_name As String, ByVal last_name As String, _
        ByVal email_address As String, ByVal booking_ref As String, ByVal val_for_money As Integer, ByVal met_expectations As Integer, _
        ByVal would_rec As Integer, ByVal overall_rating As Integer, ByVal submitted_date As DateTime, ByVal review_text As String, _
        ByVal star_rating As Integer, ByVal town_from As String, ByVal review_approved As String, _
        ByVal prop_country As String, ByVal prop_title As String, ByVal website As String) As String

        Dim saveResult As String
        Dim wsgrapple As New WSGrappleUK.zonchiholidays
        saveResult = wsgrapple.SavePropertyReviews(thisPropRef, first_name, last_name, email_address, booking_ref, val_for_money, met_expectations, _
                            would_rec, overall_rating, FormatDateTime(submitted_date, DateFormat.ShortDate), review_text, _
                            star_rating, town_from, 0, prop_country, prop_title, "gpwssecsave1997", "bx13721", website)
        wsgrapple = Nothing
        Return saveResult
    End Function
    Private Sub validateweb(ByRef website As String, ByRef thisPropRef As String)
        If website Is Nothing Or website = "" Then
            If IsNumeric(thisPropRef) Then
                website = "VR"
            Else
                website = "HH"
            End If
        End If
    End Sub
End Class
