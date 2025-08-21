using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionRecepcion : Form
    {
        FrmFacturaRemito facturaremito = new FrmFacturaRemito();
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionRecepcion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            facturaremito.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            CargarListado();
        }
        private void CargarListado()
        {
            string texto = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) && texto != "BUSCADOR PROVEEDOR")
            {
                listBox1.Visible = false;
                return;
            }
            listBox1.Items.Clear();
            DataTable cacheordenes = metodos.RecepcionOrdenes();
            foreach (DataRow fila in cacheordenes.Rows)
            {
                string idOrden = fila["IdOrden"].ToString();
                string razon = fila["RazonSocial"].ToString();
                string cuit = fila["Cuit"].ToString();
                string item = $"{idOrden} - {razon} {"("}{cuit}{")"}";

                if (idOrden.Contains(texto) || razon.ToLower().Contains(texto.ToLower()) || cuit.Contains(texto) )
                {
                    listBox1.Items.Add(item);
                }
            }

            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void AgregarProducto()
        {
            if (listBox1.SelectedItem == null)
                return;
            dataGridView1.Rows.Clear();
            string itemSeleccionado = listBox1.SelectedItem.ToString();
            int codigo = Convert.ToInt32(itemSeleccionado.Split('-')[0].Trim());
            DataTable dt = metodos.RecepcionPedidos(codigo);

            foreach (DataRow fila in dt.Rows)
            {
                string idproducto = fila["IdProducto"].ToString();
                string Producto = fila["Producto"].ToString();
                int cantidad = Convert.ToInt32(fila["CantidadPedida"].ToString().Split(' ')[0]);
                decimal precio = Convert.ToDecimal(fila["Precio"].ToString());
                dataGridView1.Rows.Add(idproducto, Producto, cantidad,precio);
            }
            listBox1.Visible = false;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarProducto();
            }
        }

        private void FrmGestionRecepcion_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Today.ToString("d");
            label15.Text = DateTime.Today.ToString("d");
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text= DateTime.Now.ToString("HH:mm:ss");
            label13.Text = DateTime.Now.ToString("HH:mm:ss");

        }
    }
}
