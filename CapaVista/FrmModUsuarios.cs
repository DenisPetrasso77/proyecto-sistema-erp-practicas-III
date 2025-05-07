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
    public partial class FrmModUsuarios : Form
    {
        public FrmModUsuarios(string usuario,string nombre, string apellido, string dni, string rol, string autorizante, string bloqueado)
        {
            InitializeComponent();
            textBox1.Text= usuario;
            textBox2.Text= nombre;
            textBox3.Text= apellido;
            textBox6.Text= dni;
            textBox5.Text = rol;
            textBox4.Text = autorizante;
            comboBox1.SelectedIndex = bloqueado == "No" ? 1 : 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
