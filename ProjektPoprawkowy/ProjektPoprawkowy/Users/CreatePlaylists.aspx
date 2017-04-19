<%@ Page Title="Stwórz swoją nowa playliste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlaylists.aspx.cs" Inherits="ProjektPoprawkowy.Users.CreatePlaylists" %>


<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <p>Stworz liste:</p>
                <table class="table table-striped table-bordered ">
                    <tr>
                        <td>
                            <asp:RadioButton Checked="True" ID="RandomRB" Text="Losowo" runat="server" GroupName="Playlist" /></td>
                        <td>
                            <asp:TextBox ID="AmountTB" TextMode="Number"  runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="AmountTB" ErrorMessage="Musi być pomiędzy 0-999" MaximumValue="999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="ByTimeRB" Text="Wg czasu [min](+/-200s)" runat="server" GroupName="Playlist" />
                        </td>
                        <td>
                            <asp:TextBox ID="TimeTB" TextMode="Number" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Musi być między 0-999" MaximumValue="999" MinimumValue="0" Type="Integer" ControlToValidate="TimeTB"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="ByAuthorRB" Text="Wg autora" runat="server" GroupName="Playlist" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ArtistDDL"  runat="server" />
                            <asp:RadioButton Checked="True" ID="RandomOrderRB" GroupName="OrderRB" Text="Losowo" runat="server"/>
                            <asp:RadioButton ID="TitleOrderRB" GroupName="OrderRB" Text="Tytuł" runat="server"/>
                            <asp:RadioButton ID="CreationOrderdRB" GroupName="OrderRB" Text="Rok powstania" runat="server"/>
                            <asp:RadioButton ID="LengthOrderRB" GroupName="OrderRB" Text="Czas" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Generate" OnClick="Generate_OnClick" CssClass="btn btn-info" Text="Generuj playliste" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="PlaylistNameTB" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PlaylistNameTB" ErrorMessage="Wymagana nazwa!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                </table>
            </div>
        </div>

    </div>

</asp:Content>
