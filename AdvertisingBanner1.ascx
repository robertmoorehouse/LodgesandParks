<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdvertisingBanner1.ascx.vb"
    Inherits="AdvertisingBanner1" %>
<asp:HyperLink ID="lnkBanner" runat="server" />
<asp:Panel ID="googlesearch" runat="server" Visible="false">
    <!-- SiteSearch Google -->
    <form method="get" action="http://www.google.com/custom" target="google_window">
        <table border="0" bgcolor="#ffffff">
            <tr>
                <td nowrap="nowrap" valign="top" align="left" height="32">
                    <a href="http://www.google.com/">
                        <img src="http://www.google.com/logos/Logo_25wht.gif" border="0" alt="Google" align="middle"></img></a>
                </td>
                <td nowrap="nowrap">
                    <input type="hidden" name="domains" value="www.lodgesandparks.com;www.villacompare.com;www.zonchi.com"></input>
                    <label for="sbi" style="display: none">
                        Enter your search terms</label>
                    <input type="text" name="q" size="31" maxlength="255" value="" id="sbi"></input>
                    <label for="sbb" style="display: none">
                        Submit search form</label>
                    <input type="submit" name="sa" value="Search" id="sbb"></input>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td nowrap="nowrap">
                    <input type="radio" name="sitesearch" value="" checked id="ss0"></input>
                    <label for="ss0" title="Search the Web">
                        <font size="-1" color="#000000">Web</font></label>
                    <input type="radio" name="sitesearch" value="www.lodgesandparks.com" id="ss1"></input>
                    <label for="ss1" title="Search www.lodgesandparks.com">
                        <font size="-1" color="#000000">lodges & parks</font></label>
                    <input type="radio" name="sitesearch" value="www.villacompare.com" id="ss2"></input>
                    <label for="ss2" title="Search www.villacompare.com">
                        <font size="-1" color="#000000">Villas</font></label>
                    <input type="radio" name="sitesearch" value="www.zonchi.com" id="ss3"></input>
                    <label for="ss3" title="Search www.zonchi.com">
                        <font size="-1" color="#000000">Zonchi</font></label>
                <input type="hidden" name="client" value="pub-1202052053654646"></input>
                <input type="hidden" name="forid" value="1"></input>
                <input type="hidden" name="channel" value="8840763469"></input>
                <input type="hidden" name="ie" value="ISO-8859-1"></input>
                <input type="hidden" name="oe" value="ISO-8859-1"></input>
                <input type="hidden" name="cof" value="GALT:#008000;GL:1;DIV:#336699;VLC:663399;AH:center;BGC:FFFFFF;LBGC:336699;ALC:0000FF;LC:0000FF;T:000000;GFNT:0000FF;GIMP:0000FF;LH:50;LW:193;L:http://www.zonchi.com/images/zonchi_logo.gif;S:http://www.zonchi.com;FORID:1"></input>
                <input type="hidden" name="hl" value="en"></input>
                </td>
            </tr>
        </table>
    </form>
    <!-- SiteSearch Google -->
</asp:Panel>
