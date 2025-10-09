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
        private void CargarPermisos()
        {
            string[] permisosiniciales = { "Ver", "Crear", "Editar", "Insertar", "Eliminar" };

            foreach (string permiso in permisosiniciales)
            {
                int filaIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[filaIndex].Cells["Permisos"].Value = permiso;
            }
            DataTable usuario = metodos.Usuarios(idusuario);
            foreach (DataRow fila in usuario.Rows)
            {               
                string permisosStr = fila["Permisos"].ToString();
                string[] permisos = permisosStr.Split(',');
                var permisosLimpios = permisos.Select(p => p.Trim()).ToList();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string permisoActual = row.Cells["Permisos"].Value?.ToString();
                    if (permisosLimpios.Contains(permisoActual))
                    {
                        row.Cells["Autorizado"].Value = "1- Si";
                    }
                    else
                    {
                        row.Cells["Autorizado"].Value = "2- No";
                    }
                }
            }
            dataGridView1.Columns["Autorizado"].ReadOnly = false;
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
            CargarPermisos();

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
            int idrol = Convert.ToInt32(cmbRol.Text.Split('-')[0]);
            metodos.EliminarIdRol(Convert.ToInt32(idrol));
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.Cells["Autorizado"].Value?.ToString() == "1- Si")
                {
                    int idPermiso = metodos.ObtenerIdPermiso(fila.Cells["Permisos"].Value.ToString());
                    metodos.InsertarRolPermiso(idrol, idPermiso);
                }
            }
        }
        private void CargarRoles()
        {
            DataTable cacheroles = metodos.TraerTodo("Roles");
            cmbRol.Items.Clear();
            foreach (DataRow fila in cacheroles.Rows)
            {
                string rol = $"{fila["IdRol"].ToString()} - {fila["NombreRol"].ToString()}";
                cmbRol.Items.Add(rol);
            }
        }
        private void CargarPreguntas()
        {
            DataTable cachepregunta = metodos.TraerTodo("PreguntasSeguridad");
            cmbPregunta.Items.Clear();
            foreach (DataRow fila in cachepregunta.Rows)
            {
                string rol = $"{fila["IdPregunta"].ToString()} - {fila["Pregunta"].ToString()}";
                cmbPregunta.Items.Add(rol);
            }
        }
    }
}
