using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCargarMedidas : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmCargarMedidas()
        {
            InitializeComponent();
        }
        private void Cargarmedidas()
        {
            DataTable cachemarcas = metodos.MedidasProductos();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachemarcas.Rows)
            {
                string nombreMarca = fila["Medida"].ToString().ToLower();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["Idmedidas"], fila["Medida"], fila["Estado"]);
                }
                else if (nombreMarca.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["Idmedidas"], fila["Medida"], fila["Estado"]);
                }
            }
        }

        private void FrmCargarMedidas_Load(object sender, System.EventArgs e)
        {
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);
        }
        private void BloquearDatagrid(DataGridView dgv)
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                fila.Cells["ID"].ReadOnly = true;
                fila.Cells["MEDIDA"].ReadOnly = true;
                fila.Cells["ESTADO"].ReadOnly = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            new FrmNuevaMedida().ShowDialog();
            Cargarmedidas();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
            button4.Visible = true;
            BloquearDatagrid(dataGridView1);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string medida = dataGridView1.CurrentRow.Cells["MEDIDA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarMedidas(id, medida, estado));
                textBox1.Focus();
                button4.Visible = !button4.Visible;
                button2.Visible = !button2.Visible;
                button3.Visible = !button3.Visible;
                button1.Visible = !button1.Visible;
                button2.Visible = !button2.Visible;
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button2.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            DataGridViewRow fila = dataGridView1.CurrentRow;
            fila.Cells["MEDIDA"].ReadOnly = false;
            fila.Cells["ESTADO"].ReadOnly = false;
            fila.Cells["ID"].ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarmedidas();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "BUSCADOR...")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "BUSCADOR...";
            }
        }
    }
}
