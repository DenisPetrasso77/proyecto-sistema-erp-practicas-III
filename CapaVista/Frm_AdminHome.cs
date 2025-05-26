using CapaLogica;
using Entities;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Frm_AdminHome : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        private DataTable productosCache = new DataTable();
        FrmCargarCategorias cate = new FrmCargarCategorias();
        FrmCargarProductos productos = new FrmCargarProductos();
        FrmGestionPR gestionpr = new FrmGestionPR();
        Usuarioactual Usuarioactual;
        FrmAdmusuarios Admusuarios;

        public Frm_AdminHome()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void AgregarProductoSeleccionado()
        {
            if (listBox1.SelectedItem == null)
                return;

            string itemSeleccionado = listBox1.SelectedItem.ToString();
            string codigo = itemSeleccionado.Split('-')[0].Trim();

            DataRow[] seleccion = productosCache.Select($"Codigo = '{codigo}'");

            if (seleccion.Length > 0)
            {
                DataRow fila = seleccion[0];

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Codigo"].Value?.ToString() == codigo)
                    {
                        if (int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidadActual))
                        {
                            cantidadActual++;
                            row.Cells["Cantidad"].Value = cantidadActual;


                            if (decimal.TryParse(row.Cells["PrecioUnidad"].Value.ToString(), out decimal precio) &&
                                decimal.TryParse(row.Cells["Descuento"].Value?.ToString(), out decimal descuento))
                            {
                                decimal total = (precio * cantidadActual) * (1 - (descuento / 100));
                                row.Cells["Subtotal"].Value = total.ToString("0.00");
                            }
                        }

                        listBox1.Visible = false;
                        textBox1.Clear();
                        textBox1.Focus();
                        return;
                    }
                }
                string codigoproduc = fila["Codigo"].ToString();
                string descripcion = fila["Descripcion"].ToString();
                int stock = Convert.ToInt32(fila["Stock"]);
                decimal preciounidad = Convert.ToDecimal(fila["Preciounidad"]);
                decimal preciox10 = fila["Preciox10"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Preciox10"]);
                decimal preciox25 = fila["Preciox25"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Preciox25"]);
                decimal preciox50 = fila["Preciox50"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Preciox50"]);
                decimal preciox100 = fila["Preciox100"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Preciox100"]);
                decimal bulto = fila["Bulto"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["Bulto"]);
                decimal subtotal = preciounidad;
                dataGridView1.Rows.Add(
                    codigoproduc,
                    descripcion,
                    stock,
                    1,
                    "",
                   preciounidad,
                   preciox10,
                   preciox25,
                   preciox50,
                   preciox100,
                   bulto,
                   "",
                   "",
                   "",
                   "",
                   0,
                   subtotal
                );
            }
            Calculartotal();
            listBox1.Visible = false;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarProductoSeleccionado();
                Calculartotal();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            AgregarProductoSeleccionado();
            Calculartotal();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["PrecioUnidad"].Value?.ToString(), out decimal precio) &&
                    int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out int cantidad))
                {
                    int Unidadesx10 = int.TryParse(row.Cells["x10Unidades"].Value?.ToString(), out int ux10) ? ux10 : 0;
                    int Unidadesx25 = int.TryParse(row.Cells["x25Unidades"].Value?.ToString(), out int ux25) ? ux25 : 0;
                    int Unidadesx50 = int.TryParse(row.Cells["x50Unidades"].Value?.ToString(), out int ux50) ? ux50 : 0;
                    int Unidadesx100 = int.TryParse(row.Cells["x100Unidades"].Value?.ToString(), out int ux100) ? ux100 : 0;
                    int Cantbulto = int.TryParse(row.Cells["Bulto"].Value?.ToString(), out int bulto) ? bulto : 0;

                    decimal Preciox10 = decimal.TryParse(row.Cells["Preciox10"].Value?.ToString(), out decimal px10) ? px10 : 0;
                    decimal Preciox25 = decimal.TryParse(row.Cells["Preciox25"].Value?.ToString(), out decimal px25) ? px25 : 0;
                    decimal Preciox50 = decimal.TryParse(row.Cells["Preciox50"].Value?.ToString(), out decimal px50) ? px50 : 0;
                    decimal Preciox100 = decimal.TryParse(row.Cells["Preciox100"].Value?.ToString(), out decimal px100) ? px100 : 0;
                    decimal Preciobulto = decimal.TryParse(row.Cells["PrecioBulto"].Value?.ToString(), out decimal pbulto) ? pbulto : 0;
                    decimal descuento = decimal.TryParse(row.Cells["Descuento"].Value?.ToString(), out decimal desc) ? desc : 0;

                    decimal subtotal = ((precio * cantidad)+(Unidadesx10*Preciox10)+(Unidadesx25*Preciox25)+(Unidadesx50*Preciox50)+(Unidadesx100*Preciox100)+(Preciobulto*Cantbulto)) * (1 - (descuento / 100));
                    row.Cells["Subtotal"].Value = subtotal.ToString("0.00");
                }
            }
            Calculartotal();
        }

        Panel p = new Panel();
        private void btnMouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            panel1.Controls.Add(p);
            p.BackColor = Color.FromArgb(90, 210, 2);
            p.Size = new Size(135, 35);
            p.Location = new Point(btn.Location.X, btn.Location.Y);
        }
        private void btnMouseLeave(object sender, EventArgs e)
        {
            panel1.Controls.Remove(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel2.Visible)
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(p);
            productos.ShowDialog();
            Cargarbuscador();
        }

        private void Calculartotal()
        {
            decimal Total = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                Total += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
            }
            label2.Text = $"{Total}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow fila in dataGridView1.Rows)
            //{ 
            //    var x1 = Convert.ToInt32(fila.Cells["Cantidad"].Value);
            //    var x10 = Convert.ToInt32(fila.Cells["x10Unidades"].Value) * 10;
            //    var x25 = Convert.ToInt32(fila.Cells["x25Unidades"].Value) * 25;
            //    var x50 = Convert.ToInt32(fila.Cells["x50Unidades"].Value) * 50;
            //    var x100 = Convert.ToInt32(fila.Cells["x10Unidades"].Value) * 100;
            //    int Totalunidades = x1 + x10 + x25 + x50 + x100;
            //}

            //int Idventa = metodos.InsertarVentas(Convert.ToDecimal(label2));
            //foreach (DataGridViewRow fila in dataGridView1.Rows)
            //{
            //    string Idproducto = fila.Cells["Codigo"].Value.ToString();
            //    int Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
            //    decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);
            //    metodos.InsertarDetalles();
            //}
        }

        private void Cargarbuscador()
        {
            string texto = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                listBox1.Visible = false;
                return;
            }

            //productosCache = metodos.MostrarTodo("Productos");
            listBox1.Items.Clear();

            foreach (DataRow fila in productosCache.Rows)
            {
                string item = $"{fila["Codigo"]} - {fila["Descripcion"]} - ${Convert.ToDecimal(fila["Preciounidad"]):0.00}";
                listBox1.Items.Add(item);
            }

            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel3.Visible)
                panel3.Visible = true;
            else
                panel3.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(p);
            Admusuarios = new FrmAdmusuarios();
            Admusuarios.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            gestionpr.Show();
        }
    }
}
