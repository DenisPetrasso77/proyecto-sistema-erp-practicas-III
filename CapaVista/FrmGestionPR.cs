using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Web;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmGestionPR : Form
    {

        CL_Metodos metodos = new CL_Metodos();
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
            DataTable stockproducmin = metodos.ProductosStockMin();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in stockproducmin.Rows)
            {
                codigo = fila["CodigoProducto"].ToString().ToUpper(); ;
                descripcion = $"{fila["Producto"]} {fila["Marca"]} {fila["Medida"]}".ToString().ToUpper();
                stockactual = Convert.ToInt32(fila["StockActual"].ToString().ToUpper());
                formadecompra = fila["Unidad"].ToString().ToUpper();
                calculoreferencia = (Convert.ToInt32(fila["StockMaximo"]) - Convert.ToInt32(fila["StockActual"]));
                sugerencia = calculoreferencia;
                dataGridView1.Rows.Add(codigo, descripcion, $"{stockactual} {formadecompra}", $"{sugerencia} {formadecompra}");
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
            DataTable prpedidos = metodos.PRpedidos();
            foreach (DataRow fila in prpedidos.Rows)
            {
                estado = fila["Estado"].ToString();
                if (estado != "Pendiente" && !checkBox1.Checked)
                    continue;
                idpr = Convert.ToInt32(fila["IdPR"]);
                fecha = Convert.ToDateTime(fila["Fecha"]).ToString("dd/mm/yyyy");
                usuario = fila["Usuario"].ToString();
                cantproductos = $"{Convert.ToInt32(fila["CantidadProductos"])} productos";
                dataGridView2.Rows.Add(idpr, fecha, usuario, cantproductos, estado);
            }
        }
        private void DetallePR()
        {
            dataGridView3.Rows.Clear();
            string descripcion;
            string codigo;
            string cantpedida;
            string unidadcarga;
            int iddetallepr;
            int Stockmax;
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            DataTable detallepr = metodos.DetallePR(idpr);
            foreach (DataRow fila in detallepr.Rows)
            {
                iddetallepr = Convert.ToInt32(fila["IdDetallePR"].ToString());
                descripcion = $"{fila["TipoProducto"]} {fila["Marca"]} {fila["Medida"]}";
                cantpedida = fila["CantidadPedida"].ToString();
                unidadcarga = fila["Unidad"].ToString();
                Stockmax = Convert.ToInt32(fila["StockMaximo"].ToString());
                codigo = fila["CodigoProducto"].ToString();
                dataGridView3.Rows.Add(iddetallepr, codigo,descripcion, Stockmax +" "+ unidadcarga, cantpedida);
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
                if (fila.Cells["Seleccionar"].Value != null && fila.Cells["Cantidadpedida"].Value == null)
                {
                    MessageBox.Show("Por favor ingrese la cantidad a pedir");
                    return;
                }
                if (fila.Cells["Seleccionar"].Value != null && Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                {
                    detalle.Rows.Add(
                        fila.Cells["Codigo"].Value.ToString(),
                        Convert.ToInt32(fila.Cells["Cantidadpedida"].Value.ToString().Split(' ')[0]),
                        Convert.ToInt32(fila.Cells["StockActual"].Value.ToString().Split(' ')[0]),
                        fila.Cells["StockActual"].Value.ToString().Split(' ')[1]
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
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Seleccione algun pedido");
                return;
            }
            if (dataGridView2.CurrentRow.Cells["ESTADO"].Value.ToString() != "Pendiente")
            {
                MessageBox.Show("No se puede modificar un pedido que ya se envio a pedir cotizacion");
                return;
            }
            dataGridView3.ReadOnly = false;
            dataGridView2.ReadOnly = true;
            dataGridView3.Columns["CantidadPedida2"].ReadOnly = false;
            button4.Visible = true;
            button6.Visible = true;
            button2.Visible = false;
            button5.Visible = true;
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
                metodos.ActualizarDetallPR(iddetallepr, idpr,cantpedida,Sesion.Usuario.IdUsuario,DateTime.Now);
                
            }
            DetallePR();
            button4.Visible=false;
            button5.Visible = false;
            button2.Visible= true;
            button6.Visible= false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count == 1)
            {
                MessageBox.Show($"Para eliminar el pedido toque el boton: {"Borrar Pedido"}");
                return;
            }
            string idproducto = dataGridView3.CurrentRow.Cells["Descripcion2"].Value.ToString();
            var resultado =MessageBox.Show($"Desea borrar el producto {idproducto}","CONFIRMACION",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                int iddetallepr = Convert.ToInt32(dataGridView3.CurrentRow.Cells["IDdetallePR"].Value);
                metodos.BorrardetallePR(iddetallepr);
                DetallePR();
            }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = !dataGridView3.ReadOnly;
            dataGridView2.ReadOnly = !dataGridView2.ReadOnly;
            dataGridView3.Columns["CantidadPedida2"].ReadOnly = !dataGridView3.Columns["CantidadPedida2"].ReadOnly;
            button4.Visible = false;
            button2.Visible = true;
            button5.Visible = true;
            button6.Visible = false;
            button5.Visible = false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cargardgvdetalle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            string resultado = metodos.BorrarPR(idpr);
            MessageBox.Show(resultado);
            DetallePR();
            Cargardgvdetalle();
        }
    }
}
