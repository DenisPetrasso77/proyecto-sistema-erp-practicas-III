using CapaEntities;
using CapaLogica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProyectoPracticas;


namespace CapaVista
{
    public partial class FrmAdminHome : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable productosCache = new DataTable();
        FrmCargarCategorias cate = new FrmCargarCategorias();


        public FrmAdminHome()
        {
            InitializeComponent();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            new FrmGestionProductos().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Productos", "Accedio al Menu Gestion Productos");
        }

        private void btnGestionPagos_Click(object sender, EventArgs e)
        {
            new FrmPagos().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Pagos", "Accedio al Menu Gestion Pagos");
        }

        private void btnReabastecer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionPR().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Pedidos Reaprovisionamiento", "Accedio al Menu Gestion Pedidos de Reaprovisionamiento");
        }

        private void btnCargarNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionProveedores().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Proveedores", "Accedio al Menu Gestion Proveedores");
        }

        private void btncotizacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionPedidoCotizaciones().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Cotizaciones", "Accedio al Menu Gestion Cotizaciones");
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionOrdenCompra().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Ordenes de Compra", "Accedio al Menu Gestion Ordenes de Compra");
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionRecepcion().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Recepcion Mercaderia", "Accedio al Menu Gestion Recepcion");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new GestionProveedores().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Proveedores", "Accedio al Menu Modificar Proveedores");
        }

        private void btnGestionAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmAdmusuarios().ShowDialog();
            this.Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Accedio al Menu Gestion Usuarios");
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Bitacora", "Accedio al Menu Gestion Bitacora");
            this.Hide();
            new FrmBitacora().ShowDialog();
            this.Show();
        }

        private void FrmAdminHome_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;


            //UI_Utilidad.EstiloFormDegradado(this,
            //    Color.FromArgb(230, 230, 230),  // gris clarito
            //    Color.FromArgb(180, 180, 180),  // gris oscurito
            //    90f);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.RedondearControl(pnlProductos, 28);
            UI_Utilidad.RedondearControl(pnlPagos, 28);
            UI_Utilidad.RedondearControl(pnlProveedores, 28);
            UI_Utilidad.RedondearControl(pnlUsuarios, 28);
            UI_Utilidad.RedondearControl(pnlCompras, 28);
            UI_Utilidad.RedondearControl(pnlAlmacen, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestion);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnReabastecer);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionPagos);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCargarNuevo);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnModificar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnBitacora);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionAdmin);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btncotizacion);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnOrden);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnRecepcion);
            //UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
        }
    }
}
