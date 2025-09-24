using CapaLogica;
using ProyectoPracticas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmVentas : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmVentas()
        {
            InitializeComponent();
        }
        private void FrmVentas_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnVenta);

            UI_Utilidad.EstiloDataGridView(dataGridView1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Buscador()
        {
            string texto = txtBuscador.Text.Trim().ToLower();
            DataTable cacheproductos = metodos.ProductosVenta();
            listBox1.Items.Clear();
            if (string.IsNullOrEmpty(texto))
            {
                listBox1.Visible = false;
                return;
            }
            foreach (DataRow fila in cacheproductos.Rows)
            {
                string idproducto = fila["IdProducto"].ToString().ToLower();
                string producto = $"{fila["TipoProducto"].ToString()} {fila["Marca"].ToString()} {fila["Medidas"].ToString()}".ToLower();

                if (idproducto.Contains(texto) || producto.Contains(texto))
                {
                    listBox1.Visible = true;
                    listBox1.Items.Add($"{idproducto}-{producto}");
                }
            }
            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
                e.Handled = true;
            }
        }

        private void AgregarProductoSeleccionado()
        {
            if (listBox1.SelectedItem == null)
                return;

            string itemSeleccionado = listBox1.SelectedItem.ToString();
            string codigo = itemSeleccionado.Split('-')[0].Trim();
            DataTable data = metodos.ProductoSeleccionado(codigo);

            if (data.Rows.Count > 0)
            {
                DataRow fila = data.Rows[0];

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Codigo"].Value?.ToString() == codigo)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        int stockactual = Convert.ToInt32(row.Cells["StockActual"].Value);

                        if (cantidad + 1 > stockactual)
                        {
                            MessageBox.Show("No hay suficiente stock disponible.",
                                            "Stock insuficiente",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return;
                        }

                        if (int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidadActual))
                        {
                            cantidadActual++;
                            row.Cells["Cantidad"].Value = cantidadActual;

                            if (decimal.TryParse(row.Cells["Precio"].Value.ToString(), out decimal precio))
                            {
                                int descuento = SeleccionarDescuento(codigo, cantidadActual);
                                row.Cells["Descuento"].Value = descuento;

                                decimal total = (precio * cantidadActual) * (1 - (descuento / 100m));
                                row.Cells["Subtotal"].Value = total.ToString("0.00");
                            }
                        }

                        listBox1.Visible = false;
                        txtBuscador.Clear();
                        txtBuscador.Focus();
                        return;
                    }
                }

                string idproducto = fila["IdProducto"].ToString().ToLower();
                string producto = $"{fila["TipoProducto"].ToString()} {fila["Marca"].ToString()} {fila["Medidas"].ToString()}";
                decimal preciounidad = Convert.ToDecimal(fila["Precio"]);
                int cantidadInicial = 1;

                int descuentoInicial = SeleccionarDescuento(codigo, cantidadInicial);
                decimal subtotal = (preciounidad * cantidadInicial) * (1 - (descuentoInicial / 100m));
                int stock = Convert.ToInt32(fila["StockActual"]);

                dataGridView1.Rows.Add
                (
                   idproducto, producto, cantidadInicial, stock, descuentoInicial, preciounidad, subtotal.ToString("0.00")
                );
            }

            listBox1.Visible = false;
            txtBuscador.Clear();
            txtBuscador.Focus();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
            //Calculartotal();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                if (!ValidarStock(row))
                    return;

                if (decimal.TryParse(row.Cells["Precio"].Value?.ToString(), out decimal precio) &&
                    int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out int cantidad))
                {
                    string codigo = row.Cells["Codigo"].Value?.ToString();

                    int descuento = SeleccionarDescuento(codigo, cantidad);
                    row.Cells["Descuento"].Value = descuento;

                    decimal subtotal = (precio * cantidad) * (1 - (descuento / 100m));
                    row.Cells["Subtotal"].Value = subtotal.ToString("0.00");
                }
            }
        }

        private bool ValidarStock(DataGridViewRow row)
        {
            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
            int stock = Convert.ToInt32(row.Cells["StockActual"].Value);

            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.",
                                "Stock insuficiente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                row.Cells["Cantidad"].Value = stock;
                return false;
            }
            return true;
        }
        private int SeleccionarDescuento(string codigo, int cantidad)
        {
            DataTable data = metodos.SeleccionarDescuentos(codigo);
            int descuento = 0;

            foreach (DataRow fila in data.Rows)
            {
                int cantidadMin = Convert.ToInt32(fila["Cantidad"]);
                int desc = Convert.ToInt32(fila["Porcentaje"]);

                if (cantidad >= cantidadMin)
                {
                    descuento = desc;
                }
            }

            return descuento;
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarProductoSeleccionado();
            }
        }
        private void CargarClientes()
        {
            cmbCliente.Items.Clear();
            DataTable clientes = metodos.SeleccionarClientes();
            cmbCliente.Items.Add("1-Consumidor Final");
            foreach (DataRow filas in clientes.Rows)
            {
                string fila = $"{filas["IdCliente"]}-{filas["Nombre"]} {filas["Apellido"]} ({filas["Dni"]})";
                cmbCliente.Items.Add(fila);
            }
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
