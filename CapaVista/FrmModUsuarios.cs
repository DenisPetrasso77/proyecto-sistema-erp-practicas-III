using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmModUsuarios : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmModUsuarios(string usuario,string nombre, string apellido, string dni, string rol, string autorizante, string bloqueado)
        {
            InitializeComponent();
            textBox1.Text= usuario;
            textBox2.Text= nombre;
            textBox3.Text= apellido;
            textBox6.Text= dni;
            textBox5.Text = rol;
            textBox4.Text = autorizante;
            comboBox1.SelectedIndex = bloqueado == "No" ? 0 : 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (metodos.ActualizarUsuario(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text, Convert.ToInt32(textBox5.Text), comboBox1.SelectedIndex) > 0)
            {
                MessageBox.Show("Usuario Actualizado");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
