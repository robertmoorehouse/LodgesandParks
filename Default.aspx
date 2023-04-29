<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="latestreviews.ascx" TagName="latestreviews" TagPrefix="uc4" %>
<%@ Register Src="locationdropdowns.ascx" TagName="locationdropdowns" TagPrefix="uc1" %>
<%@ Register Src="PopularLocations.ascx" TagName="popularlocations" TagPrefix="uc2" %>
<%@ Register Src="PopularSearches.ascx" TagName="PopularSearches" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Choose a Location</span>
        <uc1:locationdropdowns ID="Locationdropdowns1" runat="server"></uc1:locationdropdowns>
        <asp:ImageButton ID="searchButton1" runat="server" PostBackUrl="results.aspx" ImageUrl="images/search_but_up.gif" />
    </div>
    <div class="search_input_boxes">
        <uc3:PopularSearches ID="PopularSearches1" runat="server" />
    </div>
    <div class="search_input_boxes">
        <uc2:popularlocations ID="popularlocations2" runat="server"></uc2:popularlocations>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Panel ID="villatext" runat="server" Visible="false">
        <table cellspacing="2" cellpadding="2" width="95%">
            <tr>
                <td style="background-color: Blue; color: White">
                    &nbsp; <span id="ColHeader1Label">editors pick</span></td>
                <td style="background-color: Blue; color: White">
                    &nbsp; <span id="ColHeader2Label">top value</span></td>
                <td style="background-color: Blue; color: White">
                    &nbsp; <span id="ColHeader3Label">best new property</span></td>
                <td style="background-color: Blue; color: White">
                    &nbsp; <span id="ColHeader4Label">best reviews</span></td>
            </tr>
            <tr>
                <td valign="top">
                    <span id="FeaturedProp1TitleLabel"><a href="propertyDetails.aspx?ref=22107&productFilter=VR"
                        title="Les Trois Epis" target="_top">Les Trois Epis</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp2TitleLabel"><a href="propertyDetails.aspx?ref=2426&productFilter=VR"
                        title="Southern Dunes Golf Club" target="_top">Southern Dunes Golf Club</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp3TitleLabel"><a href="propertyDetails.aspx?ref=32643&productFilter=VR"
                        title="L'Orchid&eacute;e Residences - Villa C5b - Cattleya" target="_top">L'Orchid&eacute;e
                        Residences - Villa C5b - Cattleya</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp4TitleLabel"><a href="propertyDetails.aspx?ref=8650&productFilter=VR"
                        title="YOUR PERFECT HOLIDAY AT GRAN VISTA" target="_top">YOUR PERFECT HOLIDAY AT
                        GRAN VISTA</a> </span>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div>
                        <span id="FeaturedProp1ImageLabel"><a href="propertyDetails.aspx?ref=22107&productFilter=VR"
                            title="Les Trois Epis" target="_top">
                            <img src="http://www.rentalsystems.com/data/images/22107/22107_thm.jpg" alt="Les Trois Epis"
                                title="Les Trois Epis" style="border: none;"/></a> </span>
                    </div>
                </td>
                <td valign="top">
                    <div>
                        <span id="FeaturedProp2ImageLabel"><a href="propertyDetails.aspx?ref=2426&productFilter=VR"
                            title="Southern Dunes Golf Club" target="_top">
                            <img src="http://www.rentalsystems.com/data/images/2426/2426_thm.jpg" alt="Southern Dunes Golf Club"
                                title="Southern Dunes Golf Club" style="border: none;"/></a> </span>
                    </div>
                </td>
                <td valign="top">
                    <div>
                        <span id="FeaturedProp3ImageLabel"><a href="propertyDetails.aspx?ref=32643&productFilter=VR"
                            title="L'Orchid&eacute;e Residences - Villa C5b - Cattleya" target="_top">
                            <img src="http://www.rentalsystems.com/data/images/32643/32643_thm.jpg" alt="L'Orchid&eacute;e Residences - Villa C5b - Cattleya"
                                title="L'Orchid&eacute;e Residences - Villa C5b - Cattleya" style="border: none;"/></a>
                        </span>
                    </div>
                </td>
                <td valign="top">
                    <div>
                        <span id="FeaturedProp4ImageLabel"><a href="propertyDetails.aspx?ref=8650&productFilter=VR"
                            title="YOUR PERFECT HOLIDAY AT GRAN VISTA" target="_top">
                            <img src="http://www.rentalsystems.com/data/images/8650/8650_thm.jpg" alt="YOUR PERFECT HOLIDAY AT GRAN VISTA"
                                title="YOUR PERFECT HOLIDAY AT GRAN VISTA" style="border: none;"/></a> </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <span id="FeaturedProp1DescriptionLabel">Nice, France<br />
                        Ref: 22107<br />
                        Sleeps: 7<br />
                        From E 980 p/w<br />
                    </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp2DescriptionLabel">Haines City, USA<br />
                        Ref: 2426<br />
                        Sleeps: 12<br />
                        From &pound; 450 p/w<br />
                    </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp3DescriptionLabel">Patong Beach, Thailand<br />
                        Ref: 32643<br />
                        Sleeps: 5<br />
                        From $ 3,013 p/w<br />
                    </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp4DescriptionLabel">Gran Alacant / Santa Pola, Spain<br />
                        Ref: 8650<br />
                        Sleeps: 6<br />
                        From &pound; 250 p/w<br />
                    </span>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <span id="FeaturedProp1SummaryLabel">2-bedroom apartment for up to 7 in central Nice
                        - Promenade des Anglais. Terrace with Mediterranean view. Minimum 3 nights stay.
                        Available all year. ... </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp2SummaryLabel">Luxurious 5 bed/3 bath "home from home" in secluded
                        gated community overlooking 18th hole of Championship golf course within 20 minutes
                        of Disney. ... </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp3SummaryLabel">2 bedrooms - 2 bathrooms - 5 sleeps - swimming
                        pool - Sea view - Sunset - Close to the beach, restaurant, near golf courses....
                    </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp4SummaryLabel">A 3 bedroom air conditioned house located in the
                        Gran Vista complex - Gran Alacant. 4 Swimming pools, 2 Tennis courts, 24h internet,
                        etc...... </span>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <span id="FeaturedProp1ViewDetails">
                        <br />
                        <a href="propertyDetails.aspx?ref=22107&productFilter=VR" title="View details for Les Trois Epis"
                            target="_top">View details</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp2ViewDetails">
                        <br />
                        <a href="propertyDetails.aspx?ref=2426&productFilter=VR" title="View details for Southern Dunes Golf Club"
                            target="_top">View details</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp3ViewDetails">
                        <br />
                        <a href="propertyDetails.aspx?ref=32643&productFilter=VR" title="View details for L'Orchid&eacute;e Residences - Villa C5b - Cattleya"
                            target="_top">View details</a> </span>
                </td>
                <td valign="top">
                    <span id="FeaturedProp4ViewDetails">
                        <br />
                        <a href="propertyDetails.aspx?ref=8650&productFilter=VR" title="View details for YOUR PERFECT HOLIDAY AT GRAN VISTA"
                            target="_top">View details</a> </span>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="cottagetext" runat="server" Visible="false">
        <!-- COTTAGES-->
        <div id="cottagesbox" style="width: 433px; margin: 00px 0px 0px 00px; float: left;">
            <!-- COTTAGES HEADER TEXT -->
            <div style="width: 433px; background: url('images/homepage/cottageHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h2>
                    <asp:Label ID="cottageh2" runat="server" CssClass="seo_text" Text="Country Cottages in Britain"></asp:Label></h2>
            </div>
            <div style="width: 431px; background: white; height: 182px; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <!-- COTTAGES IMAGE -->
                <div style="padding: 10px 0px 0px 10px; width: 182px; float: left;">
                    <img src="images/homepage/cottages.gif" alt="Parks And Cottages" />
                </div>
                <!-- COTTAGES TEXT -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 0px; width: 228px; float: left;
                    font-size: 11px;">
                    <strong>Premium</strong> range of holiday cottages<br />
                    <strong>Thatched</strong> country cottages<br />
                    Farmhouses and <strong>barn conversions</strong><br />
                    Countryside and <strong>coastal locations</strong><br />
                    <strong>England, Wales and Scotland</strong><br />
                    Swimming pools. . .<strong> hot tubs</strong>
                    <br />
                    <strong>Romantic</strong> hideaways. .
                </div>
                <!-- COTTAGES LINK -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 10px; width: 195px; float: left;
                    font-style: italic;">
                    <a href="http://www.hoseasons.co.uk/BrochureRequest.aspx?bid=97&aid=CD48&opt=cottagehomepage"
                        target="_blank">Click to receive a Country Cottages brochure</a>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 433px; background: url('images/homepage/cottageHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h3>
                    <asp:Label ID="Label3" runat="server" CssClass="seo_text" Text="Cottages latest reviews"></asp:Label></h3>
            </div>
            <div style="padding: 10px 0px 0px 10px; width: 431px; background: white; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <uc4:latestreviews ID="Latestreviews3" runat="server" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="lodgetext" runat="server" Visible="false">
        <!-- PARKS AND LODGES -->
        <div id="parksbox" style="width: 433px; margin: 00px 0px 0px 00px; float: left;">
            <!-- PARKS AND LODGES HEADER TEXT -->
            <div style="width: 433px; background: url('images/homepage/parksHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h2>
                    <asp:Label ID="lodgeh2" runat="server" CssClass="seo_text" Text="Lodges and Parks in the UK and Channel Islands"></asp:Label></h2>
            </div>
            <div style="width: 431px; background: white; height: 182px; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <!-- PARKS AND LODGES IMAGE -->
                <div style="padding: 10px 0px 0px 10px; width: 182px; float: left;">
                    <img src="images/homepage/parks.gif" alt="Parks And Cottages" />
                </div>
                <!-- PARKS AND LODGES TEXT -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 0px; width: 228px; float: left;
                    font-size: 11px;">
                    Over 360 <strong>self-catering</strong> holiday locations<br />
                    <br />
                    Secluded <strong>forest</strong> and <strong>woodland lodges</strong><br />
                    <strong>Holiday parks</strong> with <strong>indoor pools</strong><br />
                    <strong>Entertainment</strong>and kids clubs<br />
                    <strong>Romantic breaks</strong>and hot tubs<br />
                    <strong>Family</strong> holidays... <strong>short breaks</strong><br />
                    <strong>Pets welcome</strong> at many parks
                </div>
                <!-- PARKS AND LODGES BROCHURE LINK -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 10px; width: 408px; float: left;
                    font-style: italic; clear: both;">
                    <a href="http://www.hoseasons.co.uk/BrochureRequest.aspx?bid=97&aid=CD48&opt=lodgehomepage"
                        target="_blank">Click to receive a Hoseasons Lodges and Parks brochure</a>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 433px; background: url('images/homepage/parksHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h3>
                    <asp:Label ID="Label1" runat="server" CssClass="seo_text" Text="Lodges and Parks latest reviews"></asp:Label></h3>
            </div>
            <div style="padding: 10px 0px 0px 10px; width: 431px; background: white; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <uc4:latestreviews ID="Latestreviews1" runat="server" />
            </div>
            <br />
            <br />
        </div>
    </asp:Panel>
    <asp:Panel ID="boattext" runat="server" Visible="false">
        <!-- BOATING -->
        <div id="boatsbox" style="width: 433px; margin: 00px 0px 0px 00px; float: left;">
            <!-- BOATING  HEADER TEXT -->
            <div style="width: 433px; background: url('images/homepage/boatingHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h2>
                    <asp:Label ID="boath2" runat="server" CssClass="seo_text" Text="Boating Holidays in Britain and Europe"></asp:Label></h2>
            </div>
            <div style="width: 431px; background: white; height: 182px; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <!-- BOATING  IMAGE -->
                <div style="padding: 10px 0px 0px 10px; width: 182px; float: left;">
                    <a href="#" id="hrfShowYearSelector3">
                        <img src="images/homepage/boating.gif" alt="Parks And Cottages" />
                    </a>
                </div>
                <!-- BOATING  TEXT -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 0px; width: 228px; float: left;
                    font-size: 11px;">
                    <strong>Widest choice</strong> of <a href="http://hoseasons.co.uk/AvailabilitySearchboating.aspx?HolidayType=3&bid=97&aid=CD48&opt=boatshomepage"
                        target="_blank">boating holidays</a><br />
                    <strong>UK,</strong> Ireland and Europe<br />
                    <br />
                    Cruisers on the <strong>Norfolk Broads</strong><br />
                    <strong>Narrowboats </strong>on canals and rivers<br />
                    France, Germany, Belgium
                    <br />
                    Holland and Italy<br />
                    <br />
                    An <strong>unforgettable</strong> holiday experience
                    <br />
                </div>
                <!-- BOATING  LINK -->
                <div class="brochureCTA" style="padding: 10px 0px 0px 10px; width: 409px; float: left;
                    font-style: italic; float: none">
                    <a href="http://www.hoseasons.co.uk/BrochureRequest.aspx?bid=97&aid=CD48&opt=boatshomepage"
                        target="_blank">Click to receive a Hoseasons Boating Holidays brochure</a>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 433px; background: url('images/homepage/boatingHeader.gif') no-repeat;
                height: 27px; color: white; font-size: 16px; padding: 10px 0px 0px 15px; font-weight: bold;">
                <h3>
                    <asp:Label ID="Label2" runat="server" CssClass="seo_text" Text="Boating latest reviews"></asp:Label></h3>
            </div>
            <div style="padding: 10px 0px 0px 10px; width: 431px; background: white; border-right: 1px #999 solid;
                border-left: 1px #999 solid; border-bottom: 1px #999 solid;">
                <uc4:latestreviews ID="Latestreviews2" runat="server" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="zonchitext" runat="server" Visible="false">
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Literal ID="sitemaps" runat="server"></asp:Literal>
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
    <script type="text/javascript">
        <!--
        google_ad_client = "pub-1202052053654646";
        //200x200, created 16/11/07
        google_ad_slot = "0726396365";
        google_ad_width = 200;
        google_ad_height = 200;
        //-->
    </script>
    <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
</asp:Content>
