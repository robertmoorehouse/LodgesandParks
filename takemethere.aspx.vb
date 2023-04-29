
Partial Class takemethere
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim whereto As String = "" & Request.QueryString("whereto")
        Dim ref As String = "" & Request.QueryString("ref")
        Dim sitecode As String = "" & Request.QueryString("sitecode")
        Dim productFilter As String = "" & Request.QueryString("productFilter")
        Dim land As String = "" & Request.QueryString("land")


        'example incomming links
        'to change site
        'http://www.cottageoffers.com/takemethere.aspx?whereto=boats

        'to go to villa renters
        'http://www.villacompare.com/takemethere.aspx?ref=22107&productFilter=VR&land=advert

        'to go to hoseasons
        'http://www.lodgesandparks.com/takemethere.aspx?ref=LP1007&sitecode=BULW&productFilter=HH&land=advert
        'http://www.lodgesandparks.com/takemethere.aspx?ref=LP1007&sitecode=BULW&productFilter=HH&land=location

        Select Case whereto
            Case "lodges"
                Response.Redirect("http://www.lodgesandparks.com")
            Case "cottages"
                Response.Redirect("http://www.cottageoffers.com")
            Case "boats"
                Response.Redirect("http://www.boatingoffers.co.uk")
            Case "villas"
                Response.Redirect("http://www.villacompare.com")
            Case "hotels"
                Response.Redirect("http://clkuk.tradedoubler.com/click?p=19300&a=1292087&g=627951&epi=zonchi-" & Session("keyword") & "-" & Now())
            Case "bandb"
                Response.Redirect("http://clkuk.tradedoubler.com/click?p=22535&a=1292087&g=16657960&epi=zonchi-" & Session("keyword") & "-" & Now())
            Case "insurance"
                Response.Redirect("http://clkuk.tradedoubler.com/click?p=3284&a=1292087&g=16342416&epi=zonchi-" & Session("keyword") & "-" & Now())
            Case "attractions"
                Response.Redirect("http://www.cottageoffers.com")
            Case "carhire"
                Response.Redirect("http://clkuk.tradedoubler.com/click?p=16988&a=1292087&g=16784446&epi=zonchi-" & Session("keyword") & "-" & Now())
            Case "flights"
                Response.Redirect("http://clkuk.tradedoubler.com/click?p=4506&a=1292087&g=27442&epi=zonchi-" & Session("keyword") & "-" & Now())
            Case "zonchi"
                Response.Redirect("http://www.zonchi.com")
        End Select

        Select Case productFilter
            Case "HH"
                Select Case land
                    Case "advert"
                        Response.Redirect("http://www.hoseasons.co.uk/productSite.aspx?sitecode=" & sitecode & "&ClassCode=" & ref & "&bid=97&aid=CD48&opt=" & Session("keyword") & "-" & Now())
                    Case "location"
                        Response.Redirect("http://www.hoseasons.co.uk/ProductLocation.aspx?sitecode=" & sitecode & "&ClassCode=" & ref & "&bid=97&aid=CD48&opt=" & Session("keyword") & "-" & Now())
                    Case "photos"
                        Response.Redirect("http://www.hoseasons.co.uk/ProductSite.aspx?sitecode=" & sitecode & "&classcode=" & ref & "&bid=97&aid=CD48&opt=" & Session("keyword") & "-" & Now())
                    Case Else
                        Response.Redirect("http://www.hoseasons.co.uk/productSite.aspx?sitecode=" & sitecode & "&ClassCode=" & ref & "&bid=97&aid=CD48&opt=" & Session("keyword") & "-" & Now())
                End Select
            Case "VR"
                Select Case land
                    Case "join"
                        Response.Redirect("http://www.rentalsystems.com/newowner/join_member.asp?rag=35465G&rcam=" & Session("keyword") & "-" & Now() & "&sag=35465G&sc=" & Session("keyword") & "-" & Now())
                    Case "advert"
                        Response.Redirect("http://www.rentalsystems.com/advert_summary.asp?ref=" & ref & "&rag=35465G&rcam=" & Session("keyword") & "-" & Now() & "&sag=35465G&sc=" & Session("keyword") & "-" & Now())
                    Case Else
                        Response.Redirect("http://www.rentalsystems.com/advert_summary.asp?ref=" & ref & "&rag=35465G&rcam=" & Session("keyword") & "-" & Now() & "&sag=35465G&sc=" & Session("keyword") & "-" & Now())
                End Select
        End Select

        Response.Redirect("/default.aspx")
    End Sub
End Class
