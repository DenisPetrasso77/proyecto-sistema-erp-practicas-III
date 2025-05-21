using CapaLogica;
using Entities;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Frm_Login : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        CV_Utiles utiles = new CV_Utiles();
        CV_Seguridad seguridad = new CV_Seguridad();
        Usuarioactual usuarioactual;
        Frm_Registro registro = new Frm_Registro();

        public Frm_Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //    if (utiles.CamposVacios(txtUsuario, txtContraseña))
            //    {
            //        MessageBox.Show("Por favor complete los datos de ingreso");
            //        return;
            //    }
            //    if (utiles.CamposNumericos(txtUsuario, txtContraseña))
            //    {
            //        MessageBox.Show("Los datos no pueden ser numericos");
            //        return;
            //    }
            //    usuarioactual = metodos.DatosIngreso(txtUsuario.Text);

            //    if (usuarioactual == null)
            //    {
            //        MessageBox.Show("Datos Incorrectos");
            //        return;
            //    }
            //    try
            //    {
            //        if (seguridad.VertificarHasheo(usuarioactual.contraseña, txtContraseña.Text))
            //        {
            this.Hide();
            Frm_AdminHome home = new Frm_AdminHome();
            home.Show();
            //        }
            //        else if (usuarioactual.usuario != null)
            //        {
            //            MessageBox.Show("Datos Incorrectos");
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Datos Incorrectos");
            //    }
            //}
        }
    }
}
