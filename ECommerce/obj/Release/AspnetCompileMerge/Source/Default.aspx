<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .title-center {
            text-align: center;
            font-size: larger;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
        $(document).ready(function () {
            $(".card").on("click", function () {
                var selectedCardID = $(this).data("id");
                $("#<%= SelectedCardID.ClientID %>").val(selectedCardID);
            });
        });
    </script>

    <asp:HiddenField ID="SelectedCardID" runat="server" />
    <div class="title-center">
        <h1>Bienvenido! </h1>
        <p>Mirá algunos de nuestros productos </p>
    </div>

    <div class="row">
        <div class="col-1"></div>
        <div class="col-3">
            <div class="mb-3">
                <asp:TextBox ID="tbFiltro" OnTextChanged="tbFiltro_TextChanged" PlaceHolder="Buscar por nombre" AutoPostBack="true" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:DropDownList ID="ddlMarca" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" runat="server">
                    <asp:ListItem>Samsung </asp:ListItem>
                    <asp:ListItem>Apple </asp:ListItem>
                    <asp:ListItem>Sony </asp:ListItem>
                    <asp:ListItem>Huawei </asp:ListItem>
                    <asp:ListItem>Motorola </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server">
                    <asp:ListItem>Celulares </asp:ListItem>
                    <asp:ListItem>Televisores </asp:ListItem>
                    <asp:ListItem>Media </asp:ListItem>
                    <asp:ListItem>Audio </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-1">
            <asp:Button ID="btnLimpiar" OnClick="btnLimpiar_Click" Text="Limpiar filtros" AutoPostBack="true" CssClass="btn btn-primary" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>

    <div class="col-6">
        <div class="card-container" style="display: inline-flex;">

            <% foreach (dominio.Articulo articulo in listado)

                { %>

            <div class="card" style="width: 16rem; margin: 6px;" data-id="<%: articulo.Id %>">
                <img src="<%: articulo.ImagenUrl %>" onerror="this.src='https://www.pulsecarshalton.co.uk/wp-content/uploads/2016/08/jk-placeholder-image.jpg'" class="card-img-top" height="275rem">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text"><%: articulo.Descripcion %></p>
                    <p class="card-text">$ <%: articulo.Precio %></p>
                    <asp:Button ID="btnDetalle" Text="Ver detalle" CssClass="btn btn-primary"
                        OnClick="btnDetalle_Click" runat="server" />
                </div>
            </div>

            <% }%>
        </div>
    </div>
    

</asp:Content>
