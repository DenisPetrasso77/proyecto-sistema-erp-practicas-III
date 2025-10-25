using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmLogin : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtUsuario, txtContraseña))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgCompleteDatos"));
                return;
            }
            if (CV_Utiles.CamposNumericos(txtUsuario, txtContraseña))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgNoNumericos"));
                return;
            }
            var resultado = metodos.VerificarIngreso(txtUsuario.Text, CV_Seguridad.HashearSHA256(txtContraseña.Text.Trim()));
            if (resultado != 1.ToString())
            {
                MessageBox.Show(Traductor.TraducirTexto(resultado),Traductor.TraducirTexto("msgAtencion"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Sesion.Usuario = metodos.DatosIngreso(txtUsuario.Text);
                int resultadodv = VerificarIntegridadUsuarios();
                if (resultadodv != 0)
                    if (Sesion.Usuario.Rol != "Administrador")
                    {
                        MessageBox.Show(
                            Traductor.TraducirTexto("msgRestablecerDV"),
                            Traductor.TraducirTexto("msgAtencion"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            Traductor.TraducirTexto("msgRestablecerDV"),
                            Traductor.TraducirTexto("msgAtencion"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Intento de Login Exitoso");

                        this.Hide();
                        FrmSidebar sideBar = new FrmSidebar();
                        sideBar.Show();
                        return;
                    }
                if (resultadodv == 0)
                {
                    if (Sesion.Usuario.PrimerIngreso != 0)
                    {
                        MessageBox.Show(Traductor.TraducirTexto("msgActualizarContrasena"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmActualizarContraseña frmActualizar = new FrmActualizarContraseña();
                        this.Hide();
                        frmActualizar.ShowDialog();
                        Sesion.Usuario = metodos.DatosIngreso(txtUsuario.Text);
                        this.Show();

                    }
                    else
                    {
                        this.Hide();
                        FrmSidebar sideBar = new FrmSidebar();
                        sideBar.Show();
                    }
                    metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Intento de Login Exitoso");                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Traductor.TraducirTexto("msgErrorVerificar") + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {           
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Lenguajes","Idiomas.json");
            Traductor.CargarJson(ruta);
            Traductor.Idioma = "es";
            Traductor.TraducirFormulario(this);
            CargarToolsTip();
            txtUsuario.Focus();
            cmbLenguaje.SelectedIndex = 1;
        }
        private void CargarToolsTip()
        {
            toolTip1.SetToolTip(txtUsuario, Traductor.TraducirTexto("lblUsuario"));
            toolTip1.SetToolTip(txtContraseña, Traductor.TraducirTexto("lblContraseña"));
            toolTip1.SetToolTip(btnIngresar, Traductor.TraducirTexto("lblIngresar"));
            toolTip1.SetToolTip(pbSalir, Traductor.TraducirTexto("lblSalir"));

            toolTip1.AutoPopDelay = 5000;   // tiempo visible (ms)
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer (ms)
            toolTip1.ReshowDelay = 200;     // tiempo entre tooltips (ms)
            toolTip1.ShowAlways = true;     // mostrar aunque el form no tenga foco
        }
        public int VerificarIntegridadUsuarios()
        {
            int resultado = metodos.VerificarIntegridad(CV_Seguridad.ObtenerPalabra());
            return resultado;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtContraseña.UseSystemPasswordChar)
            {
                txtContraseña.UseSystemPasswordChar = false;
                UI_Utilidad.TextBoxHelper.SetPadding(txtContraseña, 25, 5);
                pictureBox4.Image = CapaVista.Properties.Resources.Ojo_Abierto;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
                UI_Utilidad.TextBoxHelper.SetPadding(txtContraseña, 25, 5);
                pictureBox4.Image = CapaVista.Properties.Resources.Ojo_Cerrado;

            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnIngresar);
            UI_Utilidad.EstiloTextBox(txtUsuario, "Usuario");
            UI_Utilidad.EstiloTextBox(txtContraseña, "Contraseña");
            UI_Utilidad.AplicarEfectoHover(pbSalir);

            this.Text = "Papelera";

            FormDragHelper.EnableDrag(this, pictureBox1);


        }

        private void lblOlvidoContraseña_Click(object sender, EventArgs e)
        {
            FrmRecupero frmRecupero = new FrmRecupero();
            frmRecupero.ShowDialog();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            { 
                btnIngresar.PerformClick();
            }
        }

        private void cmbLenguaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLenguaje.SelectedIndex) 
            {
                case 0:
                    Traductor.Idioma = "de";
                    break;
                case 1:
                    Traductor.Idioma = "es";
                    break;
                case 2:
                    Traductor.Idioma = "fr";
                    break;
                case 3:
                    Traductor.Idioma = "en";
                    break;
                case 4:
                    Traductor.Idioma = "it";
                    break;
                case 5:
                    Traductor.Idioma = "pt";
                    break;
                case 6:
                    Traductor.Idioma = "tr";
                    break;
            }
            Traductor.TraducirFormulario(this);
            CargarToolsTip();
        }
    }
}
