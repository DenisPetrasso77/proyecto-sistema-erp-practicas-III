using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPracticas;

namespace CapaVista
{
    public partial class FrmProductoNuevo : Form
    {
        public FrmProductoNuevo()
        {
            InitializeComponent();
        }

        private void FrmProductoNuevo_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloLabels(this);
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloTextBox(textBox1);
            UI_Utilidad.EstiloTextBox(textBox2);
            UI_Utilidad.EstiloTextBox(textBox3);
            UI_Utilidad.EstiloTextBox(textBox4);
            UI_Utilidad.EstiloTextBox(textBox5);
            UI_Utilidad.EstiloTextBox(textBox6);
            UI_Utilidad.EstiloTextBox(textBox7);
            UI_Utilidad.EstiloTextBox(textBox8);
            UI_Utilidad.EstiloTextBox(textBox9);
            UI_Utilidad.EstiloTextBox(textBox10);
            UI_Utilidad.EstiloTextBox(textBox11);
            UI_Utilidad.EstiloBotonPrimarioDegradado(bntCargarImagen);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGuardar);
        }   
    }
}
