Imports bll
Partial Class AdvertisingBanner1
    Inherits System.Web.UI.UserControl

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bll As New bll
        If Not Page.IsPostBack Then
            Dim advertnumber As Integer
            advertnumber = Int((8) * Rnd() + 1)
            lnkBanner.Visible = True
            googlesearch.Visible = False
            Select Case advertnumber
                Case 1  'Holiday Autos
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16784446)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=16988&a=1292087&g=16784446&epi=topban-" & bll.thiswebsite
                Case 3  'AccorHotels
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16707096)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=31820&a=1292087&g=16707096&epi=topban-" & bll.thiswebsite
                Case 5  'Columbus travel insurance
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(185335)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=18211&a=1292087&g=185335&epi=topban-" & bll.thiswebsite
                Case 7  'Flexicover.net travel insurance
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16387182)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=49720&a=1292087&g=16387182&epi=topban-" & bll.thiswebsite
                Case 9  'Go travel insurance
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(11617033)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=3284&a=1292087&g=11617033&epi=topban-" & bll.thiswebsite
                Case 11 'Hertz
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16162022)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=37051&a=1292087&g=16162022&epi=topban-" & bll.thiswebsite
                Case 13 'interrail
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16186356)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=40263&a=1292087&g=16186356&epi=topban-" & bll.thiswebsite
                Case 15 '101cd
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(17046282)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=3289&a=1292087&g=17046282&epi=topban-" & bll.thiswebsite
                Case 2  'jackpot joy
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16952792)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=17183&a=1292087&g=16952792&epi=topban-" & bll.thiswebsite
                Case 4  'which
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16118640)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=27542&a=1292087&g=16118640&epi=topban-" & bll.thiswebsite
                Case 6  'American express travel insurance
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16609650)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=17793&a=1292087&g=16609650&epi=topban-" & bll.thiswebsite
                Case 8  'ASDA
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16388272)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=47933&a=1292087&g=16388272&epi=topban-" & bll.thiswebsite
                Case 10 'World of Linens
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16353594)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=48796&a=1292087&g=16353594&epi=topban-" & bll.thiswebsite
                Case 12 'knickerbox
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16234944)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=44307&a=1292087&g=16234944&epi=topban-" & bll.thiswebsite
                Case 14 'Ann Summers
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16958518)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=37382&a=1292087&g=16958518&epi=topban-" & bll.thiswebsite
                Case Else 'Holiday Autos
                    lnkBanner.ImageUrl = "http://impgb.tradedoubler.com/imp?type(img)g(16784446)a(1292087)"
                    lnkBanner.NavigateUrl = "http://clkuk.tradedoubler.com/click?p=16988&a=1292087&g=16784446&epi=topban-" & bll.thiswebsite
            End Select

            lnkBanner.Text = advertnumber
            lnkBanner.Target = "new"

        End If

    End Sub

End Class
