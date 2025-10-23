using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionRoles : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionRoles()
        {
            InitializeComponent();
        }
        private void CargarPermisos()
        {
            if (comboBox1.SelectedItem == null) return;
            DataTable cachePermisos = metodos.SeleccionarPermisos();
            DataTable cachePermisosRol = metodos.SeleccionaPermisos(Convert.ToInt32(comboBox1.Text.Split('-')[0]));

            dataGridView1.Rows.Clear();

            foreach (DataRow permiso in cachePermisos.Rows)
            {
                int idPermiso = Convert.ToInt32(permiso["IdPermiso"]);
                string nombrePermiso = permiso["Permiso"].ToString();

                bool autorizadoRol = cachePermisosRol.AsEnumerable().Any(r => r.Field<int>("IdPermiso") == idPermiso);

                dataGridView1.Rows.Add(
                   idPermiso, nombrePermiso, autorizadoRol
                );
            }
        }
        private void CargarRoles()
        {
            DataTable roles = metodos.SeleccionarRoles();
            comboBox1.Items.Clear();

            foreach (DataRow r in roles.Rows)
            {
                string idRol = r["IdRol"].ToString();
                string nombreRol = r["NombreRol"].ToString();
                comboBox1.Items.Add($"{idRol} - {nombreRol}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1 - Administrador")
            {
                CargarPermisos();
                dataGridView1.Columns["Permiso"].ReadOnly = true;
                dataGridView1.Columns["Autorizado"].ReadOnly = true;
                return;
            }
            CargarPermisos();
            dataGridView1.Columns["Permiso"].ReadOnly = false;
            dataGridView1.Columns["Autorizado"].ReadOnly = false;
        }

        private void FrmGestionRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Crear_Configuracion"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmNuevoRol nuevoRol = new FrmNuevoRol();
            nuevoRol.ShowDialog();
            CargarRoles();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Eliminar_Configuracion"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string rol = comboBox1.Text.ToString();
            if (rol == null) return;
            if (rol == "1 - Administrador")
            {
                MessageBox.Show("No se puede eliminar el rol de Administrador.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el rol seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string resultado = metodos.EliminarRol(Convert.ToInt32(rol.Split('-')[0]));

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRoles();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Editar_Configuracion"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idrol = Convert.ToInt32(comboBox1.Text.Split('-')[0]);
                Permisos permisosRol = new Permisos
                {
                    Detalle = new List<int>()
                };

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool autorizado = Convert.ToBoolean(row.Cells["Autorizado"].Value);
                    if (autorizado)
                    {
                        int idPermiso = Convert.ToInt32(row.Cells["IdPermisoRol"].Value.ToString());
                        permisosRol.Detalle.Add(idPermiso);
                    }
                }
                string mensaje = metodos.InsertarPermisoRol(idrol, permisosRol);
                MessageBox.Show(mensaje, "Actualización de permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();    
            CargarRoles();     
        }
        private void CargarUsuarios()
        {
            DataTable UsuariosCache = metodos.Usuarios();
            comboBox2.Items.Clear();

            foreach (DataRow fila in UsuariosCache.Rows)
            {
                string idusuario = fila["IdUsuario"].ToString().ToLower();
                string nombre = fila["Nombre"].ToString().ToLower();
                string apellido = fila["Apellido"].ToString().ToLower();
                string usuario = fila["Usuario"].ToString().ToLower();

                comboBox2.Items.Add($"{idusuario} - {nombre} {apellido}({usuario})");
            }
        }
        private void CargarPermisosUsuarios()
        {
            if (comboBox2.SelectedItem == null) return;
            DataTable cachePermisos = metodos.SeleccionarPermisos();
            DataTable cachePermisosRol = metodos.SeleccionaPermisosUsuario(Convert.ToInt32(comboBox2.Text.Split('-')[0]));

            dataGridView2.Rows.Clear();

            foreach (DataRow permiso in cachePermisos.Rows)
            {
                int idPermiso = Convert.ToInt32(permiso["IdPermiso"]);
                string nombrePermiso = permiso["Permiso"].ToString();

                bool autorizadoRol = cachePermisosRol.AsEnumerable().Any(r => r.Field<int>("IdPermiso") == idPermiso);

                dataGridView2.Rows.Add(
                    idPermiso,nombrePermiso, autorizadoRol
                );
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermisosUsuarios();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Editar_Configuracion"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idusuario = Convert.ToInt32(comboBox2.Text.Split('-')[0]);
                Permisos permisosUsuario = new Permisos
                {
                    Detalle = new List<int>()
                };

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool autorizado = Convert.ToBoolean(row.Cells["Autorizado1"].Value);
                    if (autorizado)
                    {
                        int idPermiso = Convert.ToInt32(row.Cells["IdPermiso"].Value.ToString());
                        permisosUsuario.Detalle.Add(idPermiso);
                    }
                }
                string mensaje = metodos.InsertarPermisoUsuario(idusuario, permisosUsuario);
                MessageBox.Show(mensaje, "Actualización de permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView2.Rows.Clear();
            comboBox2.Items.Clear();
            CargarUsuarios();
        }
    }
}