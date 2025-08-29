using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmAdmusuarios : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable UsuariosCache;
        public FrmAdmusuarios()
        {
            InitializeComponent(); 
        }

        private void Cargarbuscador()
        {
            UsuariosCache = metodos.Usuarios();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in UsuariosCache.Rows)
            {
                string usuario = fila["Usuario"].ToString().ToLower();
                string estado = fila["Estado"].ToString();
                string bloqueado = Convert.ToInt32(fila["Bloqueado"]) == 0 ? "No" : "Si";
                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["IdUsuario"], fila["Usuario"], fila["Nombre"], fila["Apellido"], fila["Dni"], fila["NombreRol"], bloqueado, fila["Estado"].ToString());
                }
                else if (usuario.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["IdUsuario"], fila["Usuario"], fila["Nombre"], fila["Apellido"], fila["Dni"], fila["NombreRol"], bloqueado, fila["Estado"].ToString());
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new FrmRegistro().ShowDialog();
            Cargarbuscador();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione un usuario.");
                return;
            }

            try
            {
                string usuario = dataGridView1.CurrentRow.Cells["Usuario"].Value?.ToString();

                if (metodos.BorrarUsuario(usuario) == 1)
                {
                    MessageBox.Show($"Usuario: {usuario} borrado con éxito");
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show($"Error al borrar al usuario {usuario}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
            Cargarbuscador();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int IdUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString());
            FrmModUsuarios modUsuarios = new FrmModUsuarios(IdUsuario);
            modUsuarios.Show();
        }

        private void FrmAdmusuarios_Load(object sender, EventArgs e)
        {
            Cargarbuscador();
        }
    }
}
