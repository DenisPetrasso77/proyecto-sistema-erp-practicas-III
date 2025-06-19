using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmNuevaMarca : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmNuevaMarca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de la nueva marca");
                return;
            }
            try
            {
                MessageBox.Show(metodos.InsertarMarca(textBox2.Text));
                textBox2.Text = "";
                textBox2.Focus();
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
