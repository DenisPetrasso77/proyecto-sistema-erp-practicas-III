using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
            string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes","Usuarios");
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string extension = Path.GetExtension(rutaImagenTemporal);
            string destino = Path.Combine(carpetaDestino, txtUsuario.Text + extension);

            if (File.Exists(destino))
            {
                File.Delete(destino);
            }

            File.Copy(rutaImagenTemporal, destino, true);
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
    }
}
