using CapaLogica;
using ProyectoPracticas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCobros : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmCobros()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void FrmCobros_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnDetalle);
        }
        private void CargarCobros()
        {
            DataTable cachecobros = metodos.SeleccionarCobros();
            string filtro = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();
            foreach (DataRow row in cachecobros.Rows)
            {               
                string factura = $"{row["nrocomprobante"].ToString()}";
                string cliente = row["RazonSocial"].ToString();
                string fecha = Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy");
                string total = Convert.ToDecimal(row["Total"]).ToString("N2");
                string estado = row["Estado"].ToString();
                string comprobante = row["comprobante"].ToString();
                if (string.IsNullOrEmpty(filtro) || factura.ToLower().Contains(filtro) || cliente.ToLower().Contains(filtro))
                {
                    dataGridView1.Rows.Add(factura, cliente, fecha, total, estado, comprobante);
                }

            }
        }
        private void CargarCobrosFechas(DateTime? desde = null, DateTime? hasta = null)
        {
            DataTable cachecobros = metodos.SeleccionarCobros(desde,hasta);
            string filtro = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();
            foreach (DataRow row in cachecobros.Rows)
            {
                string factura = $"{row["nrocomprobante"].ToString()}";
                string cliente = row["RazonSocial"].ToString();
                string fecha = Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy");
                string total = Convert.ToDecimal(row["Total"]).ToString("N2");
                string estado = row["Estado"].ToString();
                string comprobante = row["comprobante"].ToString();
                if (string.IsNullOrEmpty(filtro) || cliente.Contains(filtro))
                {
                    dataGridView1.Rows.Add(factura, cliente, fecha, total, estado, comprobante);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarCobros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarCobrosFechas(dateTimePicker1.Value.AddDays(-1),dateTimePicker2.Value.AddDays(+1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarCobros();
        }

        private void FrmCobros_Load(object sender, EventArgs e)
        {
            pictureBox3.Focus();
            CargarCobros();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}
