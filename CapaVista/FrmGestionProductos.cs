using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmGestionProductos : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionProductos()
        {
            InitializeComponent();
        }
        private void CargarProductos()
        {
            DataTable dt = metodos.SeleccionarProductos();
            dataGridView1.Rows.Clear();
            string textoBuscado = txtBuscador.Text.Trim();

            foreach (DataRow fila in dt.Rows)
            {
                string codigo = fila["CodigoProducto"].ToString();
                string categoria = fila["Categoria"].ToString();
                string producto = fila["Producto"].ToString();
                string marca = fila["Marca"].ToString();
                string medida = fila["Medida"].ToString();
                string item = $"{producto} {marca} {medida}";


                if (!string.IsNullOrEmpty(textoBuscado) && textoBuscado != Traductor.TraducirTexto("txtBuscador"))
                {
                    if (!(codigo.ToLower().Contains(textoBuscado.ToLower()) ||
                          categoria.ToLower().Contains(textoBuscado.ToLower()) ||
                          item.ToLower().Contains(textoBuscado.ToLower())))
                    {
                        continue;
                    }
                }

                string stockactual = fila["StockActual"].ToString();
                string stockminimo = fila["StockMinimo"].ToString();
                string descuento = (fila["Descuento"] == DBNull.Value) ? "NO" : "SI";
                string precio = fila["PrecioVenta"].ToString();

                dataGridView1.Rows.Add(codigo, item, categoria, stockactual, stockminimo, descuento, precio);
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CrearColumnasProductos();
            CargarProductos();
            CargarToolsTip();
            Traductor.TraducirFormulario(this);
        }
        private void CrearColumnasProductos()
        {
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn columnaCodigo = new DataGridViewTextBoxColumn();
            columnaCodigo.Name = "Codigo";                  
            columnaCodigo.HeaderText = Traductor.TraducirTexto("lblCodigo");   
            columnaCodigo.Width = 65;                     
            columnaCodigo.ReadOnly = true;                  
            columnaCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaProducto = new DataGridViewTextBoxColumn();
            columnaProducto.Name = "Producto";
            columnaProducto.HeaderText = Traductor.TraducirTexto("gbxProductos");
            columnaProducto.Width = 75;
            columnaProducto.ReadOnly = true;
            columnaProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaCategoria = new DataGridViewTextBoxColumn();
            columnaCategoria.Name = "Categoria";
            columnaCategoria.HeaderText = Traductor.TraducirTexto("lblCategoria");
            columnaCategoria.Width = 77;
            columnaCategoria.ReadOnly = true;
            columnaCategoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaCantActual = new DataGridViewTextBoxColumn();
            columnaCantActual.Name = "CantidadActual";
            columnaCantActual.HeaderText = Traductor.TraducirTexto("dgvCantidadActual");
            columnaCantActual.Width = 90;
            columnaCantActual.ReadOnly = true;
            columnaCantActual.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaCantMinima = new DataGridViewTextBoxColumn();
            columnaCantMinima.Name = "CantidadMinima";
            columnaCantMinima.HeaderText = Traductor.TraducirTexto("dgvCantidadMin");
            columnaCantMinima.Width = 93;
            columnaCantMinima.ReadOnly = true;
            columnaCantMinima.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn Descuentos = new DataGridViewTextBoxColumn();
            Descuentos.Name = "Descuentos";
            Descuentos.HeaderText = Traductor.TraducirTexto("dgvDescuentos");
            Descuentos.Width = 89;
            Descuentos.ReadOnly = true;
            Descuentos.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn Venta = new DataGridViewTextBoxColumn();
            Venta.Name = "PrecioVenta";
            Venta.HeaderText = Traductor.TraducirTexto("dgvPrecio");
            Venta.Width = 72;
            Venta.ReadOnly = true;
            Venta.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            
            dataGridView1.Columns.Add(columnaCodigo);
            dataGridView1.Columns.Add(columnaProducto);
            dataGridView1.Columns.Add(columnaCategoria);
            dataGridView1.Columns.Add(columnaCantActual);
            dataGridView1.Columns.Add(columnaCantMinima);
            dataGridView1.Columns.Add(Descuentos);
            dataGridView1.Columns.Add(Venta);
        }
        private void CrearColumnasProductosStockBajo()
        {
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn columnaCodigo = new DataGridViewTextBoxColumn();
            columnaCodigo.Name = "Codigo";
            columnaCodigo.HeaderText = Traductor.TraducirTexto("lblCodigo");
            columnaCodigo.Width = 65;
            columnaCodigo.ReadOnly = true;
            columnaCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaProducto = new DataGridViewTextBoxColumn();
            columnaProducto.Name = "Producto";
            columnaProducto.HeaderText = Traductor.TraducirTexto("gbxProductos");
            columnaProducto.Width = 415;
            columnaProducto.ReadOnly = true;
            columnaProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn columnaCantActual = new DataGridViewTextBoxColumn();
            columnaCantActual.Name = "CantidadActual";
            columnaCantActual.HeaderText = Traductor.TraducirTexto("dgvCantidadActual");
            columnaCantActual.Width = 86;
            columnaCantActual.ReadOnly = true;
            columnaCantActual.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn columnaSugerencia = new DataGridViewTextBoxColumn();
            columnaSugerencia.Name = "Sugerencia";
            columnaSugerencia.HeaderText = Traductor.TraducirTexto("dgvSugerencia");
            columnaSugerencia.Width = 96;
            columnaSugerencia.ReadOnly = true;
            columnaSugerencia.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn CantidadPedir = new DataGridViewTextBoxColumn();
            CantidadPedir.Name = "CantidadPedir";
            CantidadPedir.HeaderText = Traductor.TraducirTexto("dgvCantAPedir");
            CantidadPedir.Width = 79;
            CantidadPedir.ReadOnly = false;
            CantidadPedir.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewCheckBoxColumn Pedir = new DataGridViewCheckBoxColumn();
            Pedir.Name = "Pedir";
            Pedir.HeaderText = Traductor.TraducirTexto("dgvPedir");
            Pedir.Width = 69;
            Pedir.ReadOnly = false;
            Pedir.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns.Add(columnaCodigo);
            dataGridView1.Columns.Add(columnaProducto);
            dataGridView1.Columns.Add(columnaCantActual);
            dataGridView1.Columns.Add(columnaSugerencia);
            dataGridView1.Columns.Add(CantidadPedir);
            dataGridView1.Columns.Add(Pedir);
        }
        private void CargarProductosStockBajo()
        {
            DataTable stockproducmin = metodos.ProductosStockMin();
            dataGridView1.Rows.Clear();
            string textoBuscado = txtBuscador.Text.Trim();

            foreach (DataRow fila in stockproducmin.Rows)
            {
                string codigo1 = fila["CodigoProducto"].ToString();
                    string producto = fila["Producto"].ToString();
                string marca = fila["Marca"].ToString();
                string medida = fila["Medida"].ToString();
                string item = $"{producto} {marca} {medida}";
                if (!string.IsNullOrEmpty(textoBuscado) && textoBuscado != Traductor.TraducirTexto("txtBuscador"))
                {
                    if (!(codigo1.ToLower().Contains(textoBuscado.ToLower()) ||
                          item.ToLower().Contains(textoBuscado.ToLower())))
                    {
                        continue;
                    }
                }
                string codigo = fila["CodigoProducto"].ToString().ToUpper(); ;
                string descripcion = $"{fila["Producto"]} {fila["Marca"]} {fila["Medida"]}".ToString().ToUpper();
                int stockactual = Convert.ToInt32(fila["StockActual"].ToString().ToUpper());
                string formadecompra = fila["Unidad"].ToString().ToUpper();
                int calculoreferencia = (Convert.ToInt32(fila["StockMaximo"]) - Convert.ToInt32(fila["StockActual"]));
                int sugerencia = calculoreferencia;
                dataGridView1.Rows.Add(codigo, descripcion, $"{stockactual} {formadecompra}", $"{sugerencia} {formadecompra}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbStockBajo.Checked)
            {
                CrearColumnasProductosStockBajo();
                CargarProductosStockBajo();
                btnPedir.Visible = true;      
            }
            else
            {
                btnPedir.Visible = false;
                CrearColumnasProductos();
                CargarProductos();
            }
           

        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            bool hayMarcado = false;
            if (CV_Utiles.TienePermiso("Crear_Compras"))
            {
                DataTable detalle = new DataTable();
                detalle.Columns.Add("IdProducto", typeof(string));
                detalle.Columns.Add("CantidadPedida", typeof(int));
                detalle.Columns.Add("StockAlPedir", typeof(int));
                detalle.Columns.Add("UnidadVenta", typeof(string));

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells["Pedir"].Value != null && Convert.ToBoolean(fila.Cells["Pedir"].Value))
                    {
                        hayMarcado = true;
                        break;
                    }
                    if (!hayMarcado)
                    {
                        MessageBox.Show("No ha seleccionado ningún producto para pedir.");
                        return;
                    }
                }
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells["Pedir"].Value != null && fila.Cells["CantidadPedir"].Value == null)
                    {
                        MessageBox.Show("Por favor ingrese la cantidad a pedir");
                        return;
                    }


                    if (fila.Cells["Pedir"].Value != null && Convert.ToBoolean(fila.Cells["Pedir"].Value))
                    {
                        detalle.Rows.Add(
                            fila.Cells["Codigo"].Value.ToString(),
                            Convert.ToInt32(fila.Cells["CantidadPedir"].Value.ToString().Split(' ')[0]),
                            Convert.ToInt32(fila.Cells["CantidadActual"].Value.ToString().Split(' ')[0]),
                            fila.Cells["CantidadActual"].Value.ToString().Split(' ')[1]
                        );
                    }

                }
                try
                {
                    MessageBox.Show(metodos.InsertarPR(Sesion.Usuario.IdUsuario, detalle));
                    CargarProductosStockBajo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
                          

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ckbStockBajo.Checked)
            {
                CargarProductosStockBajo();
            }
            else
            {
                CargarProductos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TienePermiso("Crear_Productos"))
            {
                FrmNuevoProducto frm = new FrmNuevoProducto();
                frm.ShowDialog();
                if (ckbStockBajo.Checked)
                    CargarProductosStockBajo();
                else
                    CargarProductos();
            }
            else
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarToolsTip()
        {
            toolTip1.SetToolTip(pictureBox1, "CARGAR NUEVO PRODUCTO");
            toolTip1.SetToolTip(pictureBox2, "EDITAR PRODUCTO SELECCIONADO");
            toolTip1.SetToolTip(pictureBox3, "REFRESCAR LISTA");

            toolTip1.AutoPopDelay = 5000;   // tiempo visible (ms)
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer (ms)
            toolTip1.ReshowDelay = 200;     // tiempo entre tooltips (ms)
            toolTip1.ShowAlways = true;     // mostrar aunque el form no tenga foco
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(Traductor.TraducirTexto("msgNoProducto"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!CV_Utiles.TienePermiso("Editar_Productos"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string idproducto = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FrmEditarProducto frm = new FrmEditarProducto(idproducto);
            frm.ShowDialog();
            if (ckbStockBajo.Checked)
                CargarProductosStockBajo();
            else
                CargarProductos();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idproducto = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FrmEditarProducto frm = new FrmEditarProducto(idproducto);
            frm.ShowDialog();
            if (ckbStockBajo.Checked)
                CargarProductosStockBajo();
            else
                CargarProductos();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (ckbStockBajo.Checked)
                CargarProductosStockBajo();
            else
                CargarProductos();
        }

        private void txtBuscador_Enter(object sender, EventArgs e)
        {
            if (txtBuscador.Text == Traductor.TraducirTexto("txtBuscador"))
            {
                txtBuscador.Text = string.Empty;
            }
        }

        private void txtBuscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                txtBuscador.Text = Traductor.TraducirTexto("txtBuscador");
            }
        }

        private void FrmGestionProductos_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnPedir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCerrarProductos);
            UI_Utilidad.AplicarEfectoHover(pictureBox1);
            UI_Utilidad.AplicarEfectoHover(pictureBox2);
            UI_Utilidad.EstiloDataGridView(dataGridView1);

            FormDragHelper.EnableDrag(this, panel1);


        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                e.Control.KeyPress += (s, ev) =>
                {
                    if (!char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                        ev.Handled = true;
                };
            }
        }
    }
}
