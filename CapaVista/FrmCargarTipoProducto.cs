using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCargarTipoProducto : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable cachetipos;
        public FrmCargarTipoProducto()
        {
            InitializeComponent();
        }
        private void CargarTipoProductos()
        {
            cachetipos = metodos.TipoProductos();
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
    }
}
