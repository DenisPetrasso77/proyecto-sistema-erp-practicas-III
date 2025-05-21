using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCargarProductos : Form
    {

        CL_Metodos metodos = new CL_Metodos();
        FrmCargarCategorias Cargarcate = new FrmCargarCategorias();
        CV_Utiles utiles = new CV_Utiles();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cargarcate.ShowDialog();
            Cargarcbx();
            
        }
        
        public FrmCargarProductos()
        {
            InitializeComponent();
            Cargarcbx();
            comboBox2.SelectedIndex = 0;
        }
        private void Cargarcbx()
        {
            //DataTable Cacheproductos = metodos.MostrarTodo("Categorias");
            //foreach (DataRow filas in Cacheproductos.Rows)
            //{
            //    string fila = $"{filas["Id"]} - {filas["Categoria"]}";
            //    comboBox1.Items.Add(fila);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (utiles.CamposVacios(textBox1,textBox2,textBox9,textBox10))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            string codigo = textBox1.Text.Trim();
            string descrip = textBox2.Text.Trim();
            string cate = comboBox1.Text.Trim();
            int stockmax = Convert.ToInt32(textBox9.Text.Trim());
            int stockmin = Convert.ToInt32(textBox10.Text.Trim());
            string formadecarga = comboBox1.Text.Trim();
            int cantidadcarga = Convert.ToInt32(textBox3.Text.Trim());
            int unidadesxcarga = Convert.ToInt32(textBox4.Text.Trim());
            int vendeporunidades = checkBox4.Checked ? 1 : 0;
            int vendeporkilo = checkBox3.Checked ? 1 : 0;
            int vendeporpack = checkBox5.Checked ? 1 : 0;
            int vendeporbulto = checkBox6.Checked ? 1 : 0;
            decimal precioporunidad = textBox6.Visible ? Convert.ToDecimal(textBox6.Text.Trim()) : 0;
            decimal precioporkilo = textBox5.Visible ? Convert.ToDecimal(textBox5.Text.Trim()) : 0;
            decimal precioporpack = textBox7.Visible ? Convert.ToDecimal(textBox7.Text.Trim()) : 0;
            decimal precioporbulto = textBox8.Visible ? Convert.ToDecimal(textBox8.Text.Trim()) : 0;
            string resultado = metodos.InsertarProducto(codigo, descrip, cate, stockmin, stockmax, formadecarga, cantidadcarga, unidadesxcarga, vendeporunidades, vendeporkilo, vendeporpack, vendeporbulto, precioporunidad, precioporkilo, precioporpack, precioporbulto,1);
            MessageBox.Show(resultado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(textBox1.Text))
            //    {
            //        DataTable ids = metodos.MostrarTodo("Productos");
            //        foreach (DataRow fila in ids.Rows)
            //        {
            //            if (fila["Id"].ToString() == textBox1.Text)
            //            {
            //                MessageBox.Show($"Ya existe un producto con el codigo {textBox1.Text}");
            //                textBox1.Clear();
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error al conectar con la base de datos");
            //}
        }

        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox6.Clear();
                textBox6.Visible = true;
            }
            else
            { 
                textBox6.Clear();
                textBox6.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox5.Clear();
                textBox5.Visible = true;
            }
            else
            {
                textBox5.Clear();
                textBox5.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox7.Clear();
                textBox7.Visible = true;
            }
            else
            {
                textBox7.Clear();
                textBox7.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                textBox8.Clear();
                textBox8.Visible = true;
            }
            else
            {
                textBox8.Clear();
                textBox8.Visible = false;
            }
        }
    }
}
