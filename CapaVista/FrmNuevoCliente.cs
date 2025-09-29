using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmNuevoCliente : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidad();
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

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCodPostal();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtNombre, txtApellido, txtDNI, txtCorreo, txtCodArea, txtTelefono, txtCalle, txtNumero) || CV_Utiles.ComboboxVacios(cmbProvincia,cmbLocalidad))
            { 
                MessageBox.Show("Por favor, complete todos los campos.","Completar Campos",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string dni = txtDNI.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                int codigoarea = Convert.ToInt32(txtCodArea.Text);
                string telefono = txtTelefono.Text;
                string direccioncalle = txtCalle.Text.Trim();
                int direccionaltura = Convert.ToInt32(txtNumero.Text);
                int idprovincia = Convert.ToInt32(cmbProvincia.SelectedItem.ToString().Split('-')[0].Trim());
                int idlocalidad = Convert.ToInt32(cmbLocalidad.SelectedItem.ToString().Split('-')[0].Trim());
                int codigopostal = Convert.ToInt32(txtCodPostal.Text.ToString());
                string observaciones = txtObservaciones.Text;
                int idusuario = Sesion.Usuario.IdUsuario;
                Cliente cliente = new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni,
                    Correo = correo,
                    CodigoArea = codigoarea,
                    Telefono = Convert.ToInt32(telefono),
                    DireccionCalle = direccioncalle,
                    DireccionAltura = direccionaltura,
                    DireccionProvincia = idprovincia,
                    DireccionLocalidad = idlocalidad,
                    DireccionCodigoPostal = codigopostal,
                    Observaciones = observaciones,
                    IdUsuario = idusuario
                };
                string resultado = metodos.InsertarCliente(cliente);
                MessageBox.Show(resultado);
                CV_Utiles.LimpiarFormulario(this);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
