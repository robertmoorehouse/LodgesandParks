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
        Dim thisPropRef As String = ""
        Dim SiteCode As String = ""
        Dim keyword As String = ""
        Dim website As String = ""
        Dim productFilter As String = ""
        SiteCode = Request.QueryString("sitecode")
        If SiteCode > "" Then
            Dim a As Array
            Dim tempref As String
            thisPropRef = bll.GetRefBySitecode(SiteCode, Request.QueryString("productFilter"))
            a = Split(thisPropRef, ",")
            tempref = a(0)
            tempref = Replace(tempref, "'", "")
            useLocation = bll.getlowestlocationforpropref(tempref, Request.QueryString("productFilter"))
            website = ""
            productFilter = Request.QueryString("productFilter")
        Else
            useLocation = GetAreaCode()
            thisPropRef = ""
            website = bll.thiswebsite
            productFilter = bll.productfilter
        End If
        keyword = "" & Request.Form("searchwords")
        If keyword = "" Then keyword = "" & Request.QueryString("searchwords")
        If keyword = "" Then keyword = "" & Request.QueryString("keyword")

        If useLocation Is Nothing Then
            If Trim(keyword) = "" Then
                If Request.QueryString("subregion") Is Nothing Then
                    If Request.QueryString("region") Is Nothing Then
                    Else
                        keyword = Request.QueryString("region")
                    End If
                Else
                    keyword = Request.QueryString("subregion")
                End If
            End If
        Else
        End If
        Dim dta
        Response.Write("<!--:" & useLocation & "|" & website & "|" & productFilter & "|" & Trim(keyword) & "|" & thisPropRef & ":-->")
        'Response.End()
        dta = bll.GetSearchResults(useLocation, website, productFilter, Trim(keyword), thisPropRef)
        gvResults.DataSource = dta
        gvResults.DataBind()
        Try
            results.Text = "Your search found  " & CType(dta, ICollection).Count() & " records."
            If CType(dta, ICollection).Count() = 0 Then
                norecords.Visible = True
                maxrecords.Visible = False
                results.Visible = False
            End If
            If CType(dta, ICollection).Count() = 500 Then
                norecords.Visible = False
                maxrecords.Visible = False
                results.Visible = True
                results.Text = "We have only displayed the top 500 records for speed. Please narrow down your search by selecting a sub area."
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
                For Each item As Object In e.Row.DataItem.locations
                    btnLocationLinks = e.Row.FindControl("btnLocationLinks" & mar)
                    LblLocationLinks = e.Row.FindControl("LblLocationLinks" & mar)
                    If mar > 0 Then
                        LblLocationLinks.Visible = True
                    End If
                    doloop = False
                    allLocations = ""
                    For Each subitem As Object In e.Row.DataItem.locations
                        If subitem.LocationRef.ToString > "" Then
                            If subitem.LocationRef.ToString = item.LocationRef.ToString Then doloop = True
                            If doloop Then
                                If allLocations = "" Then
                                    allLocations = subitem.LocationRef.ToString
                                Else
                                    allLocations = subitem.LocationRef.ToString & "," & allLocations
                                End If
                            End If
                        End If
                    Next
                    btnLocationLinks.Text = item.LocationDescription.ToString

                    btnLocationLinks.NavigateUrl = "results.aspx?useit=" & item.LocationRef.ToString '& "&intPage=1&allLocations=" & allLocations
                    btnLocationLinks.Visible = True
                    mar += 1
                Next
                
                'Create thumbnail image
                Dim imgThumb As ImageButton = e.Row.FindControl("imgThumb")
                Dim imgNeeded As String = "noimage_t.jpg"
                mar = 0
                Try
                    imgNeeded = e.Row.DataItem.propimages(0).imageURL.ToString
                    imgThumb.ImageUrl = imgNeeded
                    Dim imgWidth As Integer
                    imgWidth = imgThumb.Width.Value
                    'If imgWidth > 50 Then
                    imgThumb.Width = 116
                    'End If
                Catch ex As Exception
                End Try

                'If e.Row.DataItem.website.ToString = "HH" Then
                'imgThumb.PostBackUrl = "takemethere.aspx?ref=" & e.Row.DataItem.prop_ref.ToString & "&sitecode=&productFilter=HH&land=advert"
                'Else
                imgThumb.PostBackUrl = "propertyDetails.aspx?ref=" & e.Row.DataItem.prop_ref.ToString & "&productFilter=" & e.Row.DataItem.website.ToString
                'End If
                imgThumb.AlternateText = e.Row.DataItem.Title.ToString & " a " & e.Row.DataItem.PropType.ToString & " in " & thisLocation


                Dim hylLink As HyperLink = e.Row.FindControl("hylLink")
                hylLink.NavigateUrl = "propertyDetails.aspx?ref=" & e.Row.DataItem.prop_ref.ToString & "&productFilter=" & e.Row.DataItem.website.ToString

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub searchButton_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles searchButton1.Click
        Session("redo") = "yes"
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            Dim loadingpanel As New Panel
            loadingpanel = CType(Page.Master.FindControl("pnlLoading"), Panel)
            loadingpanel.Visible = False
            loadingpanel = CType(Page.Master.FindControl("pnlLoaded"), Panel)
            loadingpanel.Visible = True
        End If
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not Page.IsPostBack Then
            Dim loadingpanel As New Panel
            loadingpanel = CType(Page.Master.FindControl("pnlLoading"), Panel)
            loadingpanel.Visible = True
            loadingpanel = CType(Page.Master.FindControl("pnlLoaded"), Panel)
            loadingpanel.Visible = False
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

    End Sub
End Class
