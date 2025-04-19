using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Crud_LAB5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            CargarClientes();
        }

        string connectionString = "Data Source=DESKTOP-GB9MITO; Initial Catalog=Neptuno; User ID=luis; Password=123456; TrustServerCertificate=True; Integrated Security = True";

        private void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarClientesActivos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgClientes.ItemsSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
            }
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClientes.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgClientes.SelectedItem;

                txtIdCliente.Text = row["idCliente"].ToString();
                txtNombreCompañia.Text = row["NombreCompañia"].ToString();
                txtNombreContacto.Text = row["NombreContacto"].ToString();
                txtCargoContacto.Text = row["CargoContacto"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtCiudad.Text = row["Ciudad"].ToString();
                txtRegion.Text = row["Region"].ToString();
                txtCodPostal.Text = row["CodPostal"].ToString();
                txtPais.Text = row["Pais"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtFax.Text = row["Fax"].ToString();
            }
        }


        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idCliente", txtIdCliente.Text);
                    cmd.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                    cmd.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                    cmd.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente agregado correctamente.");
                    CargarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ModificarCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idCliente", txtIdCliente.Text);
                    cmd.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                    cmd.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                    cmd.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente modificado correctamente.");
                    CargarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar cliente: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarCliente", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", txtIdCliente.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado lógicamente.");
                    CargarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdCliente.Clear();
            txtNombreCompañia.Clear();
            txtNombreContacto.Clear();
            txtCargoContacto.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtRegion.Clear();
            txtCodPostal.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtFax.Clear();
        }

        private void LimpiarCampos()
        {
            txtIdCliente.Clear();
            txtNombreCompañia.Clear();
            txtNombreContacto.Clear();
            txtCargoContacto.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtRegion.Clear();
            txtCodPostal.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtFax.Clear();
        }
    }
}