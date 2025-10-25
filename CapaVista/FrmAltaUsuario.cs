using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;

namespace CapaVista
{
    public partial class FrmAltaUsuario : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        private string rutaImagenTemporal = null;
        public FrmAltaUsuario()
        {
            InitializeComponent();
        }

        private void FrmAltaUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPreguntas();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtUsuario, txtContraseña, txtNombre, txtApellido, txtDNI, txtRespuesta, txtCorreo) ||
                CV_Utiles.ComboboxVacios(cmbRol,  cmbPregunta))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (!CV_Utiles.CampoMail(txtCorreo.Text))
            {
                MessageBox.Show("Por favor ingrese un correo valido");
                return;
            }
            if (CV_Utiles.CamposNumericos(txtNombre, txtApellido,txtUsuario,txtContraseña,txtCorreo,txtRespuesta))
            {
                MessageBox.Show("Los Datos NO Pueden ser Numericos");
                return;
            }

            UsuarioNuevo usuarioNuevo = new UsuarioNuevo()
            {
                Usuario = txtUsuario.Text.Trim(),
                Contraseña = CV_Seguridad.HashearSHA256(txtContraseña.Text).Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Rol = Convert.ToInt32(cmbRol.Text.Split('-')[0].ToString()),
                Dni = txtDNI.Text.Trim(),
                Pregunta = Convert.ToInt32(cmbPregunta.Text.Split('-')[0].ToString()),
                Respuesta = CV_Seguridad.HashearSHA256(txtRespuesta.Text.Trim()),
                Correo = txtCorreo.Text.Trim(),
            };

            string resultado = metodos.Registro(usuarioNuevo);
            MessageBox.Show(resultado);
            if (!string.IsNullOrEmpty(rutaImagenTemporal))
            {
                string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Usuarios");
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string extension = Path.GetExtension(rutaImagenTemporal);
                string destino = Path.Combine(carpetaDestino, txtUsuario.Text + extension);

                if (File.Exists(destino))
                {
                    File.Delete(destino);
                }

                File.Copy(rutaImagenTemporal, destino, true);

            }
            CV_Utiles.LimpiarFormulario(this);
        }
        private void CargarRoles()
        {
            DataTable cacheroles = metodos.SeleccionarRoles();
            cmbRol.Items.Clear();
            foreach (DataRow fila in cacheroles.Rows)
            {
                string rol = $"{fila["IdRol"].ToString()} - {fila["NombreRol"].ToString()}";
                cmbRol.Items.Add(rol);
            }
        }
        private void CargarPreguntas()
        {
            DataTable cachepregunta = metodos.SeleccionarPreguntas();
            cmbPregunta.Items.Clear();
            foreach (DataRow fila in cachepregunta.Rows)
            {
                string rol = $"{fila["IdPregunta"].ToString()} - {fila["Pregunta"].ToString()}";
                cmbPregunta.Items.Add(rol);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenTemporal = ofd.FileName;
                    pbFoto.Image = Image.FromFile(rutaImagenTemporal);
                }
            }
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void FrmAltaUsuario_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloLabels(this);
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAceptar);
            this.Text = "Papelera";

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
