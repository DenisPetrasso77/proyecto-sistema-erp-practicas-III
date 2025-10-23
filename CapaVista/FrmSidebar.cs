using CapaEntities;
using CapaVista;
using ProyectoPracticas;
using System;
using System.Windows.Forms;
using System.Linq;
namespace SidebarMenu
{
    public partial class FrmSidebar : Form
    {
        bool sidebarExpand = true;

        public FrmSidebar()
        {
            InitializeComponent();
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void SidebarTimer_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 60)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                    //Vuelven los Iconos

                    pbHome.Visible = true;
                    pbConfig.Visible = true;
                    pbAcerca.Visible = true;
                    pbAyuda.Visible = true;
                    pbSalir.Visible = true;

                    // Ocultar texto
                    btnHome.Text = "";
                    btnConfig.Text = "";
                    btnAyuda.Text = "";
                    btnAcerca.Text = "";
                    btnSalir.Text = "";

                    // ancho fijo cuando está colapsado
                    btnHome.Width = 40;
                    btnConfig.Width = 40;
                    btnAyuda.Width = 40;
                    btnAcerca.Width = 40;
                    btnSalir.Width = 40;

                    // altura si querés cuadrados
                    btnHome.Height = 40;
                    btnConfig.Height = 40;
                    btnAyuda.Height = 40;
                    btnAcerca.Height = 40;
                    btnSalir.Height = 40;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 200)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                    // Escondo Iconos
                    pbHome.Visible = false;
                    pbConfig.Visible = false;
                    pbAcerca.Visible = false;
                    pbAyuda.Visible = false;
                    pbSalir.Visible = false;

                    // Mostrar texto
                    btnHome.Text = "Home";
                    btnConfig.Text = "Configuración";
                    btnAyuda.Text = "Help";
                    btnAcerca.Text = "Idioma";
                    btnSalir.Text = "Salir del Sistema";

                    // ancho fijo cuando está expandido
                    btnHome.Width = 180;
                    btnConfig.Width = 180;
                    btnAyuda.Width = 180;
                    btnAcerca.Width = 180;
                    btnSalir.Width = 180;

                    // altura normal expandido
                    btnHome.Height = 40;
                    btnConfig.Height = 40;
                    btnAyuda.Height = 40;
                    btnAcerca.Height = 40;
                    btnSalir.Height = 40;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnHome);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAyuda);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnConfig);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAcerca);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);

            UI_Utilidad.AplicarEfectoHover(pbHome);
            UI_Utilidad.AplicarEfectoHover(pbAyuda);
            UI_Utilidad.AplicarEfectoHover(pbAcerca);
            UI_Utilidad.AplicarEfectoHover(pbConfig);
            UI_Utilidad.AplicarEfectoHover(pbSalir);
            UI_Utilidad.AplicarEfectoHover(pbPerfil);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(Traductor.TraducirTexto("msgDeseaSalir"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Sesion.Usuario=null;
                this.Close();
                FrmLogin login = new FrmLogin();
                login.Show();
            }          
        }

        private void pbPerfil_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FrmPerfil perfil = new FrmPerfil();
            perfil.ShowDialog();
            this.Show();
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TienePermiso("Editar_Configuracion"))
            {
                this.Close();
                FrmConfig config = new FrmConfig();
                config.Show();
            }
            else
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbConfig_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TienePermiso("Editar_Configuracion"))
            {
                this.Close();
                FrmConfig config = new FrmConfig();
                config.Show();
            }
            else
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FrmSidebar_Load(object sender, EventArgs e)
        {
            btnHome.Text = Traductor.TraducirTexto("btnHome");
            btnConfig.Text = Traductor.TraducirTexto("btnConfig");
            btnAyuda.Text = Traductor.TraducirTexto("btnAyuda");
            btnAcerca.Text = Traductor.TraducirTexto("btnAcerca");
            btnSalir.Text = Traductor.TraducirTexto("btnSalir");
            lblTituloHome.Text = Traductor.TraducirTexto("lblTituloHome");
            this.Text = Traductor.TraducirTexto("frmSidebar");
        }
    }
    
}
