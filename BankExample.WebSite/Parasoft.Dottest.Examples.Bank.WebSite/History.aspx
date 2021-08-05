<%@ Page  MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="History" Title="Example Bank - History"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="AccountLabel" runat="server" Text="Account:"></asp:Label>
    <asp:Label ID="AccountNumberLabel" runat="server" Text="NUMBER"></asp:Label><br/>
    <asp:Label ID="BalanceLabel" runat="server" Text="Balance:"></asp:Label>
    <asp:Label ID="BalanceValueLabel" runat="server" Text="BAL"></asp:Label><br/>
    
    <asp:Table ID="HistoryTable" runat="server" >
        <asp:TableHeaderRow ID="HistoryTableHeader" runat="server">
            <asp:TableHeaderCell ID="HistoryTableTime" runat="server">
                <asp:Label ID="HistoryTableTimeLabel" runat="server" Text="Date/time" Width="100px"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HistoryTableKind" runat="server">
                <asp:Label ID="HistoryTableKindLabel" runat="server" Text="Kind" Width="200px"></asp:Label>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HistoryTableAmount" runat="server">
                <asp:Label ID="HistoryTableAmountLabel" runat="server" Text="Amount" Width="100px"></asp:Label>
            </asp:TableHeaderCell>                
            <asp:TableHeaderCell ID="HistoryTableAmountFee" runat="server">
                <asp:Label ID="HistoryTableAmountFeeLabel" runat="server" Text="Fee" Width="60px"></asp:Label>
            </asp:TableHeaderCell>                                
        </asp:TableHeaderRow>
        
    </asp:Table>
</asp:Content>