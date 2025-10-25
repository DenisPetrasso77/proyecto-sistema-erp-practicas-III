using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

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
            if (CV_Utiles.CamposNumericos(txtNombre,txtApellido))
                {
                MessageBox.Show("Los campos Nombre y Apellido no pueden ser numericos.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CV_Utiles.TextboxVacios(txtNombre, txtApellido, txtDNI, txtCorreo, txtCodArea, txtTelefono, txtCalle, txtNumero) || CV_Utiles.ComboboxVacios(cmbProvincia, cmbLocalidad))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Completar Campos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                IdUsuario = idusuario,
                IdCliente = idcliente
            };
            string resultado = metodos.ModificarCliente(cliente);
            MessageBox.Show(resultado);
            this.Close();
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

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (!CV_Utiles.CampoMail(txtCorreo.Text))
            {
                MessageBox.Show("El formato del correo es incorrecto.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
            }
        }

        private void txtCodArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmEditarCliente_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.AplicarTemaAControles(this);
            UI_Utilidad.GuardarColoresOriginales(this);
            UI_Utilidad.AplicarTemaATodosLosForms();

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCancelar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregar);

        }
    }
}
