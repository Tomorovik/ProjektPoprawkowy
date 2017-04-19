<%@ Page Title="Dodawanie utworu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSong.aspx.cs" Inherits="ProjektPoprawkowy.Admin.AddSong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Podaj dane utworu.</h2>
        <div class="form-inline container">
            <hr />
            <div class=" col-lg-12">
                <div class="col-lg-12">
                    <asp:Button runat="server" ID="SaveBTN" OnClick="AddToDB" Text="Dodaj do bazy" CssClass="btn btn-info" />
                </div>
            </div>
            <div class="form-group">
                <div class="form-group col-md-3">
                    <asp:Label runat="server" AssociatedControlID="TitleTB" CssClass="col-md-12 control-label ">Tytuł</asp:Label>
                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="TitleTB" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="TitleTB"
                            CssClass="text-danger"
                            ErrorMessage="Tytuł jest wymagany."
                            Display="Dynamic" />
                        <asp:RegularExpressionValidator runat="server"
                            CssClass="text-danger" ErrorMessage="Tytuł jest wymagany."
                            ID="TitleValidator"
                            ValidationExpression="[\w\d\s\S]+"
                            ControlToValidate="TitleTB"
                            Display="Dynamic" />
                    </div>
                </div>
                <div class="form-group col-md-3">
                    <asp:Label runat="server" AssociatedControlID="AuthorTB" CssClass="col-md-12 control-label ">Autor</asp:Label>
                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="AuthorTB" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="AuthorTB"
                            CssClass="text-danger"
                            ErrorMessage="Autor jest wymagany."
                            Display="Dynamic" />
                        <asp:RegularExpressionValidator runat="server"
                            CssClass="text-danger" ErrorMessage="Autor jest wymagany."
                            ID="AuthorValidator"
                            ValidationExpression="[\w\d\s\S]+"
                            ControlToValidate="AuthorTB"
                            Display="Dynamic" />
                    </div>
                </div>
                <div class="form-group col-md-3">
                    <asp:Label runat="server" AssociatedControlID="CreationTB" CssClass="col-md-12 control-label ">Rok powstania(>1000)</asp:Label>
                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="CreationTB" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="CreationTB"
                            CssClass="text-danger"
                            ErrorMessage="Rok powstania jest wymagany."
                            Display="Dynamic" />
                        <asp:RegularExpressionValidator runat="server"
                            CssClass="text-danger"
                            ID="CreationValidator"
                            ValidationExpression="^(1[0-9]{3})|(20[0|1][0-7])$"
                            ControlToValidate="CreationTB"
                            ErrorMessage="Rok powstania jest wymagany."
                            Display="Dynamic" />
                    </div>
                </div>
                <div class="form-group col-md-3">
                    <asp:Label runat="server" AssociatedControlID="LengthTB" CssClass="col-md-12 control-label ">Długość (min:sek)</asp:Label>
                    <div>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="LengthTB" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="LengthTB"
                                CssClass="text-danger"
                                ErrorMessage="Długość utworu jest wymagana."
                                Display="Dynamic" />
                            <asp:RegularExpressionValidator runat="server"
                                CssClass="text-danger"
                                ID="LengthValidator"
                                ValidationExpression="^([0-9]+:)?([0-5]?\d)$"
                                ControlToValidate="LengthTB"
                                ErrorMessage="Długość utworu jest wymagana."
                                Display="Dynamic" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
