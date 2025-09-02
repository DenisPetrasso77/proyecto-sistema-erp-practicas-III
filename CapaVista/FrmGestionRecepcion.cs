using CapaEntities;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace CapaVista
{
    public partial class FrmGestionRecepcion : Form
    {
        FrmFacturaRemito facturaremito = new FrmFacturaRemito();
        CL_Metodos metodos = new CL_Metodos();
        string idproveedor = string.Empty;
        int puestoventa = 0;
        int numeroremito = 0;
        string cuitremito = string.Empty;
        string razonsocial = string.Empty;

        public FrmGestionRecepcion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            facturaremito.ShowDialog();
            puestoventa = int.TryParse(facturaremito.PuestoNumero, out int tmppv) ? tmppv : 0;
            numeroremito=int.TryParse(facturaremito.NumeroRemito, out int tmpnr) ? tmpnr : 0;
            cuitremito = facturaremito.cuit == null ? string.Empty : facturaremito.cuit;
            razonsocial = facturaremito.RazonSocial == null ? string.Empty : facturaremito.RazonSocial;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            CargarListadoRecepcion();
        }
        private void CargarListadoRecepcion()
        {
            string texto = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) && texto != "BUSCAR PROVEEDOR")
            {
                listBox1.Visible = false;
                return;
            }
            listBox1.Items.Clear();
            DataTable cacheordenes = metodos.RecepcionOrdenes();
            foreach (DataRow fila in cacheordenes.Rows)
            {
                if (fila["Estado"].ToString() == "Esperando Recepcion")
                {
                    string idOrden = fila["IdOrden"].ToString();
                    string razon = fila["RazonSocial"].ToString();
                    string cuit = fila["Cuit"].ToString();
                    string item = $"{idOrden} - {razon} {"("}{cuit}{")"}";

                    if (idOrden.Contains(texto) || razon.ToLower().Contains(texto.ToLower()) || cuit.Contains(texto))
                    {
                        listBox1.Items.Add(item);
                    }
                }
   
            }

            listBox1.Visible = listBox1.Items.Count > 0;
        }
        private void CargarListadoDevolucion()
        {
            string texto = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) && texto != "BUSCAR PROVEEDOR")
            {
                listBox2.Visible = false;
                return;
            }
            listBox2.Items.Clear();
            DataTable cachedevoluciones = metodos.TraerDevoluciones();
            foreach (DataRow fila in cachedevoluciones.Rows)
            {
                string idRecepcion = fila["IdRecepcion"].ToString();
                string razon = fila["RazonSocial"].ToString();
                string cuit = fila["Cuit"].ToString();
                string item = $"{idRecepcion} - {razon} {"("}{cuit}{")"}";

                if (idRecepcion.Contains(texto) || razon.ToLower().Contains(texto.ToLower()) || cuit.Contains(texto))
                {
                    listBox2.Items.Add(item);
                }
                //if (fila["Estado"].ToString() == "Enviado a Proveedor")
                //{

                //}            
            }

            listBox2.Visible = listBox2.Items.Count > 0;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            AgregarRecepcion();
        }

        private void AgregarRecepcion()
        {
            if (listBox1.SelectedItem == null)
                return;
            dataGridView1.Rows.Clear();
            string itemSeleccionado = listBox1.SelectedItem.ToString();
            int codigo = Convert.ToInt32(itemSeleccionado.Split('-')[0].Trim());
            DataTable dt = metodos.RecepcionPedidos(codigo);

            foreach (DataRow fila in dt.Rows)
            {
                string idproducto = fila["IdProducto"].ToString().Trim();
                string Producto = fila["Producto"].ToString().Trim();
                int cantidad = Convert.ToInt32(fila["CantidadPedida"].ToString().Split(' ')[0]);
                decimal precio = Convert.ToDecimal(fila["Precio"].ToString());
                dataGridView1.Rows.Add(idproducto, Producto, cantidad, precio);
            }
            listBox1.Visible = false;
            label5.Text = itemSeleccionado.Split('-')[1];
            label7.Text = $"{"OC-"}{itemSeleccionado.Split('-')[0]}";
            textBox1.Text = string.Empty;
            idproveedor = label5.Text.Split('(')[1].Split(')')[0].ToString();
        }

        private void AgregarDevolucion()
        {
            if (listBox2.SelectedItem == null)
                return;
            dataGridView2.Rows.Clear();
            string itemSeleccionado = listBox2.SelectedItem.ToString();
            int codigo = Convert.ToInt32(itemSeleccionado.Split('-')[0].Trim());
            DataTable dt = metodos.TraerDetalleDevoluciones(codigo);

            foreach (DataRow fila in dt.Rows)
            {
                string idproducto = fila["IdProducto"].ToString().Trim();
                string Producto = fila["Producto"].ToString().Trim();
                int cantidad = Convert.ToInt32(fila["CantidadDevuelta"].ToString());
                dataGridView2.Rows.Add(idproducto, Producto, cantidad);
            }
            listBox2.Visible = false;
            label11.Text = itemSeleccionado.Split('-')[1];
            label9.Text = $"RE-{int.Parse(dt.Rows[0]["IdRecepcion"].ToString())}";
            textBox2.Text = string.Empty;
            idproveedor = label11.Text.Split('(')[1].Split(')')[0].ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarRecepcion();
            }
        }

        private void FrmGestionRecepcion_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Today.ToString("d");
            label15.Text = DateTime.Today.ToString("d");
            timer1.Start();
            timer1.Interval = 1000;
            CargarMotivosDevolucion();
            dataGridView1.Columns["Motivo"].ReadOnly = true;
            label20.Text = Sesion.Usuario.Usuario;
            label17.Text= Sesion.Usuario.Usuario;
            string idproveedor = string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("HH:mm:ss");
            label13.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void CargarMotivosDevolucion()
        {
            DataTable motivos = metodos.TraerTodo("MotivosDevolucion");
            var comboCol = (DataGridViewComboBoxColumn)dataGridView1.Columns["Motivo"];
            comboCol.DataSource = motivos;
            comboCol.DisplayMember = "Descripcion";
            comboCol.ValueMember = "IdMotivo";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "BUSCAR PROVEEDOR")
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "BUSCAR PROVEEDOR";
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dataGridView1.Rows[e.RowIndex];

            // CALCULAR DIFERENCIA
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Recibida")
            {
                int recibido = 0;
                int pedido = 0;

                int.TryParse(fila.Cells["Recibida"].Value?.ToString(), out recibido);
                int.TryParse(fila.Cells["CantidadPedida"].Value?.ToString(), out pedido);

                int restante = recibido - pedido;
                fila.Cells["Diferencia"].Value = restante;
            }

            // HABILITAR MOTIVOS
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Diferencia")
            {
                int cantidad = 0;
                int.TryParse(fila.Cells["Diferencia"].Value?.ToString(), out cantidad);

                fila.Cells["Motivo"].ReadOnly = cantidad == 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (puestoventa == 0 || numeroremito == 0 || cuitremito == null || razonsocial == null)
            {
                MessageBox.Show("Por favor ingrese los datos del remito");
                return;
            }

            var detalle = new List<(string Idproducto, string Producto, int CantidadPedida, int CantidadRecibida, int Diferencia, string IdProveedor, int Motivo)>();

            int idusuario = Sesion.Usuario.IdUsuario;
            string estado = string.Empty;
            int contador = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                contador += Convert.ToInt32(fila.Cells["Diferencia"].Value.ToString());
                estado = (contador == 0) ? "Completado" : "En Proceso";

                int idmotivo = fila.Cells["Motivo"].Value == null ? 0 : Convert.ToInt32(fila.Cells["Motivo"].Value);
                detalle.Add
                    ((
                   fila.Cells["Codigo"].Value.ToString(),
                   fila.Cells["Producto"].Value.ToString(),
                   Convert.ToInt32(fila.Cells["CantidadPedida"].Value.ToString()),
                   Convert.ToInt32(fila.Cells["Recibida"].Value.ToString()),
                   Convert.ToInt32(fila.Cells["Diferencia"].Value.ToString()),
                   idproveedor,
                   idmotivo
                   ));
            }
            InformesRecepcion informesRecepcion = new InformesRecepcion
            {
                IdOrdenCompra = Convert.ToInt32(label7.Text.Split('-')[1].ToString()),
                IdUsuario = Sesion.Usuario.IdUsuario,
                Estado = estado,
                puestonumero = puestoventa,
                numeroremito = numeroremito,
                cuit = cuitremito,
                razonsocial = razonsocial,
                Detalle = detalle
            };
            foreach (var i in detalle)
            {
                MessageBox.Show(i.ToString());
            }
            var resultado = metodos.InsertarInformeRecepcion(informesRecepcion);
            MessageBox.Show(resultado);
            dataGridView1.Rows.Clear();
            label5.Text = string.Empty;
            label7.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label5.Text.Split('(')[1].Split(')')[0].ToString());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CargarListadoDevolucion();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "BUSCAR PROVEEDOR")
            {
                textBox2.Text = string.Empty;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "BUSCAR PROVEEDOR";
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox2.Visible && listBox2.Items.Count > 0)
            {
                listBox2.Focus();
                listBox2.SelectedIndex = 0;
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            AgregarDevolucion();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            var detalle = new List<(int IdRecepcion, string IdProducto, int Cantidad, string Estado, int IdUsuario)>();
            try
            {
                int idrecepcion = Convert.ToInt32(label9.Text.Split('-')[1].ToString());
                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    detalle.Add
                        ((
                       idrecepcion,
                       fila.Cells["Codigo2"].Value.ToString(),
                       Convert.ToInt32(fila.Cells["Diferencia2"].Value.ToString()),
                       fila.Cells["Estado2"].Value.ToString().Split('-')[1],
                       Sesion.Usuario.IdUsuario
                       ));
                }
                Devoluciones devoluciones = new Devoluciones
                {
                    Detalle = detalle
                };
                var resultado = metodos.InsertarDevolucion(devoluciones);
                MessageBox.Show(resultado);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al registrar la devolucion {ex.Message}");
            }
            label11.Text = string.Empty;
            label9.Text = string.Empty;
            dataGridView2.Rows.Clear();
        }
    }
}
