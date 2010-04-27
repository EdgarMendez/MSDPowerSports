<%@ Page Language="VB" MasterPageFile="~/MSDMain.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" title="MSD Ignition" %>
<%@ Register TagPrefix="CMS" Namespace="Ektron.Cms.Controls" Assembly="Ektron.Cms.Controls" %>

<asp:Content ID="ContentMSD" ContentPlaceHolderID="ContentPlaceHolderMSD" Runat="Server">
    

<div id="mainWrapperRow" style="margin:0 0; padding:0 0; width:790px;"> 
<div id="MainBanner" style="width:815px; text-align:center; margin:0 0 0 0">
	<CMS:Collection CacheInterval="20" DefaultCollectionID="19" GetHtml="true" Random="true" ID="CollectionMSDBanner" runat="server" />
</div>
    
	<div id="leftMain" style="width:560px; float:left; margin:0;overflow: hidden; ">
	
	<div id="newsHome" style="float:left; ">
	
	<style>
		
		div.blogHeader
		{
		background-color:#FFFFFF;
		}
		h1.blogTitle
		{
		font: normal 9px Verdana, Arial, Helvetica, sans-serif;
		padding-left: 20px;
		padding-top: 7px;
		margin: 0px;
		height: 0px;
		}
		
		
	</style>
	
    <CMS:BlogEntries DisplayXslt="xmlfiles/MSD-BlogSummary.xsl" BlogID="429" ID="BlogEntriesMSD" runat="server" />
	</div>
	</div>
    <asp:Label ID="rightMain" CssClass="rightMain" runat="server" >
    
    	<img src="images/social_media.jpg" alt="Social Media" border="0" usemap="#Map" />
        <map name="Map" id="Map">
          <area shape="rect" coords="4,26,34,55" href="http://www.youtube.com/user/MSDvideosdotcom" target="_blank" alt="YouTube.com" />
        <area shape="rect" coords="41,25,71,54" href="http://www.facebook.com/pages/MSD-Ignition/17287208333?_fb_noscript=1" target="_blank" alt="Facebook" />
        <area shape="rect" coords="119,24,148,53" href="http://www.hubgarage.com/mygarage/MSDgarage/vehicles" target="_blank" alt="HubGarage" />
        <area shape="rect" coords="157,24,186,53" href="http://user.streetfire.net/profile/MSDIgnition.htm" target="_blank" alt="StreetFire.net" /><area shape="rect" coords="80,24,112,54" href="http://twitter.com/MSDignition" target="_blank" alt="Twitter" />
        <area shape="rect" coords="196,23,227,53" href="http://www.msdignition.com/WorkArea/blogs/blogrss.aspx?blog=429" target="_self" alt="MSD News Feed" />
        </map>
        
        
        
        <a href=http://www.msdignition.com/form.aspx?ekfrm=14638>
        <img alt="2010 MSD Ignition Car Show" src="images/banners/CarShow2010.gif" 
            style="width: 230px; height: 280px" border="0"/></a>
        
      

		
       <h5>NEW PRODUCTS FOR 2010</h5>
		<CMS:Collection DefaultCollectionID="20"  CssClass="feedBlockProducts" DisplayXslt="xmlfiles/MSD-CollectionList.xsl" ID="CollectionMSDNewProducts" runat="server" /><br />

		
        <CMS:Collection  DefaultCollectionID="17" GetHtml="true" Random="true" ID="CollectionMSD" runat="server" />   
		<h5>POLL QUESTION</h5>
		<td><CMS:Poll CssClass="feedBlock"  PollID="15836" ID="MSDPoll" runat="server" /></td>
		<br />	
		
		
        
		
       				
		<h5>FORUM FEED</h5>
		<td><cms:RssAggregator CssClass="feedBlockForum" WrapTag="div" id="RssAggregatorMSD" runat="server"  URL="http://apps.msdignition.com/forum/external.php?type=rss2" ></cms:RssAggregator></td>
		
		<CMS:AnalyticsTracker ID="AnalyticsTrackerMSD" runat="server" EnableAnalytics="ConfigSpecified" />
        
	
   </asp:Label>
	  
	

	
	</div>
	
	  		

</asp:Content>

