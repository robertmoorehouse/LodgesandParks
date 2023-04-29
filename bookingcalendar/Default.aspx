<%@ Page Language="VB" MasterPageFile="~/bookingcalendar/freebookingcalendar-noside.master"
    AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="bookingcalendar_Default"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript">
<!-- Begin
function NewWindow(mypage, myname, w, h, scroll) {
var winl = (screen.width - w) / 2;
var wint = (screen.height - h) / 2;
winprops = 'height='+h+',width='+w+',top='+wint+',left='+winl+',scrollbars='+scroll+',resizable'
win = window.open(mypage, myname, winprops)
if (parseInt(navigator.appVersion) >= 4) { win.window.focus(); }
}
//  End -->
    </script>

    <div align="center">
        <table border="0" width="622" id="table1">
            <tr>
                <td colspan="2" align="center">
                    <h1>
                        FreeBookingCalendar.com<br />
                        <br />
                        Get a free availability calendar to maintain your bookings!</h1>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../images/bookingcalendar/samplemonth.gif" alt="Graphical calendar" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <font face="Verdana" size="2"><b>What are the advantages:</b><br />
                        - It is free<br />
                        - Setup in just a few minutes<br />
                        - Login and alter your calendar as often as you wish<br />
                        - Maintain multiple calenders from the same account<br />
                        - Media control - Keep track of your advertisement<br />
                        - Many special features and tools available<br />
                        - freebookingcalendar.com is an independent non-profit website<br />
                        - option to include further details and list your property on our holiday sites<br />
                        &nbsp;&nbsp;<a href="register.aspx">Click here to sign up for a FREE calendar...</a>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <center>
            <table width="300">
                <tr>
                    <td width="100%" height="25" colspan="2" align="center">
                        Already have a calendar? Login here!
                    </td>
                </tr>
                <tr>
                    <td width="36%" align="left" height="25">
                        E-Mail:
                    </td>
                    <td width="64%" align="left" height="25">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="36%" align="left" height="21">
                        Password:
                    </td>
                    <td width="64%" align="left" height="21">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="2" height="27" align="center">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnSubmit" runat="server" Text="Login" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="2" height="27" align="center">
                        <br />
                        <a href="~/bookingcalendar/passwordReminder.aspx" onclick="NewWindow('passwordReminder.aspx','name','450','250','yes');return false;">
                            Forgot your password? Click here...</a>
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="2" height="27" align="center">
                        <br />
                        <a href="mailto:robert@moorehouse.eu">Contact us</a>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
