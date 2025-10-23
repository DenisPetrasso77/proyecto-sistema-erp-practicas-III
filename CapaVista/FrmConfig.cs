using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;
using System;
using System.Windows.Forms;

namespace CapaVista
{

    public partial class FrmConfig : Form
    {
        CL_Metodos metodos = new CL_Metodos();
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
            lbltituloConfig.Text = Traductor.TraducirTexto("lbltituloConfig");
            lblColores.Text=Traductor.TraducirTexto("lblColores");
            grbTema.Text=Traductor.TraducirTexto("grbTema");
            rdbEstandar.Text = Traductor.TraducirTexto("rdbEstandar");
            rdbOscuro.Text = Traductor.TraducirTexto("rdbOscuro");
            rdbContraste.Text = Traductor.TraducirTexto("rdbContraste");
            lblFuente.Text = Traductor.TraducirTexto("lblFuente");
            grbFuente.Text = Traductor.TraducirTexto("grbFuente");
            rdbChico.Text = Traductor.TraducirTexto("rdbChico");
            rdbMediana.Text = Traductor.TraducirTexto("rdbMediana");
            rdbGrande.Text = Traductor.TraducirTexto("rdbGrande");
            lblIdioma.Text = Traductor.TraducirTexto("lblIdioma");
            grbIdioma.Text = Traductor.TraducirTexto("grbIdioma");
            grbIntegridad.Text = Traductor.TraducirTexto("grbIntegridad");
            btnCalcular.Text = Traductor.TraducirTexto("btnCalcular");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string decision = MessageBox.Show(Traductor.TraducirTexto("msgIntegridad"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
            if (decision != "Yes")
            { 
                return;
            }
            string respuesta = metodos.ArreglarDV(CV_Seguridad.ObtenerPalabra());
            MessageBox.Show(respuesta);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
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
        }
    }
}
