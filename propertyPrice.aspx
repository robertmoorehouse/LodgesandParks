<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="propertyPrice.aspx.vb" Inherits="propertyPrice" Title="Untitled Page" %>
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
        <asp:HyperLink ID="lnkPrice" runat="server" CssClass="advert_tabs_selected">Price & Booking</asp:HyperLink>
        <asp:HyperLink ID="lnkEnquiry" runat="server" CssClass="advert_tabs">Enquiry</asp:HyperLink>
        <asp:HyperLink ID="lnkReviews" runat="server" CssClass="advert_tabs">Reviews</asp:HyperLink>
        <asp:HyperLink ID="lnkMaps" runat="server" CssClass="advert_tabs">Maps</asp:HyperLink>
        <asp:HyperLink ID="lnkPhotos" runat="server" CssClass="advert_tabs">Photos</asp:HyperLink>
        <asp:Label ID="lblownerref" runat="server" Visible="false" />    
    </div>
    <!--End of main advert tab navigation-->
    <asp:Panel ID="prices" runat="server">
        <div class="adverts_content_shell">
            <div class="adverts_content_full_shell">
                <div class="adverts_content_shell_all">
                    <div class="adverts_content_all">
                        <table width="550" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="0" align="center" class="arial12">
                                        <tr>
                                            <td width="30%" class="arial8BlackBold">
                                                From</td>
                                            <td width="31%" class="arial8BlackBold">
                                                To</td>
                                            <td rowspan="2" align="right">
                                                <table border="0" cellpadding="0" cellspacing="0" class="arial8Black">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span class="arial8BlackBold">People</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="5" class="arial8Black">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <asp:DropDownList ID="extra_people" runat="server">
                                                                            <asp:ListItem Text="1" Value="1" Selected="True" />
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="right" valign="top">
                                                                        <asp:Button ID="complete" runat="server" Text="BOOK" CausesValidation="true" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="day1" runat="server">
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="month1" runat="server">
                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                    <asp:ListItem Value="09">Sep</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="year1" runat="server">
                                                    <asp:ListItem Value="2007">07</asp:ListItem>
                                                    <asp:ListItem Value="2008">08</asp:ListItem>
                                                    <asp:ListItem Value="2009">09</asp:ListItem>
                                                    <asp:ListItem Value="2010">10</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="day2" runat="server">
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="month2" runat="server">
                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                    <asp:ListItem Value="09">Sep</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="year2" runat="server">
                                                    <asp:ListItem Value="2007">07</asp:ListItem>
                                                    <asp:ListItem Value="2008">08</asp:ListItem>
                                                    <asp:ListItem Value="2009">09</asp:ListItem>
                                                    <asp:ListItem Value="2010">10</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="warning" ForeColor="red" runat="server" Text="Label" Visible="false"></asp:Label><asp:TextBox
                                                    ID="datetodo" runat="server" Style="visibility: hidden" Text="date1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="arial8Black">
                                                <table border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="arial8Black">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left" valign="top">
                                                            <asp:TextBox ID="date1" runat="server" Style="visibility: hidden"></asp:TextBox>
                                                            <asp:TextBox ID="date2" runat="server" Style="visibility: hidden"></asp:TextBox>
                                                            <input type="hidden" name="day" />
                                                            <input type="hidden" name="req1" />
                                                            <input type="hidden" name="req2" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left" valign="top" class="arial8Black">
                                                            If you have a special discount code enter here:
                                                            <asp:TextBox ID="dscode" runat="server" Width="50" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="84%" class="arial8Black">
                                                            <div align="center">
                                                                <br>
                                                                <img src='images/newcalendar/calhtml/red.gif' alt="Booked (red)" width="15" height="15"
                                                                    align="absmiddle" />
                                                                Booked / not available
                                                                <img src='images/newcalendar/calhtml/green.gif' alt="Available (green)" width="15"
                                                                    height="15" align="absmiddle" />
                                                                Available
                                                            </div>
                                                        </td>
                                                        <td width="16%" class="arial8Black">
                                                            <div align="center">
                                                                <strong>weekly price indicator
                                                                    <br />
                                                                    <asp:Literal ID="cal_curr" runat="server"></asp:Literal>
                                                                    <asp:TextBox ID="temp_price" runat="server" CssClass="hiddenprice" size="5" />
                                                                </strong>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="1" cellspacing="0" bgcolor="#FFFFFF" align="center">
                                        <tr valign="top">
                                            <td valign="top">
                                                <asp:Repeater ID="rpCalendars" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Literal ID="calendarData1" runat="server"></asp:Literal>
                                                        <asp:Literal ID="calendarData2" runat="server"></asp:Literal>
                                                        <asp:Literal ID="calendarData3" runat="server"></asp:Literal>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
    function temp_prices(pval)
    {
	    var temp_price = document.getElementById('<%= temp_price.clientID %>');
        temp_price.value = pval;
    }


    function pickdate( pdate, d1, m1, y1, change_day, first_day, jtext)
    {
        // firstly check to see if the start date is a preferred start day.. if not alert user
        var day1 = document.getElementById('<%= day1.clientID %>');
        var month1 = document.getElementById('<%= month1.clientID %>');
        var year1 = document.getElementById('<%= year1.clientID %>');
        var day2 = document.getElementById('<%= day2.clientID %>');
        var month2 = document.getElementById('<%= month2.clientID %>');
        var year2 = document.getElementById('<%= year2.clientID %>');
        var date1 = document.getElementById('<%= date1.clientID %>');
        var date2 = document.getElementById('<%= date2.clientID %>');
        var datetodo = document.getElementById('<%= datetodo.clientID %>');
        
        if (datetodo.value == 'date1')
        {
            date1.value = y1 + "/" + m1 +"/" + d1;
            day1.selectedIndex = parseInt(d1) -1;
            month1.selectedIndex = parseInt(m1) - 1;
            year1.selectedIndex = parseInt(y1) - 2008;
            datetodo.value = "date2"
        }
        else 
        {
            date2.value = y1 + "/" + m1 +"/" + d1;
            day2.selectedIndex = parseInt(d1) -1;
            month2.selectedIndex = parseInt(m1) - 1;
            year2.selectedIndex = parseInt(y1) - 2008;
            datetodo.value = "date1"
        }
    }
function IMG1_onclick() {

}

        </script>
    </asp:Panel>
    <asp:Panel ID="HHprices" runat="server">
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