<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="addproperty.aspx.vb" Inherits="addproperty" Title="Untitled Page" %>
<%@ Register Src="locationdropdowns.ascx" TagName="locationdropdowns" TagPrefix="uc1" %>
<%@ Register Src="PopularLocations.ascx" TagName="popularlocations" TagPrefix="uc2" %>
<%@ Register Src="PopularSearches.ascx" TagName="PopularSearches" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Choose a Location</span>
    </div>
    <uc1:locationdropdowns ID="Locationdropdowns1" runat="server"></uc1:locationdropdowns>
    <asp:ImageButton ID="searchButton1" runat="server" PostBackUrl="~/results.aspx" ImageUrl="~/images/search_but_up.gif" />
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Popular Searches</span>
        <uc3:PopularSearches ID="PopularSearches1" runat="server" />
        <br /><br />
    </div>
    <div class="search_input_boxes">
        <span class="searchbox_text_bold">Popular Locations</span>
        <uc2:popularlocations ID="popularlocations2" runat="server"></uc2:popularlocations>
        <br /><br />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="position: relative; width: 620px; margin: 5px; border: 0px; padding: 5px;
        float: left;">
        <img height="152" src="images/conceptHeader2.jpg" alt="What we do for you" width="600" />&nbsp;
        <br />
        <strong>What we do</strong>
        <p>
            We provide you with our online rental business software for free. We also provide
            you with bookings from our marketing site Villarenters.com and from our extensive
            affiliate network for a very low commission.
            <br />
            We do NOT ask you to sign any marketing exclusivity - you're free to market widely
            and with our software that's easy to manage and gives you an unlimited advantage.
        </p>
        <p>
            <strong>What you do</strong>
        </p>
        <p>
            Set up your rental business and advertising using our easy-to-use templated system.
            Supply the accommodation as described. Arrange cleaning and maintenance locally.
            Organise key collection and any meet and greet arrangements. Deal with all issues
            relating to your customers in a professional way&nbsp;
        </p>
        <p>
            <strong>What you get</strong>
        </p>
        <ul>
            <li>Fully customisable online holiday home booking system&nbsp; </li>
            <li>A rental business model suitable for one property or thousands </li>
            <li>Contract template with customisable terms and conditions </li>
            <li>Automated emails chasing payments </li>
            <li>Arrival instructions automatically sent to your customers </li>
            <li>Automatic cancellation policies </li>
            <li>Central booking calendar that integrates with Villarenters.com that can be integrated
                with your own website, making double bookings a thing of the past </li>
            <li>Access to your online member account means you can track the status of your bookings
                from anywhere at any time&nbsp; </li>
            <li>All booking details, customer information and communication stored centrally </li>
            <li>With RentalSystems you can update property details in seconds </li>
            <li>Create your own extra pricing models&nbsp; </li>
            <li>Create your own automatic discounting models, last minute long stay or early bird
                discounts are calculated instantly </li>
            <li>Credit card authorisation for breakage deposits, damages can be claimed online&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </li>
        </ul>
        <p>
            <strong>What your customers get</strong>
        </p>
        <ul>
            <li>Customer satisfaction </li>
            <li>Customer assurance </li>
            <li>Browse property details including photographs and videos online </li>
            <li>Instant availability check </li>
            <li>Instant online quotes </li>
            <li>Instant reservations </li>
            <li>Bookings can be placed at any time of the day or night </li>
            <li>Read past guest reviews </li>
            <li>Payment reminders </li>
            <li>Option to pay online by credit or debit card </li>
            <li>Invitation to submit reviews </li>
            <li>Online renters area containing full booking details which they can access from anywhere
                at any time</li>
        </ul>
        <asp:HyperLink ID="hypJoin" runat="server" NavigateUrl="http://www.rentalsystems.com/newowner/ownerjoin_ub.asp?sag=&sc=&rag=35465G&rcam=fvlogin">
            <asp:Image ID="Image1" runat="server" ImageUrl="images/join_now_button.gif" />
        </asp:HyperLink>
    </div>
</asp:Content>
