<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="propertyEnquiry.aspx.vb" Inherits="propertyEnquiry" Title="Untitled Page" %>
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
        <asp:HyperLink ID="lnkEnquiry" runat="server" CssClass="advert_tabs_selected">Enquiry</asp:HyperLink>
        <asp:HyperLink ID="lnkReviews" runat="server" CssClass="advert_tabs">Reviews</asp:HyperLink>
        <asp:HyperLink ID="lnkMaps" runat="server" CssClass="advert_tabs">Maps</asp:HyperLink>
        <asp:HyperLink ID="lnkPhotos" runat="server" CssClass="advert_tabs">Photos</asp:HyperLink>
        <asp:Label ID="lblownerref" runat="server" Visible="false" />    
    </div>
    <!--End of main advert tab navigation-->
    <asp:Panel ID="Enquire" runat="server">
    <div class="adverts_content_shell">
        <div class="adverts_content_full_shell">
            <div class="adverts_content_shell_all">
                <div class="adverts_content_all">
                    <strong>You need to be a member to raise an enquiry.</strong>
                    <br />
                    <br />
                    <br />
                    To proceed please select one of the following options and click continue.
                    <br />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Selected="True" Value="optNew">I am a new customer</asp:ListItem>
                        <asp:ListItem Selected="False" Value="optReturning"> I am a returning customer and my customer ID Number is:</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:TextBox ID="txtUserID" TextMode="SingleLine" runat="server" />
                    <asp:Label ID="lblWarning" runat="server" ForeColor="red" Text="Please enter your user NUMBER."
                        Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Continue" />
                </div>
            </div>
        </div>
    </div>
    </asp:Panel>
    <asp:Panel ID="HHEnquire" runat="server">
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        You can Enquire about this property by phone
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"><asp:Image ID="Image1" runat="server" ImageUrl="Images/HHenquiry.gif" BorderStyle="None" /></asp:HyperLink>
                        <br />
                        <br />
                       
Our friendly and efficient booking team are ready to help seven days a week. If you want to use our website to search for your holiday and then book by phone, make sure you note down the name and code of your chosen accommodation. When you call, please have your personal reference number ready (shown on the back cover of your brochure if you have one).
<br />Note : We are committed to providing good customer service. To help us in this, some telephone calls are monitored and taped for training and audit purposes.
                        
                        <iframe width="0" height="0" src="http://www.hoseasons.co.uk/termsandconditions.aspx?bid=97&aid=CD48&opt=iframedisplaydetails-enquiry"></iframe>
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
    </asp:Panel>
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