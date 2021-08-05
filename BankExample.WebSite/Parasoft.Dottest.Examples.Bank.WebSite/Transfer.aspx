<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Transfer.aspx.cs" Inherits="Transfer" Title="Example Bank - Transfer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="AccountLabel" runat="server" Text="Account:"></asp:Label>
    <asp:Label ID="AccountNumberLabel" runat="server" Text="Account"></asp:Label><br/>
    <asp:Label ID="BalanceLabel" runat="server" Text="Balance:"></asp:Label>
    <asp:Label ID="BalanceValueLabel" runat="server" Text="Balance"></asp:Label><br/>

    <asp:Label ID="TargetAccountLabel" runat="server" Text="Target Account:"></asp:Label>
    <asp:TextBox ID="TargetAccountTextBox" runat="server"></asp:TextBox><br/>

    <asp:Label ID="AmountLabel" runat="server" Text="Amount:"></asp:Label>
    <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox><br/>
    <br />
    <asp:Button ID="TransferButton" runat="server" Text="Transfer" OnClick="TransferButton_Click" />
    <br />
    <br />
    <asp:Label ID="UsersAccountsLabel" runat="server" Text="Your accounts:"></asp:Label>
    <asp:Table ID="UsersAccountsTable" runat="server">
        <asp:TableHeaderRow ID="UsersAccountsTableHeaderRow" runat="server">
            <asp:TableHeaderCell ID="UsersAccountsTableNumberHeaderCell" runat="server" Width="250px">
                <asp:Label ID="UsersAccountsTableNumberHeaderLabel" runat="server" Text="Account number"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell ID="UsersAccountsTableBalanceHeaderCell" runat="server" Width="100px">
                <asp:Label ID="UsersAccountsTableBalanceHeaderLabel" runat="server" Text="Balance"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell ID="UsersAccountsTableUseButtonHeaderCell" runat="server" Width="60px">
                
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>