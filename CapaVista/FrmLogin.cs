using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

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
                MessageBox.Show("Por favor complete los datos de ingreso");
                return;
            }
            if (CV_Utiles.CamposNumericos(txtUsuario, txtContraseña))
            {
                MessageBox.Show("Los datos no pueden ser numericos");
                return;
            }
            Sesion.Usuario = metodos.DatosIngreso(txtUsuario.Text);

            if (Sesion.Usuario == null)
            {
                MessageBox.Show("Datos Incorrectos");
                return;
            }
            if (Sesion.Usuario.Bloqueado == "1")
            {
                metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Intento de Login Con Usuario Bloqueado");
                MessageBox.Show("Usuario Bloqueado, Contacte con Administracion");
                return;
            }
            try
            {
                if (CV_Seguridad.VertificarHasheo(Sesion.Usuario.Contraseña, txtContraseña.Text))
                {
                    metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", $"Intento de Login Exitoso");
                    this.Hide();
                    FrmAdminHome home = new FrmAdminHome();
                    home.Show();
                }
                else
                {
                    metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", $"Intento de Login Erroneo Clave Usada {txtContraseña.Text}");
                    metodos.Intentos(Sesion.Usuario.Usuario);
                    MessageBox.Show("Datos Incorrectos");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos Incorrectos" + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            //if (!VerificarIntegridadUsuarios())
            //{
            //    MessageBox.Show("Error en la integridad de los datos, por favor contacte con soporte");
            //    this.Close();
            //}
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
    }
}
