using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenIIBaseDeDatos
{
    public partial class Facturacion : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["PRESUPUESTOConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientesDDL();
                CargarFacturas();
            }
        }

        // ==========================
        // CARGAR CLIENTES EN DROPDOWN
        // ==========================
        void CargarClientesDDL()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Nombre FROM Cliente", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlClientes.DataSource = dt;
                ddlClientes.DataTextField = "Nombre";   // Lo que se muestra
                ddlClientes.DataValueField = "ID";      // El ID real del cliente
                ddlClientes.DataBind();
            }
        }

        // ==========================
        // CARGAR FACTURAS
        // ==========================
        void CargarFacturas()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT F.ID, F.Fecha, F.Cajero, C.Nombre AS Cliente " +
                "FROM Factura F INNER JOIN Cliente C ON F.IdCliente = C.ID", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewFactura.DataSource = dt;
                GridViewFactura.DataBind();
            }
        }

        // ==========================
        // AGREGAR FACTURA
        // ==========================
        protected void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Factura (Cajero, IdCliente) VALUES (@cajero, @cliente)", conn);

                cmd.Parameters.AddWithValue("@cajero", txtCajero.Text);
                cmd.Parameters.AddWithValue("@cliente", ddlClientes.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarFacturas();
        }

        // ==========================
        // MODIFICAR FACTURA
        // ==========================
        protected void btnModificarFactura_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Factura SET Cajero=@cajero, IdCliente=@cliente WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@id", txtFacturaID.Text);
                cmd.Parameters.AddWithValue("@cajero", txtCajero.Text);
                cmd.Parameters.AddWithValue("@cliente", ddlClientes.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarFacturas();
        }

        // ==========================
        // BORRAR FACTURA
        // ==========================
        protected void btnBorrarFactura_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Factura WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@id", txtFacturaID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarFacturas();
        }
    }
}
