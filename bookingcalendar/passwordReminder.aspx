<%@ Page Language="VB" AutoEventWireup="false" CodeFile="passwordReminder.aspx.vb" Inherits="bookingcalendar_passwordReminder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script language="javascript">
function submitit(){
var MailAddress=document.myform.emailAddress.value;

if (MailAddress==""){
alert("Please type in your email address")
document.myform.emailAddress.focus()
return false
        }
        
if (MailAddress!=""){
        if (MailAddress.indexOf('@', 0) == -1 || MailAddress.indexOf('.', 0) == -1){ 
        alert("This is not a valid email address!");
document.myform.emailAddress.focus()
return false
                        }
                }
                               
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div align="center">
<table border="0" width="100%">
  <tr>
    <td width="100%" align="center"><b>Get your password sent to your email address</b></td>
  </tr>

  <tr>
    <td width="100%" align="center" class="small"><br/>Use the email address that you signed up with on www.freebookingcalendar.com</td>
  </tr>
              <tr>  
                <td width="100%" align="center"><br/>Type in your email address:</td>
              </tr>    
              <tr>
                <td width="100%" align="center"><input class="noBorderField" type="emailAddress" name="emailAddress" size="35"></td>

              </tr>
              <tr>
                <td width="100%" align="center"><input class="button" type="submit" value="Send password" name="B1"></td>
              </tr>
  <tr>
    <td width="100%" align="right"><a href="javascript:window.close()" class="small">Close window</a>&nbsp;</td>
  </tr>
</table>

    </div>
    </form>
</body>
</html>
