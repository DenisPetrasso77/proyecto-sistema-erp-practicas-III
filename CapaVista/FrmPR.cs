using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmPR : Form
    {
        DataTable stockproducmin = new DataTable();
        CL_Metodos metodos = new CL_Metodos();
        public FrmPR()
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
                dataGridView1.Rows.Add(codigo,descripcion,stockactual,formadecompra,referencia,sugerencia);
            }
        }
    }
}
