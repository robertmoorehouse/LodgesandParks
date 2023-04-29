Imports system.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports bll
Partial Class locationdropdowns
    Inherits System.Web.UI.UserControl
    Public bll As New bll

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim useit As String = ""
        Dim ppc As String = ""
        Dim ref As String = ""
        Dim sitecode As String = ""

        If Not Page.IsPostBack Then
            ref = Request.QueryString("ref")
            sitecode = Request.QueryString("sitecode")
            If sitecode > "" Then
                Dim tempref As String
                Dim a As Array
                tempref = bll.GetRefBySitecode(sitecode, Request.QueryString("productFilter"))
                a = Split(tempref, ",")
                tempref = a(0)
                tempref = Replace(tempref, "'", "")
                useit = bll.getlowestlocationforpropref(tempref, Request.QueryString("productFilter"))
            Else
                useit = Request.QueryString("useit")
                ppc = Request.QueryString("ppc") & Request.QueryString("region") & Request.QueryString("subregion")
            End If

        End If

        If Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0") > "" And useit = "" Then
            Dim controlID As Integer = 0
            Dim locationCount As Integer = 0
            Dim incomingValue As String = ""

            processSubLocations(0, -1)
            subLocations0.SelectedValue = Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0")
            Dim counter As Integer = 0
            Do While controlID < 11
                incomingValue = Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations" & (controlID))
                Try
                    If incomingValue > "" And incomingValue <> "0" Then
                        processSubLocations(incomingValue, controlID)
                        controlID += 1

                        Select Case controlID - 1
                            Case 0
                                subLocations0.SelectedValue = Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0")
                            Case 1
                                subLocations1.SelectedValue = incomingValue
                            Case 2
                                subLocations2.SelectedValue = incomingValue
                            Case 3
                                subLocations3.SelectedValue = incomingValue
                            Case 4
                                subLocations4.SelectedValue = incomingValue
                            Case 5
                                subLocations5.SelectedValue = incomingValue
                            Case 6
                                subLocations6.SelectedValue = incomingValue
                            Case 7
                                subLocations7.SelectedValue = incomingValue
                            Case 8
                                subLocations8.SelectedValue = incomingValue
                            Case 9
                                subLocations9.SelectedValue = incomingValue
                            Case 10
                                subLocations10.SelectedValue = incomingValue
                        End Select
                        lblCatRef.Text = incomingValue
                        If Request.QueryString("useit") = incomingValue Then controlID = 13
                    ElseIf incomingValue = Nothing Or incomingValue = "0" Then
                        controlID = 13
                    End If
                    counter += 1
                Catch ex As Exception

                End Try


            Loop
            For counter = counter + 1 To 10
                Select Case counter
                    Case 1
                        subLocations1.Visible = False
                    Case 2
                        subLocations2.Visible = False
                    Case 3
                        subLocations3.Visible = False
                    Case 4
                        subLocations4.Visible = False
                    Case 5
                        subLocations5.Visible = False
                    Case 6
                        subLocations6.Visible = False
                    Case 7
                        subLocations7.Visible = False
                    Case 8
                        subLocations8.Visible = False
                    Case 9
                        subLocations9.Visible = False
                    Case 10
                        subLocations10.Visible = False
                End Select
            Next
        Else
            If useit > "" Then
                processDeeplink(Request.QueryString("useit"))
            ElseIf ppc > "" Then
                processDeeplink("ppc")
            Else
                processSubLocations(0, -1)
            End If
        End If

        If ref > "" Then
            Dim thisPropRef As String = Request.QueryString("ref")
            Dim website As String = Request.QueryString("filter")
            Dim objUse = bll.GetPropertyDetails(thisPropRef, Request.QueryString("productFilter"))
            Dim cnt As Integer = 0
            Dim nextDDL As DropDownList
            processSubLocations(0, -1)
            For Each item As Object In objUse(0).Locations
                callpopulateDeeplinkedLocations(item.locationref.ToString, (cnt))
                nextDDL = FindControl("subLocations" & cnt)
                Try
                    nextDDL.SelectedValue = item.locationref.ToString
                Catch ex As Exception
                End Try
                cnt += 1
            Next

        End If


        'Else
        '    If Request.QueryString("useit") > "" Then
        '        processDeeplink(Request.QueryString("useit"))
        '    ElseIf (Request.QueryString("ppc") > "") Or (Request.QueryString("region") > "") Or (Request.QueryString("subregion") > "") Then
        '        processDeeplink("ppc")
        '    End If
        'End If

        If Left(HttpContext.Current.Request.ServerVariables("SCRIPT_NAME"), 9) <> "/property" Then
            SetPageHeaders()
        End If
    End Sub
    Public Sub SetPageHeaders()

        Dim controlID As Integer = 0
        Dim subloc As DropDownList
        Dim locationText As String = ""
        Dim incomingValue As String
        Do While controlID < 11
            Try
                subloc = FindControl("subLocations" & controlID)
                If subloc.SelectedValue > 0 Then
                    If controlID > 0 Then
                        locationText &= " > "
                    End If
                    locationText &= subloc.SelectedItem.ToString
                Else
                    incomingValue = Request("ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations" & (controlID))
                End If
            Catch ex As Exception
                controlID = 13
            End Try
            controlID += 1
        Loop
        Dim Header As HtmlHead = CType(Page.Master.FindControl("Head1"), HtmlHead)
        SetP3Pheaders(Header)
        Dim pageheadertext As Literal
        pageheadertext = CType(Page.Master.FindControl("pageheadertext"), Literal)

        Select Case bll.productfilter
            Case "villa"
                If locationText > "" Then
                    Header.Title = "Holiday Villas in " & locationText & " at the best prices."
                    pageheadertext.Text = Request.QueryString("keyword") & " Holiday Villas in " & locationText & " at the best prices."
                Else
                    Header.Title = "holiday villas, homes, rentals - online booking made easy at the best price."
                    pageheadertext.Text = Request.QueryString("keyword") & " holiday Lodges, holiday parks, holiday villas, holiday boats and holiday cottages at the best prices"
                End If
            Case "lodge"
                If locationText > "" Then
                    Header.Title = "Holiday Parks, Lodges and caravan parks in " & locationText & " at the best prices."
                    pageheadertext.Text = Request.QueryString("keyword") & " Holiday Parks, Lodges and caravan parks in " & locationText & " at the best prices."
                Else
                    Header.Title = "Holiday Parks, Lodges and caravan parks online booking made easy at the best price"
                    pageheadertext.Text = Request.QueryString("keyword") & " Holiday Parks, Lodges and caravan parks at the best prices"
                End If
            Case "cottage"
                If locationText > "" Then
                    Header.Title = "Holiday Cottages in " & locationText & " at the best prices."
                    pageheadertext.Text = Request.QueryString("keyword") & " Holiday Cottages in " & locationText & " at the best prices."
                Else
                    Header.Title = "Holiday Cottages - online booking made easy at the best price."
                    pageheadertext.Text = Request.QueryString("keyword") & " holiday cottages at the best prices"
                End If
            Case "boat"
                If locationText > "" Then
                    Header.Title = "Boating Holidays in " & locationText & " at the best prices."
                    pageheadertext.Text = Request.QueryString("keyword") & " Boating Holidays in " & locationText & " at the best prices."
                Else
                    Header.Title = "Boating Holidays  - online booking made easy at the best price."
                    pageheadertext.Text = Request.QueryString("keyword") & " holiday Lodges, holiday parks, holiday villas, holiday boats and holiday cottages at the best prices"
                End If
        End Select
        
    End Sub
    Public Sub SetP3Pheaders(ByRef Header)

        Dim metaValue As New HtmlMeta
        metaValue.Name = "policyref"
        metaValue.Content = "http://www.rentalsystems.com/w3c/p3p.xml"" , CP=""CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"""
        Header.Controls.AddAt(1, metaValue)
        metaValue.Name = "CP"
        metaValue.Content = "CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"
        Header.Controls.AddAt(2, metaValue)

    End Sub
    Public Sub processDeeplink(ByVal useit As String)
        'www.lodgesandparks.co.uk/results.aspx?HolidayType=UKParks&Region=Scotland&SubRegion=Dunfries-Shire&ppc=Adwords&keyword=aqua+park+Dunfries-Shire
        Dim alllocationstring As String = bll.getareacodes

        Dim alllocations As Array = Split(alllocationstring, ",")
        Dim cnt As Integer = 0
        Dim tplev As Integer = alllocations.Length
        processSubLocations(0, -1)
        Dim nextDDL As DropDownList
        try
		For cnt = 0 To tplev - 1
            	callpopulateDeeplinkedLocations(alllocations(cnt).ToString, (cnt))
        	Next
        	For cnt = 0 To tplev - 1
       		nextDDL = FindControl("subLocations" & cnt)
            	Try
                	nextDDL.SelectedValue = alllocations(cnt).ToString
            	Catch ex As Exception

            	End Try
        	Next
	catch
