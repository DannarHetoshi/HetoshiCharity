<%@ Page Title="" Language="C#" MasterPageFile="~/HetoshiMaster.master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="body">
        <div class="heading2donordriveevent">
            <h1>Create Account</h1>
        </div>
    </div>
    <div id="Create_New_Account">
        <table id="createNewAccountTable">
            <tr>
                <td><asp:Label ID="UserName" runat="server" Text="User Name:" /></td>
                <td><asp:TextBox id="uNameTxt" runat="server"/></td>
                <asp:RequiredFieldValidator ID="UserNameRV" runat="server" ErrorMessage="RequiredFieldValidator" 
                        ControlToValidate="uNameTxt" Text="User Name Required!" />
            </tr>
            <tr>
                <td><asp:Label ID="Password" runat="server" Text="Password:" /></td>
                <td><asp:TextBox id="uPasswordTxt" runat="server" TextMode="Password"/></td>
                <asp:RequiredFieldValidator ID="PasswordRV" runat="server" ErrorMessage="RequiredFieldValidator" 
                    ControlToValidate="uPasswordTxt" Text="Password Required!" />
            </tr>
            <tr>
                <td><asp:Label ID="ConfirmPassword" runat="server" Text="Confirm Password:" /></td>
                <td><asp:TextBox ID="uCNFPasswordTxt" runat="server" TextMode="Password"/></td>
                <asp:CompareValidator ID="PasswordCV" runat="server" ErrorMessage="CompareValidator" 
                    ControlToCompare="uPasswordTxT" ControlToValidate="uCNFPasswordTxt" />
            </tr>
            <tr>
                <td><asp:Label ID="Email" runat="server" Text="Email:" /></td>
                <td><asp:TextBox ID="uEmailTxt" runat="server"/></td>
                <asp:RequiredFieldValidator ID="EmailRV" runat="server" ErrorMessage="RequiredFieldValidator" 
                    ControlToValidate="uEmailTxt" Text="Email Required!" />
            </tr>
            <tr>
                <td><asp:Label ID="Question" runat="server" Text="Security Question:" /></td>
                <td><asp:TextBox ID="userQuestion" runat="server"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Answer" runat="server" Text="Security Answer:" /></td>
                <td><asp:TextBox ID="userAnswer" runat="server"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Block">
                        <ContentTemplate>
                            <asp:Button ID="RegistrationButton" type="submit" runat="server" Text="Create Account" OnClick="RegistrationButton_Click" CausesValidatio="True" UseSubmitBehavior="false"></asp:Button>   
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>



        <%--<div id="Label Test">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
        </div>--%>

        <div id="AccountValidation">
            <asp:TextBox ID="createAccountValidation" runat="server" ></asp:TextBox>
        </div>
        
        <%--        <asp:TemplateField HeaderText="Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="UserPassword" runat="server" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" Enabled="false" runat="server" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Confirm Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="ConfirmUserPassword" runat="server" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID ="TextBox3" Enabled="false" runat="server" TextMode="Password" Text='<%# Bind("ConfirmPassword") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" CancelText="" DeleteText="" EditText="" InsertText="Create Account" NewText="" SelectText="" ShowCancelButton="false" ShowInsertButton="true" UpdateText="">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>--%>
    </div>

</asp:Content>


