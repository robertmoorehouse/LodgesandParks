<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="bookingcalendar_users_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    




<p class="headline2" align="center">robert's calendar(s)</p>

<div align="center">
  <center>
  <table border="0" width="74%">
    <tr>
      <td width="100%">Below you have your calender(s) listed and you may at any time enter to modify it. You also have the option to use the media statistics which allows you to keep track of which advertising medias works best for you. Click the link "My medias" in the menu to learn more.<br><br>It is very easy to refer to your calendar on other websits. Simply type in http://www.freebookingcalendar.com/ and your calendar id.<br>Example: http://www.freebookingcalendar.com/22<br>You can click on 'Your link' to see it.<br><br>Please note that if a calendar has not been edited in 4 months it is disabled. It will be enabled again when you edit it again.</td>

    </tr>
  </table>
  </center>
</div>
<br>
<br>
<div align="center">
<table border="1" cellpadding="0" cellspacing="0" width="475">
  <tr class="breadbold">
    <td width="45">Id</td>
    <td width="325">Calendar name</td>

    <td width="45" align="center">Modify</td>    
    <td width="60" align="center">See live</td>
  </tr>
  


  <tr class="bread" onmouseover="rowOver();" onmouseout="rowOut();">
    <td width="45"><a href="calendar/checkCalendar.asp?calendarId=19736">19736</td>
    <td width="325"><a href="calendar/checkCalendar.asp?calendarId=19736">My calendar....</td>
    <td width="45" align="center"><a href="calendar/checkCalendar.asp?calendarId=19736">Modify</td>

    <td width="60" align="center"><a href="http://www.freebookingcalendar.com/19736" target="blanc">Your link</td>
  </tr>

			</table>
</div>
<p align="center">ADD THIS CALENDAR TO YOUR OWN WEBSITE<br>If you have your own website you may add this calendar to it. It is a realtime calendar, so when you make a change to the calendar from your account on www.freebookingcalendar.com, it reflects immediatly on your own website. <br>Note that you may change the background color to match your own website.<br><br>All you have to is click on the id above and at the bottom of that page you will find the information need.








<br><br><br><br>

    </div>
    </form>
</body>
</html>
