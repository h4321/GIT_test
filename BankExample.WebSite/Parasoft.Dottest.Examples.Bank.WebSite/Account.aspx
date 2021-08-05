<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" Title="Examples Bank - Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="AccountLabel" runat="server" Text="Account:"></asp:Label>
    <asp:Label ID="AccountNumberLabel" runat="server" Text="Account"></asp:Label><br/>
    <asp:Label ID="BalanceLabel" runat="server" Text="Balance:"></asp:Label>
    <asp:Label ID="BalanceValueLabel" runat="server" Text="Balance"></asp:Label><br/><br/>
    
    <asp:Button ID="TransferButton" runat="server" Text="Transfer" OnClick="TransferButton_Click" />
    <asp:Button ID="HistoryButton" runat="server" Text="History" OnClick="HistoryButton_Click" />
</asp:Content>
