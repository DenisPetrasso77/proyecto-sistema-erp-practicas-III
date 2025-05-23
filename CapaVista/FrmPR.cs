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
    public partial class FrmPR : Form
    {
        public FrmPR()
        {
            InitializeComponent();
            Cargardgv();
        }
        private void Cargardgv()
        {
            dataGridView1.Rows.Add("CAPIZZA001", "CAJA DE PIZZA SUPER COOL","250 Unidades","Bulto","1 Bulto = 100 unidades","7 Bultos");
            dataGridView1.Rows.Add("BOCAMI001", "BOLSAS CAMISETAS DURAS COMO CORAZON DE PRESTAMISTA", "100 Packs", "Paquete Cerrado", "1 Paquete Cerrado = 10 packs", "10 Paquetes Cerrados");
            dataGridView1.Rows.Add("ROAL01", "ROLLO DE ALUMINIO", "20 Kilos", "Bulto", "1 Bulto = 10 kilos", "30 Bultos");
        }
    }
}
