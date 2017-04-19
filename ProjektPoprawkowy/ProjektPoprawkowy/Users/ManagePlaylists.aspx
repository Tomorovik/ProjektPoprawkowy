<%@ Page Title="Odtwórz playlisty" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePlaylists.aspx.cs" Inherits="ProjektPoprawkowy.Users.ManagePlaylists" %>


<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <div class="row">
        <p>Dostępne playlisty:</p>
        <asp:Repeater runat="server" ID="PlaylistsListRepeater" OnItemCommand="PlaylistsListRepeater_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <td>Nazwa playlisty</td>
                        <td>Akcja</td>
                        <td>Godzina ostatniego odtworzenia playlisty</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" Enabled="False" ID="TitleTB" Text='<%#Eval("Name") %>'></asp:TextBox></td>
                    <td>
                        <asp:LinkButton runat="server" ID="PlayBTN" CommandName="Play" CommandArgument='<%# Eval("Id") %>' Text='Odtwórz'></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="DetailsBTN" CommandName="Details" CommandArgument='<%# Eval("Id") %>' Text='Detale'></asp:LinkButton></td>
                    <td>
                        <asp:TextBox runat="server" Enabled="False" ID="CreationTB" TextMode="DateTime" Text='<%#Eval("LastPlayingTime") %>'></asp:TextBox></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
