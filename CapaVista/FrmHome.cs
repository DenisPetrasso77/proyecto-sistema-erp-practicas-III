using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using SidebarMenu;
using System;
using System.Linq;
using System.Windows.Forms;


namespace CapaVista
{
    public partial class FrmHome : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionProductos().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Productos", "Accedio al Menu Gestion Productos");
        }

        private void btnGestionPagos_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPagos().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Pagos", "Accedio al Menu Gestion Pagos");
        }

        private void btnReabastecer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionPR().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Pedidos Reaprovisionamiento", "Accedio al Menu Gestion Pedidos de Reaprovisionamiento");
        }

        private void btnCargarNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionProveedores().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Proveedores", "Accedio al Menu Gestion Proveedores");
        }

        private void btncotizacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionPedidoCotizaciones().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Cotizaciones", "Accedio al Menu Gestion Cotizaciones");
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionOrdenCompra().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Ordenes de Compra", "Accedio al Menu Gestion Ordenes de Compra");
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmGestionRecepcion().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Recepcion Mercaderia", "Accedio al Menu Gestion Recepcion");
        }
        private void btnGestionAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmGestionUsuarios().Show();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Usuarios", "Accedio al Menu Gestion Usuarios");
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            this.Hide();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Bitacora", "Accedio al Menu Gestion Bitacora");
            new FrmBitacora().Show();
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


            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionProductos);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnReabastecer);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionPagos);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionProveedores);
            //UI_Utilidad.EstiloBotonPrimarioDegradado(btnModificar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnBitacora);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGestionAdmin);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCotizacion);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnOrden);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnRecepcion);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnClientes);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnVentas);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnCobros);

            UI_Utilidad.AplicarTemaAControles(this);
            UI_Utilidad.GuardarColoresOriginales(this);
            UI_Utilidad.AplicarFuenteATodosLosForms();

        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmSidebar frmSidebar = new FrmSidebar();
            frmSidebar.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Ventas", "Accedio al Menu de Ventas");
            FrmVentas ventas = new FrmVentas();
            this.Hide();
            ventas.Show();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            this.Close();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Cobros", "Accedio al Menu de Cobros");
            FrmCobros cobros = new FrmCobros();
            cobros.Show();
        }

        private void bntClientes_Click(object sender, EventArgs e)
        {
            FrmGestionClientes clientes = new FrmGestionClientes();
            this.Hide();
            clientes.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            if ((Sesion.Usuario.Rol == "Encargado Almacen" && Sesion.Usuario.PermisosRol.Contains("Ver_Productos")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Productos"))
            { 
                pnlProductos.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Pagos" && Sesion.Usuario.PermisosRol.Contains("Ver_Pagos")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Pagos"))
            {
                pnlPagos.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Almacen" && Sesion.Usuario.PermisosRol.Contains("Ver_Proveedores")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Proveedores"))
            {
                pnlProveedores.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Almacen" && Sesion.Usuario.PermisosRol.Contains("Ver_Proveedores")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Proveedores"))
            {
                pnlProveedores.Visible = true;
            }
            if (Sesion.Usuario.PermisosUsuario.Contains("Ver_Configuracion"))
            {
                pnlUsuarios.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Almacen" && Sesion.Usuario.PermisosRol.Contains("Ver_Compras")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Compras"))
            {
                pnlCompras.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Almacen" && Sesion.Usuario.PermisosRol.Contains("Ver_Almacen")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Almacen"))
            {
                pnlAlmacen.Visible = true;
            }
            if ((Sesion.Usuario.Rol == "Encargado Ventas" && Sesion.Usuario.PermisosRol.Contains("Ver_Ventas")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Ventas"))
            {
                pnlVentas.Visible = true;
            }            
            if ((Sesion.Usuario.Rol == "Encargado Cobros" && Sesion.Usuario.PermisosRol.Contains("Ver_Cobros")) || Sesion.Usuario.PermisosUsuario.Contains("Ver_Cobros"))
            {
                pnlCobros.Visible = true;
            }
            if  (Sesion.Usuario.PermisosUsuario.Contains("Ver_Clientes"))
            {
                pnlClientes.Visible = true;
            }

            Traductor.TraducirFormulario(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGestionRoles roles = new FrmGestionRoles();
            roles.ShowDialog();
            metodos.Bitacora(Sesion.Usuario.IdUsuario, "Roles", "Accedio al Menu Gestion Roles");
        }
    }
}
