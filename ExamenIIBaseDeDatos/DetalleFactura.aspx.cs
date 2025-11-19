using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExamenIIBaseDeDatos
{
    public partial class DetalleFactura : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["PRESUPUESTOConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFacturas();
            }
        }
        void CargarFacturas()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT ID FROM Factura", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlFacturas.DataSource = dt;
                ddlFacturas.DataTextField = "ID";
                ddlFacturas.DataValueField = "ID";
                ddlFacturas.DataBind();
            }

            CargarDetalles();
        }

        void CargarDetalles()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT IdDetalle, Articulo, Precio, Cantidad, SubTotal " +
                "FROM DetalleFactura WHERE IdFactura = @id", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@id", ddlFacturas.SelectedValue);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewDetalles.DataSource = dt;
                GridViewDetalles.DataBind();
            }
        }

        protected void ddlFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDetalles();
        }

        protected void GridViewDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewDetalles.SelectedRow;

            txtIdDetalle.Text = row.Cells[0].Text;    
            txtArticulo.Text = row.Cells[1].Text;
            txtPrecio.Text = row.Cells[2].Text;
            txtCantidad.Text = row.Cells[3].Text;
            txtSubTotal.Text = row.Cells[4].Text;
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            decimal precio = decimal.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);
            decimal subtotal = precio * cantidad;

            txtSubTotal.Text = subtotal.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO DetalleFactura (IdFactura, Articulo, Precio, Cantidad) " +
                    "VALUES (@idFactura, @articulo, @precio, @cantidad)", conn);

                cmd.Parameters.AddWithValue("@idFactura", ddlFacturas.SelectedValue);
                cmd.Parameters.AddWithValue("@articulo", txtArticulo.Text);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarDetalles();
        }

        protected void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE DetalleFactura SET Articulo=@articulo, Precio=@precio, Cantidad=@cantidad " +
                    "WHERE IdDetalle=@idDetalle", conn);

                cmd.Parameters.AddWithValue("@idDetalle", txtIdDetalle.Text);
                cmd.Parameters.AddWithValue("@articulo", txtArticulo.Text);
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@cantidad", int.Parse(txtCantidad.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarDetalles();
        }

        protected void btnBorrarDetalle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM DetalleFactura WHERE IdDetalle=@idDetalle", conn);

                cmd.Parameters.AddWithValue("@idDetalle", txtIdDetalle.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarDetalles();
        }
    }
}
