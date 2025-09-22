using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;


namespace CapaVista
{
    public partial class FrmHome : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable productosCache = new DataTable();
        FrmCargarCategorias cate = new FrmCargarCategorias();


        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            new FrmGestionPR().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Pedidos Reaprovisionamiento", "Accedio al Menu Gestion Pedidos de Reaprovisionamiento");
        }

        private void btnCargarNuevo_Click(object sender, EventArgs e)
        {
            new FrmGestionProveedores().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Proveedores", "Accedio al Menu Gestion Proveedores");
        }

        private void btncotizacion_Click(object sender, EventArgs e)
        {
            new FrmGestionPedidoCotizaciones().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Cotizaciones", "Accedio al Menu Gestion Cotizaciones");
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            new FrmGestionOrdenCompra().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Ordenes de Compra", "Accedio al Menu Gestion Ordenes de Compra");
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            new FrmGestionRecepcion().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Recepcion Mercaderia", "Accedio al Menu Gestion Recepcion");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            new GestionProveedores().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Proveedores", "Accedio al Menu Modificar Proveedores");
        }

        private void btnGestionAdmin_Click(object sender, EventArgs e)
        {
            new FrmAdmusuarios().ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Accedio al Menu Gestion Usuarios");
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            this.Hide();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Bitacora", "Accedio al Menu Gestion Bitacora");
            new FrmBitacora().ShowDialog();
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

            //UI_Utilidad.RedondearControl(pnlProductos, 28);
            //UI_Utilidad.RedondearControl(pnlPagos, 28);
            //UI_Utilidad.RedondearControl(pnlProveedores, 28);
            //UI_Utilidad.RedondearControl(pnlUsuarios, 28);
            //UI_Utilidad.RedondearControl(pnlCompras, 28);
            //UI_Utilidad.RedondearControl(pnlAlmacen, 28);

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
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
            //UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSidebar sideBar = new FrmSidebar();
            sideBar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmVentas ventas = new FrmVentas();
            ventas.ShowDialog();
        }
    }
}
