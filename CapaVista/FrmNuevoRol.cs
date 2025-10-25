using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmNuevoRol : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmNuevoRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre del rol no puede estar vacío.");
                return;
            }
            string rol = textBox1.Text.Trim();
            string resultado = metodos.InsertarRol(rol);
            MessageBox.Show(resultado);
            this.Close();
        }

        private void FrmNuevoRol_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAceptar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
