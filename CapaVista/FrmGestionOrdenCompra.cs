using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionOrdenCompra : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionOrdenCompra()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarDetalleSolicitudes();
        }
        private void CargarSolicitudes()
        {
            DataTable cachesolicitudes = metodos.TraerSolicitudesCotizaciones();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            foreach (DataRow fila in cachesolicitudes.Rows)
            {
                string estado = fila["Estado"].ToString();

                if (estado != "Seleccionando Cotizacion")
                    continue;
                dataGridView1.Rows.Add(fila["idsolicitud"].ToString(), fila["Usuario"].ToString());

            }
        }
        private void CargarDetalleSolicitudes()
        {
            int idpresupuesto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCotizacion"].Value);
            DataTable presupuestos = metodos.TraerPresupuestos(idpresupuesto);

            dataGridView2.Rows.Clear();

            Dictionary<string, int> mapaFilas = new Dictionary<string, int>();

            foreach (DataRow fila in presupuestos.Rows)
            {
                string idProducto = fila["IdProducto"].ToString();
                string producto = fila["Producto"].ToString();

                if (fila["Precio"] == DBNull.Value) continue;
                decimal precio = Convert.ToDecimal(fila["Precio"]);
                if (precio <= 0) continue;

                string itemCombo = $"{fila["IdProveedor"]}-{fila["RazonSocial"]} ${precio:N2}";

                if (!mapaFilas.ContainsKey(idProducto))
                {
                    int nrofila = dataGridView2.Rows.Add();
                    dataGridView2.Rows[nrofila].Cells["IdProducto"].Value = idProducto;
                    dataGridView2.Rows[nrofila].Cells["Producto"].Value = producto;

                    var comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[nrofila].Cells["Cotizacion"];
                    comboCell.Items.Add(itemCombo);
                    comboCell.Value = itemCombo; 

                    mapaFilas[idProducto] = nrofila; 
                }
                else
                {
                    int nrofila = mapaFilas[idProducto];
                    var comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[nrofila].Cells["Cotizacion"];
                    comboCell.Items.Add(itemCombo);
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows.Cast<DataGridViewRow>().ToList())
            {
                var comboCell = (DataGridViewComboBoxCell)row.Cells["Cotizacion"];
                if (comboCell.Items.Count == 0)
                {
                    dataGridView2.Rows.Remove(row);
                }
            }
        }
        private void CargarOrdenes()
        {
            DataTable cacheordenes = metodos.TraerOrdenesdeCompra();
            dataGridView4.Rows.Clear();
            foreach (DataRow fila in cacheordenes.Rows)
            {
                int idorden = Convert.ToInt32(fila["IdOrden"].ToString());
                string estado = fila["Estado"].ToString();
                string usuario = fila["Usuario"].ToString();

                dataGridView4.Rows.Add(idorden,usuario,estado);

            }
        }
        private void FrmGestionOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarSolicitudes();
            CargarOrdenes();
            dataGridView2.Columns["Producto"].ReadOnly = true;
            dataGridView2.Columns["Cotizacion"].ReadOnly = true;
            dataGridView2.Columns["Enviar"].ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idcoti = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCotizacion"].Value.ToString());

            var agrupadoPorProveedor = new Dictionary<int, List<(string IdProducto, string Producto, int IdDetalleCoti, decimal Precio)>>();

            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.Cells["Cotizacion"].Value == null) continue;

                string idproducto = fila.Cells["IdProducto"].Value.ToString();
                string producto = fila.Cells["Producto"].Value.ToString();
                int idProveedor = Convert.ToInt32(fila.Cells["Cotizacion"].Value.ToString().Split('-')[0]);
                string razonSocial = fila.Cells["Cotizacion"].Value.ToString().Split('-')[1].Split('$')[0].Trim();
                decimal precio = Convert.ToDecimal(fila.Cells["Cotizacion"].Value.ToString().Split('$')[1]);

                var detalleItem = (idproducto, producto, idcoti, precio);

                if (!agrupadoPorProveedor.ContainsKey(idProveedor))
                    agrupadoPorProveedor[idProveedor] = new List<(string, string, int, decimal)>();

                agrupadoPorProveedor[idProveedor].Add(detalleItem);
            }

            try
            {
                foreach (var kvp in agrupadoPorProveedor)
                {
                    int idProveedor = kvp.Key;
                    var detalleProveedor = kvp.Value;

                    OrdendeCompra ordendeCompra = new OrdendeCompra
                    {
                        IdUsuario = Sesion.Usuario.IdUsuario,
                        IdSolicitud = idcoti,
                        Fecha = DateTime.Now,
                        IdProveedor = idProveedor,
                        Detalle = detalleProveedor
                    };
                    var resultado = metodos.InsertarOrdendeCompra(ordendeCompra);
                    MessageBox.Show($"Orden de compra generada para Proveedor {idProveedor}: {resultado}");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CargarSolicitudes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }
        private void CargarDetalleOrdenes()
        {
            int idorden = Convert.ToInt32(dataGridView4.CurrentRow.Cells["Idorden"].Value);
            DataTable detalleordenes = metodos.TraerDetalleOrdenesCompra(idorden);

            dataGridView3.Rows.Clear();

            foreach (DataRow fila in detalleordenes.Rows)
            {
                dataGridView3.Rows.Add(fila["Producto"].ToString(), fila["RazonSocial"].ToString() + " " +"$" + fila["Precio"].ToString());
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarDetalleOrdenes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.Columns["Cotizacion"].ReadOnly = false;
            dataGridView2.Columns["Enviar"].ReadOnly = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView2.Columns["Cotizacion"].ReadOnly = true;
            dataGridView2.Columns["Enviar"].ReadOnly = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;

        }
    }
}
