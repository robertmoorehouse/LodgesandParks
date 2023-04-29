<%@ Page Language="VB" MasterPageFile="~/masterpage-noside.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <panel id="login" runat="server">
    <h1 title="Join Us" class="subheadingtext">
        Login to our community</h1>
    <br />
    <span class="formtitlestext_blue">As a registered member of our community you can add your own property to our listings, earn cashback from your bookings and receive exclusive offers in our newsletters.<br />
        <asp:TextBox Style="visibility: hidden" ID="type" runat="server" Text="" />
        <asp:TextBox Style="visibility: hidden" ID="preload" runat="server" Text="" />
        <asp:TextBox Style="visibility: hidden" ID="join_type" runat="server" Text="" />
        <br />
        To create an account <a href="join.aspx">Click Here</a>
        <br />
        <br />
        or enter your details below to login<br />
        <br />
        <span class="redtext">Community sites include Funds4Me<%--, wishtotravel--%> and Zonchi.</span>
        <br />
        <br />
    </span>
    <div class="join_tabs_shell">
        <asp:LinkButton ID="step1bluetab" runat="server" Text="Enter Your Details"
            CssClass="first_tab" />
       <asp:LinkButton ID="step2bluetab" runat="server" Text="Members Area"
            CssClass="tabs" />
    </div>
    <%--<div class="affiliates_spacer">
        <img src="images/1x1_spacer.gif" height="10" alt="line" />
    </div>
    <div class="affiliates_joinsteps">
        
            <asp:Label ID="lblStep1" runat="server" Text="1. Enter Username and password"
                CssClass="redtext" />
           <asp:Label ID="lblStep4" runat="server" Text="2. Members Area"
                CssClass="greytext" />
        
    </div>
    <div class="affiliates_line">
        <img src="images/middle_line.gif" alt="line" width="860px" />
    </div>
    <div class="affiliates_spacer">
        <img src="images/1x1_spacer.gif" height="10" alt="line" />
    </div>--%>
    </panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Panel ID="step1" runat="server">
    <br /><br />
        <span class="subheadingtext">3. Please Enter Password</span>
        <br />
        <span class="formtitlestext_blue">For security we need to make sure only you can access
            your account. We do this by using a username and password. Please enter the combination
            you would like to use below.</span>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Username</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="username" runat="server" CssClass="affiliates_joinformbox" />
            <asp:Label ID="Label1" runat="server"></asp:Label></div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Password</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="password" runat="server" CssClass="affiliates_joinformbox" TextMode="Password" />
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be 8 - 20 characters long and have both letters and numbers."
                ControlToValidate="password" ValidationExpression="(?=.{7,21})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+"
                Display="Dynamic"></asp:RegularExpressionValidator>--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password"
                Display="Dynamic" ErrorMessage="Password Required"></asp:RequiredFieldValidator></div>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <asp:ImageButton ID="panel3Continue" CausesValidation="true" runat="server" ImageUrl="images/continue_button.gif" />
            <!--<asp:ImageButton ID="panel3Clear" ImageUrl="images/clear_button.gif" runat="server" />-->
        </div>
    </asp:Panel>
 
    
 
    <asp:Panel ID="Step4" runat="server" Visible="false">
        <br /><br />
            <span class="formtitlestext_blue"><strong>ADD YOUR PROPERTY</strong><br /><br />
            <strong>Option 1: FULL PAYMENT SYSTEM - charged commission - 2% or 10%</strong><br />
            If you wish to use payment services provided by rental systems you can add your property now simply <strong><a href="/takemethere.aspx?productFilter=VR&land=join">CLICK HERE</a></strong> joining this way will mean a 2% owner booking charge and a 10% charge where we find you the bookings.
            Our system is still in development. We hope to be launching the following services soon.
            <br /><br />
            <strong>Option 2: FULL PAYMENT SYSTEM - Discounted commission - 2% or 5% + annual fee of £60.</strong><br />
            As option 1 but with reduced commission for sales we find you from 10% down to 5%
            <br /><br />
            <strong>Option 3: FULL PAYMENT SYSTEM - Discounted commission - 2% + annual fee of £120.</strong><br />
            As option 1 but with reduced commission for sales we find you from 10% down to 2%
            <br /><br />
            if you would like to join using option 2 or 3 please send an email with your choice to <a href="mailto:robert@moorehouse.eu?subject=Discounted commission enquiry&body=I am interested in the reduced commission adverts please send me more information." >Robert</a> so we can contact you with further details.
            <br /><br />
            Our free system is still in development. We hope to be launching the following services soon.
            <br /><br />
            <strong>4: OUR FREE SYSTEM - AVAILABLE FEBRUARY 2008</strong><br />
            Add your own property and use our calendar managing your own bookings for free, this service will not have any payment services.
            <br /><br />
            
        </span>
        
    </asp:Panel>
</asp:Content>
