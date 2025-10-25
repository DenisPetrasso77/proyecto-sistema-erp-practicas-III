using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmNuevoProveedor : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        bool _limpiando;
        public FrmNuevoProveedor()
        {
            InitializeComponent();
        }
        private void CargarProvincias()
        {
            CV_Utiles.LimpiarControles(cmbProvincia);
            DataTable cacheprovincias = metodos.SeleccionarProvincias();
            foreach (DataRow filas in cacheprovincias.Rows)
            {
                string fila = $"{filas["IdProvincia"]} - {filas["Provincia"]}";
                cmbProvincia.Items.Add(fila);
            }
        }
        private void CargarLocalidades(int id)
        {
            CV_Utiles.LimpiarControles(cmbLocalidad);
            DataTable cacheLocalidades = metodos.Localidades(id);
            foreach (DataRow filas in cacheLocalidades.Rows)
            {
                string fila = $"{filas["IdLocalidad"]} - {filas["Localidad"]}";
                cmbLocalidad.Items.Add(fila);
            }
        }

        private void FrmNuevoProveedor_Load(object sender, EventArgs e)
        {
            CargarProvincias();

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_limpiando) { return; }

            if (cmbProvincia.Text != null)
            {
                int idprovincia = Convert.ToInt32(cmbProvincia.Text.Split('-')[0].Trim());
                CargarLocalidades(idprovincia);
                cmbLocalidad.Enabled = true;
            }
            else
            {
                CV_Utiles.LimpiarControles(cmbProvincia);
                cmbLocalidad.Enabled = false;
            }
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_limpiando) { return; }

            if (cmbLocalidad.Text != null)
            {
                int idlocalidad = Convert.ToInt32(cmbLocalidad.Text.Split('-')[0].Trim());
                txtCodPostal.Text = metodos.CodigoPostal(idlocalidad).ToString();
            }
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtRazonSocial, txtCUIT, txtCodPostal, txtTelefono, txtCalle, txtNumero) && CV_Utiles.ComboboxVacios(cmbProvincia, cmbLocalidad))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (CV_Utiles.ComboboxVacios(cmbProvincia, cmbLocalidad))
            {
                MessageBox.Show("Por favor seleccione Provincia y Localidad");
                return;
            }

            if (!CV_Utiles.CampoMail(txtCorreo.Text))
            {
                MessageBox.Show("Formato de Mail Incorrecto");
                return;
            }
            if (txtCUIT.Text.Length <11)
            {
                MessageBox.Show("El CUIT No Tiene La Cantidad Correcta");
                return;
            }
            try
            {
                string comercial = txtComercial.Text.TrimStart().TrimEnd();
                string razonsocial = txtRazonSocial.Text.TrimStart().TrimEnd();
                string cuit = txtCUIT.Text.TrimStart().TrimEnd();
                string correo = txtCorreo.Text.TrimStart().TrimEnd();
                int CodigoArea = Convert.ToInt32(txtCodArea.Text);
                int Telefono = Convert.ToInt32(txtTelefono.Text);
                string calle = txtCalle.Text.TrimStart().TrimEnd();
                int numero = Convert.ToInt32(txtNumero.Text.Trim());
                int provincia = Convert.ToInt32(cmbProvincia.Text.Split('-')[0].Trim());
                int localidad = Convert.ToInt32(cmbLocalidad.Text.Split('-')[0].Trim());
                int codpostal = Convert.ToInt32(txtCodPostal.Text);
                string observaciones = txtObservaciones.Text;
                Proveedor proveedor = new Proveedor
                {
                    NombreComercial = comercial,
                    RazonSocial = razonsocial,
                    NumeroDeIdentificacion = cuit,
                    Correo = correo,
                    CodigoArea = CodigoArea,
                    Telefono = Telefono,
                    DireccionCalle = calle,
                    DireccionAltura = numero,
                    DireccionProvincia = provincia,
                    DireccionLocalidad = localidad,
                    DireccionCodigoPostal = codpostal,
                    Observaciones = observaciones,
                    IdUsuarioAlta = Sesion.Usuario.IdUsuario,
                };

                string resultado = metodos.InsertarProveedor(proveedor);
                MessageBox.Show(resultado);
                _limpiando = true;
                CV_Utiles.LimpiarFormulario(this);
                _limpiando = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message);
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarProductos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNuevoProveedor_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);


            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregar);
        }
    }
}
