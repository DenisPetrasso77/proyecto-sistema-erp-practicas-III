using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DataTable cachePermisos = metodos.TraerTodo("Permisos");
            DataTable cachePermisosRol = metodos.SeleccionaPermisos(Convert.ToInt32(comboBox1.Text.Split('-')[0]));

            dataGridView1.Rows.Clear();

            foreach (DataRow permiso in cachePermisos.Rows)
            {
                int idPermiso = Convert.ToInt32(permiso["IdPermiso"]);
                string nombrePermiso = permiso["Permiso"].ToString();

                bool autorizadoRol = cachePermisosRol.AsEnumerable().Any(r => r.Field<int>("IdPermiso") == idPermiso);

                dataGridView1.Rows.Add(
                    nombrePermiso, autorizadoRol
                );
            }
        }
        private void CargarRoles()
        {
            DataTable roles = metodos.TraerTodo("Roles");
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
            CargarPermisos();
        }

        private void FrmGestionRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmNuevoRol nuevoRol = new FrmNuevoRol();
            nuevoRol.ShowDialog();
            CargarRoles();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string rol = comboBox1.Text.ToString();
            if (rol == null) return;
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
                        int idPermiso = metodos.ObtenerIdPermiso(row.Cells["Permiso"].Value.ToString());
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
            DataTable cachePermisos = metodos.TraerTodo("Permisos");
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