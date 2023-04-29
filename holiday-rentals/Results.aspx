<%@ Page Language="VB" MasterPageFile="/MasterPage.master" AutoEventWireup="false"
    CodeFile="Results.aspx.vb" Inherits="Results" Title="Untitled Page" %>
<%@ Register Src="/locationdropdowns.ascx" TagName="locationdropdowns" TagPrefix="uc1" %>
<%@ Register Src="/PopularLocations.ascx" TagName="popularlocations" TagPrefix="uc2" %>
<%@ Register Src="/PopularSearches.ascx" TagName="PopularSearches" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Choose a Location</span>
        <uc1:locationdropdowns ID="Locationdropdowns1" runat="server"></uc1:locationdropdowns>
    <asp:ImageButton ID="searchButton1" runat="server" PostBackUrl="/results.aspx" ImageUrl="/images/search_but_up.gif" />    
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
        <asp:Image ID="maxrecords" runat="server" ImageUrl="/Images/maxRecords.gif" Visible="false" />
        <asp:Image ID="norecords" runat="server" ImageUrl="/Images/noResults.gif" Visible="false" />
    </asp:Panel>
    <asp:GridView ID="gvResults" OnPageIndexChanging="gvResults_PageIndexChanging" OnSorting="gvResults_Sorting"
        runat="server" AutoGenerateColumns="false" Width="95%" AllowPaging="false" AllowSorting="true"
        ShowFooter="false" ShowHeader="true" UseAccessibleHeader="false"
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
                                    <asp:Image ID="imgThumb" runat="server" />
                                </td>
                                <td valign="top" colspan="2">
                                    <br />
                                    <asp:Label ID="Summary" runat="server" Text='<%# Bind("Summary") %>'></asp:Label>
                                    <p>
                                        <br />
                                        <strong>Price:</strong>
                                        <asp:Label ID="MinPrice" runat="server" Text='<%# Bind("PriceRange") %>'></asp:Label>
                                         &nbsp;
                                        <asp:Label ID="Currency" runat="server" Text='<%# Bind("Currency") %>'></asp:Label>
                                        </p>
                                    <p>
                                        <strong>Features:</strong>
                                        <asp:Label ID="Features" runat="server" Text='<%# Eval("Features") %>' Visible='true' />
                                        
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="hylLink" runat="server">
                                        <asp:Image ID="imgLink" runat="server" ImageUrl="/images/continue_anim.gif" BorderStyle="none" />
                                    </asp:HyperLink>
                                </td>
                                <td colspan="2">
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
