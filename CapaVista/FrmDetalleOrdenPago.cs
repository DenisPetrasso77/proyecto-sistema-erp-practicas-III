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

namespace CapaVista
{
    public partial class FrmDetalleOrdenPago : Form
    {
        public int NroOrden { get; set; } // Propiedad para recibir el número de orden
        CL_Metodos metodos = new CL_Metodos();


        public FrmDetalleOrdenPago()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmDetalleOrdenPago_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
          

        }
    }
}