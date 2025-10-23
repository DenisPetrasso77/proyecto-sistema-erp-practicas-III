using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace CapaVista
{
    public partial class FrmEditarUsuario : Form
    {
        int idusuario;
        CL_Metodos metodos = new CL_Metodos();
        private string rutaImagenTemporal = string.Empty;
        public FrmEditarUsuario(int idusuario)
        {
            InitializeComponent();
            this.idusuario = idusuario;
        }       
        private void CargarDatos()
        {
            DataTable datos = metodos.SeleccionarDatosUsuario(idusuario);
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
            CargarRoles();
            CargarPreguntas();
            CargarDatos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Está seguro de que desea restablecer la contraseña a {txtUsuario.Text}?", "Confirmar Restablecimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            string contraseña = CV_Seguridad.HashearSHA256("ingreso123");
            try
            { 
                string resultado = metodos.RestablecerContraseña(idusuario, contraseña);
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

                if (CV_Utiles.TextboxVacios(txtUsuario, txtNombre, txtApellido, txtDNI, txtCorreo) ||
                    CV_Utiles.ComboboxVacios(cmbRol))
                {
                    MessageBox.Show("Por favor complete todos los campos");
                    return;
                }
                if (!CV_Utiles.CampoMail(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor ingrese un correo valido");
                    return;
                }
                if (CV_Utiles.CamposNumericos(txtNombre, txtApellido, txtUsuario, txtCorreo ))
                {
                    MessageBox.Show("Los Datos NO Pueden ser Numericos");
                    return;
                }
                string Usuario = txtUsuario.Text.Trim();
                string Nombre = txtNombre.Text.Trim();
                string Apellido = txtApellido.Text.Trim();
                int Rol = Convert.ToInt32(cmbRol.Text.Split('-')[0].ToString());
                string Dni = txtDNI.Text.Trim();
                string Correo = txtCorreo.Text.Trim();
                int bloqueado = comboBox1.SelectedIndex == 0 ? 1 : 0;
                string resultado = metodos.ActualizarUsuario(this.idusuario, Usuario, Nombre, Apellido, Dni, bloqueado, Rol, Correo,CV_Seguridad.ObtenerPalabra());
                MessageBox.Show(resultado);

            
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}


            if (string.IsNullOrEmpty(rutaImagenTemporal))
            {
                return;
            }
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
    }
}
