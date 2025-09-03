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
using System.Drawing.Drawing2D;
using CapaVista;


namespace CapaVista
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
        }

        private void FrmProductos_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloLabels(this);
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloTextBox(txtBuscador, "Buscador...");
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCerrar);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}
