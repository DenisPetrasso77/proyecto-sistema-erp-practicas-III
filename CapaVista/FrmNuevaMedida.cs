using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
namespace CapaVista
{
    public partial class FrmNuevaMedida : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmNuevaMedida()
        {
            InitializeComponent();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "EJEM. 18X18X18")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text ="EJEM. 18X18X18";
                textBox2.ForeColor = SystemColors.ActiveBorder;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor ingrese las medidas nuevas");
                return;
            }
            try
            {
                MessageBox.Show(metodos.InsertarMedidas(textBox2.Text));
                textBox2.Text = "";
                textBox2.Focus();
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
        }
    }
}
