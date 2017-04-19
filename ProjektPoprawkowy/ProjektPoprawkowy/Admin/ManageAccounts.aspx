<%@ Page Title="Aktywuj konta nowych u¿ytkowników." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="ProjektPoprawkowy.Admin.ManageAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>
        <asp:Repeater runat="server" ID="UserListRepeater" OnItemCommand="UserListRepeater_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <td>Email uzytkownika</td>
                        <td>Stan Aktywnosci</td>
                        <td>Aktywacja</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="EmailLBL" Text='<%#Eval("Email") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" ID="StatusLBL" Text='<%#Eval("IsActive") %>'></asp:Label></td>
                    <td>
                        <asp:LinkButton runat="server" ID="ActivateBTN" CommandName="Activate" CommandArgument='<%# Eval("Id") %>' Text='Aktywuj'></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
