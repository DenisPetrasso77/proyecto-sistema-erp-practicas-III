using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        CL_Metodos metodos = new CL_Metodos();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(txtUsuario, txtContraseña))
            {
                MessageBox.Show("Por favor complete los datos de ingreso");
                return;
            }
            if (CV_Utiles.CamposNumericos(txtUsuario, txtContraseña))
            {
                MessageBox.Show("Los datos no pueden ser numericos");
                return;
            }
            var resultado = metodos.VerificarIngreso(txtUsuario.Text, CV_Seguridad.HashearSHA256(txtContraseña.Text.Trim()));
            if (resultado != 1.ToString())
            {
                MessageBox.Show(resultado);
                return;
            }
            try
            {
                Sesion.Usuario = metodos.DatosIngreso(txtUsuario.Text);
                metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", $"Intento de Login Exitoso");
                this.Hide();
                FrmSidebar sideBar = new FrmSidebar();
                sideBar.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar verificar los datos" + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CargarToolsTip();
            txtUsuario.Focus();
            //if (!VerificarIntegridadUsuarios())
            //{
            //    MessageBox.Show("Error en la integridad de los datos, por favor contacte con soporte");
            //    this.Close();
            //}
        }
        private void CargarToolsTip()
        {
            toolTip1.SetToolTip(txtUsuario, "INGRESE SU USUARIO");
            toolTip1.SetToolTip(txtContraseña, "INGRESE SU CONTRASEÑA");
            toolTip1.SetToolTip(btnIngresar, "INGRESAR");
            toolTip1.SetToolTip(pbSalir, "CERRAR EL SISTEMA");

            toolTip1.AutoPopDelay = 5000;   // tiempo visible (ms)
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer (ms)
            toolTip1.ReshowDelay = 200;     // tiempo entre tooltips (ms)
            toolTip1.ShowAlways = true;     // mostrar aunque el form no tenga foco
        }
        public bool VerificarIntegridadUsuarios()
        {
            DataTable usuarios = metodos.Usuarios();

            foreach (DataRow fila in usuarios.Rows)
            {
                int DVoriginal = Convert.ToInt32(fila["dv"]);

                string cadena = fila["Usuario"].ToString()
                                + fila["Contraseña"].ToString()
                                + fila["Estado"].ToString()
                                + fila["Nombre"].ToString()
                                + fila["Apellido"].ToString()
                                + fila["Intentos"].ToString()
                                + fila["Bloqueado"].ToString()
                                + fila["Idrol"].ToString()
                                + fila["Dni"].ToString();

                int recalculadoDV = CV_Seguridad.CalcularDVH(cadena);
                if (DVoriginal != recalculadoDV)
                {
                    metodos.Bitacora(Convert.ToInt32(fila["IdUsuario"].ToString()), "Usuarios", $"DV esperado: {fila["dv"].ToString()} DV Obtenido {recalculadoDV}");
                    return false;
                }
            }
            return true;
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
    }
}
