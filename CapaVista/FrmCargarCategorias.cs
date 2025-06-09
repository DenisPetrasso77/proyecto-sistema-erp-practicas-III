using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCargarCategorias : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable cachecategorias = new DataTable();
        public FrmCargarCategorias()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de la nueva categoria");
                return;
            }
            try
            {
                MessageBox.Show(metodos.InsertarCate(textBox2.Text));
                textBox2.Text = "";
                textBox2.Focus();
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarcategorias();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string categoria = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarCate(id, categoria, estado));
                textBox2.Text = "";
                textBox1.Focus();
                button2.Visible = true;
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarcategorias();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                button2.Enabled = true;
            }
            else
            { 
                button2.Enabled = false;
            }
        }
        private void Cargarcategorias()
        {
            cachecategorias = metodos.Categorias();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachecategorias.Rows)
            {
                string nombreCategoria = fila["Categoria"].ToString().ToLower();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["IdCategoria"], fila["Categoria"], fila["Estado"]);
                }
                else if (nombreCategoria.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["IdCategoria"], fila["Categoria"], fila["Estado"]);
                }
            }
        }

        private void FrmCargarCategorias_Load(object sender, EventArgs e)
        {
            Cargarcategorias();
            dataGridView1.Columns["ID"].ReadOnly = true;
            dataGridView1.Columns["CATEGORIA"].ReadOnly = false;
            dataGridView1.Columns["ESTADO"].ReadOnly = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarcategorias();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cargarcategorias();
        }

    }
}
