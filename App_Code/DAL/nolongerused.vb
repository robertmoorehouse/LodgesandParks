'Imports Microsoft.VisualBasic
'Imports System.Web.HttpContext
'Imports System.Data
'Imports System.Data.SqlClient
'Public Class nolongerused
'    Public Function GetPropertyReviews(ByVal thisPropRef As Integer, ByVal prop_country As String, ByVal prop_title As String)
'        Try
'            If IsNothing(Current.Cache.Item("thisPropRef" & thisPropRef & "reviews")) Then
'                Dim linkCount As Integer = 0
'                Dim linkCount1 As Integer = 0
'                Dim newrecnum As Integer = 0
'                Dim saveResult As String = ""
'                Dim strXML
'                Dim strXMLgrapple
'                Dim mergedXML
'                Dim saveit As Boolean
'                Dim wsservice As New VR_VillaSearch.villa_search
'                Dim wsgrapple As New WSGrappleUK.zonchiholidays
'                Dim website As String = "finda-villa"
'                strXML = wsservice.GetPropertyReviews(thisPropRef, 1)


'                strXMLgrapple = wsgrapple.GetPropertyReviews(thisPropRef)
'                If strXMLgrapple.reviews.Length = 0 Then
'                    For linkCount = 0 To strXML.reviews.Length - 1
'                        saveResult = wsgrapple.SavePropertyReviews(thisPropRef, strXML.reviews(linkCount).by.ToString, "", "", "", 0, 0, _
'                        0, 0, FormatDateTime(strXML.reviews(linkCount).ReviewDate.ToString, DateFormat.ShortDate), strXML.reviews(linkCount).Article.ToString, _
'                        strXML.reviews(linkCount).StarRating.ToString, strXML.reviews(linkCount).from.ToString, 1, prop_country, prop_title, "gpwssecsave1997", "bx13721", website)
'                    Next
'                    mergedXML = strXML
'                Else
'                    mergedXML = strXMLgrapple
'                    For linkCount = 0 To strXML.reviews.Length - 1
'                        saveit = True
'                        For linkCount1 = 0 To strXMLgrapple.reviews.Length - 1
'                            If (Trim(strXMLgrapple.reviews(linkCount1).by.ToString) = Trim(strXML.reviews(linkCount).by.ToString)) And (Trim(strXMLgrapple.reviews(linkCount1).from.ToString) = Trim(strXML.reviews(linkCount).from.ToString)) Then
'                                saveit = False
'                            End If
'                        Next
'                        If saveit Then
'                            saveResult = wsgrapple.SavePropertyReviews(thisPropRef, strXML.reviews(linkCount).by.ToString, "", "", "", 0, 0, _
'                            0, 0, FormatDateTime(strXML.reviews(linkCount).ReviewDate.ToString, DateFormat.ShortDate), strXML.reviews(linkCount).Article.ToString, _
'                            strXML.reviews(linkCount).StarRating.ToString, strXML.reviews(linkCount).from.ToString, 1, prop_country, prop_title, "gpwssecsave1997", "bx13721", website)
'                            'mergedXML.reviews(newrecnum).by = strXML.reviews(linkCount).by.ToString
'                            'mergedXML.reviews(newrecnum).ReviewDate = FormatDateTime(strXML.reviews(linkCount).ReviewDate.ToString)
'                            'mergedXML.reviews(newrecnum).Article = strXML.reviews(linkCount).Article.ToString
'                            'mergedXML.reviews(newrecnum).StarRating = strXML.reviews(linkCount).StarRating.ToString
'                            'mergedXML.reviews(newrecnum).From = strXML.reviews(linkCount).from.ToString
'                            newrecnum += 1
'                        End If
'                    Next
'                End If

'                If newrecnum > 0 Then
'                    mergedXML = wsgrapple.GetPropertyReviews(thisPropRef)
'                End If

'                Current.Cache.Add("thisPropRef" & thisPropRef & "reviews", mergedXML, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)

'            End If
'        Catch ex As Exception
'            Dim str As String = ex.ToString
'            Current.Response.Write(str)
'            Current.Response.End()
'        End Try
'        Return Current.Cache.Item("thisPropRef" & thisPropRef & "reviews")
'    End Function
'    Public Function GetLocations(ByVal parentRef As Integer)
'        Try
'            If IsNothing(Current.Cache.Item("Locations" & parentRef)) Then

'                Dim objSearchService As New VR_VillaSearch.villa_search  'SearchService.Search
'                Dim objSearchQuery As New VR_VillaSearch.ChildLocation '.childLocations

'                objSearchQuery = objSearchService.GetChildLocations(parentRef, 0)

'                Current.Cache.Add("Locations" & parentRef, objSearchQuery, Nothing, DateTime.Now.AddHours(24), TimeSpan.Zero, CacheItemPriority.Normal, Nothing)

'            End If
'        Catch ex As Exception
'            Dim str As String = ex.ToString
'            Current.Response.Write(str)
'            Current.Response.End()
'        End Try
'        Return Current.Cache.Item("Locations" & parentRef)
'    End Function
'End Class
