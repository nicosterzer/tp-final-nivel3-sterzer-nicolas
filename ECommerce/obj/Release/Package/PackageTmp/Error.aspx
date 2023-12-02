<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ECommerce.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="title-center">
        <h1>Ha ocurrido un error </h1>
        <asp:Label Text="Error" ID="lbError" runat="server" CssClass="form-label"/>
    </div>

</asp:Content>
