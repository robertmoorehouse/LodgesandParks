<%@ Page Language="VB" MasterPageFile="~/masterpage-noside.master" AutoEventWireup="false"
    CodeFile="join.aspx.vb" Inherits="join" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 title="Join Us" class="subheadingtext">
        Join our community</h1>
    <br />
    <span class="formtitlestext_blue">As a member us you are able to add your own properties to our lists, receive member only
        offers through our newsletter and earn cashback from many of the properties listed
        on our site through our partner site <a href="http://www.funds4me.com" target="_blank">
            Funds4Me</a>. Just for signing up with us Funds4Me will open you an account
        and give you an initial $10 (£5) starting balance.<br />
        <asp:TextBox Style="visibility: hidden" ID="type" runat="server" Text="" />
        <asp:TextBox Style="visibility: hidden" ID="preload" runat="server" Text="" />
        <asp:TextBox Style="visibility: hidden" ID="join_type" runat="server" Text="" />
        <br />
        To create your account simply fill in the form below and press the Continue button.
        <br />
        <br />
        Please make sure that you enter information into all the boxes labelled in <span
            class="formtitlestext_redbold">red</span>.<br />
        <br />
        <span class="redtext">Funds4Me members are already members of this site
            and visa-versa so you do not need to re-join.</span>
        <br />
        <br />
    </span>
    <div class="join_tabs_shell">
        <asp:LinkButton ID="step1bluetab" runat="server" Text="Enter Your Personal Details"
            CssClass="first_tab" />
        <asp:LinkButton ID="step2bluetab" runat="server" Text="Enter Your Email Address"
            CssClass="tabs" />
        <asp:LinkButton ID="step3bluetab" runat="server" Text="Enter Password" CssClass="tabs" />
    </div>
    <div class="affiliates_spacer">
        <img src="images/1x1_spacer.gif" height="10" alt="line" />
    </div>
    <div class="affiliates_joinsteps">
        <span class="redtext">Start&nbsp;&nbsp; &gt; &nbsp;&nbsp;
            <asp:Label ID="lblStep1" runat="server" Text="1. Enter personal Details&nbsp;&nbsp;"
                CssClass="greytext" />
            <asp:Label ID="lblStep2" runat="server" Text="2. Enter Email Address&nbsp;&nbsp; &gt; &nbsp;&nbsp;"
                CssClass="greytext" />
            <asp:Label ID="lblStep3" runat="server" Text="3. Enter Password and Submit&nbsp;&nbsp; &gt; &nbsp;&nbsp;"
                CssClass="greytext" />
            <asp:Label ID="lblStep4" runat="server" Text="Finish" CssClass="greytext" />
        </span>
    </div>
    <div class="affiliates_line">
        <img src="images/middle_line.gif" alt="line" width="860px" />
    </div>
    <div class="affiliates_spacer">
        <img src="images/1x1_spacer.gif" height="10" alt="line" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Panel ID="step1" runat="server">
        <div class="affiliates_contentleftshell">
            <div class="affiliates_leftcontent">
                <span class="subheadingtext">1. Please Enter Your Personal Details</span>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_red">Title</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:DropDownList ID="titles" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">First Name</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="firstname" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_red">Surname</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="surname" runat="server" CssClass="affiliates_joinformbox" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="surname"
                        ErrorMessage="Please enter your Surname"></asp:RequiredFieldValidator></div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">Trading / company name (if applicable)</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="tradingname" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">Address</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="Address1" runat="server" CssClass="affiliates_joinformbox" /><br />
                    <br />
                    <asp:TextBox ID="Address2" runat="server" CssClass="affiliates_joinformbox" /><br />
                    <br />
                    <asp:TextBox ID="Address3" runat="server" CssClass="affiliates_joinformbox" /><br />
                    <br />
                </div>
            </div>
        </div>
        <div class="affiliates_middleline">
            <img src="images/line_verticle.gif" alt="line" />
        </div>
        <div class="affilaites_rightcontentshell">
            <div class="affiliates_rightcontent">
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">Town / City</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="town" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">County / State</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="county" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">Post Code / Zip</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="postcode" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_formshell">
                    <span class="formtitlestext_red">Country</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:DropDownList ID="country" runat="server">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="affiliates_formshell">
                    <span class="formtitlestext_blue">Telephone Number</span>
                </div>
                <div class="affiliates_formshell">
                    <asp:TextBox ID="telephonenumber" runat="server" CssClass="affiliates_joinformbox" />
                </div>
                <div class="affiliates_phonecodes">
                    <asp:ImageButton ID="panel1Continue" runat="server" ImageUrl="images/continue_button.gif" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Step2" runat="server" Visible="false">
        <span class="subheadingtext">2. Please Enter Your Email Address</span>
        <br />
        <span class="formtitlestext_blue">We use your email address to keep in contact with
            you. Please enter the address you would like us to use in both boxes below (this
            is a check to avoid typing errors).</span>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Email Address</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="email" runat="server" CssClass="affiliates_joinformbox" />&nbsp;<br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid email address"
                ControlToValidate="email" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Please retype the email address below</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="confirmemail" runat="server" CssClass="affiliates_joinformbox" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="email"
                ControlToValidate="confirmemail" ErrorMessage="Emails must match"></asp:CompareValidator></div>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <asp:ImageButton ID="panel2Continue" runat="server" ImageUrl="images/continue_button.gif" />
            <!--<asp:ImageButton ID="panel2Clear" ImageUrl="images/clear_button.gif" runat="server" />-->
        </div>
    </asp:Panel>
    <asp:Panel ID="Step3" runat="server" Visible="false">
        <span class="subheadingtext">3. Please Enter Password</span>
        <br />
        <span class="formtitlestext_blue">For security we need to make sure only you can access
            your account. We do this by using a username and password. Please enter the combination
            you would like to use below.</span>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_blue">Username</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="username" runat="server" CssClass="affiliates_joinformbox" ReadOnly="true" />
            <asp:Label ID="lblUsernameUsed" runat="server"></asp:Label></div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Password (at least 8 characters)</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="password" runat="server" CssClass="affiliates_joinformbox" TextMode="Password" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Password must be 8 - 20 characters long and have both letters and numbers."
                ControlToValidate="password" ValidationExpression="(?=.{7,21})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+"
                Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password"
                Display="Dynamic" ErrorMessage="Password Required"></asp:RequiredFieldValidator></div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_red">Please retype the password below</span>
        </div>
        <div class="affiliates_formshell">
            <asp:TextBox ID="confirmpassword" runat="server" CssClass="affiliates_joinformbox"
                TextMode="Password" /><asp:CompareValidator ID="ComparePassword" ControlToValidate="password"
                    ControlToCompare="confirmpassword" runat="server" ErrorMessage="<br/>Passwords must match"></asp:CompareValidator>
        </div>
        <div class="affiliates_formshell">
            <span class="formtitlestext_blue">How did you hear about us ?</span>
        </div>
        <div class="affiliates_formshell">
            <asp:DropDownList ID="hearabout" runat="server">
                <asp:ListItem>Google</asp:ListItem>
                <asp:ListItem>Zonchi.com</asp:ListItem>
                <asp:ListItem>WishtoTravel.com</asp:ListItem>
                <asp:ListItem>Member (let us know which one so we can reward them)</asp:ListItem>
                <asp:ListItem>Press (please say which below)</asp:ListItem>
                <asp:ListItem>Other (please explain below)</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:TextBox ID="hearaboutother" runat="server" CssClass="affiliates_joinformbox"
                Text="enter more details here" />
        </div>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <asp:ImageButton ID="panel3Continue" CausesValidation="true" runat="server" ImageUrl="images/continue_button.gif" />
            <!--<asp:ImageButton ID="panel3Clear" ImageUrl="images/clear_button.gif" runat="server" />-->
        </div>
    </asp:Panel>
    <asp:Panel ID="Step4" runat="server" Visible="false">
        <div class="affiliates_formshell">
            Thank you for joining our advertising and management system.<br />
            You should make a note of the details below (together with your password) as you
            will need them to log on to the web site or to get in contact with us.
            <br />
            <br />
            User Name
            <asp:Label ID="lblUsername" runat="server" Text="" />
            <br />
            <br />
            Membership Number
            <asp:Label ID="lblMembership" runat="server" Text="" />
            <br />
            <br />
            Thank you for joining the zonchi community - your username and password has been sent
            to you by email.<br />
            Use the login form above to logon with your new account details.
        </div>
        <div class="affiliates_spacer">
            <img src="images/1x1_spacer.gif" height="10" alt="line" />
        </div>
        <div class="affiliates_formshell">
            <asp:ImageButton ID="panel4Continue" runat="server" ImageUrl="images/continue_button.gif"
                PostBackUrl="default.aspx" />
        </div>
    </asp:Panel>
</asp:Content>
