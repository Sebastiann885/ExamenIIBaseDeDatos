<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="ExamenIIBaseDeDatos.Facturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Facturación</title>
    <link href="CCS/Main.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <header>
            Sistema de Facturación Web
        </header>


        <nav class="navbar">
            <ul>
                <li><a href="Inicio.aspx">Inicio</a></li>
                <li><a href="Facturacion.aspx">Facturación</a></li>
                <li><a href="DetalleFactura.aspx">Detalles de la Factura</a></li>
            </ul>
        </nav>


        <div class="container">
            <h2>Registrar Factura</h2>

            <label>ID Factura</label>
            <asp:TextBox ID="txtFacturaID" runat="server" CssClass="input"></asp:TextBox>

            <label>Cajero</label>
            <asp:TextBox ID="txtCajero" runat="server" CssClass="input"></asp:TextBox>

            <label>Cliente</label>
            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="input"></asp:DropDownList>

            <asp:Button ID="btnAgregarFactura" runat="server" Text="Agregar Factura" CssClass="btn"
                OnClick="btnAgregarFactura_Click" />

            <asp:Button ID="btnModificarFactura" runat="server" Text="Modificar Factura" CssClass="btn-warning"
                OnClick="btnModificarFactura_Click" />

            <asp:Button ID="btnBorrarFactura" runat="server" Text="Borrar Factura" CssClass="btn-danger"
                OnClick="btnBorrarFactura_Click" />
        </div>


        <div class="container">
            <h2>Listado de Facturas</h2>
            <asp:GridView ID="GridViewFactura" runat="server" AutoGenerateColumns="true" CssClass="GridView"></asp:GridView>
        </div>

        <footer>
            © 2025 Sistema de Facturación | Desarrollado por Justin Padilla
        </footer>

    </form>
</body>
</html>
