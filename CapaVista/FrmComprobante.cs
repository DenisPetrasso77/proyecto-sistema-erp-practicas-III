using CapaLogica;
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
    public partial class FrmComprobante : Form
    {
        int idOrden;
        CL_Metodos metodos = new CL_Metodos();
        public FrmComprobante(int idorden)
        {
            InitializeComponent();
            this.idOrden = idorden;
        }

        private void FrmComprobante_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Debe ingresar un comprobante");
                return;
            }
            if (metodos.InsertarComprobantePago(idOrden, textBox1.Text) !=0)
            {
                MessageBox.Show("Comprobante actualizado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el comprobante");
            }
        }
    }
}
