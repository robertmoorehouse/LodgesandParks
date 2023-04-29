Imports bll
Partial Class sitemapMasterPage
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

