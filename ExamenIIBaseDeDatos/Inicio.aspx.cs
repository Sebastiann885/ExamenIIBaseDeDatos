using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenIIBaseDeDatos
{

    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        string connStr = ConfigurationManager.ConnectionStrings["PRESUPUESTOConnectionString"].ConnectionString;
        void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Cliente (Nombre, Telefono, Direccion) VALUES (@n, @t, @d)", conn);

                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@d", txtDireccion.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarClientes();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Cliente SET Nombre=@n, Telefono=@t, Direccion=@d WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@d", txtDireccion.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarClientes();

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Cliente WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@id", txtID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarClientes();
        }


    }
}