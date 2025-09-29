using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmComprobanteVenta : Form
    {
        public bool Exito { get; set; }

        CL_Metodos metodos = new CL_Metodos();
        private List<(string Idproducto, string Producto, int Cantidad, int Descuento, decimal precio)> _detalle;
        string _FormaPago;
        DateTime _Fecha;
        decimal _total;
        int _cliente;

        public FrmComprobanteVenta(List<(string Idproducto, string Producto, int Cantidad, int Descuento, decimal precio)> detalle, string formaPago, DateTime fecha, decimal total, int cliente)
        {
            InitializeComponent();
            _detalle = detalle;
            _FormaPago = formaPago;
            _Fecha = fecha;
            _total = total;
            _cliente = cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 == null)
            { 
                MessageBox.Show("Por favor, ingrese un número de comprobante válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Ventas ventas = new Ventas
            {
                FormaPago = _FormaPago,
                IdUsuario = Sesion.Usuario.IdUsuario,
                Fecha = _Fecha,
                total = _total,
                cliente = _cliente,
                Detalle = _detalle,
                comprobante = textBox1.Text
            };
            try
            {
                string resultado = metodos.InsertarVentas(ventas);
                MessageBox.Show(resultado, "Resultado de la Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.Contains("Correctamente"))
                {
                    Exito = true;
                    this.Close();
                }
                else
                {
                    Exito = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la venta. Inténtelo de nuevo.\n\nDetalles del error: " + ex.Message,
                                "Error en la Venta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
