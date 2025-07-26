using CapaLogica;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmBitacora : Form
    {
        DataTable cachebitacora;
        CL_Metodos metodos = new CL_Metodos();
        public FrmBitacora()
        {
            InitializeComponent();
            CargarDetalle();
        }
        private void CargarDetalle()
        {
            cachebitacora = metodos.TraerTodo("Bitacora");

            string usuario = textBox1.Text.Trim().ToLower();
            string tabla = textBox2.Text.Trim().ToLower();
            string descripcion = textBox3.Text.Trim().ToLower();

            dataGridView1.Rows.Clear();

            foreach (DataRow dr in cachebitacora.Rows)
            {
                string usuario2 = dr["Usuario"].ToString().ToLower();
                string tabla2 = dr["TablaAfectada"].ToString().ToLower();
                string descripcion2 = dr["Descripcion"].ToString().ToLower();

                bool coincideUsuario = string.IsNullOrWhiteSpace(usuario) || usuario2.Contains(usuario);
                bool coincideTabla = string.IsNullOrWhiteSpace(tabla) || tabla2.Contains(tabla);
                bool coincideDescripcion = string.IsNullOrWhiteSpace(descripcion) || descripcion2.Contains(descripcion);

                if (coincideUsuario && coincideTabla && coincideDescripcion)
                {
                    dataGridView1.Rows.Add(
                        dr["IdBitacora"].ToString(),
                        Convert.ToDateTime(dr["FechaHora"]).ToString("d/M/yyyy HH:mm:ss"),
                        dr["Usuario"].ToString(),
                        dr["TablaAfectada"].ToString(),
                        dr["Descripcion"].ToString()
                    );
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var valor = dataGridView1.CurrentRow;
            if (valor == null)
            {
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdBitacora"].Value);
            DialogResult resultado = MessageBox.Show("¿Desea Eliminar el Registro Seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (metodos.BorrarDetalleBitacora(id) > 0)
                {
                    MessageBox.Show("Detalle Seleccionado Borrado");
                    return;
                }
            }
            else
            {
                return;
            }
            CargarDetalle();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Eliminar el Registro Completo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (metodos.BorrarBitacora() > 0)
                {
                    MessageBox.Show("Bitacora Eliminada");
                    return;
                }
            }
            else
            {
                return;
            }
            CargarDetalle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
