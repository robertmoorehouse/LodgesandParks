<%@ Control Language="VB" AutoEventWireup="false" CodeFile="locationdropdowns.ascx.vb"
    Inherits="locationdropdowns" %>


<%--<asp:UpdatePanel ChildrenAsTriggers="true" UpdateMode="Conditional" runat="server"
    ID="upnCountries">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="subLocations0" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations1" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations2" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations3" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations4" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations5" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations6" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations7" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations8" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations9" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="subLocations10" EventName="SelectedIndexChanged" />
    </Triggers>
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="upnCountries" runat="server" >
            <ProgressTemplate>
                locations updating...
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        
        <asp:DropDownList ID="subLocations0" runat="server" Visible="true" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True"  />
        <asp:DropDownList ID="subLocations1" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations2" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations3" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations4" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations5" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations6" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations7" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations8" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations9" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:DropDownList ID="subLocations10" runat="server" Visible="false" CssClass="findavilla_leftnav_dropdowns"
            OnSelectedIndexChanged="callpopulateLocations" AutoPostBack="True" />
        <asp:Label ID="lblCatRef" runat="server" Visible="false" />
        <asp:Label ID="lblDropDown" runat="server" Visible="false" />
        <asp:Label ID="lblErrors" runat="server" Font-Bold="true" ForeColor="#ffffff" />
  <%--  </ContentTemplate>
</asp:UpdatePanel>
--%>