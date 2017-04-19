<%@ Page Title="Detale playlisty" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaylistDetails.aspx.cs" Inherits="ProjektPoprawkowy.Users.PlaylistDetails" %>


<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="container">
        <div>
            <asp:Repeater runat="server" ID="SongsListRepeater">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                        <tr>
                            <td>Tytuł</td>
                            <td>Autor</td>
                            <td>Rok powstania</td>
                            <td>Długość</td>
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
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td>Łączny czas playlisty:</td>
                        <td><asp:Label ID="TotalPlaylistTime" runat="server"></asp:Label></td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
