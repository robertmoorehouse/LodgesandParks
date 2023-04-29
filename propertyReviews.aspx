<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="propertyReviews.aspx.vb" Inherits="propertyReviews" Title="Untitled Page" %>
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
        <asp:HyperLink ID="lnkReviews" runat="server" CssClass="advert_tabs_selected">Reviews</asp:HyperLink>
        <asp:HyperLink ID="lnkMaps" runat="server" CssClass="advert_tabs">Maps</asp:HyperLink>
        <asp:HyperLink ID="lnkPhotos" runat="server" CssClass="advert_tabs">Photos</asp:HyperLink>
        <asp:Label ID="lblownerref" runat="server" Visible="false" />    
    </div>
    <!--End of main advert tab navigation-->
    <div class="adverts_content_shell">
        <div class="adverts_content_full_shell">
            <div class="adverts_content_shell_all">
                <div class="adverts_content_all">
                    <asp:Panel ID="pnlReviews" runat="server" Visible="false">
                        <asp:LinkButton ID="lnkAddReviewtop" OnClick="addReview" runat="server" Text="<br/><br/>Click here to submit a review.<br/><br/>" />
                        <asp:Label ID="lblReviews" runat="server" />
                        <asp:LinkButton ID="lnkAddReview" OnClick="addReview" runat="server" Text="<br/><br/>Click here to submit a review." />
                    </asp:Panel>
                    <asp:Panel ID="pnlReviewFirst" runat="server" Visible="false">
                    <strong>Be the first to add a review of this property.</strong>
                    <br /><br />
               
                    </asp:Panel>
                    <asp:Panel ID="pnlReviewAdd" runat="server" Visible="false">
                        We are very interested to know what you think about the property you stayed in.
                        We collect reviews and ratings so that we can publish them on the website against
                        the property. That way future visitors can see an independant opinion and be able
                        to judge whether the property is suitable for their needs.
                        <br />
                        
                        When scoring the overall property rating please take into consideration the following
                        <br />
                        <br />
                        <strong>Was it good value for money?<br>
                            Did it meet your expectations?<br>
                            Was the description accurate?<br>
                            Would you recommend it to a friend?<br>
                            Were you adequately looked after during your stay?</strong>
                        <br />
                        <br />
                        Please try to be as fair and as accurate as you can - we will publish both poor
                        and good reviews providing they are well written and constructive.
                        <br />
                        <br />
                        <b>Please note that only your name and home town will be used to identify you on the review
                            page and we will not show your email address.</b>
                        <br />
                        <br />
                        <table border="0" align="left">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="verdana10">
                                    <div align="left">
                                        First name* 
                                        </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFirstName"  runat="server" ErrorMessage="Please enter your first name"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="verdana10">
                                    <div align="left">
                                        Last name*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtLastName"  runat="server" ErrorMessage="Please enter your last name"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="verdana10">
                                    <div align="left">
                                        Your Email Address*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtEmail" runat="server" ErrorMessage="Please enter a valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="verdana10">
                                    <div align="left">
                                        Your home town*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtHomeTown" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtHomeTown"  runat="server" ErrorMessage="Please enter your home town"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Booking reference no</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtBookingRef" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Value for money*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlValForMoney" runat="server">
                                        <asp:ListItem Value="" Text="Select" />
                                        <asp:ListItem Value="3" Text="Excellent" />
                                        <asp:ListItem Value="2" Text="Good" />
                                        <asp:ListItem Value="1" Text="Fair" />
                                        <asp:ListItem Value="0" Text="Poor" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Met your expectations*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlExpectations" runat="server">
                                        <asp:ListItem Value="" Text="Select" />
                                        <asp:ListItem Value="2" Text="Exceeded them" />
                                        <asp:ListItem Value="1" Text="Yes - satisfied" />
                                        <asp:ListItem Value="0" Text="No - disappointed" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Would you recommend to a friend*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlRec" runat="server">
                                        <asp:ListItem Value="" Text="Select" />
                                        <asp:ListItem Value="2" Text="Definitely" />
                                        <asp:ListItem Value="1" Text="Yes" />
                                        <asp:ListItem Value="0" Text="No" />
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Your overall rating for this property*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlOverall" runat="server">
                                        <asp:ListItem Value="" Text="Select" />
                                        <asp:ListItem Value="3" Text="Excellent" />
                                        <asp:ListItem Value="2" Text="Good" />
                                        <asp:ListItem Value="1" Text="Fair" />
                                        <asp:ListItem Value="0" Text="Poor" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <div align="left">
                                        Your review of the property*</div>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" Rows="10" Columns="30" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="submitReview" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                        Thank you, your review has been successfully received. Once approved, your review
                        will be visible here.
                    </asp:Panel>
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