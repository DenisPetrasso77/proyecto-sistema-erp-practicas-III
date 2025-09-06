using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmRemito : Form
    {
        public FrmRemito()
        {
            InitializeComponent();
        }

        private void FrmFacturaRemito_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(textBox1, textBox2, textBox4, textBox5))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            this.Hide();
        }
        public string PuestoNumero
        {
            get { return textBox1.Text; }
        }
        public string NumeroRemito
        {
            get { return textBox2.Text; }
        }
        public string cuit
        {
            get { return textBox4.Text; }
        }
        public string RazonSocial
        {
            get { return textBox5.Text; }
        }
    }
}
