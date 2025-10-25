using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmCargarMarcas : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmCargarMarcas()
        {
            InitializeComponent();
        }
        private void Cargarmarcas()
        {
            DataTable cachemarcas = metodos.MarcasProductos();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachemarcas.Rows)
            {
                string nombreMarca = fila["Marca"].ToString().ToLower();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["Idmarca"], fila["Marca"], fila["Estado"]);
                }
                else if (nombreMarca.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["Idmarca"], fila["Marca"], fila["Estado"]);
                }
            }
        }

        private void FrmCargarMarcas_Load(object sender, System.EventArgs e)
        {
            BloquearDatagrid(dataGridView1);
            Cargarmarcas();
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

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            Cargarmarcas();
            BloquearDatagrid(dataGridView1);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            new FrmNuevaMarca().ShowDialog();
            Cargarmarcas();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
            btnModificar.Visible = true;
            btnSalir.Visible = true;
            BloquearDatagrid(dataGridView1);
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string marca = dataGridView1.CurrentRow.Cells["MARCA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarMarca(id, marca, estado));
                textBox1.Focus();
                btnSalir.Visible = !btnSalir.Visible;
                btnModificar.Visible = !btnModificar.Visible;
                btnCancelar.Visible = !btnCancelar.Visible;
                btnActualizar.Visible = !btnActualizar.Visible;
                btnModificar.Visible = !btnModificar.Visible;
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarmarcas();
            BloquearDatagrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnSalir.Visible = false;
            btnModificar.Visible = false;
            btnActualizar.Visible = true;
            btnCancelar.Visible = true;
            DataGridViewRow fila = dataGridView1.CurrentRow;
            fila.Cells["MARCA"].ReadOnly = false;
            fila.Cells["ESTADO"].ReadOnly = false;
            fila.Cells["ID"].ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarmarcas();
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

        private void FrmCargarMarcas_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Text = "Papelera";

            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnActualizar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnNuevo);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnModificar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCancelar);

            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloDataGridView(dataGridView1);

        }
    }
}
