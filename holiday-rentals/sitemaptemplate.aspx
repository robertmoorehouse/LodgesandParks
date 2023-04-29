<%@ Page Language="VB" MasterPageFile="sitemap.master" AutoEventWireup="false" CodeFile="sitemaptemplate.aspx.vb" Inherits="sitemaptemplate" title="Untitled Page" %>
<%@ Register Src="/latestreviews.ascx" TagName="latestreviews" TagPrefix="uc4" %>
<%@ Register Src="/locationdropdowns.ascx" TagName="locationdropdowns" TagPrefix="uc1" %>
<%@ Register Src="/PopularLocations.ascx" TagName="popularlocations" TagPrefix="uc2" %>
<%@ Register Src="/PopularSearches.ascx" TagName="PopularSearches" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="search_input_boxes">
        <span class="searchbox_text_bold">Choose a Location</span>
        <div id="ctl00_ContentPlaceHolder1_Locationdropdowns1_upnCountries">
	
        <div id="ctl00_ContentPlaceHolder1_Locationdropdowns1_UpdateProgress1" style="display:none;">

		
                locations updating...
            
	</div>
        
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations0\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations0" class="findavilla_leftnav_dropdowns">
		<option value="0">All locations...</option>
		<option value="3923">Africa (28)</option>
		<option value="3925">Asia (83)</option>
		<option value="3922">Caribbean (64)</option>

		<option value="3927">Central America (11)</option>
		<option selected="selected" value="3929">Europe (2094)</option>
		<option value="3930">Middle East (14)</option>
		<option value="3928">North America (789)</option>
		<option value="3926">Oceania (3)</option>
		<option value="3924">South America (8)</option>

	</select>
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations1" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations1\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations1" class="findavilla_leftnav_dropdowns">
		<option value="0">All locations...</option>
		<option value="14">Austria (1)</option>
		<option value="21">Belgium (1)</option>
		<option value="33">Bulgaria (33)</option>

		<option value="54">Croatia (25)</option>
		<option value="56">Cyprus (257)</option>
		<option value="57">Czech Republic (1)</option>
		<option value="74">France (77)</option>
		<option value="84">Greece (155)</option>
		<option value="103">Ireland (14)</option>

		<option value="105">Italy (138)</option>
		<option value="132">Malta (8)</option>
		<option value="160">Norway (2)</option>
		<option value="170">Poland (1)</option>
		<option value="171">Portugal (189)</option>
		<option value="175">Romania (1)</option>

		<option selected="selected" value="197">Spain (762)</option>
		<option value="215">Turkey (427)</option>
		<option value="222">United Kingdom (1)</option>

	</select>
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations2" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations2\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations2" class="findavilla_leftnav_dropdowns">
		<option value="0">All locations...</option>

		<option value="465">Balearic Islands (88)</option>
		<option value="261">Canary Islands - Canaries (78)</option>
		<option value="1134">Castilla y Leon (1)</option>
		<option value="732">Costa Azahar - Valencia (22)</option>
		<option selected="selected" value="509">Costa Blanca - Alicante (340)</option>
		<option value="470">Costa Brava - Barcelona (1)</option>

		<option value="4150">Costa Brava - Girona (6)</option>
		<option value="506">Costa Calida - Murcia (82)</option>
		<option value="752">Costa de Almeria - Almeria (12)</option>
		<option value="925">Costa de la Luz - Cadiz (14)</option>
		<option value="4151">Costa de la Luz - Huelva (6)</option>
		<option value="476">Costa del Sol - Malaga (85)</option>

		<option value="803">Costa Dorada - Tarragona (6)</option>
		<option value="744">Costa Tropical - Granada (12)</option>
		<option value="3042">Extremadura (1)</option>
		<option value="4179">Northern Andalucia (9)</option>

	</select>
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations3" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations3\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations3" class="findavilla_leftnav_dropdowns">

		<option value="0">All locations...</option>
		<option value="12696">Alicante region (12)</option>
		<option value="12695">Baja Vinalopa (16)</option>
		<option value="7884">Costa Blanca - Alicante (other areas) (3)</option>
		<option value="12698">Inland Costa Blanca (1)</option>
		<option selected="selected" value="12693">Marina Alta - Denia (161)</option>

		<option value="12694">Marina Baja - Benidorm (11)</option>
		<option value="12697">Orihuela - Torrevieja (136)</option>

	</select>
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations4" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations4\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations4" class="findavilla_leftnav_dropdowns">
		<option value="0">All locations...</option>
		<option value="8328">Benimeli (1)</option>

		<option value="870">Benissa (2)</option>
		<option value="869">Benitachell (10)</option>
		<option value="871">Calpe (9)</option>
		<option value="864">Denia (22)</option>
		<option value="868">Jalon / Jalon Valley (1)</option>
		<option selected="selected" value="867">Javea (58)</option>

		<option value="866">Moraira (41)</option>
		<option value="3385">Orba (4)</option>
		<option value="3658">Pego (13)</option>

	</select>
        <select name="ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations5" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$Locationdropdowns1$subLocations5\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_Locationdropdowns1_subLocations5" class="findavilla_leftnav_dropdowns">
		<option value="0">All locations...</option>

		<option value="3714">Capsades (1)</option>
		<option value="3430">Gata de Gorgos (1)</option>
		<option selected="selected" value="8017">Javea (other areas) (51)</option>
		<option value="12650">Javea Arenal (3)</option>
		<option value="8326">Pinosol (2)</option>

	</select>
     
        <span id="ctl00_ContentPlaceHolder1_Locationdropdowns1_lblErrors" style="color:White;font-weight:bold;"></span>
    <asp:ImageButton ID="searchButton1" runat="server" PostBackUrl="/results.aspx" ImageUrl="/images/search_but_up.gif" />    
    
