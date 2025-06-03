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
    public partial class FrmCargarProductos : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        FrmCargarCategorias Cargarcate = new FrmCargarCategorias();
        FrmCargarMarcas Cargarmarcas = new FrmCargarMarcas();
        CV_Utiles utiles = new CV_Utiles();
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cargarcate.ShowDialog();
            Cargarcbxcategorias();
        }
        
        public FrmCargarProductos()
        {
            InitializeComponent();
            Cargarcbxcategorias();
            Cargarcbxmarcas();
            Cargarcbxmedidas();
            Cargarcbxventa();
        }

        private void Cargarcbxcategorias()
        {
            DataTable CacheCategorias = metodos.Categorias();
            foreach (DataRow filas in CacheCategorias.Rows)
            {
                string fila = $"{filas["IdCategoria"]} - {filas["Categoria"]}";
                comboBox1.Items.Add(fila);
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
            if (utiles.TextboxVacios(textBox1, textBox2, textBox9, textBox10))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            string codigo = textBox1.Text.Trim();
            string descrip = textBox2.Text.Trim();
            int marca = Convert.ToInt32(comboBox4.Text.Split('-')[0].Trim());
            int medidas = Convert.ToInt32(comboBox2.Text.Split('-')[0].Trim());
            int cate = Convert.ToInt32(comboBox1.Text.Split('-')[0].Trim());
            string estado = comboBox5.Text.Trim();
            int fventa = Convert.ToInt32(comboBox3.Text.Split('-')[0].Trim());
            decimal preciocompra = Convert.ToDecimal(textBox3.Text.Trim());
            decimal precioventa = Convert.ToDecimal(textBox4.Text.Trim());
            int stockactual = Convert.ToInt32(textBox5.Text.Trim());
            int stockmax = Convert.ToInt32(textBox9.Text.Trim());
            int stockmin = Convert.ToInt32(textBox10.Text.Trim());
            //            int can1 = string.IsNullOrWhiteSpace(textBox8.Text) ? 0 : Convert.ToInt32(textBox8.Text.Trim());
            //            int por1 = string.IsNullOrWhiteSpace(textBox11.Text) ? 0 : Convert.ToInt32(textBox11.Text.Trim());
            //            int can2 = string.IsNullOrWhiteSpace(textBox13.Text) ? 0 : Convert.ToInt32(textBox13.Text.Trim());
            //            int por2 = string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : Convert.ToInt32(textBox12.Text.Trim());
            //            int can3 = string.IsNullOrWhiteSpace(textBox15.Text) ? 0 : Convert.ToInt32(textBox15.Text.Trim());
            //            int por3 = string.IsNullOrWhiteSpace(textBox14.Text) ? 0 : Convert.ToInt32(textBox14.Text.Trim());
            //            int can4 = string.IsNullOrWhiteSpace(textBox17.Text) ? 0 : Convert.ToInt32(textBox17.Text.Trim());
            //            int por4 = string.IsNullOrWhiteSpace(textBox16.Text) ? 0 : Convert.ToInt32(textBox16.Text.Trim());
            //            var descuentos = new List<(int cantidadMinima, int porcentaje)>
            //{
            //    (can1, por1),
            //    (can2, por2),
            //    (can3, por3),
            //    (can4, por4)
            //}.Where(d => d.cantidadMinima > 0 && d.porcentaje > 0)
            //.OrderByDescending(d => d.cantidadMinima)
            //.ToList();
            string resultado = metodos.InsertarProducto(codigo, descrip,cate,marca,medidas,fventa, stockactual, stockmin,stockmax,estado,DateTime.Now,1,preciocompra,precioventa);
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= textBox2.TextLength; i++)
            {
                label7.Text = $"{i.ToString()}/30";
            }
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
    }
}
