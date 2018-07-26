<%@ Page Language="C#" MasterPageFile="~/HetoshiMaster.master" AutoEventWireup="true" CodeFile="TwitchTV.aspx.cs" Inherits="TwitchTV" Title="TwitchTV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3><a href="https://www.twitch.tv/DannarHetoshi">Watch me Live on Twitch TV!</a></h3> 
                
        <div id="twitch-embed"></div>
        <script src="https://embed.twitch.tv/embed/v1.js"></script>
    
        <!-- Create a Twitch.Embed object that will render within the "twitch-embed" root element. -->
        <script type="text/javascript">
            new Twitch.Embed("twitch-embed", {
                width: 854,
                height: 480,
                channel: "DannarHetoshi",
                chat: "mobile",
                theme: "dark",
            });

            embed.addEventListener(Twitch.Embed.VIDEO_READY, () => {
                var player = embed.getPlayer();
                player.play();
            });
        </script>
    <p>Your donation is tax-deductible and will make miracles happen for families who desperately need them. Click the "Support My Charity" button at the top of this page to make a safe and easy online donation.&nbsp;</p> 
	<p></p>
</asp:Content>

