using System;
using System.Data;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;

namespace CapaVista
{
    public partial class FrmRegistro : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmRegistro()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioNuevo usuarioNuevo = new UsuarioNuevo()
            {
                Usuario = txtUsuario.Text.Trim(),
                Contraseña = CV_Seguridad.Hasheo(txtContraseña.Text).Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Rol = Convert.ToInt32(cmbRol.Text.Split('-')[0].ToString()),
                Dni = txtDNI.Text.Trim(),
                dv = CV_Seguridad.CalcularDVH(txtUsuario.Text + CV_Seguridad.Hasheo(txtContraseña.Text) + "Activo"+ txtNombre.Text + txtApellido.Text + Convert.ToInt32(cmbRol.Text.Split('-')[0].ToString()) + 0 + cmbRol.Text.Split('-')[0].ToString() + txtDNI.Text)
            };
            string resultado = metodos.Registro(usuarioNuevo);
            MessageBox.Show(resultado);
        }
        private void CargarRoles()
        {
            DataTable cacheroles = metodos.TraerTodo("Roles");
            cmbRol.Items.Clear();
            foreach (DataRow fila in cacheroles.Rows)
            {
                string rol = $"{fila["IdRol"].ToString()} - {fila["NombreRol"].ToString()}";
                cmbRol.Items.Add(rol);
            }
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void FrmRegistro_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloTextBox(txtApellido);
            UI_Utilidad.EstiloTextBox(txtNombre);
            UI_Utilidad.EstiloTextBox(txtDNI);
            UI_Utilidad.EstiloTextBox(txtUsuario);
            UI_Utilidad.EstiloTextBox(txtContraseña);
            UI_Utilidad.EstiloTextBox(cmbRol);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAceptar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCancelar);

            UI_Utilidad.HacerCircular(pbFoto);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
