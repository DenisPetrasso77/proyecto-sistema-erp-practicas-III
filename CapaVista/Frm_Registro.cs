using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Frm_Registro : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        CV_Seguridad seguridad = new CV_Seguridad();
        public int Idactual { get; set; }
        public Frm_Registro()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (metodos.Registro(textBox1.Text,seguridad.Hasheo(textBox2.Text),textBox3.Text,textBox4.Text,textBox5.Text,Idactual) > 0)
            {
                MessageBox.Show("Guardado Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
    }
}
