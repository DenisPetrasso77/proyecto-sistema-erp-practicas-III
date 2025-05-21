using CapaLogica;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmAdmusuarios : Form
    {
        Frm_Registro registro = new Frm_Registro();
        CL_Metodos metodos = new CL_Metodos();
        DataTable productosCache;
        public FrmAdmusuarios()
        {
            InitializeComponent();
            Cargarbuscador();
        }

        private void Cargarbuscador()
        {
            string texto = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                listBox1.Visible = false;
                return;
            }

            //productosCache = metodos.MostrarTodo("Usuarios");
            listBox1.Items.Clear();

            foreach (DataRow fila in productosCache.Rows)
            {
                string item = $"{fila["Usuario"]} - {fila["Nombre"]} - {fila["Apellido"]} - {fila["Dni"]}- {fila["Rol"]} - {Convert.ToInt32(fila["Autorizante"].ToString())} - {fila["Bloqueado"]}";
                listBox1.Items.Add(item);
            }

            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
        }

        private void AgregarProductoSeleccionado()
        {
            if (listBox1.SelectedItem == null)
                return;

            string itemSeleccionado = listBox1.SelectedItem.ToString();
            string usuario = itemSeleccionado.Split('-')[0].Trim();

            DataRow[] seleccion = productosCache.Select($"Usuario = '{usuario}'");

            if (seleccion.Length > 0)
            {
                DataRow fila = seleccion[0];

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Usuario"].Value?.ToString() == usuario)
                    {
                        MessageBox.Show("Usuario ya agregado");
                        listBox1.Visible = false;
                        textBox1.Clear();
                        textBox1.Focus();
                        return;
                    }
                }
                string Usuario = fila["Usuario"].ToString();
                string Nombre = fila["Nombre"].ToString();
                string Apellido = fila["Apellido"].ToString();
                string Dni = fila["Dni"].ToString();
                int Rol = Convert.ToInt32(fila["Rol"].ToString());
                int Autorizante = Convert.ToInt32(fila["Autorizante"].ToString());
                string Bloqueado = Convert.ToInt32(fila["Bloqueado"]) == 0 ? "No" : "Si";
                dataGridView1.Rows.Add(
                    Usuario,
                    Nombre,
                    Apellido,
                    Dni,
                    Rol,
                   Autorizante,
                   Bloqueado
                );
            }
            listBox1.Visible = false;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            registro.ShowDialog();
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
            string usuario = dataGridView1.CurrentRow.Cells["Usuario"].Value?.ToString();
            string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();
            string apellido = dataGridView1.CurrentRow.Cells["Apellido"].Value?.ToString();
            string dni = dataGridView1.CurrentRow.Cells["Dni"].Value?.ToString();
            string rol = dataGridView1.CurrentRow.Cells["Rol"].Value?.ToString();
            string autorizante = dataGridView1.CurrentRow.Cells["Autorizante"].Value?.ToString();
            string bloqueado = dataGridView1.CurrentRow.Cells["Bloqueado"].Value?.ToString();
            FrmModUsuarios modUsuarios = new FrmModUsuarios(usuario, nombre, apellido, dni, rol, autorizante, bloqueado);
            modUsuarios.Show();
        }
    }
}
