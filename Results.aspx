<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Results.aspx.vb" Inherits="Results" Title="Untitled Page" %>
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
    <asp:Panel ID="pnlNumber" runat="server" Visible="true">
        <asp:Literal ID="results" runat="server" Text="" />
        <br />
        <asp:Image ID="maxrecords" runat="server" ImageUrl="Images/maxRecords.gif" Visible="false" />
        <asp:Image ID="norecords" runat="server" ImageUrl="Images/noResults.gif" Visible="false" />
    </asp:Panel>
    <asp:GridView ID="gvResults" OnPageIndexChanging="gvResults_PageIndexChanging" OnSorting="gvResults_Sorting"
        runat="server" AutoGenerateColumns="false" Width="95%" AllowPaging="true" AllowSorting="true"
        ShowFooter="false" ShowHeader="true" UseAccessibleHeader="false" PageSize="10"
        BorderStyle="none" BorderWidth="0" PagerSettings-Visible="true" PagerSettings-Mode="NumericFirstLast">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <!--VillarentersIndex InstantBooking-->
                </HeaderTemplate>
                <ItemTemplate>
                    <fieldset>
                        <legend>
                            <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                            (
                            <asp:Label ID="PropType" runat="server" Text='<%# Bind("PropType") %>'></asp:Label>
                            )</legend>
                        <table width="95%" cellspacing="0" cellpadding="3" border="0">
                            <tr>
                                <td valign="top">
                                    <asp:ImageButton ID="imgThumb" runat="server" />
                                </td>
                                <td valign="top" colspan="2">
                                    <br />
                                    <asp:Label ID="Summary" runat="server" Text='<%# Bind("Summary") %>'></asp:Label>
                                    <p>
                                        <br />
                                        <strong>Price:</strong>
                                        <asp:Label ID="MinPrice" runat="server" Text='<%# Bind("PriceRange") %>'></asp:Label>
                                        <%--<asp:Label ID="MaxPrice" runat="server" Text='<%# Bind("MaxPrice") %>'></asp:Label>--%>
                                        &nbsp;
                                        <asp:Label ID="Currency" runat="server" Text='<%# Bind("Currency") %>'></asp:Label>
                                        <%--<br />
                                        <strong>Nearest Airport:</strong>
                                        <asp:Label ID="Airport" runat="server" Text='<%# Bind("Airport") %>'></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text='<%#  Eval("AirportDistance") & " away."%>'></asp:Label>--%>
                                    </p>
                                    <p>
                                        <strong>Features:</strong>
                                        <asp:Label ID="Features" runat="server" Text='<%# Eval("Features") %>' Visible='true' />
                                        <%--<asp:Label ID="Freezer" runat="server" Text="Freezer : " Visible='<%# Eval("Freezer") %>' />
                                        <asp:Label ID="Nonesmoking" runat="server" Text="None smoking : " Visible='<%# Eval("Nonesmoking") %>' />
                                        <asp:Label ID="Romantic" runat="server" Text="Romantic : " Visible='<%# Eval("Romantic") %>' />
                                        <asp:Label ID="Tourist" runat="server" Text="Tourist : " Visible='<%# Eval("Tourist") %>' />
                                        <asp:Label ID="Patio" runat="server" Text="Patio : " Visible='<%# Eval("Patio") %>' />
                                        <asp:Label ID="AirConditioning" runat="server" Text="Air Conditioning : " Visible='<%# Eval("AirConditioning") %>' />
                                        <asp:Image ID="Pets" runat="server" ImageUrl="~/images/pets.gif" Visible='false' AlternateText="Pets are welcome at this property" ToolTip="Pets are welcome at this property" />
                                        <asp:Label ID="Pets1" runat="server" Text="Pets welcome : " Visible='<%# Eval("Pets") %>' />
                                        <asp:Label ID="Telephone" runat="server" Text="Telephone : " Visible='<%# Eval("Telephone") %>' />
                                        <asp:Label ID="TV" runat="server" Text="TV : " Visible='<%# Eval("TV") %>' />
                                        <asp:Label ID="Relaxing" runat="server" Text="Relaxing : " Visible='<%# Eval("Relaxing") %>' />
                                        <asp:Label ID="Balcony" runat="server" Text="Balcony : " Visible='<%# Eval("Balcony") %>' />
                                        <asp:Label ID="Parking" runat="server" Text="Parking : " Visible='<%# Eval("Parking") %>' />
                                        <asp:Label ID="SightSeeing" runat="server" Text="SightSeeing : " Visible='<%# Eval("SightSeeing") %>' />
                                        <asp:Label ID="TennisCourt" runat="server" Text="Tennis Court : " Visible='<%# Eval("TennisCourt") %>' />
                                        <asp:Label ID="Microwave" runat="server" Text="Satellite : " Visible='<%# Eval("Microwave") %>' />
                                        <asp:Label ID="Activity" runat="server" Text="Activity : " Visible='<%# Eval("Activity") %>' />
                                        <asp:Label ID="CentralHeating" runat="server" Text="Central Heating : " Visible='<%# Eval("CentralHeating") %>' />
                                        <asp:Label ID="SharedPool" runat="server" Text="Shared Pool : " Visible='<%# Eval("SharedPool") %>' />
                                        <asp:Label ID="LinenProvided" runat="server" Text="Linen Provided : " Visible='<%# Eval("LinenProvided") %>' />
                                        <asp:Label ID="OpenFire" runat="server" Text="Open Fire : " Visible='<%# Eval("OpenFire") %>' />
                                        <asp:Label ID="InstantBooking" runat="server" Text="Instant Booking Available : "
                                            Visible='<%# Eval("InstantBooking") %>' />
                                        <asp:Image ID="PrivatePool1" runat="server" ImageUrl="~/images/pool.gif" Visible='false' AlternateText="This property has a private pool" ToolTip="This property has a private pool" />
                                        <asp:Label ID="PrivatePool" runat="server" Text="Private Pool : " Visible='<%# Eval("PrivatePool") %>' />
                                        <asp:Label ID="Garden" runat="server" Text="Garden : " Visible='<%# Eval("Garden") %>' />
                                        <asp:Label ID="Cooker" runat="server" Text="Cooker : " Visible='<%# Eval("Cooker") %>' />
                                        <asp:Label ID="Internet" runat="server" Text="Internet" Visible='<%# Eval("Internet") %>' />--%>
                                    </p>
                                    <asp:Image ID="imgHHPhone" runat="server" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="hylLink" runat="server">
                                        <asp:Image ID="imgLink" runat="server" ImageUrl="~/images/continue_anim.gif" BorderStyle="none" />
                                    </asp:HyperLink>
                                </td>
                                <td colspan="2">
                                    <%--<asp:HyperLink ID="lnkMap" runat="server" NavigateUrl='<%# Bind("MapLink") %>' Target="_blank">Map</asp:HyperLink>--%>
                                    <asp:HyperLink ID="btnLocationLinks0" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks1" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks1" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks2" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks2" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks3" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks3" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks4" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks4" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks5" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks5" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks6" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks6" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks7" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks7" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks8" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks8" runat="server" Text="" Visible="false" />
                                    <asp:Label ID="LblLocationLinks9" runat="server" Text=" > " Visible="false" />
                                    <asp:HyperLink ID="btnLocationLinks9" runat="server" Text="" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <script type="text/javascript"><!--
        google_ad_client = "pub-1202052053654646";
        //results page
        google_ad_slot = "5883872066";
        google_ad_width = 160;
        google_ad_height = 600;
        //-->
    </script>
    <script type="text/javascript"
    src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
</asp:Content>