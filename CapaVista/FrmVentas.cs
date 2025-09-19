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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

        }

        private void FrmVentas_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnVenta);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnImprimir);

            UI_Utilidad.EstiloDataGridView(dataGridView1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
