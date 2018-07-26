<%@ Page Language="C#" MasterPageFile="~/HetoshiMaster.master" AutoEventWireup="true" CodeFile="OnlyRegisteredCanSeeThis.aspx.cs" Inherits="OnlyRegisteredCanSeeThis" Title="Logged In Users Section" %>
<%@ MasterType VirtualPath="~/HetoshiMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Here's how it works</h3> 
    <ul> 
        <li><p class="big"><asp:Label ID="Welcome" runat="server"></asp:Label></p> </li> 
        <li><p class="big">This is a landing page for users that have registered and Logged In.  Eventually this will be the start of a registered users only forum.</p> </li> 
    </ul> 
</asp:Content>

