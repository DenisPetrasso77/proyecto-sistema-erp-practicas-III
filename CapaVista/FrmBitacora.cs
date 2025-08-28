using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmBitacora : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmBitacora()
        {
            InitializeComponent();
        }
        private void CargarDetalle()
        {
            DataTable cachebitacora = metodos.TraerBitacora();

            string usuario = textBox1.Text.Trim().ToLower();
            string tabla = textBox2.Text.Trim().ToLower();
            string descripcion = textBox3.Text.Trim().ToLower();

            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachebitacora.Rows)
            {
                string usuario2 = fila["Usuario"].ToString().ToLower();
                string tabla2 = fila["TablaAfectada"].ToString().ToLower();
                string descripcion2 = fila["Descripcion"].ToString().ToLower();

                bool coincideUsuario = string.IsNullOrWhiteSpace(usuario) || usuario2.Contains(usuario);
                bool coincideTabla = string.IsNullOrWhiteSpace(tabla) || tabla2.Contains(tabla);
                bool coincideDescripcion = string.IsNullOrWhiteSpace(descripcion) || descripcion2.Contains(descripcion);

                if (coincideUsuario && coincideTabla && coincideDescripcion)
                {
                    dataGridView1.Rows.Add(
                        fila["IdBitacora"].ToString(),
                        Convert.ToDateTime(fila["FechaHora"]).ToString("d/M/yyyy HH:mm:ss"),
                        fila["Usuario"].ToString(),
                        fila["TablaAfectada"].ToString(),
                        fila["Descripcion"].ToString()
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

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }
    }
}
