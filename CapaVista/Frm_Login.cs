using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Frm_Login : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        CV_Utiles utiles = new CV_Utiles();
        Frm_Registro registro = new Frm_Registro();
        Frm_AdminHome home = new Frm_AdminHome();
        CV_Seguridad seguridad = new CV_Seguridad();

        public Frm_Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
                
            if (utiles.CamposVacios(txtUsuario, txtContraseña))
            {
                MessageBox.Show("Por favor complete los datos de ingreso");
                return;
            }
            if (utiles.CamposNumericos(txtUsuario, txtContraseña))
            {
                MessageBox.Show("Los datos no pueden ser numericos");
                return;
            }

            if (seguridad.VertificarHasheo(metodos.DatosIngreso(txtUsuario.Text),(txtContraseña.Text)))
            {
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("Datos de Ingreso Incorrectos");
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            //registro.ShowDialog();
        }
    }
}
