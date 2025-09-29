using CapaLogica;
using ProyectoPracticas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionUsuarios : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionUsuarios()
        {
            InitializeComponent(); 
        }

        private void Cargarbuscador()
        {
            DataTable UsuariosCache = metodos.Usuarios();
            string texto = txtBuscador.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in UsuariosCache.Rows)
            {
                string usuario = fila["Usuario"].ToString().ToLower();
                string estado = fila["Estado"].ToString();
                string bloqueado = Convert.ToInt32(fila["Bloqueado"]) == 0 ? "No" : "Si";
                if (string.IsNullOrWhiteSpace(texto) || txtBuscador.Text == "Buscador de Usuarios")
                {
                    dataGridView1.Rows.Add(fila["IdUsuario"], fila["Usuario"], fila["Nombre"], fila["Apellido"], fila["Dni"], fila["NombreRol"], bloqueado, fila["Estado"].ToString());
                }
                else if (usuario.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["IdUsuario"], fila["Usuario"], fila["Nombre"], fila["Apellido"], fila["Dni"], fila["NombreRol"], bloqueado, fila["Estado"].ToString());
                }
            }
        }

        private void FrmAdmusuarios_Load(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new FrmAltaUsuario().ShowDialog();
            Cargarbuscador();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
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
            string usuario = dataGridView1.CurrentRow.Cells["Usuario"].Value?.ToString();
            DialogResult resultado = MessageBox.Show($"¿Está seguro que desea marcar como deshabilitado este usuario? {usuario}", "Confirmar deshabilitacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No)
            {
                return;
            }
            try
            {             
                if (metodos.BorrarUsuario(usuario) == 1)
                {
                    MessageBox.Show($"Usuario: {usuario} deshabilitado con éxito");
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show($"Error al deshabilitar al usuario {usuario}");
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
            FrmEditarUsuario editusuario = new FrmEditarUsuario(IdUsuario);
            editusuario.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdmusuarios_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloTextBox(txtBuscador, "Buscador de Usuarios");


        }
    }
}
