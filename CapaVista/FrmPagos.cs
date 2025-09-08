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
using SidebarMenu;

namespace CapaVista
{
    public partial class FrmPagos : Form
    {
        FrmFacturaRemito facturaremito = new FrmFacturaRemito();
        

        public FrmPagos()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            facturaremito.ShowDialog();
        }

        private void FrmPagos_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregarFactura);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAgregarNotaCredito);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnEmitirOrdenPago);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnDetalle);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnPagar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnVolver);

            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese un número de Orden o Factura para buscar");
                return;
            }

            int nroOrden;
            if (!int.TryParse(txtBuscar.Text, out nroOrden))
            {
                MessageBox.Show("El número ingresado no es válido");
                return;
            }

            FrmDetalleOrdenPago detalle = new FrmDetalleOrdenPago();
            detalle.NroOrden = nroOrden;
            this.Hide();           // Ocultamos Home
            detalle.ShowDialog();  // Esto bloquea Home hasta que se cierre el detalle
            this.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
