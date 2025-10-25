using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

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
            try
            {
                DataTable UsuariosCache = metodos.Usuarios();
                string texto = txtBuscador.Text.Trim().ToLower();
                bool incluirInactivos = checkBox1.Checked;

                dataGridView1.Rows.Clear();

                foreach (DataRow fila in UsuariosCache.Rows)
                {
                    string estado = fila["Estado"].ToString();
                    string usuario = fila["Usuario"].ToString().ToLower();
                    string bloqueado = Convert.ToInt32(fila["Bloqueado"]) == 0 ? "No" : "Sí";
                    string rol = fila["NombreRol"] == DBNull.Value ? "SIN ROL" : fila["NombreRol"].ToString();
                    if (!incluirInactivos && estado == "Inactivo")
                        continue;

                    bool coincideBusqueda = string.IsNullOrWhiteSpace(texto) ||
                                            txtBuscador.Text == "Buscador de Usuarios" ||
                                            usuario.Contains(texto);

                    if (coincideBusqueda)
                    {
                        dataGridView1.Rows.Add(
                            fila["IdUsuario"],
                            fila["Usuario"],
                            fila["Nombre"],
                            fila["Apellido"],
                            fila["Dni"],
                            rol,
                            bloqueado,
                            estado
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdmusuarios_Load(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Crear_Usuarios"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new FrmAltaUsuario().ShowDialog();
            Cargarbuscador();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Eliminar_Usuarios"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione un usuario.");
                return;
            }
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString()) == 1)
            {
                MessageBox.Show("No Se Puede Deshablitar El Usuario Administrador");
                metodos.Bitacora(Sesion.Usuario.IdUsuario,"Usuarios","Intento Eliminar El Usuario Administrador");
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
                    metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", $"Deshabilito el Usuario {usuario}");
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
            if (!CV_Utiles.TienePermiso("Editar_Usuarios"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int IdUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString());
            FrmEditarUsuario editusuario = new FrmEditarUsuario(IdUsuario);
            editusuario.Show();
            Cargarbuscador();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmHome().Show();
        }

        private void FrmAdmusuarios_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloTextBox(txtBuscador, "Buscador de Usuarios");
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);

            UI_Utilidad.AplicarEfectoHover(pictureBox1);
            UI_Utilidad.AplicarEfectoHover(pictureBox2);
            UI_Utilidad.AplicarEfectoHover(pictureBox3);

            UI_Utilidad.EstiloDataGridView(dataGridView1);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Editar_Usuarios"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int IdUsuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString());
            FrmEditarUsuario editusuario = new FrmEditarUsuario(IdUsuario);
            editusuario.Show();
        }
    }
}
