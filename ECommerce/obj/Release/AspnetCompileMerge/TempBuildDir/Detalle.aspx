<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ECommerce.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
            <div class="col-4">
                <label for="imgArticulo">Imagen </label>
                <div class="mb-3">
                    <img src="<%: (Session["Articulo"] as dominio.Articulo).ImagenUrl %>"  onerror="this.src='https://www.pulsecarshalton.co.uk/wp-content/uploads/2016/08/jk-placeholder-image.jpg'"  Width="400px" Height="550px"/>
                </div>
            </div>
        <div class="col-4">

            <div class="mb-3">
                <label for="tbCodigo" class="form-label">Código </label>
                <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="tbNombre" class="form-label">Nombre del artículo </label>
                <asp:TextBox ID="tbNombre" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="tbDescripcion" class="form-label">Descripción </label>
                <asp:TextBox ID="tbDescripcion" TextMode="MultiLine"
                    CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="tbPrecio">Precio </label>
                <asp:TextBox ID="tbPrecio" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="tbMarca">Marca </label>
                <asp:TextBox ID="tbMarca" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="tbCategoria">Categoría </label>
                <asp:TextBox ID="tbCategoria" CssClass="form-control" runat="server" />
            </div>

        </div>

    </div>
</asp:Content>
