using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmEditarProveedor : Form
    {
        int id;
        CL_Metodos metodos = new CL_Metodos();
        bool _limpiando;

        public FrmEditarProveedor(int proveedor)
        {
            InitializeComponent();
            this.id = proveedor;
        }
        private void Cargardatos()
        {
            DataTable datos = metodos.Proveedores(id);
            foreach (DataRow row in datos.Rows)
            {             
                txtComercial.Text = row["NombreComercial"].ToString();
                txtRazonSocial.Text = row["RazonSocial"].ToString();
                txtCUIT.Text = row["CUIT"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                txtCodArea.Text = row["CodArea"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCalle.Text = row["Calle"].ToString();
                txtNumero.Text = row["Altura"].ToString();
                cmbProvincia.Text = row["Provincia"].ToString();
                cmbLocalidad.Text = row["Localidad"].ToString();
                txtCodPostal.Text = row["CodPostal"].ToString();
                comboBox1.Text = row["Estado"].ToString();
                txtObservaciones.Text = row["Observaciones"].ToString();             
            }
        }

        private void FrmEditarProveedor_Load(object sender, System.EventArgs e)
        {
            CargarProvincias();
            Cargardatos();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtRazonSocial, txtCUIT, txtCodPostal, txtTelefono, txtCalle, txtNumero) && CV_Utiles.ComboboxVacios(cmbProvincia, cmbLocalidad))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (!CV_Utiles.CampoMail(txtCorreo.Text))
            {
                MessageBox.Show("Formato de Mail Incorrecto");
                return;
            }
            string comercial = txtComercial.Text.Trim();
            string razonsocial = txtRazonSocial.Text.Trim();
            string cuit = txtCUIT.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            int CodigoArea = Convert.ToInt32(txtCodArea.Text);
            int Telefono = Convert.ToInt32(txtTelefono.Text);
            string calle = txtCalle.Text.Trim();
            int numero = Convert.ToInt32(txtNumero.Text.Trim());
            int provincia = Convert.ToInt32(cmbProvincia.Text.Split('-')[0].Trim());
            int localidad = Convert.ToInt32(cmbLocalidad.Text.Split('-')[0].Trim());
            int codpostal = Convert.ToInt32(txtCodPostal.Text);
            string observaciones = txtObservaciones.Text;
            Proveedor proveedor = new Proveedor
            {
                idProveedor = this.id,
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
                IdUsuarioUltModificacion = Sesion.Usuario.IdUsuario,
                Estado = comboBox1.Text
            };
            try
            {
                string resultado = metodos.ActualizarProveedor(proveedor);
                MessageBox.Show(resultado);
                if (resultado.Contains("Error"))
                {
                    return;
                }
                _limpiando = true;
                CV_Utiles.LimpiarFormulario(this);
                _limpiando = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message);
            }
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
    }
}
