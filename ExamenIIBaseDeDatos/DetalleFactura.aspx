<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="ExamenIIBaseDeDatos.DetalleFactura" %>

<!DOCTYPE html>
<html lang="es">

<head runat="server">
    <meta charset="UTF-8" />
    <title>Examen 2 | Detalle de Factura</title>
    <link href="CCS/Main.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <header>
            Sistema de Facturación Web | Examen II
        </header>
        <nav class="navbar">
            <ul>
                <li><a href="Inicio.aspx">Inicio</a></li>
                <li><a href="Facturacion.aspx">Facturación</a></li>
                <li><a href="DetalleFactura.aspx">Detalles de la Factura</a></li>
            </ul>
        </nav>

        <div class="container">

            <h2>Detalle de Factura</h2>

            <label>Seleccionar Factura</label>
            <asp:DropDownList ID="ddlFacturas" runat="server" CssClass="input"
                AutoPostBack="True" OnSelectedIndexChanged="ddlFacturas_SelectedIndexChanged">
            </asp:DropDownList>

        </div>

        <!-- GRIDVIEW de los detalles -->
        <h2 style="text-align: center; margin-top: 40px;">Detalles Registrados</h2>

        <div class="container">
            <asp:GridView ID="GridViewDetalles" runat="server" AutoGenerateColumns="False" CssClass="GridView"
                OnSelectedIndexChanged="GridViewDetalles_SelectedIndexChanged">

                <Columns>
                    <asp:BoundField DataField="IdDetalle" HeaderText="ID" />
                    <asp:BoundField DataField="Articulo" HeaderText="Artículo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>

            </asp:GridView>
        </div>

        <div class="container">
            <h2>Editar o Agregar Detalle</h2>

            <label>ID Detalle</label>
            <asp:TextBox ID="txtIdDetalle" runat="server" CssClass="input" ReadOnly="True"></asp:TextBox>

            <label>Artículo</label>
            <asp:TextBox ID="txtArticulo" runat="server" CssClass="input"></asp:TextBox>

            <label>Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="input"></asp:TextBox>

            <label>Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="input"></asp:TextBox>

            <label>Subtotal</label>
            <asp:TextBox ID="txtSubTotal" runat="server" CssClass="input" ReadOnly="True"></asp:TextBox>

            <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar Detalle"
                CssClass="btn" OnClick="btnAgregarDetalle_Click" />

            <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar Detalle"
                CssClass="btn-warning" OnClick="btnModificarDetalle_Click" />

            <asp:Button ID="btnBorrarDetalle" runat="server" Text="Borrar Detalle"
                CssClass="btn-danger" OnClick="btnBorrarDetalle_Click" />
        </div>

        <footer>
            © 2025 UH Examen II | Desarrollado por Justin Padilla
        </footer>

    </form>
</body>

</html>
67