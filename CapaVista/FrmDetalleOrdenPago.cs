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

        private void FrmDetalleOrdenPago_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;

            // Definición de columnas con nombres más claros
            dataGridView2.Columns.Add("IdOrden", "Número de Orden");
            dataGridView2.Columns.Add("Proveedor", "Proveedor");
            dataGridView2.Columns.Add("Producto", "Producto");
            dataGridView2.Columns.Add("PrecioUnitario", "Precio Unitario ($)");
            dataGridView2.Columns.Add("CantidadDevuelta", "Cantidad Devuelta");
            dataGridView2.Columns.Add("MontoNotaCredito", "Monto Nota Crédito ($)");
            dataGridView2.Columns.Add("IdNotaCredito", "Número Nota Crédito");
            dataGridView2.Columns.Add("MotivoNotaCredito", "Motivo");
            dataGridView2.Columns.Add("FechaNotaCredito", "Fecha Nota Crédito");
            dataGridView2.Columns.Add("EstadoOrdenDePago", "Estado Orden");
            dataGridView2.Columns.Add("FechaOrden", "Fecha Orden");

            if (NroOrden <= 0)
            {
                MessageBox.Show("Número de orden inválido");
                return;
            }

            // Traemos el detalle desde la BD
            DataTable detalle = metodos.TraerDetalleOrden(NroOrden);

            // Limpiamos el grid
            dataGridView2.Rows.Clear();

            foreach (DataRow fila in detalle.Rows)
            {
                int rowIndex = dataGridView2.Rows.Add(
                    fila["NroOrdenDePago"],
                    fila["Proveedor"],
                    fila["Producto"],
                    fila["PrecioUnitario"],
                    fila["CantidadDevuelta"],
                    fila["MontoNotaCredito"],
                    fila["IdNotaCredito"],
                    fila["MotivoNotaCredito"],
                    fila["FechaNotaCredito"],
                    fila["EstadoOrdenDePago"],
                    fila["FechaOrden"]
                );

                // --- Formato de fila ---
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                // Precio y montos en formato moneda
                if (decimal.TryParse(fila["PrecioUnitario"].ToString(), out decimal precio))
                    row.Cells["PrecioUnitario"].Value = precio.ToString("C2");

                if (decimal.TryParse(fila["MontoNotaCredito"].ToString(), out decimal monto))
                    row.Cells["MontoNotaCredito"].Value = monto.ToString("C2");

                // Fechas en formato claro
                if (DateTime.TryParse(fila["FechaOrden"].ToString(), out DateTime fechaOrden))
                    row.Cells["FechaOrden"].Value = fechaOrden.ToString("dd/MM/yyyy HH:mm");

                if (DateTime.TryParse(fila["FechaNotaCredito"].ToString(), out DateTime fechaNC))
                    row.Cells["FechaNotaCredito"].Value = fechaNC.ToString("dd/MM/yyyy");

                // Colorear según estado
                string estado = fila["EstadoOrdenDePago"].ToString();
                if (estado.Contains("Enviado"))
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (estado.Contains("Pendiente"))
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                else if (estado.Contains("Devuelto"))
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void FrmDetalleOrdenPago_Leave(object sender, EventArgs e)
        {

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