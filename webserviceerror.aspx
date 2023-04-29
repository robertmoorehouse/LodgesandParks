<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="webserviceerror.aspx.vb" Inherits="_webserviceerror" Title="Untitled Page" %>

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

    <script> 
function	Homepage(){
<!--
// in real bits,	urls get	returned to our script like this:
// res://shdocvw.dll/http_404.htm#http://www.DocURL.com/bar.htm 

	//For	testing use	DocURL	= "res://shdocvw.dll/http_404.htm#https://www.microsoft.com/bar.htm"
	DocURL=document.URL;
	
	//this	is where the http or https will be,	as	found by searching for :// but	skipping the res://
	protocolIndex=DocURL.indexOf("://",4);
	
	//this	finds	the ending	slash	for the domain server	
	serverIndex=DocURL.indexOf("/",protocolIndex +	3);

	//for the href,	we need a	valid	URL to the	domain.	We search	for the # symbol to find the begining 
	//of the true URL, and	add 1 to skip it -	this is the BeginURL value. We use serverIndex as the end marker.
	//urlresult=DocURL.substring(protocolIndex - 4,serverIndex);
	BeginURL=DocURL.indexOf("#",1) + 1;
	urlresult=DocURL.substring(BeginURL,serverIndex);
		
	//for display, we	need	to	skip after http://, and	go	to	the next slash
	displayresult=DocURL.substring(protocolIndex + 3 ,serverIndex);
	document.write(	'<A TITLE="' + displayresult + '"	HREF="'	+ escape(urlresult) +	'">' + displayresult	+ "</a>");
}
//-->
    </script>

    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="15">
                                <img src="/images/1x1_spacer.gif" width="15" height="15"></td>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img src="/images/1x1_spacer.gif" width="15" height="15"></td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="8" cellspacing="0" class="tableBorder">
                                    <tr>
                                        <td width="156" align="center">
                                            <img src="/images/error-icon.gif" width="100" height="88" alt="Error Image"></td>
                                        <td valign="top" align="left" class="text-small">
                                            <h1 style="color: #000000; font: 13pt/15pt verdana">
                                                <!--Problem-->
                                                The page cannot be displayed</h1>
                                            <font style="color: #000000; font: 8pt/11pt verdana">There is a problem with the page
                                                you are trying to reach and it cannot be displayed.</font> <font style="color: #000000;
                                                    font: 8pt/11pt verdana">
                                                    <hr color="#C0C0C0" noshade>
                                                    <p>
                                                        Please try the following:</p>
                                                    <ul>
                                                        <li id="instructionsText1">Click the back button then the<a href="javascript:location.reload()"
                                                            title="Refresh"> Refresh</a> button, or try again later.<br />
                                                        </li>
                                                        <li>Open the

                                                            <script>
	  <!--
	  if	(!((window.navigator.userAgent.indexOf("MSIE") > 0) && (window.navigator.appVersion.charAt(0) == "2")))
	  {
		 Homepage();
	  }
	  //-->
                                                            </script>

                                                            home page, and then look for links to the information you want. </li>
                                                        <li>If you continue to experience problems, contact <a href="mailto:websupport@grappleuk.com"
                                                            title="websupport@grappleuk.com">websupport@grappleuk.com</a></li>
                                                    </ul>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#dfe7ef">
                                            <img src="/images/1x1_spacer.gif" width="8" height="8"><b>Technical Information</b></td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <asp:Literal ID="errMessge" runat="server"></asp:Literal>
                                <ul>
                                    <li>Browser Type:<br />
                                        <asp:Label ID="lblBrowser" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>Page:<br />
                                        <asp:Label ID="lblPage" runat="server" Text="Label"></asp:Label></li>
                                    <li>Time:<br />
                                        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label></li>
                                    <li>More information:<br />
                                        Our engineers have been informed and the issue will be examined shortly.
                                        <br />
                                        If you wish to report this error, please quote the error identification code shown
                                        below.
                                        <br />
                                        ERROR ID:
                                        <asp:Literal ID="errCode" runat="server"></asp:Literal>
                                        <br />
                                        <br />
                                        The Grapple (UK) Development Team
                                        <br />
                                        <a href="mailto:errors@grappleuk.com">errors@grappleuk.com</a> </li>
                                </ul>
                            </td>
                            <td width="15">
                                <img src="/images/1x1_spacer.gif" width="15" height="15"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Literal ID="sitemaps" runat="server"></asp:Literal>
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