using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionMedidas : PlantillaDetalle
    {
        DataTable cachemedidas = new DataTable();
        CL_Metodos metodos = new CL_Metodos();
        FrmNuevaMedida medida = new FrmNuevaMedida();

        public FrmGestionMedidas()
        {
            InitializeComponent();
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
        private void Cargarmedidas()
        {
            cachemedidas = metodos.TraerTodo("Medidas");
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachemedidas.Rows)
            {
                string medidas = fila["Medida"].ToString().ToUpper();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["Idmedidas"], fila["Medida"], fila["Estado"]);
                }
                else if (medidas.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["Idmedidas"], fila["Medida"], fila["Estado"]);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);
        }
        private void BloquearDatagrid(DataGridView dgv)
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                fila.Cells["ID"].ReadOnly = true;
                fila.Cells["MARCA"].ReadOnly = true;
                fila.Cells["ESTADO"].ReadOnly = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
            button4.Visible = true;
            BloquearDatagrid(dataGridView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button2.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            button1.Focus();
            dataGridView1.Columns["ID"].ReadOnly = true;
            dataGridView1.Columns["MARCA"].ReadOnly = false;
            dataGridView1.Columns["ESTADO"].ReadOnly = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string marca = dataGridView1.CurrentRow.Cells["MARCA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarMedidas(id, marca, estado));
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
        }

        private void FrmGestionMedidas_Load(object sender, EventArgs e)
        {
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            medida.ShowDialog();
            Cargarmedidas();
            BloquearDatagrid(dataGridView1);

        }
    }
}
