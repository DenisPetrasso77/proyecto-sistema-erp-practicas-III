using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionPR : Form
    {
        DataTable stockproducmin = new DataTable();
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionPR()
        {
            InitializeComponent();
            Cargardgv();
        }
        private void Cargardgv()
        {
            string codigo;
            string descripcion;
            string stockactual;
            string formadecompra;
            string unidadventa;
            string sugerencia;
            int stockmax;
            string cantidadporcarga;
            string referencia;
            int calculoref;
            stockproducmin = metodos.ProductosStockMin();
            foreach (DataRow fila in stockproducmin.Rows)
            {
                codigo = fila["Idproducto"].ToString();
                descripcion = fila["Descripcion"].ToString();
                unidadventa = fila["UnidadReferencia"].ToString();
                stockactual = $"{fila["StockActual"]} {unidadventa}";
                formadecompra = fila["UnidadCarga"].ToString();
                stockmax = Convert.ToInt32(fila["StockMaximo"]);
                cantidadporcarga = fila["CantidadPorUnidadCarga"].ToString();
                referencia = $"1 {formadecompra} = {cantidadporcarga} {unidadventa}";
                calculoref = (Convert.ToInt32(stockmax) - Convert.ToInt32(fila["StockActual"])) / Convert.ToInt32(cantidadporcarga);
                sugerencia = $"{calculoref} {formadecompra}";
                dataGridView1.Rows.Add(codigo, descripcion, stockactual, formadecompra, referencia, sugerencia);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable detalle = new DataTable();
            detalle.Columns.Add("IdProducto", typeof(string));
            detalle.Columns.Add("CantidadPedida", typeof(int));
            detalle.Columns.Add("UnidadCarga", typeof(string));
            detalle.Columns.Add("CantidadPorUnidad", typeof(int));
            detalle.Columns.Add("StockActual", typeof(int));
            detalle.Columns.Add("UnidadVenta", typeof(string));

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Seleccionar"].Value) == true)
                {
                    detalle.Rows.Add(
                        fila.Cells["Codigo"].Value.ToString(),
                        Convert.ToInt32(fila.Cells["CantidadPedida"].Value),
                        fila.Cells["UnidadCompra"].Value.ToString(),
                        Convert.ToInt32(fila.Cells["Referencia"].Value.ToString().Split('=')[1].Trim().Split(' ')[0]),
                        Convert.ToInt32(fila.Cells["StockActual"].Value.ToString().Split(' ')[0]),
                        fila.Cells["Referencia"].Value.ToString().Split('=')[1].Split(' ')[2]
                    );
                }
            }
            try
            {
                MessageBox.Show(metodos.InsertarPR(1, detalle));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
