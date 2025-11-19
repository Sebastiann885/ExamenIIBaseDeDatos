<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="ExamenIIBaseDeDatos.Inicio" %>


<!DOCTYPE html>
<script runat="server">
</script>

<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Examen 2 | Sistema Web</title>
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
            <h2>Registrar Cliente</h2>

            <label>ID Cliente</label>
            <asp:TextBox ID="txtID" runat="server" CssClass="input"></asp:TextBox>

            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input"></asp:TextBox>

            <label>Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="input"></asp:TextBox>

            <label>Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="input"></asp:TextBox>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente"
                CssClass="btn" OnClick="btnAgregar_Click" />

            <asp:Button ID="btnModificar" runat="server" Text="Modificar Cliente"
                CssClass="btn-warning" OnClick="btnModificar_Click" />

            <asp:Button ID="btnBorrar" runat="server" Text="Borrar Cliente"
                CssClass="btn-danger" OnClick="btnBorrar_Click" />
        </div>

        <h2 style="text-align: center; margin-top: 40px;">Clientes Registrados</h2>

        <div class="container">
            <h2>Clientes Registrados</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="GridView"></asp:GridView>
        </div>

        <footer>
            © 2025 UH Examen II | Desarrollado por Justin Padilla
        </footer>

    </form>
</body>
</html>
