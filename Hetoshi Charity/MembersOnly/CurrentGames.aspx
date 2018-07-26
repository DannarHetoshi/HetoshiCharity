<%@ Page Language="C#" MasterPageFile="~/HetoshiMaster.master" AutoEventWireup="true" CodeFile="CurrentGames.aspx.cs" Inherits="CurrentGames" Title="Current Games"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Here are the games I'm playing: </h3>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" style="max-width: 818px;">
            <ajaxToolkit:TabPanel ID="dummyPanel" runat="server" HeaderText="Games" enabled="true">
                <ContentTemplate>
                    <h6 style="font: 16px arial;">Here you will find the Wikipedia entry for all of the games I'm currently playing as a part of my Extra-Life Fundraiser.</h6>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="League of Legends">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/League_of_Legends?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Dishonored (Series)">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/Dishonored?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Path of Exile">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/Path_of_Exile?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Civilization VI">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/Civilization_VI?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Subnautica">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/Subnautica?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="Stardew Valley">
                <ContentTemplate>
                    <iframe class="iFrameContent" src="https://en.wikipedia.org/wiki/Stardew_Valley?printable=yes"></iframe>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    <p>Your donation is tax-deductible and will make miracles happen for families who desperately need them. Click the "Support My Charity" button at the top of this page to make a safe and easy online donation.&nbsp;</p> 
	<p></p>
</asp:Content>

