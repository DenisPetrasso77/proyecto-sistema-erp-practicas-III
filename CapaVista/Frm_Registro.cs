using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Frm_Registro : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        CV_Seguridad seguridad = new CV_Seguridad();
        public Frm_Registro()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //metodos.InsertarCliente();
        }
    }
}
