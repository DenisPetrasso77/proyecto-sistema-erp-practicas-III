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
        Frm_Registro registro = new Frm_Registro();
        Frm_AdminHome home = new Frm_AdminHome();
        CV_Seguridad seguridad = new CV_Seguridad();
        Usuarioactual usuarioactual;

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
            usuarioactual = metodos.DatosIngreso(txtUsuario.Text);
            if (usuarioactual == null)
            {
                MessageBox.Show("Datos Incorrectos");
                return;
            }
            if (usuarioactual.bloqueado == 1)
            {
                MessageBox.Show("Usuario Bloqueado");
                metodos.Bitacora($"El usuario: {txtUsuario.Text} ha intentado ingresar estando bloqueado",DateTime.Now);
                return;
            }

            try
            {
                if (seguridad.VertificarHasheo(usuarioactual.contraseña, txtContraseña.Text))
                {
                    metodos.Bitacora($"El usuario ({usuarioactual.usuario}) ha ingreso al sistema correctamente", DateTime.Now);
                    this.Hide();
                    home.Show();
                }
                else if (usuarioactual.usuario != null)
                {
                    metodos.Bitacora($"Ingreso incorrecto del usuario ({usuarioactual.usuario}) con la contraseña ({txtContraseña.Text})", DateTime.Now);
                    metodos.StatusBloq(txtUsuario.Text);
                    MessageBox.Show("Datos Incorrectos");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos Incorrectos");
            }

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            registro.ShowDialog();
        }
    }
}
