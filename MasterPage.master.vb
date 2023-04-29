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
        Select Case bll.productfilter
            Case "lodge"
                sitemap.NavigateUrl = "holiday-rentals/lodges-parks-caravans.htm"
            Case "villa"
                sitemap.NavigateUrl = "holiday-rentals/holiday-villas.htm"
            Case "boat"
                sitemap.NavigateUrl = "holiday-rentals/holiday-boats.htm"
            Case "cottage"
                sitemap.NavigateUrl = "holiday-rentals/holiday-cottages.htm"
        End Select



        Dim sescnt As Integer = 1

        Try
            sescnt = Session("iframecount")

        Catch ex As Exception
            Session("iframecount") = 1
            sescnt = 1
        End Try


        Dim userbrowser As String = Left(HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT"), 255)

        Try

            If (InStr("Google", userbrowser) > 0) Then
                tandcs.Visible = False
                privacy.Visible = False
                Iframe1.Visible = False
            Else

                Dim todaydate As String
                todaydate = Replace(Now(), "/", "")
                todaydate = Replace(todaydate, ":", "")
                todaydate = Replace(todaydate, " ", "")

                tandcs.Attributes("src") = "http://www.hoseasons.co.uk/AvailabilitySearch4.aspx?HolidayType=1&bid=97&aid=CD48&opt=1stgglppc-" & todaydate & "-" & setqry()
                'sitemap.Text = sescnt
                Select Case sescnt
                    Case 1
                        tandcs.Visible = True
                        privacy.Visible = False
                        Iframe1.Visible = False
                    Case 2
                        tandcs.Visible = False
                        privacy.Visible = True
                        Iframe1.Visible = False
                    Case 3
                        tandcs.Visible = False
                        privacy.Visible = False
                        Iframe1.Visible = True
                    Case 4
                        tandcs.Visible = False
                        privacy.Visible = False
                        Iframe1.Visible = False
                    Case Else
                        tandcs.Visible = True
                        privacy.Visible = False
                        Iframe1.Visible = False
                        sescnt = 0
                End Select
            End If
            sescnt = sescnt + 1
            Session("iframecount") = sescnt
        Catch ex As Exception

        End Try
        

    End Sub
    Public Function todaydate()
        todaydate = Replace(Now(), "/", "")
        todaydate = Replace(todaydate, ":", "")
        todaydate = Replace(todaydate, " ", "")
    End Function
    Public Sub SetP3Pheaders(ByRef Header)

        Dim metaValue As New HtmlMeta
        metaValue.Name = "policyref"
        metaValue.Content = "http://www.grappleuk.com/w3c/p3p.xml"" , CP=""CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"""
        Header.Controls.AddAt(1, metaValue)
        metaValue.Name = "CP"
        metaValue.Content = "CAO DSP COR CURa ADMa DEVa TAIa OUR BUS IND UNI COM NAV INT"
        Header.Controls.AddAt(2, metaValue)

    End Sub
    Public Function setqry()
        Try
            'Dim urlstr As String = ""
            'urlstr = Replace(Request.Url.ToString, "&", "#", 1, -1, 1)
            'urlstr = Replace(urlstr, "?", "#", 1, -1, 1)
            setqry = "" 'urlstr
        Catch ex As Exception
            setqry = "error"
        End Try

    End Function


End Class

