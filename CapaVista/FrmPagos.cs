using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmPagos : Form
    {
        FrmFactura factura;
        FrmNotaCredito notaCredito;
        CL_Metodos metodos = new CL_Metodos();
        FrmDetalleRecepcion detalleRecepcion;

        public FrmPagos()
        {
            InitializeComponent();
        }


        private void CargarPagosPendientesDocumentacion()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = metodos.TraerPagosPendientesDocumentacion();
            foreach (DataRow fila in dt.Rows)
            {
               string id = fila["IdRecepcion"].ToString();
               string OrdenCompra = fila["IdOrdenCompra"].ToString();
               string Proveedor = fila["RazonSocial"].ToString();
               decimal total = Convert.ToDecimal(fila["CantidadPedida"].ToString().Split(' ')[0]) * Convert.ToDecimal(fila["Precio"].ToString());
               string Importe = total.ToString("N2");
               string Factura = fila["Factura"].ToString() == "-" ? "CARGAR" : fila["Factura"].ToString();
               string NotaCredito = fila["NotaCredito"] == DBNull.Value ? "NO TIENE" : "CARGAR";
               dataGridView1.Rows.Add(id, OrdenCompra, Proveedor, Importe, Factura, NotaCredito);
            }
        }
        private void CargarPagosPendientes()
        {
            dataGridView2.Rows.Clear();
            DataTable dt = metodos.SeleccionarPagosPendientes();
            foreach (DataRow fila in dt.Rows)
            {
                if (fila["Estado"].ToString() == "Pagado") continue;
                string id = fila["IdRecepcion"].ToString();
                string Proveedor = fila["RazonSocial"].ToString();
                string Cuit = fila["cuit"].ToString();
                string Factura = fila["Factura"].ToString();
                decimal totalfactura = Convert.ToDecimal(fila["TotalFactura"].ToString());
                string totalf = totalfactura.ToString("N2");
                string NotaCredito = fila["NotaCredito"] == DBNull.Value ? "NO TIENE" : fila["NotaCredito"].ToString();
                decimal TotalNotaCcredito = fila["TotalNC"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["NotaCredito"].ToString());
                string totalnc = TotalNotaCcredito.ToString("N2");
                dataGridView2.Rows.Add(id, Proveedor,Cuit, Factura,totalf, NotaCredito,totalnc);
            }
        }
        private void CargarPagosCompletados()
        {
            string totalf;
            dataGridView3.Rows.Clear();
            DataTable dt = metodos.SeleccionarPagosCompletados();
            foreach (DataRow fila in dt.Rows)
            {
                string id = fila["IdRecepcion"].ToString();
                string idOrdenPago= fila["IdOrdenPago"].ToString();
                string Proveedor = fila["RazonSocial"].ToString();
                string FormaPago = fila["FormaPago"].ToString();
                if (fila["TotalNC"] != DBNull.Value)
                { 
                    decimal total = Convert.ToDecimal(fila["TotalFactura"].ToString()) - Convert.ToDecimal(fila["TotalNC"].ToString());
                    totalf = total.ToString("N2");
                } 
                else
                {
                    decimal total = Convert.ToDecimal(fila["TotalFactura"].ToString());
                    totalf = total.ToString("N2");
                }
                string estado = fila["Estado"].ToString();
                string comprobante = fila["Comprobante"] != DBNull.Value ? fila["Comprobante"].ToString() : "CARGAR" ;
                dataGridView3.Rows.Add(id, idOrdenPago, Proveedor, FormaPago,totalf,estado,comprobante);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Pagar"].Value) && fila.Cells["FormaPago"].Value == null)
                {
                    MessageBox.Show("Por favor seleccione una forma de pago para los pagos a realizar");
                    return;
                }
            }

            var detalle = new List<(int IdRecepcion, string RazonSocial, string Cuit, string NroFactura, string NroNC, string FormaPago, DateTime FechaAlta, int IdUsuarioAlta, string Estado)>();

            int idusuario = Sesion.Usuario.IdUsuario;

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                detalle.Add
                    ((
                   Convert.ToInt32(fila.Cells["IdRecepcion"].Value.ToString()),
                   fila.Cells["RazonSocial"].Value.ToString(),
                   fila.Cells["CUITCUIL"].Value.ToString(),
                   fila.Cells["NroFactura"].Value.ToString(),
                   fila.Cells["NotasCredito"].Value.ToString(),
                   fila.Cells["FormaPago"].Value.ToString(),
                   DateTime.Now,
                   idusuario,
                   "PAGADO"
                   ));
            }
            OrdenesPago ordenes = new OrdenesPago
            {

                Detalle = detalle
            };
            var resultado = metodos.InsertarOrdenesPago(ordenes);
            MessageBox.Show(resultado);
            CargarPagosPendientes();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            detalleRecepcion = new FrmDetalleRecepcion(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            detalleRecepcion.ShowDialog();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarPagosPendientes();
        }

        private void FrmPagos_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregarFactura);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregarNotaCredito);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            //UI_Utilidad.EstiloBotonPrimarioDegradado(btnDetalle);
            //UI_Utilidad.EstiloBotonPrimarioDegradado(btnPagar);
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() != "CARGAR")
            {
                MessageBox.Show("Ya tiene una factura cargada");
                return;
            }
            factura = new FrmFactura(dataGridView1.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            factura.ShowDialog();
            CargarPagosPendientesDocumentacion();
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            CargarPagosPendientesDocumentacion();
            CargarPagosPendientes();
            CargarPagosCompletados();
        }

        private void btnAgregarNotaCredito_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "NO TIENE")
            {
                MessageBox.Show("No es necesario cargar una nota de credito");
                return;
            }
            notaCredito = new FrmNotaCredito(dataGridView1.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            notaCredito.ShowDialog();
            CargarPagosPendientesDocumentacion();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal totalfactura = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[4].Value.ToString());
            decimal totalnc = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[6].Value.ToString());
            textBox4.Text = totalfactura.ToString("N2");
            textBox6.Text = totalnc.ToString("N2");
            textBox3.Text = (totalfactura - totalnc).ToString("N2");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CargarPagosCompletados();
        }
    }
}
