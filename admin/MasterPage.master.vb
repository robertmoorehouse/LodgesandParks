Imports bll
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        
        Dim cph1 As ContentPlaceHolder = FindControl("ContentPlaceHolder1")
        Dim a As UserControl = cph1.FindControl("Locationdropdowns1")
        Dim controlID As Integer = 0
        Dim subloc As DropDownList
        Dim locationText As String = ""
        Dim incomingValue As String
        Do While controlID < 11
            Try
                subloc = a.FindControl("subLocations" & controlID)
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
        Dim bll As New bll

        'Select Case bll.productfilter
        '    Case "villa"
        '        If locationText > "" Then
        '            Header.Title = "Holiday Villas in " & locationText & " at the best prices."
        '            pageheadertext.Text = "Holiday Villas in " & locationText & " at the best prices."
        '        Else
        '            Header.Title = "Private villas, holiday homes, holiday rentals - online booking made easy at the best price."
        '            pageheadertext.Text = "Lodges, parks, villas, boats and cottages at the best prices"
        '        End If
        '    Case "lodge"
        '        If locationText > "" Then
        '            Header.Title = "Holiday Parks and Lodges in " & locationText & " at the best prices."
        '            pageheadertext.Text = "Holiday Parks and Lodges in " & locationText & " at the best prices."
        '        Else
        '            Header.Title = "Holiday Parks and Lodges - online booking made easy at the best price."
        '            pageheadertext.Text = "Lodges, parks, villas, boats and cottages at the best prices"
        '        End If
        '    Case "boat"
        '        If locationText > "" Then
        '            Header.Title = "Boating Holidays in " & locationText & " at the best prices."
        '            pageheadertext.Text = "Boating Holidays in " & locationText & " at the best prices."
        '        Else
        '            Header.Title = "Boating Holidays  - online booking made easy at the best price."
        '            pageheadertext.Text = "Lodges, parks, villas, boats and cottages at the best prices"
        '        End If
        'End Select
        

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
End Class

