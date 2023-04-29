<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="bookingcalendar_register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <TITLE>Free availability calendar check booking calendar - freebookingcalendar.com</TITLE>
<meta name="keywords" content="availability calendar,booking calendar,calendar,booking,availability,bookingcalendar,check">
<meta name="description" content="availability calendar check booking calendar">
<SCRIPT>myString=""</SCRIPT>

<SCRIPT LANGUAGE="JavaScript">
function NewWindow(mypage, myname, w, h, scroll) {
var winl = (screen.width - w) / 2;
var wint = (screen.height - h) / 2;
winprops = 'height='+h+',width='+w+',top='+wint+',left='+winl+',scrollbars='+scroll+',resizable'
win = window.open(mypage, myname, winprops)
if (parseInt(navigator.appVersion) >= 4) { win.window.focus(); }
}
</script>

<script language="javascript">
function submitit(){
var firstname=document.myform.fname.value;
var lastname=document.myform.lname.value;
var country=document.myform.country.value;
var MailAddress=document.myform.MailAddress.value;

if (firstname==""){
alert("Please type in your firstname")
document.myform.fname.focus()
return false       
        } 
        
if (lastname==""){
alert("Please type in your lastname")
document.myform.lname.focus()
return false
        }
       
if (country==""){
alert("Please type in your country")
document.myform.country.focus()
return false
        }

if (MailAddress==""){
alert("Please type in your own e-mail address")
document.myform.MailAddress.focus()
return false
        }
        
if (MailAddress!=""){
        if (MailAddress.indexOf('@', 0) == -1 || MailAddress.indexOf('.', 0) == -1){ 
        alert("This is not a valid e-mail address!");
document.myform.MailAddress.focus()
return false
                        }
                }
document.myform.signUp.disabled = true;                                
}
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="javascript:history.back()"><-- Back</a>           
                
<!-- Add new customer -->


<br>
<br>
<center>

<table border="0" width="75%">
  <tr>
    <td width="100%">
        <h2 align=center>Sign up for a new availability calender on freebookingcalendar.com</h2>

        <div align="center">
          <center>
          <table border="0" width="95%">
            <tr>
              <td width="100%"><br><b>What are the advantages:</b></td>
            </tr>
            <tr>
              <td width="100%">- Setup in just a few minutes</td>

            </tr>
            <tr>
              <td width="100%">- Login and maintain your calendar at any time and as often as you wish</td>
            </tr>
            <tr>
              <td width="100%">- Maintain multiple calenders from the same account</td>
            </tr>
            <tr>

              <td width="100%">- Media controle - Keep track of your advertisement</td>
            </tr>
            <tr>
              <td width="100%">- bookingcalender.info is a non-profit website</td>
            </tr>
            <tr>
              <td width="100%">- Many special features and tools available</td>

            </tr>
            <tr>
              <td width="100%">- It is free</td>
            </tr>
            <tr>
              <td width="100%"></td>
            </tr>
            <tr>

              <td width="100%"><br><b>Conditions in order to keep a high standard:</b></td>
            </tr>
            <tr>
              <td width="100%">- You must maintain the calendar on a regular basis</td>
            </tr>
            <tr>
              <td width="100%"></td>
            </tr>

            <a name="ankerToForm">
              <td width="100%"><br><b>How do I sign up:</b></td>
            <tr>
              <td width="100%">Just fill in the fields below and press the
                &quot;sign up&quot;. You will then within a few minutes receive
                an email with your password to enter your new calender account.</td>
            </tr>
            <tr>
              <td width="100%">&nbsp;</td>

            </tr>
            <tr>
              <td width="100%">Important! Your information are NEVER passed on to third parties!</td>
            </tr>
          </table>
          </center>
        </div>


        <div align="center">
          <center>
          <table border="0" width="87%">
            <tr>
              <td width="36%" height="25"><font color="#FF0000">* </font>Requiredfields</td>
              <td width="64%" height="25"></td>
            </tr>
            <tr>

              <td width="36%" height="25">First name:</td>
              <td width="64%" height="25"><font color="#FF0000">*</font><input type="text" name="fname" size="31" class="noBorderField"></td>
            </tr>
            <tr>
              <td width="36%" height="25">Last name:</td>
              <td width="64%" height="25"><font color="#FF0000">*</font><input type="text" name="lname" size="31" class="noBorderField"></td>
            </tr>

            <tr>
              <td width="36%" align="left" height="25">Country:</td>
              <td width="64%" align="left" height="25"><font color="#FF0000">*</font><input type="text" name="country" size="31" class="noBorderField"></td>
            </tr>
            <tr>
              <td width="36%" align="left" height="25">Phone(incl.country code):</td>
              <td width="64%" align="left" height="25">&nbsp;&nbsp;<input type="text" name="phone" size="31" class="noBorderField"></td>

            </tr>
            <tr>
              <td width="36%" align="left" height="25">Mobil(incl.country code):</td>
              <td width="64%" align="left" height="25">&nbsp;&nbsp;<input type="text" name="mobil" size="31" class="noBorderField"></td>
            </tr>
            <tr>
              <td width="36%" align="left" height="25">E-Mail:</td>
              <td width="64%" align="left" height="25"><font color="#FF0000">*</font><input type="text" name="MailAddress" size="31" class="noBorderField"></td>

            </tr>
            <tr>
              <td width="36%" align="left" height="21">&nbsp;</td>
              <td width="64%" align="left" height="21"></td>
            </tr>
            <tr>
              <td width="100%" colspan="2" align="center" height="27"><input type="submit" value="Sign up" name="signUp" class="button"></td>
            </tr>
            
          </table>

          </center>
        </div>

      </td>
  </tr>
</table>


    </div>
    </form>
</body>
</html>
