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
using SidebarMenu;

namespace CapaVista
{
    public partial class FrmPerfil : Form
    {
        public FrmPerfil()
        {
            InitializeComponent();
        }

        private void FrmPerfil_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGuardar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnEditar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCambiarFoto);
            UI_Utilidad.HacerCircular(pbFoto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmSidebar home = new FrmSidebar();
            home.Show();
        }
    }
}
