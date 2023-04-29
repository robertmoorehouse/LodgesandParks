<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="propertyPhotos.aspx.vb" Inherits="propertyPhotos" Title="Untitled Page" %>
<%@ Register Src="locationdropdowns.ascx" TagName="locationdropdowns" TagPrefix="uc1" %>
<%@ Register Src="PopularLocations.ascx" TagName="popularlocations" TagPrefix="uc2" %>
<%@ Register Src="PopularSearches.ascx" TagName="PopularSearches" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Choose a Location</span>
        <uc1:locationdropdowns ID="Locationdropdowns1" runat="server"></uc1:locationdropdowns>
    <asp:ImageButton ID="searchButton1" runat="server" PostBackUrl="~/results.aspx" ImageUrl="~/images/search_but_up.gif" />    
    </div>
    <div class="search_input_boxes">
        <uc3:PopularSearches ID="PopularSearches1" runat="server" />
    </div>
    <div class="search_input_boxes">
        <uc2:popularlocations ID="popularlocations2" runat="server"></uc2:popularlocations>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <h2 class="adverts_title_text"><asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
    <!--Start of main advert tab navigation-->
    <div class="content_shell">
        <asp:HyperLink ID="lnkSummary" runat="server" CssClass="advert_first_tabs">Summary</asp:HyperLink>
        <asp:HyperLink ID="lnkFullDetails" runat="server" CssClass="advert_tabs" Visible="false" Target="_blank">Full Details</asp:HyperLink>
        <asp:HyperLink ID="lnkPrice" runat="server" CssClass="advert_tabs">Price & Booking</asp:HyperLink>
        <asp:HyperLink ID="lnkEnquiry" runat="server" CssClass="advert_tabs">Enquiry</asp:HyperLink>
        <asp:HyperLink ID="lnkReviews" runat="server" CssClass="advert_tabs">Reviews</asp:HyperLink>
        <asp:HyperLink ID="lnkMaps" runat="server" CssClass="advert_tabs">Maps</asp:HyperLink>
        <asp:HyperLink ID="lnkPhotos" runat="server" CssClass="advert_tabs_selected">Photos</asp:HyperLink>
        <asp:Label ID="lblownerref" runat="server" Visible="false" />    
    </div>
    <!--End of main advert tab navigation-->
    <div class="adverts_content_shell">
        <div class="adverts_content_full_shell">
            <div class="adverts_content_shell_all">
                <div class="adverts_content_all">
                    <span class="small_text">
                        <div align="center">
                            <asp:Label ID="lblPhotos" runat="server" />
                        </div>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"><!--
google_ad_client = "pub-1202052053654646";
/* 468x60, created 08/04/08 */
google_ad_slot = "5250927716";
google_ad_width = 468;
google_ad_height = 60;
//-->
</script>
<script type="text/javascript"
src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <script type="text/javascript"><!--
        google_ad_client = "pub-1202052053654646";
        //160x600, created 20/11/07
        google_ad_slot = "0976239038";
        google_ad_width = 160;
        google_ad_height = 600;
        //--></script>
    <script type="text/javascript"
        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
</asp:Content>