using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmModUsuarios : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        int id;
        public FrmModUsuarios(int idusuario)
        {
            InitializeComponent();
            id= idusuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (metodos.ActualizarUsuario(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text, Convert.ToInt32(comboBox2.Text), comboBox1.SelectedIndex) > 0)
            //{
            //    MessageBox.Show("Usuario Actualizado");
            //}
            //else
            //{
            //    MessageBox.Show("Error");
            //}
        }
        private void CargarDatos()
        {
            string[] permisosiniciales = { "Ver", "Crear", "Editar", "Insertar", "Eliminar" };

            foreach (string permiso in permisosiniciales)
            {
                int filaIndex = dataGridView1.Rows.Add(); 
                dataGridView1.Rows[filaIndex].Cells["Permisos"].Value = permiso;
            }
            DataTable usuario = metodos.Usuarios(id);
            foreach (DataRow fila in usuario.Rows)
            { 
                textBox1.Text = fila["Usuario"].ToString();
                textBox2.Text = fila["Nombre"].ToString();
                textBox6.Text = fila["Dni"].ToString();
                textBox3.Text = fila["Apellido"].ToString();
                comboBox1.Text = Convert.ToInt32(fila["Bloqueado"].ToString()) == 0 ? "No" : "Si";
                comboBox2.Text = fila["NombreRol"].ToString();
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

        private void FrmModUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
