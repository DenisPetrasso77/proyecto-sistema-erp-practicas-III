using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Drawing;
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

                if (idOrden.Contains(texto) || razon.ToLower().Contains(texto.ToLower()) || cuit.Contains(texto))
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
                string idproducto = fila["IdProducto"].ToString().Trim();
                string Producto = fila["Producto"].ToString().Trim();
                int cantidad = Convert.ToInt32(fila["CantidadPedida"].ToString().Split(' ')[0]);
                decimal precio = Convert.ToDecimal(fila["Precio"].ToString());
                dataGridView1.Rows.Add(idproducto, Producto, cantidad, precio);
            }
            listBox1.Visible = false;
            label5.Text = itemSeleccionado.Split('-')[1];
            label7.Text = $"{"OC-"}{itemSeleccionado.Split('-')[0]}";
            textBox1.Text = string.Empty;
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
            CargarMotivosDevolucion();
            dataGridView1.Columns["Motivo"].ReadOnly = true;
            label20.Text = Sesion.Usuario.Usuario;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("HH:mm:ss");
            label13.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void CargarMotivosDevolucion()
        {
            DataTable motivos = metodos.TraerTodo("MotivosDevolucion");
            var comboCol = (DataGridViewComboBoxColumn)dataGridView1.Columns["Motivo"];
            comboCol.DataSource = motivos;
            comboCol.DisplayMember = "Descripcion";
            comboCol.ValueMember = "IdMotivo";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "BUSCADOR PROVEEDOR")
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "BUSCADOR PROVEEDOR";
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dataGridView1.Rows[e.RowIndex];

            // CALCULAR DIFERENCIA
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Recibida")
            {
                int recibido = 0;
                int pedido = 0;

                int.TryParse(fila.Cells["Recibida"].Value?.ToString(), out recibido);
                int.TryParse(fila.Cells["CantidadPedida"].Value?.ToString(), out pedido);

                int restante = recibido - pedido;
                fila.Cells["Diferencia"].Value = restante;
            }

            // HABILITAR MOTIVOS
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Diferencia")
            {
                int cantidad = 0;
                int.TryParse(fila.Cells["Diferencia"].Value?.ToString(), out cantidad);

                fila.Cells["Motivo"].ReadOnly = cantidad == 0;
            }
        }
    }
}
