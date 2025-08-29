using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

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
                Usuario = textBox1.Text.Trim(),
                Contraseña = CV_Seguridad.Hasheo(textBox2.Text).Trim(),
                Nombre = textBox3.Text.Trim(),
                Apellido = textBox4.Text.Trim(),
                Rol = Convert.ToInt32(comboBox1.Text.Split('-')[0].ToString()),
                Dni = textBox5.Text.Trim(),
                dv = CV_Seguridad.CalcularDVH(textBox1.Text + CV_Seguridad.Hasheo(textBox2.Text) + "Activo"+ textBox3.Text + textBox4.Text + Convert.ToInt32(comboBox1.Text.Split('-')[0].ToString()) + 0 + comboBox1.Text.Split('-')[0].ToString() + textBox5.Text)
            };
            string resultado = metodos.Registro(usuarioNuevo);
            MessageBox.Show(resultado);
        }
        private void CargarRoles()
        {
            DataTable cacheroles = metodos.TraerTodo("Roles");
            comboBox1.Items.Clear();
            foreach (DataRow fila in cacheroles.Rows)
            {
                string rol = $"{fila["IdRol"].ToString()} - {fila["NombreRol"].ToString()}";
                comboBox1.Items.Add(rol);
            }
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }
    }
}
