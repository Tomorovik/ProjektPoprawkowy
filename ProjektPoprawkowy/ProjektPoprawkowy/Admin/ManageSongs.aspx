<%@ Page Title="Zarządzaj piosenkami" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSongs.aspx.cs" Inherits="ProjektPoprawkowy.Admin.ManageSongs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div class="container">
        <table class="table table-bordered">
            <tr>
                <td><strong>Najczęściej wybierany utwór</strong></td>
                <td><strong>Najrzadziej wybierany utwór</strong></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="MostPopular"></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="LeastPopular"></asp:Label></td>
            </tr>
        </table>
        <div>
            <asp:Repeater runat="server" ID="SongsListRepeater" OnItemCommand="SongsListRepeater_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                        <tr>
                            <td>Tytuł</td>
                            <td>Autor</td>
                            <td>Rok powstania</td>
                            <td>Długość</td>
                            <td>Akcje</td>
                            <td>Ilosc użytych razy</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" Enabled="False" ID="TitleTB" Text='<%#Eval("Title") %>'></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" Enabled="False" ID="AuthorTB" Text='<%#Eval("Artist") %>'></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" Enabled="False" ID="CreationTB" Text='<%#Eval("Creation") %>'></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" Enabled="False" ID="LengthTB" Text='<%# String.Format($"{Eval("Minutes")}:{Eval("Seconds")}") %> '></asp:TextBox></td>
                        <td>
                            <asp:LinkButton runat="server" ID="UpdateBtn" CommandName="Update" CommandArgument='<%# Eval("Id") %>' Text='Aktualizuj'></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="DeleteBTN" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text='Usun'></asp:LinkButton></td>
                        <td>
                            <asp:Label Text='<%# Eval("TimesPlayed") %>' runat="server"></asp:Label></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
