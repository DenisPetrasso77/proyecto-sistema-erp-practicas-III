using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionProductos : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        FrmCargarCategorias Cargarcate = new FrmCargarCategorias();
        FrmCargarMarcas Cargarmarcas = new FrmCargarMarcas();
        FrmCargarTipoProducto Tipoproducto = new FrmCargarTipoProducto();
        CV_Utiles utiles = new CV_Utiles();
        
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cargarcate.ShowDialog();
            Cargarcbxcategorias();
        }
        
        public FrmGestionProductos()
        {
            InitializeComponent();
        }

        private void Cargarcbxcategorias()
        {
            DataTable CacheCategorias = metodos.Categorias();
            foreach (DataRow filas in CacheCategorias.Rows)
            {
                if (filas["Estado"].ToString().Trim() != "Inactivo")
                {
                    string fila = $"{filas["IdCategoria"]} - {filas["Categoria"]}";
                    comboBox1.Items.Add(fila);
                }
            }
        }

        private void Cargarcbxtpoproducto()
        {
            DataTable CacheTipoProducto = metodos.TipoProductos();
            foreach (DataRow filas in CacheTipoProducto.Rows)
            {
                string fila = $"{filas["IdTipoProducto"]} - {filas["TipoProducto"]}";
                comboBox6.Items.Add(fila);
            }
        }
        private void Cargarcbxmedidas()
        {
            DataTable CacheMedidas = metodos.Medidas();
            foreach (DataRow filas in CacheMedidas.Rows)
            {
                string fila = $"{filas["Idmedidas"]} - {filas["Medida"]}";
                comboBox2.Items.Add(fila);
            }
        }
        private void Cargarcbxmarcas()
        {
            DataTable CacheMarcas = metodos.Marcas();
            foreach (DataRow filas in CacheMarcas.Rows)
            {
                string fila = $"{filas["Idmarca"]} - {filas["Marca"]}";
                comboBox4.Items.Add(fila);
            }
        }
        private void Cargarcbxventa()
        {
            DataTable CacheFVentas = metodos.UnidadVenta();
            foreach (DataRow filas in CacheFVentas.Rows)
            {
                string fila = $"{filas["idUnidad"]} - {filas["Unidad"]}";
                comboBox3.Items.Add(fila);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                if (utiles.TextboxVacios(textBox1) && utiles.ComboboxVacios(comboBox1, comboBox2, comboBox4, comboBox5,comboBox6))
                {
                    MessageBox.Show("Por favor complete todos los campos");
                    return;
                }
            }
            else if (checkBox2.Checked)
            {
                if (utiles.TextboxVacios(textBox3, textBox4,textBox5,textBox9,textBox10) && utiles.ComboboxVacios(comboBox3))
                {
                    MessageBox.Show("Por favor complete todos los campos");
                    return;
                }
            }
            

            string codigo = textBox1.Text.Trim();
            int tipoproducto = Convert.ToInt32(comboBox6.Text.Split('-')[0].Trim());
            int marca = Convert.ToInt32(comboBox4.Text.Split('-')[0].Trim());
            int medidas = Convert.ToInt32(comboBox2.Text.Split('-')[0].Trim());
            int cate = Convert.ToInt32(comboBox1.Text.Split('-')[0].Trim());
            string estado = comboBox5.Text.Trim();
            int? fventa = string.IsNullOrWhiteSpace(comboBox3.Text) ? (int?)null : Convert.ToInt32(comboBox3.Text.Split('-')[0].Trim());
            decimal preciocompra = string.IsNullOrWhiteSpace(textBox3.Text) ? (decimal)0 : Convert.ToDecimal(textBox3.Text.Trim());
            decimal precioventa = string.IsNullOrWhiteSpace(textBox4.Text) ? (decimal)0 : Convert.ToDecimal(textBox4.Text.Trim());
            int stockactual = string.IsNullOrWhiteSpace(textBox5.Text) ? (int)0 : Convert.ToInt32(textBox5.Text.Trim());
            int stockmax = string.IsNullOrWhiteSpace(textBox9.Text) ? (int)0 : Convert.ToInt32(textBox9.Text.Trim());
            int stockmin = string.IsNullOrWhiteSpace(textBox10.Text) ? (int)0 : Convert.ToInt32(textBox10.Text.Trim());
            int can1 = string.IsNullOrWhiteSpace(textBox8.Text) ? 0 : Convert.ToInt32(textBox8.Text.Trim());
            int por1 = string.IsNullOrWhiteSpace(textBox11.Text) ? 0 : Convert.ToInt32(textBox11.Text.Trim());
            int can2 = string.IsNullOrWhiteSpace(textBox13.Text) ? 0 : Convert.ToInt32(textBox13.Text.Trim());
            int por2 = string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : Convert.ToInt32(textBox12.Text.Trim());
            int can3 = string.IsNullOrWhiteSpace(textBox15.Text) ? 0 : Convert.ToInt32(textBox15.Text.Trim());
            int por3 = string.IsNullOrWhiteSpace(textBox14.Text) ? 0 : Convert.ToInt32(textBox14.Text.Trim());
            int can4 = string.IsNullOrWhiteSpace(textBox17.Text) ? 0 : Convert.ToInt32(textBox17.Text.Trim());
            int por4 = string.IsNullOrWhiteSpace(textBox16.Text) ? 0 : Convert.ToInt32(textBox16.Text.Trim());
            var descuentos = new List<(int cantidadMinima, int porcentaje)>
            {
                (can1, por1),
                (can2, por2),
                (can3, por3),
                (can4, por4)
            }.Where(d => d.cantidadMinima > 0 && d.porcentaje > 0)
            .OrderByDescending(d => d.cantidadMinima)
            .ToList();
            ProductoNuevo productoNuevo = new ProductoNuevo
            {
                CodigoProducto = codigo,
                Nombre = tipoproducto,
                IdCategoria = cate,
                IdMarca = marca,
                IdMedida = medidas,
                IdUnidadVenta = fventa,
                StockMin = stockmin,
                StockMax = stockmax,
                StockActual = stockactual,
                Estado = estado,
                FechaAlta = DateTime.Now,
                IdUsuarioAlta = 1,
                PrecioCompra = preciocompra,
                PrecioVenta = precioventa,
                Descuentos = descuentos,
            };

            string resultado = metodos.InsertarProducto(productoNuevo);
            MessageBox.Show(resultado);
            utiles.LimpiarControles(this);
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox5.Enabled = true;
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox8.Text = "";
                textBox11.Text = "";
            }
            else
            {
                groupBox5.Enabled = false;
                textBox12.Text = Convert.ToString(0);
                textBox13.Text = Convert.ToString(0);
                textBox14.Text = Convert.ToString(0);
                textBox15.Text = Convert.ToString(0);
                textBox16.Text = Convert.ToString(0);
                textBox17.Text = Convert.ToString(0);
                textBox8.Text = Convert.ToString(0);
                textBox11.Text = Convert.ToString(0);
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox13.Visible = true;
            textBox12.Visible = true;
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;
            pictureBox7.Visible = true;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox14.Visible = true;
            textBox15.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox16.Visible = true;
            textBox17.Visible = true;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = true;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox16.Visible= false;
            textBox17.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
            pictureBox4.Visible= true;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            textBox14.Visible= false;
            textBox15.Visible = false;
            pictureBox3.Visible = true;
            pictureBox7.Visible = true;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible= false;
            pictureBox7.Visible = false;
            pictureBox2.Visible = true;
            textBox12.Visible= false;
            textBox13.Visible = false;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Cargarmarcas.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = !groupBox2.Enabled;
            }
        }

        private void FrmCargarProductos_Load(object sender, EventArgs e)
        {
            Cargarcbxcategorias();
            Cargarcbxmarcas();
            Cargarcbxmedidas();
            Cargarcbxventa();
            Cargarcbxtpoproducto();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Tipoproducto.ShowDialog();
            Cargarcbxtpoproducto();
        }
    }
}
