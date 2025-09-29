using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmEditarCliente : Form
    {
        int idcliente;
        CL_Metodos metodos = new CL_Metodos();
        public FrmEditarCliente(int idcliente)
        {
            InitializeComponent();
            this.idcliente = idcliente;
        }
        private void CargarDatosCliente()
        {
            DataTable data = metodos.SeleccionarClienteMod(idcliente);
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                txtDNI.Text = row["Dni"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                txtCodArea.Text = row["CodArea"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCalle.Text = row["DireccionCalle"].ToString();
                txtNumero.Text = row["DireccionAltura"].ToString();
                cmbProvincia.Text = row["Provincia"].ToString();
                cmbLocalidad.Text = row["Localidad"].ToString();
                txtCodPostal.Text = row["CodigoPostal"].ToString();
                txtObservaciones.Text = row["Observaciones"].ToString();
            }
        }

        private void FrmEditarCliente_Load(object sender, System.EventArgs e)
        {
            CargarProvincias();
            CargarLocalidad();
            CargarDatosCliente();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {

        }
        private void CargarProvincias()
        {
            DataTable cacheprovincias = metodos.Provincias();
            cmbProvincia.Items.Clear();
            foreach (DataRow row in cacheprovincias.Rows)
            {
                int id = Convert.ToInt32(row["IdProvincia"]);
                string provincia = row["Provincia"].ToString();
                string info = $"{id} - {provincia}";
                cmbProvincia.Items.Add(info);
            }
        }
        private void CargarCodPostal()
        {
            if (cmbLocalidad.SelectedItem == null) return;
            int idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedItem.ToString().Split('-')[0].Trim());
            int codigopostal = metodos.CodigoPostal(idLocalidad);
            txtCodPostal.Text = codigopostal.ToString();
        }
        private void CargarLocalidad()
        {
            if (cmbProvincia.SelectedItem == null) return;
            cmbLocalidad.Items.Clear();
            int idProvincia = Convert.ToInt32(cmbProvincia.SelectedItem.ToString().Split('-')[0].Trim());
            DataTable cachelocalidad = metodos.Localidades(idProvincia);
            foreach (DataRow row in cachelocalidad.Rows)
            {
                int id = Convert.ToInt32(row["IdLocalidad"]);
                string localidad = row["Localidad"].ToString();
                string info = $"{id} - {localidad}";
                cmbLocalidad.Items.Add(info);
            }
            cmbLocalidad.Enabled = true;
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCodPostal();
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidad();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
