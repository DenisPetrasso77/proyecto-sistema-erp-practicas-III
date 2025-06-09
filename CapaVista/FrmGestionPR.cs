using CapaLogica;
using System;
using System.Data;
using System.Web;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionPR : Form
    {
        DataTable stockproducmin = new DataTable();
        CL_Metodos metodos = new CL_Metodos();
        DataTable prpedidos;
        DataTable detallepr;
        public FrmGestionPR()
        {
            InitializeComponent();
        }
        private void Cargardgv()
        {
            string codigo;
            string descripcion;
            int stockactual;
            string formadecompra;
            int sugerencia;
            int calculoreferencia;
            stockproducmin = metodos.ProductosStockMin();
            dataGridView1.Rows.Clear();
            foreach (DataRow fila in stockproducmin.Rows)
            {
                codigo = fila["CodigoProducto"].ToString();
                descripcion = $"{fila["Producto"].ToString()} {fila["Marca"].ToString()} {fila["Medida"].ToString()}";
                stockactual = Convert.ToInt32(fila["StockActual"].ToString());
                formadecompra = fila["Unidad"].ToString();
                calculoreferencia = (Convert.ToInt32(fila["StockMaximo"]) - Convert.ToInt32(fila["StockActual"]));
                sugerencia = calculoreferencia;
                dataGridView1.Rows.Add(codigo, descripcion, stockactual, formadecompra, sugerencia);
            }
        }

        private void Cargardgvdetalle()
        {
            dataGridView2.Rows.Clear();
            int idpr;
            string fecha;
            string usuario;
            string cantproductos;
            string estado;
            prpedidos = metodos.PRpedidos();
            foreach (DataRow fila in prpedidos.Rows)
            {
                idpr = Convert.ToInt32(fila["IdPR"]);
                fecha = Convert.ToDateTime(fila["Fecha"]).ToString("dd/mm/yyyy");
                usuario = fila["Usuario"].ToString();
                cantproductos = $"{Convert.ToInt32(fila["CantidadProductos"])} productos";
                estado = fila["Estado"].ToString();
                
                dataGridView2.Rows.Add(idpr, fecha, usuario, cantproductos, estado);
            }
        }

        private void DetallePR()
        {
            dataGridView3.Rows.Clear();
            string descripcion;
            string cantpedida;
            string unidadcarga;
            int iddetallepr;
            int Stockmax;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            detallepr = metodos.DetallePR(idpr);
            foreach (DataRow fila in detallepr.Rows)
            {
                iddetallepr = Convert.ToInt32(fila["IdDetallePR"].ToString());
                descripcion = $"{fila["Producto"]} {fila["Marca"]} {fila["Medida"]}";
                cantpedida = fila["CantidadPedida"].ToString();
                unidadcarga = fila["Unidad"].ToString();
                Stockmax = Convert.ToInt32(fila["StockMaximo"].ToString());
                dataGridView3.Rows.Add(iddetallepr, descripcion, Stockmax + unidadcarga, cantpedida);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable detalle = new DataTable();
            detalle.Columns.Add("IdProducto", typeof(string));
            detalle.Columns.Add("CantidadPedida", typeof(int));
            detalle.Columns.Add("StockAlPedir", typeof(int));
            detalle.Columns.Add("UnidadVenta", typeof(string));

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Seleccionar"].Value) && fila.Cells["Seleccionar"].Value != null)
                {
                    detalle.Rows.Add(
                        fila.Cells["Codigo"].Value.ToString(),
                        Convert.ToInt32(fila.Cells["Cantidadpedida"].Value.ToString()),
                        Convert.ToInt32(fila.Cells["StockActual"].Value.ToString()),
                        fila.Cells["UnidadVenta"].Value.ToString()
                    );
                }
            }
            try
            {
                MessageBox.Show(metodos.InsertarPR(1, detalle));
                Cargardgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DetallePR();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = false;
            dataGridView2.ReadOnly = true;
            dataGridView3.Columns["Descripcion2"].ReadOnly = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            dataGridView3.Rows.Clear();
            string descripcion;
            string cantpedida;
            string unidadcarga;
            string idproducto;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            detallepr = metodos.DetallePR(idpr);
            foreach (DataRow fila in detallepr.Rows)
            {
                idproducto = fila["IdDetallePR"].ToString();
                descripcion = fila["Descripcion"].ToString();
                cantpedida = fila["CantidadPedida"].ToString();
                unidadcarga = fila["UnidadCarga"].ToString();
                dataGridView3.Rows.Add(idproducto,descripcion, cantpedida);
            }
        }

        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int iddetallepr;
            int cantpedida;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            foreach (DataGridViewRow fila in dataGridView3.Rows)
            {
                iddetallepr = Convert.ToInt32(fila.Cells["IDdetallePR"].Value);
                cantpedida = Convert.ToInt32(fila.Cells["CantidadPedida2"].Value);
                metodos.ActualizarDetallPR(iddetallepr, idpr,cantpedida,1,DateTime.Now);
                
            }
            DetallePR();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int iddetallepr = Convert.ToInt32(dataGridView3.CurrentRow.Cells["IDdetallePR"].Value);
            metodos.BorrardetallePR(iddetallepr);
            DetallePR();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = !dataGridView3.ReadOnly;
            dataGridView2.ReadOnly = !dataGridView2.ReadOnly;
            dataGridView3.Columns["Descripcion2"].ReadOnly = !dataGridView3.Columns["Descripcion2"].ReadOnly;
            button4.Visible = !button4.Visible;
            button5.Visible = !button5.Visible;
            button6.Visible = !button6.Visible;
            Cargardgvdetalle();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cargardgvdetalle();
        }

        private void FrmGestionPR_Load(object sender, EventArgs e)
        {
            Cargardgv();
            Cargardgvdetalle();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cargardgv();
        }
        
    }
}
