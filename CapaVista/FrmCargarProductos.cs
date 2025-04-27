using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            comboBox1.SelectedIndex = 0;
        }
        private void Cargarcbx()
        {
            DataTable Cacheproductos = metodos.MostrarTodo("Categorias");
            foreach (DataRow filas in Cacheproductos.Rows)
            {
                string fila = $"{filas["Id"]} - {filas["Categoria"]}";
                comboBox1.Items.Add(fila);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (utiles.CamposVacios(textBox1,textBox2,textBox4,textBox5))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            string codigo = textBox1.Text.Trim();
            string desc = textBox2.Text.Trim();
            int idcate = Convert.ToInt32(comboBox1.Text.Split('-')[0].Trim());
            int stock = Convert.ToInt32(textBox9.Text.Trim());
            int cantmin = Convert.ToInt32(textBox10.Text.Trim());
            decimal preciobulto = textBox7.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox7.Text.Trim());
            decimal preciounidad = textBox3.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox3.Text.Trim());
            decimal preciox10 = textBox4.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox4.Text.Trim());
            decimal preciox25 = textBox5.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox5.Text.Trim());
            decimal preciox50 = textBox6.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox6.Text.Trim());
            decimal preciox100 = textBox8.Text.Trim() == "" ? 0 : Convert.ToDecimal(textBox8.Text.Trim());
            try
            {
                metodos.InsertarProductos(codigo,desc,idcate,stock,cantmin,preciobulto,preciounidad,preciox10,preciox25,preciox50,preciox100);
                utiles.LimpiarControles(this);
                textBox1.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al guardar - {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    DataTable ids = metodos.MostrarTodo("Productos");
                    foreach (DataRow fila in ids.Rows)
                    {
                        if (fila["Id"].ToString() == textBox1.Text)
                        {
                            MessageBox.Show($"Ya existe un producto con el codigo {textBox1.Text}");
                            textBox1.Clear();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con la base de datos");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