</div>
    
<div id="ctl00_ContentPlaceHolder1_PopularSearches1_lodgetext">
	
    <img src="/Images/1x1_spacer.gif" width="1" height="10" alt="spacer" /><br />
    England > <a href="/results.aspx?region=North_Devon" title="holidays in North Devon">North Devon</a> > <a href="/results.aspx?region=alverdiscott" title="holidays in alverdiscott">alverdiscott</a>
    <br />
    England > <a href="/results.aspx?region=Norfolk" title="holidays in Norfolk">Norfolk</a> > <a href="/results.aspx?region=Great_Yarmouth" title="holidays in great yarmouth">Great Yarmouth</a>
    <br />
    England > <a href="/results.aspx?region=Peak_District" title="holidays in Peak District">Peak District</a> > <a href="/results.aspx?region=Buxton" title="holidays in Buxton">Buxton</a>
    <br />
    <br />
    Scotland > <a href="/results.aspx?region=northern_highlands" title="holidays in northern highlands">Northern Highlands</a>
    <br />
    Scotland > <a href="/results.aspx?region=edinburgh" title="holidays in edinburgh">Edinburgh</a>
    <br />
    Scotland > <a href="/results.aspx?region=Argyll" title="holidays in Argyll">Argyll</a>
    <br />
    <br />
    Wales > <a href="/results.aspx?region=South_Wales" title="holidays in South Wales">South Wales</a>
    <br />
    Wales > <a href="/results.aspx?region=Mid_Wales" title="holidays in Mid Wales">Mid Wales</a>
    <br />
    Wales > <a href="/results.aspx?region=Mid_Glamorgan" title="holidays in Mid Glamorgan">Mid_Glamorgan</a>
</div>


<br /><br />
    </div>
    <div class="search_input_boxes">

        
    <span class="searchbox_text_bold">Popular Destinations</span>



<div id="ctl00_ContentPlaceHolder1_popularlocations2_lodgetext">
	
   <a href="/propertyDetails.aspx?ref=LP2313&productFilter=HH" title="Park holiday in Isle of Wight">
        Gurnard Pines Cowes, Isle of Wight</a><br />
    <br />
    <a href="/propertyDetails.aspx?ref=LP2674&productFilter=HH" title="Park holiday in Devon">
        Lime Kiln Holcombe Rogus, Devon </a>
    <br />
    <br />
    <a href="/propertyDetails.aspx?ref=LP1022&productFilter=HH" title="Park holiday in Wivelscombe">
        Exmoor Gate Waterrow, Wivelscombe</a><br />
    <br />
    <br />
    <a href="/propertyDetails.aspx?ref=LP3251&productFilter=HH" title="Park holiday in Staffordshire">
        Rudyard Lake Lodges Near Leek, Staffordshire </a>
    <br />
    <br />
    <a href="/propertyDetails.aspx?ref=LP2629&productFilter=HH" title="Park holiday in Trimingham, Norfolk">
        Woodland Leisure Park Trimingham, Norfolk</a>
</div>


<br /><br />

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <!--inhere-->    
</asp:Content>



