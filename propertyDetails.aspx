<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="propertyDetails.aspx.vb" Inherits="propertyDetails" Title="Untitled Page" %>
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
        <asp:HyperLink ID="lnkSummary" runat="server" CssClass="advert_first_tabs_selected">Summary</asp:HyperLink>
        <asp:HyperLink ID="lnkFullDetails" runat="server" CssClass="advert_tabs" Visible="false" Target="_blank">Full Details</asp:HyperLink>
        <asp:HyperLink ID="lnkPrice" runat="server" CssClass="advert_tabs">Price & Booking</asp:HyperLink>
        <asp:HyperLink ID="lnkEnquiry" runat="server" CssClass="advert_tabs">Enquiry</asp:HyperLink>
        <asp:HyperLink ID="lnkReviews" runat="server" CssClass="advert_tabs">Reviews</asp:HyperLink>
        <asp:HyperLink ID="lnkMaps" runat="server" CssClass="advert_tabs">Maps</asp:HyperLink>
        <asp:HyperLink ID="lnkPhotos" runat="server" CssClass="advert_tabs">Photos</asp:HyperLink>
        <asp:Label ID="lblownerref" runat="server" Visible="false" />    
    </div>
    <!--End of main advert tab navigation-->
    <div class="adverts_content_shell">
        <div class="adverts_content_left_shell">
            <div class="adverts_content_half_shell_flash">
                <div id="flashcontent">
                    <br />
                    <asp:HyperLink ID="lnkPhotos1" runat="server" Text="click here for more photos" Font-Bold="true" />
                    <br />
                    <img alt="" src="" />
                    <asp:Image ID="imgPhotos" runat="server" />
                    <br />
                    <asp:Image ID="imgFlash" runat="server" />
                    Want a Flash Slideshow instead ?<br />
                    <a href="http://download.macromedia.com/pub/shockwave/flash/english/win95nt/7.0.14.0/flashplayer7installer.exe"
                        onclick="window.open(this.href); return false;">Click here to update your player</a>
                    <br />

                    <script type="text/javascript">
                    // <![CDATA[
                    var fo = new FlashObject("SlideShow/Slideshow.swf", "Slides", "265", "252", "7", "");		
                    fo.addVariable("Path", "<%= SlideshowPath %>");
                    fo.addVariable("flashExtra", "none");
                    fo.write("flashcontent");

                    // ]]>
                    </script>

                </div>
            </div>
        </div>
        <div class="adverts_content_right_shell">
            <div class="adverts_content_half_shell_data">
                <div class="adverts_content_right">
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">Town :</span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblTown" runat="server" />
                            </span>
                        </div>
                    </div>
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">Country :</span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblCountry" runat="server" />
                            </span>
                        </div>
                    </div>
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">
                                <asp:literal ID="lblSleepsTitle" runat="server" />
                            </span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblSleeps" runat="server" />
                            </span>
                        </div>
                    </div>
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">Currency :</span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblCurrency" runat="server" /></span>
                        </div>
                    </div>
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">Prices from :</span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblPriceRange" runat="server" /></span>
                        </div>
                    </div>
                    <div class="adverts_data_shell">
                        <div class="adverts_data_label">
                            <span class="small_text_bold">Accommodation :</span>
                        </div>
                        <div class="adverts_data_output">
                            <span class="small_text">
                                <asp:literal ID="lblAccommodation" runat="server" />
                            </span>
                        </div>
                    </div>
                    <asp:Panel ID="pnlRating" runat="server" Visible="false">
                        <div class="adverts_data_shell">
                            <div class="adverts_data_label">
                                <span class="small_text_bold">Rating :</span>
                            </div>
                            <div class="adverts_data_output">
                                <asp:Image ID="imgRating" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                    <span class="small_text">
                        <asp:Label ID="lblreview" runat="server" />
                        <asp:Image ID="reviewimg" runat="server" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div class="adverts_content_box">
        <div class="adverts_content_subheading_bar">
            <h3 class="adverts_heading_title">
                <span class="sub_title_text_bold_white">
                    <asp:Label ID="lblDescriptionTitle" runat="server" />
                </span>
            </h3>
        </div>
    </div>
    <div class="adverts_content_shell">
        <div class="adverts_content_full_shell">
            <div class="adverts_content_shell_all">
                <div class="adverts_content_all">
                    <span class="small_text">
                        <asp:Label ID="lblDescription" runat="server" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <!-- begin facilities -->
    <asp:Panel ID="FacilitiesPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="lblFacilitiesTitle" runat="server" />
                    </span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <asp:Label ID="lblFacilitieshead" runat="server" Text="(Times are in minutes to drive)" CssClass="small_text" />
                    </div>
                    <asp:Label ID="lblFacilities" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end facilities -->
    <!-- begin property summary -->
    <asp:Panel ID="PropSummaryPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="PropSummaryTitleLabel" runat="server" />
                    </span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="PropSummaryTextLabel" runat="server" />
                            <asp:Label ID="PropSummaryText2Label" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end property summary -->
    <!-- begin outside property info -->
    <asp:Panel ID="OutsidePanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="OutsideTitleLabel" runat="server" />
                    </span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="OutsideTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end outside property info -->
    <!-- begin key locations info -->
    <asp:Panel ID="KeyLocationsPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="KeyLocationsTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="KeyLocationsTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end key locations info -->
    <!-- begin reviews -->
    <asp:Panel ID="ReviewsPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="ReviewsTitleLabel" runat="server" />
                    </span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="ReviewsTextLabel" runat="server" /></span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end reviews -->
    <!-- begin discounts info -->
    <asp:Panel ID="DiscountsPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="DiscountTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="DiscountTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end discounts info -->
    <!-- begin extras info -->
    <asp:Panel ID="ExtrasPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="ExtrasTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="ExtrasTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end extras info -->
    <!-- the following panels belong to b&b properties -->
    <!-- begin guest amenities -->
    <asp:Panel ID="GuestAmenitiesPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="GuestAmenitiesTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="GuestAmenitiesTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end guest amenities -->
    <!-- begin guest amenities -->
    <asp:Panel ID="LocalAreaPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="LocalAreaTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="LocalAreaTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end guest amenities -->
    <!-- begin guest amenities -->
    <asp:Panel ID="RestaurantPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="RestaurantTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="RestaurantTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end guest amenities -->
    <!-- begin directions -->
    <asp:Panel ID="DirectionsPanel" runat="server" Visible="false">
        <div class="adverts_content_box_2">
            <div class="adverts_content_subheading_bar">
                <h3 class="adverts_heading_title">
                    <span class="sub_title_text_bold_white">
                        <asp:Label ID="DirectionsTitleLabel" runat="server" /></span>
                </h3>
            </div>
        </div>
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <span class="small_text">
                            <asp:Label ID="DirectionsTextLabel" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- end directions -->
    <!-- end panels which belong to b and b properties -->
    <asp:Label ID="lblPropRef" runat="server" Visible="false" />
    <asp:Label ID="propReftxt" runat="server" Visible="false" />
    <asp:Label ID="dStartDate" runat="server" Visible="false" />
    <asp:Label ID="dEndDate" runat="server" Visible="false" />
    <asp:Label ID="nNights" runat="server" Visible="false" />
    <asp:Label ID="sCurrencyVar" runat="server" Visible="false" />
    <asp:Label ID="propNameVar" runat="server" Visible="false" />
    <asp:Label ID="sLat" runat="server" Visible="false" />
    <asp:Label ID="sLon" runat="server" Visible="false" />
    <asp:Label ID="nSleeps" runat="server" Visible="false" />
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