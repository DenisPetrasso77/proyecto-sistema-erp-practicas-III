using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmCargarTipoProducto : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmCargarTipoProducto()
        {
            InitializeComponent();
        }
        private void CargarTipoProductos()
        {
            DataTable cachetipos = metodos.TipoProductos();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachetipos.Rows)
            {
                string tipoproducto = fila["TipoProducto"].ToString().ToLower();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["IdTipoProducto"], fila["TipoProducto"], fila["Estado"]);
                }
                else if (tipoproducto.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["IdTipoProducto"], fila["TipoProducto"], fila["Estado"]);
                }

            }
        }

        private void FrmCargarTipoProducto_Load(object sender, EventArgs e)
        {
            
            dataGridView1.Columns["ID"].ReadOnly = true;
            dataGridView1.Columns["TIPO"].ReadOnly = true;
            dataGridView1.Columns["ESTADO"].ReadOnly = false;
            CargarTipoProductos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string categoria = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                string estado = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
                MessageBox.Show(metodos.ActualizarTipoProducto(id, categoria,estado));
                textBox2.Text = "";
                textBox2.Focus();
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            CargarTipoProductos();
        }

        private void FrmCargarTipoProducto_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Text = "Papelera";


            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnBorrar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnNuevo);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnModificar);

            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloDataGridView(dataGridView1);
        }
    }
}
