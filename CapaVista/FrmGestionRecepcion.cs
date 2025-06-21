using System.Windows.Forms;
using CapaLogica;

namespace CapaVista
{
    public partial class FrmGestionRecepcion : Form
    {
        FrmFacturaRemito facturaremito = new FrmFacturaRemito();
        public FrmGestionRecepcion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            facturaremito.ShowDialog();
        }
    }
}
