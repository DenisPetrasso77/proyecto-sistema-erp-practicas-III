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
        DataTable cacheproveedores;


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
                idpr = Convert.ToInt32(fila["IdPR"]);
                fecha = Convert.ToDateTime(fila["Fecha"]).ToString("dd/mm/yyyy");
                usuario = fila["Usuario"].ToString();
                cantproductos = $"{Convert.ToInt32(fila["CantidadProductos"])} productos";
                estado = fila["Estado"].ToString();

                dataGridView2.Rows.Add(idpr, fecha, usuario, cantproductos);
            }
        }
        private void DetallePR()
        {
            dataGridView3.Rows.Clear();
            string producto;
            string cantpedida;
            string unidadcarga;
            int idproducto;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            DataTable detallepr = metodos.DetallePR(idpr);
            foreach (DataRow fila in detallepr.Rows)
            {
                idproducto = Convert.ToInt32(fila["Producto"].ToString());
                producto = $"{fila["Producto"]} {fila["Marca"]} {fila["Medida"]}";
                cantpedida = fila["CantidadPedida"].ToString();
                unidadcarga = fila["Unidad"].ToString();
                dataGridView3.Rows.Add(idproducto, producto, cantpedida + " " + unidadcarga, DBNull.Value);
            }
        }

        private void FrmGestionPedidoCotizaciones_Load(object sender, EventArgs e)
        {
            Cargardgv();
            cacheproveedores = metodos.Proveedores();
            cacheproveedores.Columns.Add("DisplayProveedor", typeof(string), "RazonSocial + ' (' + NumeroDeIdentificacion + ')'");
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
    }
}
