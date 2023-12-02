<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ECommerce.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ingresar a mi cuenta </h1>
    <div class="row">

        <div class="col-4">

            <div class="mb-3">
                <label for="tbEmail" class="form-label">Email </label>
                <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="tbPass" class="form-label">Contraseña </label>
                <asp:TextBox ID="tbPass" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click"
                    CssClass="btn btn-primary" Text="Ingresar" runat="server" />
                <asp:Button ID="btnInvitado" OnClick="btnInvitado_Click"
                    CssClass="btn btn-outline-success" Text="Ingresar como invitado" runat="server" />
            </div>
            <div class="mb-3">
            </div>
        </div>

    </div>

</asp:Content>