end try
    End Sub

    Public Sub callpopulateLocations(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim addValue As Integer = 0

        If sender.SelectedItem.Value > 0 Then

            processSubLocations(sender.SelectedItem.Value, Right(sender.ID, 1))
            addValue = 2

        Else

            addValue = 1
            lblCatRef.Text = 0

        End If

        Dim controlCount As Integer = 0

        Dim nextDDL As DropDownList
        Dim i As Integer

        For i = (Right(sender.ID, 1) + addValue) To 8

            nextDDL = FindControl("subLocations" & i)
            nextDDL.Visible = False

        Next

    End Sub
    Public Sub callpopulateDeeplinkedLocations(ByVal parentRef As Integer, ByVal controlID As Integer)

        Dim addValue As Integer = 0

        processSubLocations(parentRef, controlID)
        addValue = 2

        Dim controlCount As Integer = 0

        Dim nextDDL As DropDownList
        Dim i As Integer

        For i = (controlID + addValue) To 8

            nextDDL = FindControl("subLocations" & i)
            nextDDL.Visible = False

        Next

    End Sub

    Public Sub processSubLocations(ByVal parentRef As Integer, ByVal controlID As Integer)

        lblCatRef.Text = parentRef

        Dim thisDDL As New DropDownList
        thisDDL = DirectCast(FindControl("subLocations" & (controlID + 1)), DropDownList)
        thisDDL.Items.Clear()

        lblDropDown.Text = (controlID + 1)

        Dim objSearchQuery = bll.GetLocations(parentRef, bll.thiswebsite, bll.productfilter)
        'Response.Write(parentRef & ":" & bll.thiswebsite & ":" & bll.productfilter)
        Dim locationCount As Integer = 0

        Dim newListItemb As New ListItem()
        newListItemb.Text = "All locations..."
        newListItemb.Value = 0
        thisDDL.Items.Insert(0, newListItemb)
        Try
            For locationCount = 0 To objSearchQuery.ChildLocations.Length - 1

                Dim newListItem As New ListItem()
                newListItem.Text = objSearchQuery.ChildLocations(locationCount).LocationDescription
                newListItem.Value = objSearchQuery.ChildLocations(locationCount).LocationRef
                thisDDL.Items.Insert((locationCount + 1), newListItem)

            Next
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try


        If locationCount > 0 Then
            If Not Page.IsPostBack Then thisDDL.SelectedValue = parentRef
            thisDDL.Visible = True

        End If

    End Sub


End Class

