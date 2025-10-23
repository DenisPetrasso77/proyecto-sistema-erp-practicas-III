using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;

namespace CapaVista
{
    public partial class FrmGestionPR : Form
    {

        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionPR()
        {
            InitializeComponent();
        }
        private void Cargardgvdetalle()
        {
            string textoBuscado = txtBuscador.Text.Trim().ToLower();
            dataGridView2.Rows.Clear();
            DataTable prpedidos = metodos.PRpedidos();

            foreach (DataRow fila in prpedidos.Rows)
            {
                string estado = fila["Estado"].ToString();
                string usuario = fila["Usuario"].ToString();
                int idpr = Convert.ToInt32(fila["IdPR"]);

                if (!string.IsNullOrEmpty(txtBuscador.Text) && txtBuscador.Text != "BUSCADOR...")
                {
                    if (!(usuario.ToLower().Contains(textoBuscado) || idpr.ToString().Contains(textoBuscado)))
                        continue;
                }

                if (estado != "Pendiente" && !checkBox1.Checked)
                    continue;

                string fecha = Convert.ToDateTime(fila["Fecha"]).ToString("dd/MM/yyyy");
                string cantproductos = $"{Convert.ToInt32(fila["CantidadProductos"])} productos";

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
            if (!CV_Utiles.TienePermiso("Editar_Compras"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            if (!CV_Utiles.TienePermiso("Eliminar_Compras"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            Cargardgvdetalle();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cargardgvdetalle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Eliminar_Compras"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Desea Borra El Pedido Seleccionado?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                return;
            }
            int idpr = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IDPR"].Value);
            string resultado = metodos.BorrarPR(idpr);
            MessageBox.Show(resultado);
            DetallePR();
            Cargardgvdetalle();
        }

        private void txtBuscador_Enter(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "BUSCADOR...")
            { 
                txtBuscador.Text = string.Empty;
            }
        }

        private void txtBuscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscador.Text))
            { 
                txtBuscador.Text = "BUSCADOR...";
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            Cargardgvdetalle();
        }

        private void FrmGestionPR_Shown(object sender, EventArgs e)
        {
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(button1);
            UI_Utilidad.EstiloBotonPrimarioDegradado(button2);
            UI_Utilidad.EstiloBotonPrimarioDegradado(button4);
            UI_Utilidad.EstiloBotonPrimarioDegradado(button5);
            UI_Utilidad.EstiloBotonPrimarioDegradado(button6);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);

            UI_Utilidad.EstiloDataGridView(dataGridView2);
            UI_Utilidad.EstiloDataGridView(dataGridView3);

            //UI_Utilidad.EstiloGroupBoxSoloTitulo(groupBox1,
            //    new Font("Segoe UI", 14, FontStyle.Bold),   // título
            //    new Font("Segoe UI", 12, FontStyle.Regular) ); // hijos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
