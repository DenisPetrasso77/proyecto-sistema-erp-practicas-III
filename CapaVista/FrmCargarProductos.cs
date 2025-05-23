using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

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
            if (utiles.TextboxVacios(textBox1, textBox2, textBox9, textBox10))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            string codigo = textBox1.Text.Trim();
            string descrip = textBox2.Text.Trim();
            string cate = comboBox1.Text.Trim();
            int stockmax = Convert.ToInt32(textBox9.Text.Trim());
            int stockmin = Convert.ToInt32(textBox10.Text.Trim());
            string formadecarga = comboBox2.Text.Trim();
            int cantidadcarga = Convert.ToInt32(textBox3.Text.Trim());
            int unidadesxcarga = Convert.ToInt32(textBox4.Text.Trim());
            int vendeporunidades = checkBox4.Checked ? 1 : 0;
            int vendeporkilo = checkBox3.Checked ? 1 : 0;
            int vendeporpack = checkBox5.Checked ? 1 : 0;
            decimal precioporunidad = textBox6.Visible ? Convert.ToDecimal(textBox6.Text.Trim()) : 0;
            decimal precioporkilo = textBox5.Visible ? Convert.ToDecimal(textBox5.Text.Trim()) : 0;
            decimal precioporpack = textBox7.Visible ? Convert.ToDecimal(textBox7.Text.Trim()) : 0;
            string unidadreferencia = comboBox1.Text.Trim();
            string resultado = metodos.InsertarProducto(codigo, descrip, cate, stockmin, stockmax, formadecarga, cantidadcarga, unidadesxcarga, vendeporunidades, vendeporkilo, vendeporpack, precioporunidad, precioporkilo, precioporpack, 1, unidadreferencia);
            MessageBox.Show(resultado);
            utiles.LimpiarControles(this);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            { 
                label5.Visible = false;
                textBox3.Visible = false;
            }
            if (comboBox2.SelectedItem.ToString()== "Bulto")
            {
                label5.Visible = true;
                label5.Text = "¿Cuantos Bultos?";
                textBox3.Visible = true;
                textBox3.Location = new Point(398, 18);
                label6.Visible = true;
                textBox4.Visible = true;
                label9.Visible = true;
            }
            else
            {
                label5.Visible = true;
                label5.Text = "¿Cuantos Paquetes Cerrados?";
                textBox3.Visible = true;
                textBox3.Location = new Point(489, 18);
                label6.Visible = true;
                textBox4.Visible = true;
                label9.Visible = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text= comboBox3.Text;
        }

        private void actualizarresumen()
        {
            if (!utiles.TextboxVacios(textBox1, textBox2, textBox3, textBox4, textBox9, textBox10) && !utiles.ComboboxVacios(comboBox1, comboBox2, comboBox3))
            {
                int a = Convert.ToInt32(textBox3.Text);
                int b = Convert.ToInt32(textBox4.Text);
                label7.Visible = true;
                label14.Visible = true;
                label14.Text = $"Stock Maximo: {textBox9.Text} {comboBox3.Text}";
                label15.Visible = true;
                label15.Text = $"Stock Minimo: {textBox10.Text} {comboBox3.Text}";
                label10.Visible = true;
                label10.Text = $"1 {comboBox2.Text} = {textBox4.Text} {comboBox3.Text}";
                label13.Visible = true;
                label13.Text = $"Total a Ingresar: {a * b} {comboBox3.Text}";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void groupBox4_Enter_1(object sender, EventArgs e)
        {
            actualizarresumen();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox8.Visible = true;
                textBox5.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                textBox8.Visible = false;
                textBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                textBox12.Visible = false;
                textBox12.Text = Convert.ToString(0);
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
            }
        }
    }
}
