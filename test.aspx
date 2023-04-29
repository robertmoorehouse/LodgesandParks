<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <iframe id="tandcs" style="width:0px; height:0px; visibility:hidden;" src='privacy.asp?<%=setdate()%>'></iframe>
                        
</asp:Content>

