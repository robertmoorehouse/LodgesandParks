<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="admin_Default" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Clear Search Results" /><br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Clear Reviews" />&nbsp;<br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Clear Property Details" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Clear Property Availability" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="Clear Locations" />
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="Clear ALL" />
        <br />
        <br />
        <asp:Button ID="Button7" runat="server" Text="Google SiteMaps" />
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" Text="Site Errors" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
            <asp:Literal ID="appVals" runat="server"></asp:Literal>
            Current Application Number:
            <asp:Label ID="lblApplication" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddApplication" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>75</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="appButton1" runat="server" Text="Change" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        
        
            
</asp:Content>

