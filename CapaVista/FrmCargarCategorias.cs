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
    public partial class FrmCargarCategorias : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmCargarCategorias()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                metodos.InsertarCate(textBox1.Text);
                MessageBox.Show(textBox1.Text);
                MessageBox.Show("Categoria Cargada");
                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
