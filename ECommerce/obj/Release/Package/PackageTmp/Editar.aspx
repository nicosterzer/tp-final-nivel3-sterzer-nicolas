<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="ECommerce.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-4">

            <div class="mb-3">
                <label for="tbCodigo">Código </label>
                <asp:TextBox ID="tbCodigo" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="tbCodigo" Display="Static" runat="server" ErrorMessage="Código requerido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="tbNombre">Nombre </label>
                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="tbNombre" Display="Static" runat="server" ErrorMessage="Nombre requerido"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="tbDescripcion">Descripción </label>
                <asp:TextBox ID="tbDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="tbPrecio">Precio </label>
                <asp:TextBox ID="tbPrecio" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ControlToValidate="tbPrecio" Display="Static" runat="server" ErrorMessage="Precio requerido"></asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="col-4">

            <div class="mb-3">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <label for="imgArticulo">Imagen </label>
                        <asp:TextBox ID="tbImagen" CssClass="form-control" OnTextChanged="tbImagen_TextChanged" runat="server" AutoPostBack="true" />
                        <asp:Image ID="imgArticulo" ImageUrl="imageurl" runat="server" AutoPostBack="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="mb-3">
                <label for="ddlMarca">Marca </label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlMarca" Display="Static" runat="server" ErrorMessage="Marca requerida"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria">Categoria </label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="ddlCategoria" Display="Static" runat="server" ErrorMessage="Categoría requerida"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" Text="Agregar" runat="server" />
                <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Text="Eliminar" runat="server" />
            </div>
        </div>
        

    </div>
</asp:Content>
