using System;
using System.Data;
using System.Windows.Forms;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmNotaCredito : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        string proveedor;
        int recepcion;
        public FrmNotaCredito(string proveedor, int idrecepcion)
        {
            InitializeComponent();
            this.proveedor = proveedor;
            this.recepcion = idrecepcion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Npuesto = Convert.ToInt32(textBox1.Text);
                int Nfactura = Convert.ToInt32(textBox2.Text);
                int tipofactura = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split('-')[0].Trim());
                string cuit = textBox4.Text;
                string razonsocial = textBox5.Text;
                decimal total = Convert.ToDecimal(textBox3.Text);
                string resultado = metodos.InsertarComprobanteNotaCredito(recepcion, Npuesto, Nfactura, tipofactura, cuit, razonsocial, total);
                MessageBox.Show(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{"Error"}{ex.Message}");
            }
        }

        private void FrmNotaCredito_Load(object sender, EventArgs e)
        {
            CargarDatosProveedor();
            CargarTipoFacturas();
        }
        private void CargarDatosProveedor()
        {
            DataTable dt = metodos.TraerDatosProveedorFactura(proveedor);
            foreach (DataRow fila in dt.Rows)
            {
                textBox4.Text = fila["cuit"].ToString();
                textBox5.Text = fila["RazonSocial"].ToString();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = string.IsNullOrWhiteSpace(textBox3.Text) ? string.Empty : Convert.ToDecimal(textBox3.Text).ToString("N2"); ;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
        private void CargarTipoFacturas()
        {
            CV_Utiles.LimpiarControles(comboBox1);
            DataTable cachetipofacturas = metodos.TraerTipoFacturas();
            foreach (DataRow filas in cachetipofacturas.Rows)
            {
                if (filas["TipoFactura"].ToString() != "Nota de Credito") continue;
                string fila = $"{filas["IdTipoFactura"]} - {filas["TipoFactura"]}";
                comboBox1.Items.Add(fila);
            }
        }

        private void FrmNotaCredito_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCancelar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAceptar);
        }
    }
}
