<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" Title="Examples Bank - Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div>
        <asp:Label ID="AccountsLabel" runat="server" Text="Home:"></asp:Label>
        <asp:Table ID="AccountsTable" runat="server">
            <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell runat="server" Width="250px">
                    <asp:Label runat="server" Text="Account number"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="100px">
                    <asp:Label runat="server" Text="Balance"></asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="100px">
                    
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>

