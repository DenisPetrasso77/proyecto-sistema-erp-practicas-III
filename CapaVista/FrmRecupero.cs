using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmRecupero : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmRecupero()
        {
            InitializeComponent();
        }
        private void ValidarDatos()
        { 
            if (CV_Utiles.TextboxVacios(txtDato))
            {
                MessageBox.Show("Por favor ingrese su usuario/correo");
                return;
            }
            if (CV_Utiles.CamposNumericos(txtDato))
            {
                MessageBox.Show("Los datos no pueden ser numericos");
                return;
            }
            DataTable dt = metodos.TraerPregunta(txtDato.Text);
            if (dt.Rows.Count > 0)
            {
                txtPregunta.Text = dt.Rows[0]["Pregunta"].ToString();
                txtDato.Enabled = false;
                button1.Enabled = false;
                label2.Visible = true;
                label3.Visible= true;
                txtPregunta.Visible = true;
                txtRespuesta.Visible = true;
                button2.Visible = true;
            }
            else
            {
                MessageBox.Show("Verifique el dato ingresado");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string respuesta = CV_Seguridad.HashearSHA256(txtRespuesta.Text.ToLower());
            int resultado = metodos.VerificarRespuesta(txtDato.Text, respuesta);
            switch(resultado)
            {
                case 1:
                    label4.Visible = true;
                    label5.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    button3.Visible = true;
                    txtPregunta.Enabled = false;
                    txtRespuesta.Enabled = false;
                    button2.Enabled = false;
                    break;
                case 0:
                    MessageBox.Show("Respuesta Incorrecta, intente nuevamente");
                    break;
                case -2:
                    MessageBox.Show("Usuario Bloqueado, Contacte con Administracion");
                    break;
                case -1:
                    MessageBox.Show("Usuario No Encontrado");
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(textBox1, textBox2))
            {
                MessageBox.Show("Por favor complete ambos campos");
                return;
            }
            if (CV_Utiles.CamposNumericos(textBox1, textBox2))
            {
                MessageBox.Show("Las Contraseñas no Pueden ser Numericas");
                return;
            }
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            string nuevaContraseña = CV_Seguridad.Hasheo(textBox1.Text);
            try
            {
                MessageBox.Show(metodos.CambiarContraseña(txtDato.Text, nuevaContraseña));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message);
                return;
            }
        }
    }
}
