using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmPerfil : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        string rutaImagenTemporal = string.Empty;
        public FrmPerfil()
        {
            InitializeComponent();
        }

        private void FrmPerfil_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGuardar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCambiarFoto);
            UI_Utilidad.HacerCircular(pbFoto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmSidebar home = new FrmSidebar();
            home.Show();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            if (Sesion.Usuario.PrimerIngreso != 0)
            {
                button2.PerformClick();
            }
            CargarDatos();
        }
        private void CargarDatos()
        {
            DataTable datos = metodos.SeleccionaDatosPerfil(Sesion.Usuario.IdUsuario);
            foreach (DataRow row in datos.Rows)
            {
                txtNombre.Text = row["Nombre"].ToString();
                txtApellido.Text = row["Apellido"].ToString();
                textBox1.Text = row["Dni"].ToString();
                txtRol.Text = row["NombreRol"].ToString();
                txtMail.Text = row["Correo"].ToString();
                textBox2.Text = row["Pregunta"].ToString();
                MostrarImagenUsuario(Sesion.Usuario.Usuario);
            }
        }
        private void MostrarImagenUsuario(string usuario)
        {
            string carpeta = Path.Combine(Application.StartupPath, "Imagenes", "Usuarios");
            string rutaImagenJpg = Path.Combine(carpeta, usuario + ".jpg");
            string rutaImagenPng = Path.Combine(carpeta, usuario + ".png");
            string rutaImagenBmp = Path.Combine(carpeta, usuario + ".bmp");

            if (File.Exists(rutaImagenJpg))
                pbFoto.Image = Image.FromFile(rutaImagenJpg);
            else if (File.Exists(rutaImagenPng))
                pbFoto.Image = Image.FromFile(rutaImagenPng);
            else if (File.Exists(rutaImagenBmp))
                pbFoto.Image = Image.FromFile(rutaImagenBmp);
            else
                pbFoto.Image = Properties.Resources.usuario1;
        }

        private void btnCambiarFoto_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(rutaImagenTemporal))
                {
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Usuarios");
                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    string extension = Path.GetExtension(rutaImagenTemporal);
                    string destino = Path.Combine(carpetaDestino, Sesion.Usuario.Usuario + extension);

                    if (File.Exists(destino))
                    {
                        File.Delete(destino);
                    }

                    File.Copy(rutaImagenTemporal, destino, true);
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar la imagen del producto", "Error al Obtener la Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmActualizarPregunta actualizarPregunta = new FrmActualizarPregunta();
            actualizarPregunta.ShowDialog();
            CargarDatos();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmActualizarContraseña actualizarContraseña = new FrmActualizarContraseña();
            actualizarContraseña.ShowDialog();
        }
    }
}
