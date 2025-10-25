using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmGestionProveedores : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionProveedores()
        {
            InitializeComponent();
        }
        private void Cargarbuscador()
        {
            string texto = txtBuscador.Text.Trim().ToLower();

            DataTable proveedorescache = metodos.Proveedores();
            dataGridView1.Rows.Clear();
            foreach (DataRow fila in proveedorescache.Rows)
            {
                int id = Convert.ToInt32(fila["idProveedor"]);
                string razon = fila["RazonSocial"].ToString().ToUpper();
                string cuit = fila["NumeroDeIdentificacion"].ToString().ToLower();
                string correo = fila["Correo"].ToString().ToLower();
                string codarea = fila["CodigoArea"].ToString().ToLower();
                string telefono = fila["Telefono"].ToString().ToLower();
                string dato = $"{codarea}-{telefono}";

                if (txtBuscador.Text == "Buscador..." || razon.ToLower().Contains(texto) || cuit.Contains(texto))
                {
                    dataGridView1.Rows.Add(id, razon, cuit, correo, dato);
                }

            }

        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
        }

        private void txtBuscador_Enter(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "Buscador...")
            {
                txtBuscador.Text = "";
                txtBuscador.ForeColor = Color.Black;
            }
        }

        private void txtBuscador_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                txtBuscador.Text = "Buscador...";
                Cargarbuscador();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Crear_Proveedores"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmNuevoProveedor proveedor = new FrmNuevoProveedor();
            proveedor.ShowDialog();
            Cargarbuscador();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!CV_Utiles.TienePermiso("Editar_Proveedores"))
            {
                MessageBox.Show(Traductor.TraducirTexto("msgSinPermiso"), Traductor.TraducirTexto("msgAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmEditarProveedor editar = new FrmEditarProveedor(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            editar.ShowDialog();
            Cargarbuscador();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void FrmGestionProveedores_Shown(object sender, EventArgs e)
        {

            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            UI_Utilidad.AplicarEfectoHover(pictureBox1);
            UI_Utilidad.AplicarEfectoHover(pictureBox2);
            UI_Utilidad.EstiloDataGridView(dataGridView1);

        }
    }
}
