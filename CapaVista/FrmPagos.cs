using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmPagos : Form
    {
        FrmFactura factura;
        CL_Metodos metodos = new CL_Metodos();
        FrmDetalleRecepcion detalleRecepcion;

        public FrmPagos()
        {
            InitializeComponent();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            CargarPagosPendientes();
        }

        private void CargarPagosPendientes()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = metodos.TraerPagosPendientes();
            foreach (DataRow fila in dt.Rows)
            {
               string id = fila["IdRecepcion"].ToString();
               string OrdenCompra = fila["IdOrdenCompra"].ToString();
               string Proveedor = fila["RazonSocial"].ToString();
               string Factura = fila["Factura"].ToString() == "-" ? "CARGAR" : fila["Factura"].ToString();
               string NotaCredito = fila["NotaCredito"] == DBNull.Value ? "NO TIENE" : "CARGAR";
               dataGridView1.Rows.Add(id, OrdenCompra, Proveedor, Factura, NotaCredito);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView2.CurrentRow.Cells[1].Value.ToString());
        }


        private void button6_Click(object sender, EventArgs e)
        {
            detalleRecepcion = new FrmDetalleRecepcion(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            detalleRecepcion.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            factura = new FrmFactura(dataGridView1.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            factura.ShowDialog();
            CargarPagosPendientes();
        }

    }
}
