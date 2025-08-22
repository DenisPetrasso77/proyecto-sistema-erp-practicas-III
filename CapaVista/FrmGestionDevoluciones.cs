using CapaEntities;
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
    public partial class FrmGestionDevoluciones : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionDevoluciones()
        {
            InitializeComponent();
        }

        private void FrmGestionDevoluciones_Load(object sender, EventArgs e)
        {
        }
    }
}
