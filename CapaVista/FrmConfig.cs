using ProyectoPracticas;
using SidebarMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmSidebar sidebar = new FrmSidebar();
            sidebar.Show();
        }

        private void rdbEstandar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEstandar.Checked)
            {
                CV_ConfigSistema.TemaActual = TipoTema.Estandar;
            }
        }

        private void rdbOscuro_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOscuro.Checked)
            {
                UI_Utilidad.AplicarTema(TipoTema.Oscuro);

            }
        }

        private void rdbContraste_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbContraste.Checked)
            {
                UI_Utilidad.AplicarTema(TipoTema.ContrasteAlto);
            }
        }

        private void rdbChico_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbChico.Checked)
            {
                CV_ConfigSistema.TamañoFuenteActual = TamañoFuente.Chico;
            }
        }

        private void rdbMediana_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMediana.Checked)
            {
                CV_ConfigSistema.TamañoFuenteActual = TamañoFuente.Mediano;
            }
        }

        private void rdbGrande_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGrande.Checked)
            {
                CV_ConfigSistema.TamañoFuenteActual = TamañoFuente.Grande;
            }
        }

        private void FrmConfig_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.AplicarTemaAControles(this);
            UI_Utilidad.GuardarColoresOriginales(this);
            UI_Utilidad.AplicarTemaATodosLosForms();

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {


        }
    }
}
