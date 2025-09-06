using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmDetalleRecepcion : Form
    {
        int recepcion;
        CL_Metodos metodos = new CL_Metodos();

        public FrmDetalleRecepcion(int recepcion)
        {
            InitializeComponent();
            this.recepcion = recepcion;
        }

        private void FrmDetalleRecepcion_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }
        private void CargarDetalle()
        {
            dataGridView1.Rows.Clear();
            DataTable cachedetalle = metodos.TraerDetalleMercaderia(recepcion);
            foreach (DataRow filas in cachedetalle.Rows)
            {
                string idproducto = filas["idProducto"].ToString();
                string producto = filas["Producto"].ToString();
                dataGridView1.Rows.Add(idproducto,producto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
