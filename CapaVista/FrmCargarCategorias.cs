using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

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

        private void button2_Click(object sender, EventArgs e)
        {
            btnSalir.Visible = false;
            btnModificar.Visible = false;
            btnActualizar.Visible = true;
            btnAtras.Visible = true;
            DataGridViewRow fila = dataGridView1.CurrentRow;
            fila.Cells["CATEGORIA"].ReadOnly = false;
            fila.Cells["ESTADO"].ReadOnly = false;
            fila.Cells["ID"].ReadOnly = true;
        }
        private void Cargarcategorias()
        {
            cachecategorias = metodos.CategoriaProductos();
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
            BloquearDatagrid(dataGridView1);
        }
        private void BloquearDatagrid(DataGridView dgv )
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                fila.Cells["ID"].ReadOnly = true;
                fila.Cells["CATEGORIA"].ReadOnly = true;
                fila.Cells["ESTADO"].ReadOnly = true;
            }
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
            BloquearDatagrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string categoria = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarCate(id, categoria, estado));
                textBox1.Focus();
                btnSalir.Visible = !btnSalir.Visible;
                btnModificar.Visible = !btnModificar.Visible;
                btnAtras.Visible = !btnAtras.Visible;
                btnActualizar.Visible = !btnActualizar.Visible;
                btnModificar.Visible = !btnModificar.Visible;
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarcategorias();
            BloquearDatagrid(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FrmNuevaCate().ShowDialog();
            Cargarcategorias();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            btnAtras.Visible = false;
            btnModificar.Visible = true;
            btnSalir.Visible = true;
            BloquearDatagrid(dataGridView1);
        }

        private void FrmCargarCategorias_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Text = "Papelera";


            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnActualizar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnModificar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnNuevo);

            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloDataGridView(dataGridView1);

        }
    }
}
