Imports system.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.IO
Imports System.Web.HttpContext

Partial Class Results
    Inherits findavillaparks.ui.basepage.BasePage
    Dim paged As Integer = 0
     
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim keyword As String
        keyword = "" & Request.Form("searchwords")
        If keyword = "" Then keyword = "" & Request.QueryString("searchwords")
        If keyword = "" Then keyword = "" & Request.QueryString("keyword") & " " & Request.QueryString("region") & " " & Request.QueryString("subRegion")
        useLocation = GetAreaCode()
        If useLocation Is Nothing Then
            If keyword = "" Then
                If Request.QueryString("subregion") Is Nothing Then
                    If Request.QueryString("region") Is Nothing Then
                    Else
                        keyword = Request.QueryString("region")
                    End If
                Else
                    keyword = Request.QueryString("subregion")
                End If
            End If
        End If
        Dim dta
        dta = bll.GetSearchResults(useLocation, bll.thiswebsite, bll.productfilter, keyword)
        gvResults.DataSource = dta
        gvResults.DataBind()
        Try
            results.Text = "Your search found  " & CType(dta, ICollection).Count() & " records."
            If CType(dta, ICollection).Count() = 0 Then
                norecords.Visible = True
                maxrecords.Visible = False
                results.Visible = False
            End If
            If CType(dta, ICollection).Count() = 300 Then
                norecords.Visible = False
                maxrecords.Visible = True
                results.Visible = False
            Else
                norecords.Visible = False
                maxrecords.Visible = False
                results.Visible = True
            End If
        Catch ex As Exception
            norecords.Visible = True
            maxrecords.Visible = False
            results.Visible = False
        End Try
        Session("redo") = "no"
    End Sub
    
    Protected Sub gvResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvResults.PageIndexChanging

        If paged = 0 Then
            paged = 1
            gvResults.PageIndex = e.NewPageIndex
            gvResults.DataBind()
        End If

    End Sub

    Protected Sub gvResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvResults.Sorting
        Dim m_datatable As DataTable = gvResults.DataSource
        If m_datatable Is Nothing Then
        Else
            Dim m_dataveiw As New DataView
            m_dataveiw = m_datatable.DefaultView
            m_dataveiw.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection)
            gvResults.DataSource = m_dataveiw
            gvResults.DataBind()
        End If

    End Sub

    Private Function ConvertSortDirectionToSql(ByVal SortDirection As SortDirection) As String

        Dim m_SortDirection As String = ""

        Select Case SortDirection
            Case SortDirection.Ascending
                m_SortDirection = "ASC"
            Case SortDirection.Descending
                m_SortDirection = "DESC"
        End Select

        Return m_SortDirection

    End Function

    Private Function GetAreaCode() As String
        GetAreaCode = ""
        Dim useit As String = ""
        Dim ppc As String = ""
        If Not Page.IsPostBack Then
            useit = Request.QueryString("useit")
            ppc = Request.QueryString("ppc") & Request.QueryString("region") & Request.QueryString("subregion")
        End If
        Try
            If Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0") > "" And useit = "" Then
                Dim controlID As Integer = 0
                Dim incomingValue As String = ""
                Do While controlID < 11
                    incomingValue = Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations" & (controlID))
                    If incomingValue > "" And incomingValue <> "0" Then
                        controlID += 1
                        GetAreaCode = incomingValue
                    ElseIf incomingValue = Nothing Or incomingValue = "0" Then
                        controlID = 13
                    End If
                Loop
            Else
                If (useit > "") Or (ppc > "") Then
                    GetAreaCode = bll.getareacodes
                    If GetAreaCode > "" Then
                        Do While InStr(GetAreaCode, ",") > 0
                            GetAreaCode = Right(GetAreaCode, Len(GetAreaCode) - InStr(GetAreaCode, ","))
                        Loop
                    End If
                End If
            End If
        Catch ex As Exception
            GetAreaCode = ""
        End Try

        Return GetAreaCode

    End Function

    Protected Sub gvResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvResults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then

            End If

            If e.Row.RowType = DataControlRowType.Footer Then

            End If

            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim mar As Integer = 0

                ' create the links for changing the search
                Dim btnLocationLinks As HyperLink
                Dim LblLocationLinks As Label
                Dim LocList = ""
                Dim thisLocation As String = ""
                Dim allLocations As String = ""
                Dim doloop As Boolean = False
                Dim newFilename As String = ""
                For Each item As Object In e.Row.DataItem.locations
                    btnLocationLinks = e.Row.FindControl("btnLocationLinks" & mar)
                    LblLocationLinks = e.Row.FindControl("LblLocationLinks" & mar)
                    If mar > 0 Then
                        LblLocationLinks.Visible = True
                    End If
                    doloop = False
                    allLocations = ""
                    
                    btnLocationLinks.Text = item.LocationDescription.ToString
                    thisLocation = item.LocationDescription.ToString
                    newFilename = Trim(LCase(Regex.Replace(Regex.Replace(Regex.Replace(item.LocationDescription.ToString, "/", "-"), " ", "-"), ",", "-")))
                    Select Case bll.productfilter
                        Case "lodge"
                            newFilename = "/holiday-rentals/lodges-parks-caravans-for-rent-" & newFilename & "/lodges-parks-caravans.htm"
                        Case "villa"
                            newFilename = "/holiday-rentals/villas-for-rent-" & newFilename & "/holiday-villas.htm"
                        Case "boat"
                            newFilename = "/holiday-rentals/boats-for-rent-" & newFilename & "/holiday-boats.htm"
                        Case "cottage"
                            newFilename = "/holiday-rentals/cottages-for-rent-" & newFilename & "/holiday-cottages.htm"
                    End Select
                    btnLocationLinks.NavigateUrl = newFilename
                    btnLocationLinks.Visible = True
                    mar += 1
                Next
                
                'Create thumbnail image
                Dim imgThumb As Image = e.Row.FindControl("imgThumb")
                Dim imgNeeded As String = "noimage_t.jpg"
                mar = 0
                Try
                    imgNeeded = e.Row.DataItem.propimages(0).imageURL.ToString
                    imgThumb.ImageUrl = imgNeeded
                Catch ex As Exception
                End Try

                newFilename = Trim(LCase(Regex.Replace(Regex.Replace(Regex.Replace(thisLocation, "/", "-"), " ", "-"), ",", "-")))
                Select Case bll.productfilter
                    Case "lodge"
                        newFilename = "/holiday-rentals/lodges-parks-caravans-for-rent-" & newFilename
                    Case "villa"
                        newFilename = "/holiday-rentals/villas-for-rent-" & newFilename
                    Case "boat"
                        newFilename = "/holiday-rentals/boats-for-rent-" & newFilename
                    Case "cottage"
                        newFilename = "/holiday-rentals/cottages-for-rent-" & newFilename
                End Select

                imgThumb.AlternateText = e.Row.DataItem.Title.ToString & " a " & e.Row.DataItem.PropType.ToString & " in " & thisLocation
                imgThumb.Width = 116
                
                Dim hylLink As HyperLink = e.Row.FindControl("hylLink")
                hylLink.NavigateUrl = "/propertyDetails.aspx?ref=" & e.Row.DataItem.prop_ref.ToString & "&productFilter=" & e.Row.DataItem.website.ToString
                
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub searchButton_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles searchButton1.Click
        Session("redo") = "yes"
    End Sub
End Class
