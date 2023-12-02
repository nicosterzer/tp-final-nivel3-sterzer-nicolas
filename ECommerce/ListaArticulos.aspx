<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ECommerce.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 style="text-align: center;">Listado de artículos  </h1>

    <div class="row">
        <div class="col-2"></div>
        <div class="col-2">
            <div class="mb-3">
                <asp:TextBox ID="tbFiltro" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="tbFiltro_TextChanged" PlaceHolder="Buscar por nombre" />
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:DropDownList ID="ddlMarca" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged">
                    <asp:ListItem>Samsung </asp:ListItem>
                    <asp:ListItem>Apple </asp:ListItem>
                    <asp:ListItem>Sony </asp:ListItem>
                    <asp:ListItem>Huawei </asp:ListItem>
                    <asp:ListItem>Motorola </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                    <asp:ListItem>Celulares </asp:ListItem>
                    <asp:ListItem>Televisores </asp:ListItem>
                    <asp:ListItem>Media </asp:ListItem>
                    <asp:ListItem>Audio </asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <asp:Button ID="btnLimpiar" OnClick="btnLimpiar_Click" Text="Limpiar filtros" AutoPostBack="true" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>
    <div class="col-2"></div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <asp:UpdatePanel runat="server">
                <contenttemplate>
                    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="false" DataKeyNames="Id"
                        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                        AllowPaging="true" PageSize="5" AutoPostBack="true">

                        <columns>
                            <asp:BoundField HeaderText="Código" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Editar" />
                        </columns>

                    </asp:GridView>
                </contenttemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
    </div>
</asp:Content>
