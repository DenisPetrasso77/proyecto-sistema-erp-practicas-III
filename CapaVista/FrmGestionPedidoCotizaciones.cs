using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionPedidoCotizaciones : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        CV_Utiles utiles = new CV_Utiles();
        DataTable cacheproveedores;
        DataTable detalleCotizaciones;



        public FrmGestionPedidoCotizaciones()
        {
            InitializeComponent();

        }
        private void Cargardgv()
        {
            dataGridView2.Rows.Clear();
            int idpr;
            string fecha;
            string usuario;
            string cantproductos;
            string estado;
            DataTable prpedidos = metodos.PRpedidos();
            foreach (DataRow fila in prpedidos.Rows)
            {
                if (fila["Estado"].ToString() != "Esperando Cotizacion")
                {
                    idpr = Convert.ToInt32(fila["IdPR"]);
                    fecha = Convert.ToDateTime(fila["Fecha"]).ToString("dd/mm/yyyy");
                    usuario = fila["Usuario"].ToString();
                    cantproductos = $"{Convert.ToInt32(fila["CantidadProductos"])} productos";
                    estado = fila["Estado"].ToString();
                    dataGridView2.Rows.Add(idpr, fecha, usuario, cantproductos);
                }
            }
        }
        private void DetallePR()
        {
            dataGridView3.Rows.Clear();
            string producto;
            string cantpedida;
            string unidadcarga;
            string idproducto;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            DataTable detallepr = metodos.DetallePR(idpr);
            foreach (DataRow fila in detallepr.Rows)
            {
                idproducto = fila["CodigoProducto"].ToString();
                producto = $"{fila["TipoProducto"]} {fila["Marca"]} {fila["Medida"]}";
                cantpedida = fila["CantidadPedida"].ToString();
                unidadcarga = fila["Unidad"].ToString();
                dataGridView3.Rows.Add(idproducto, producto, cantpedida + " " + unidadcarga, DBNull.Value);
            }
        }
        private void Solicitudes()
        {
            dataGridView4.Rows.Clear();
            string nrocoti;
            DateTime _fecha;
            string fecha;
            string usuario;
            
            DataTable solicitudes = metodos.SolicitudCotizaciones();
            foreach (DataRow fila in solicitudes.Rows)
            {
                nrocoti = fila["IdSolicitud"].ToString();
                _fecha = Convert.ToDateTime(fila["FechaLimite"]);
                fecha = _fecha.ToString("dd-MM-yyyy");
                usuario = fila["Usuario"].ToString();
                dataGridView4.Rows.Add(nrocoti, fecha, usuario);
            }
        }

        private void FrmGestionPedidoCotizaciones_Load(object sender, EventArgs e)
        {
            Cargardgv();
            cacheproveedores = metodos.Proveedores();
            cacheproveedores.Columns.Add("DisplayProveedor", typeof(string), "RazonSocial + ' (' + NumeroDeIdentificacion + ')'");
            dataGridView3.ReadOnly = true;
            button1.Enabled = false;
            button3.Enabled = false;
            dateTimePicker1.Enabled = false;
            Solicitudes();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DetallePR();
            var comboCol = (DataGridViewComboBoxColumn)dataGridView3.Columns["Proveedor1"];
            comboCol.DataSource = cacheproveedores;
            comboCol.DisplayMember = "DisplayProveedor";
            comboCol.ValueMember = "IdProveedor";
            dataGridView3.Columns["Proveedor2"].ReadOnly = true;
            dataGridView3.Columns["Proveedor3"].ReadOnly = true;

        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView3.Columns["Proveedor1"].Index)
            {
                var celdaProveedor1 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor1"];
                var celdaProveedor2 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor2"];
                var celdaProveedor3 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor3"];

                if (celdaProveedor1.Value != null && celdaProveedor1.Value != DBNull.Value)
                {
                    int proveedor1Seleccionado = Convert.ToInt32(celdaProveedor1.Value);

                    celdaProveedor2.ReadOnly = false;

                    var dtProveedor2 = FiltrarProveedores(excluirIds: new List<int> { proveedor1Seleccionado });
                    celdaProveedor2.DataSource = dtProveedor2;
                    celdaProveedor2.DisplayMember = "DisplayProveedor";
                    celdaProveedor2.ValueMember = "IdProveedor";

                    celdaProveedor2.Value = null;

                    celdaProveedor3.ReadOnly = true;
                    celdaProveedor3.Value = null;
                    celdaProveedor3.DataSource = null;
                }
                else
                {
                    var combo2 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor2"];
                    combo2.ReadOnly = true;
                    combo2.Value = null;
                    combo2.DataSource = null;

                    var combo3 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor3"];
                    combo3.ReadOnly = true;
                    combo3.Value = null;
                    combo3.DataSource = null;
                }

                dataGridView3.InvalidateRow(e.RowIndex);
            }
            else if (e.ColumnIndex == dataGridView3.Columns["Proveedor2"].Index)
            {
                var celdaProveedor1 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor1"];
                var celdaProveedor2 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor2"];
                var celdaProveedor3 = (DataGridViewComboBoxCell)dataGridView3.Rows[e.RowIndex].Cells["Proveedor3"];

                if (celdaProveedor2.Value != null && celdaProveedor2.Value != DBNull.Value)
                {
                    int proveedor1Seleccionado = celdaProveedor1.Value != null && celdaProveedor1.Value != DBNull.Value
                        ? Convert.ToInt32(celdaProveedor1.Value)
                        : -1;

                    int proveedor2Seleccionado = Convert.ToInt32(celdaProveedor2.Value);

                    celdaProveedor3.ReadOnly = false;

                    var dtProveedor3 = FiltrarProveedores(excluirIds: new List<int> { proveedor1Seleccionado, proveedor2Seleccionado });
                    celdaProveedor3.DataSource = dtProveedor3;
                    celdaProveedor3.DisplayMember = "DisplayProveedor";
                    celdaProveedor3.ValueMember = "IdProveedor"; 
                    celdaProveedor3.Value = null;
                }
                else
                {
                    celdaProveedor3.ReadOnly = true;
                    celdaProveedor3.Value = null;
                    celdaProveedor3.DataSource = null;
                }

                dataGridView3.InvalidateRow(e.RowIndex);
            }
        }
        private DataTable FiltrarProveedores(List<int> excluirIds)
        {
            var dtFiltrado = cacheproveedores.Clone();

            foreach (DataRow dr in cacheproveedores.Rows)
            {
                int id = Convert.ToInt32(dr["IdProveedor"]);
                if (!excluirIds.Contains(id))
                {
                    dtFiltrado.ImportRow(dr);
                }
            }

            return dtFiltrado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = false;
            dataGridView2.ReadOnly = true;
            button1.Enabled = true;
            button3.Enabled = true;
            dateTimePicker1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView2.ReadOnly=false;
            dataGridView3.ReadOnly = true;
            button1.Enabled = false;
            button3.Enabled = false;
            dateTimePicker1.Enabled = false;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PedidoCotizacion pedido = new PedidoCotizacion
            {
                IdPR = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IdPR"].Value),
                Estado = "Activo",
                FechaAlta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                IdUsuarioAlta = 1,
                FechaUltModificacion = DateTime.Now,
                IdUsuarioUltModificacion = 1
            };

            DateTime fechaLimite = dateTimePicker1.Value;

            List<DetalleSoliCotizaciones> detalles = new List<DetalleSoliCotizaciones>();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.IsNewRow) continue;

                string idProducto = row.Cells["Descripcion2"].Value?.ToString();
                string cantidad = row.Cells["CantidadPedida"].Value.ToString();

                if (row.Cells["Proveedor1"].Value != null)
                {
                    detalles.Add(new DetalleSoliCotizaciones
                    {
                        IdProducto = idProducto,
                        Producto = row.Cells["Descripcion2"].Value.ToString(),
                        IdProveedor = Convert.ToInt32(row.Cells["Proveedor1"].Value),
                        FechaLimite = fechaLimite,
                        Cantidad = cantidad
                    });
                }
                if (row.Cells["Proveedor2"].Value != null)
                {
                    detalles.Add(new DetalleSoliCotizaciones
                    {
                        IdProducto = idProducto,
                        Producto = row.Cells["Descripcion2"].Value.ToString(),
                        IdProveedor = Convert.ToInt32(row.Cells["Proveedor1"].Value),
                        FechaLimite = fechaLimite,
                        Cantidad = cantidad
                    });
                }
                if (row.Cells["Proveedor3"].Value != null)
                {
                    detalles.Add(new DetalleSoliCotizaciones
                    {
                        IdProducto = idProducto,
                        Producto = row.Cells["Descripcion2"].Value.ToString(),
                        IdProveedor = Convert.ToInt32(row.Cells["Proveedor1"].Value),
                        FechaLimite = fechaLimite,
                        Cantidad = cantidad
                    });
                }
            }

            DataTable detalleTable = ConvertirADetalleCotizacionesTipo(detalles);
            string resultado = metodos.InsertarSolicitudCotizacion(pedido, detalleTable);

            MessageBox.Show(resultado);
            dataGridView3.Rows.Clear();
            Cargardgv();
        }
        private DataTable ConvertirADetalleCotizacionesTipo(List<DetalleSoliCotizaciones> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", typeof(string));
            dt.Columns.Add("IdProveedor", typeof(int));
            dt.Columns.Add("FechaLimite", typeof(DateTime));
            dt.Columns.Add("Cantidad", typeof(string));

            foreach (var item in lista)
            {
                dt.Rows.Add(item.IdProducto, item.IdProveedor, item.FechaLimite, item.Cantidad);
            }

            return dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
