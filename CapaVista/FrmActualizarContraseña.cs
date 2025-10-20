using CapaEntities;
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
    public partial class FrmActualizarContraseña : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmActualizarContraseña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(textBox1,textBox3))
                {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CV_Utiles.CamposNumericos(textBox1, textBox3))
            {
                MessageBox.Show("Las Contraseñas No Pueden ser Numericas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox1.Text == textBox3.Text)
            {
                string contraseña = CV_Seguridad.HashearSHA256(textBox1.Text);
                string resultado = metodos.CambiarContraseña(Sesion.Usuario.Usuario, contraseña, CV_Seguridad.ObtenerPalabra());
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
