using CapaLogica;
using System;
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
                dataGridView3.Rows.Add(idproducto, producto, cantpedida +" "+ unidadcarga,DBNull.Value);
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
           

            // Asignar el DataSource a la columna combo solo una vez
            var comboCol = (DataGridViewComboBoxColumn)dataGridView3.Columns["Proveedor1"];
            comboCol.DataSource = cacheproveedores;
            comboCol.DisplayMember = "DisplayProveedor";
            comboCol.ValueMember = "IdProveedor";
            dataGridView3.Columns["Proveedor2"].ReadOnly = true;
            dataGridView3.Columns["Proveedor3"].ReadOnly = true;

        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Proveedor1")
            {
                var row = dataGridView3.Rows[e.RowIndex];
                var proveedor1 = row.Cells["Proveedor1"].Value;

                if (proveedor1 != null)
                {
                    // Clonar tabla y filtrar
                    DataView dv = new DataView(cacheproveedores);
                    dv.RowFilter = $"IdProveedor <> {proveedor1}";

                    // Acceder al ComboBox de la columna Proveedor2
                    DataGridViewComboBoxCell celdaProveedor2 = (DataGridViewComboBoxCell)row.Cells["Proveedor2"];
                    celdaProveedor2.DataSource = dv.ToTable();
                    celdaProveedor2.DisplayMember = "RazonSocial";
                    celdaProveedor2.ValueMember = "IdProveedor";
                    celdaProveedor2.Value = null; // limpiar selección anterior
                    celdaProveedor2.ReadOnly = false; // habilitar si estaba deshabilitada
                }
            }
        }
    }
}
