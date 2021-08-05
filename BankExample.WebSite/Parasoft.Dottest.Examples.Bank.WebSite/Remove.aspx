<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="Remove.aspx.cs" Inherits="Remove" Title="Example Bank - Remove"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="AccountLabel" runat="server" Text="Account:"></asp:Label>
    <asp:Label ID="AccountNumberLabel" runat="server" Text="NUMBER"></asp:Label><br/>
    <asp:Label ID="BalanceLabel" runat="server" Text="Balance:"></asp:Label>
    <asp:Label ID="BalanceValueLabel" runat="server" Text="BAL"></asp:Label><br/><br/>

    <asp:Label ID="Label1" runat="server" Text="Use one of following accounts to transfer means from actual account:"></asp:Label><br/> 
    <asp:RadioButtonList ID="rblAccounts" runat="server">
    </asp:RadioButtonList>

    <br/><br/>

    <asp:Button ID="Button1" runat="server" Text="Remove" OnClick="RemoveButton_Click"/>
    
</asp:Content>
