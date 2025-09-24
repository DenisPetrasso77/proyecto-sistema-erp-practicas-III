using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace CapaVista
{
    public partial class FrmEditarUsuario : Form
    {
        private int usuario;
        CL_Metodos metodos = new CL_Metodos();
        private string rutaImagenTemporal = string.Empty;
        public FrmEditarUsuario(int usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void CargarDatos()
        {
            DataTable datos = metodos.SeleccionarDatosUsuario(usuario);
            foreach (DataRow row in datos.Rows)
            {
                string nombre = row["Nombre"].ToString();
                string apellido = row["Apellido"].ToString();
                string dni = row["Dni"].ToString();
                string usuario = row["Usuario"].ToString();
                int bloqueado = Convert.ToInt32(row["Bloqueado"].ToString());
                string correo = row["Correo"].ToString();
                string rol = row["Rol"].ToString();
                string pregunta = row["Pregunta"].ToString();

                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtDNI.Text = dni;
                txtUsuario.Text = usuario;
                comboBox1.SelectedIndex = bloqueado == 0 ? 1 : 0;
                txtCorreo.Text = correo;
                cmbRol.Text = rol;
                cmbPregunta.Text = pregunta;
            }
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string contraseña = CV_Seguridad.HashearSHA256("ingreso123");
            try
            { 
                string resultado = metodos.RestablecerContraseña(usuario,contraseña);
                MessageBox.Show(resultado);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //me falta terminar la actualizacion jajajaja
        }
    }
}
