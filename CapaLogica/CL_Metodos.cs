using CapaDatos;
using CapaEntities;
using System;
using System.Data;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();

        #region METODOS
        public string InsertarPermisoUsuario(int idusuario, Permisos permisos)
        { 
            return metodos.InsertarPermisoUsuario(idusuario, permisos);
        }
        public string InsertarPermisoRol(int idrol, Permisos permisos)
        { 
            return metodos.InsertarPermisoRol(idrol, permisos);
        }
        public string EliminarRol(int rol)
        { 
            return metodos.EliminarRol(rol);
        }
        public DataTable SeleccionaPermisosUsuario(int idusuario)
        {
            return metodos.SeleccionaPermisosUsuario(idusuario);
        }
        public string InsertarRol(string rol)
        {
            return metodos.InsertarRol(rol);
        }
        public DataTable SeleccionaPermisos(int idrol)
        { 
            return metodos.SeleccionaPermisos(idrol);
        }
        public int EliminarIdRol(int idrol)
        {
            return metodos.EliminarIdRol(idrol);
        }
        public int ObtenerIdPermiso(string permiso)
        {
            return metodos.ObtenerIdPermiso(permiso);
        }
        public string InsertarRolPermiso(int idrol, int idpermiso)
        {
            return metodos.InsertarRolPermiso(idrol,idpermiso);
        }

        public int Intentos(string usuario)
        { 
            return metodos.Intentos(usuario);
        }
        public int InsertarFacturas(int recepcion, int puesto, int factura, int tipo, string cuit, string razonsocial, decimal total)
        {  
            return metodos.InsertarFacturas(recepcion, puesto, factura, tipo, cuit, razonsocial, total);
        }
        public int InsertarComprobantePago(int idorden, string transaccion)
        { 
            return metodos.InsertarComprobantePago(idorden, transaccion);
        }
        public string InsertarComprobanteNotaCredito(int recepcion, int puesto, int notacredito, int tipo, string cuit, string razonsocial, decimal total)
        { 
            return metodos.InsertarComprobanteNotaCredito(recepcion, puesto, notacredito, tipo, cuit, razonsocial, total);
        }
        public DataTable SeleccionarPagosCompletados()
        { 
            return metodos.SeleccionarPagosCompletados();
        }
        public string InsertarOrdenesPago(OrdenesPago OrdenesPago)
        { 
            return metodos.InsertarOrdenesPago(OrdenesPago);
        }
        public DataTable TraerDetalleProductos(string idproducto)
        { 
            return metodos.TraerDetalleProductos(idproducto);
        }
        public DataTable SeleccionarProductos()
        { 
            return metodos.SeleccionarProductos();
        }
        public DataTable TraerPregunta(string dato)
        {
            return metodos.TraerPregunta(dato);
        }
        public DataTable SeleccionarDescuentos(string codigo)
        { 
            return metodos.SeleccionarDescuentos(codigo);
        }
        public DataTable Provincias()
        { 
            return metodos.Provincias();
        }
        public DataTable SeleccionarClienteMod(int id)
        { 
            return metodos.SeleccionarClienteMod(id);
        }
        public string ModificarCliente(Cliente cliente)
        {
            return metodos.ModificarCliente(cliente);
        }
        public DataTable Proveedores(int id)
        { 
            return metodos.Proveedores(id);
        }

        public string InsertarCliente(Cliente cliente)
        { 
            return metodos.InsertarCliente(cliente);
        }
        public DataTable SeleccionarDatosUsuario(int usuario)
        { 
            return metodos.SeleccionarDatosUsuario(usuario);
        }
        public int VerificarRespuesta(string dato, string respuesta)
        { 
            return metodos.VerificarRespuesta(dato, respuesta);
        }
        public DataTable ProductosVenta()
        { 
            return metodos.ProductosVenta();
        }
        public string CambiarContraseña(string dato, string respuesta)
        { 
            return metodos.CambiarContraseña(dato, respuesta);
        }
        public string InsertarDevolucion(Devoluciones devoluciones)
        {
            return metodos.InsertarDevolucion(devoluciones);
        }
        public DataTable SeleccionarListadoClientes()
        { 
            return metodos.SeleccionarListadoClientes();
        }
        public DataTable TraerDetalleMercaderia(int recepcion)
        {
            return metodos.TraerDetalleMercaderia(recepcion);
        }
        public DataTable TraerTipoFacturas()
        { 
            return metodos.TraerTipoFacturas();
        }
        public DataTable TraerDatosProveedorFactura(string proveedor)
        { 
            return metodos.TraerDatosProveedorFactura(proveedor);
        }
        public DataTable TraerPagosPendientesDocumentacion()
        { 
            return metodos.TraerPagosPendientesDocumentacion();
        }
        public DataTable SeleccionarPagosPendientes()
        { 
            return metodos.SeleccionarPagosPendientes();
        }
        public DataTable TraerDevoluciones()
        { 
            return metodos.TraerDevoluciones();
        }
        public DataTable TraerDetalleDevoluciones(int id)
        {
            return metodos.TraerDetalleDevoluciones(id);
        }
        public int ActualizarDetalleCotizaciones(int idsolicitud, string idproducto, string proveedor, decimal precio)
        {
            return metodos.ActualizarDetalleCotizaciones(idsolicitud, idproducto, proveedor, precio);
        }
        public string InsertarInformeRecepcion(InformesRecepcion informesRecepcion)
        {
            return metodos.InsertarInformeRecepcion(informesRecepcion);
        }
        public DataTable TraerBitacora()
        { 
            return metodos.TraerBitacora();
        }
        public DataTable RecepcionPedidos(int id)
        {
            return metodos.RecepcionPedidos(id);
        }
        public DataTable RecepcionOrdenes()
        {
            return metodos.RecepcionOrdenes();
        }
        public DataTable ProductoSeleccionado(string codigo)
        { 
            return metodos.ProductoSeleccionado(codigo);
        }
        public string InsertarVentas(Ventas ventas)
        { 
            return metodos.InsertarVentas(ventas);
        }
        public DataTable SeleccionarCobros(DateTime? desde = null, DateTime? hasta = null)
        {
            return metodos.SeleccionarCobros(desde, hasta);
        }
        public DataTable TraerDetalleOrdenesCompra(int id)
        {
            return metodos.TraerDetalleOrdenesCompra(id);
        }
        public DataTable TraerPresupuestos(int id)
        {
            return metodos.TraerPresupuestos(id);
        }
        public DataTable TraerOrdenesdeCompra()
        {
            return metodos.TraerOrdenesdeCompra();
        }
        public string InsertarOrdendeCompra(OrdendeCompra ordendeCompra)
        {
            return metodos.InsertarOrdendeCompra(ordendeCompra);
        }

        public DataTable TraerSolicitudesCotizaciones()
        {
            return metodos.TraerSolicitudesCotizaciones();
        }
        public int BorrarDetalleBitacora(int id)
        {
            return metodos.BorrarDetalleBitacora(id);
        }
        public int BorrarBitacora()
        { 
            return metodos.BorrarBitacora();
        }
        public UsuarioActual DatosIngreso(string Usuario)
        {
            return metodos.DatosIngreso(Usuario);
        }
        public DataTable DetalleCotizaciones(int id)
        {
            return metodos.DetalleCotizaciones(id);
        }
        public DataTable ProveedoresCotizacion(int id)
        {
            return metodos.ProveedoresCotizacion(id);
        }
        public DataTable SolcitudesCotizacion()
        { 
            return metodos.SolcitudesCotizacion();
        }
        public string BorrarPR(int id)
        { 
            return metodos.BorrarPR(id);
        }
        public DataTable Proveedores(int? id = null)
        { 
            return metodos.Proveedores(id);
        }
        public DataTable Usuarios(int? idusuario = null)
        {
            return metodos.Usuarios(idusuario);
        }
        public string ActualizarMarca(int id, string nombre, string estado)
        {
            return metodos.ActualizarMarca(id,nombre,estado);
        }
        public string ActualizarMedidas(int id, string nombre, string estado)
        {
            return metodos.ActualizarMedidas(id, nombre, estado);
        }
        public string InsertarMedidas(string nombre)
        { 
            return metodos.InsertarMedidas(nombre);
        }
        public string InsertarSolicitudCotizacion(PedidoCotizacion pedidoCotizacion, DataTable detalle)
        {
            return metodos.InsertarSolicitudCotizacion(pedidoCotizacion,detalle);
        }
        public string InsertarProveedor(Proveedor proveedor)
        {
            return metodos.InsertarProveedor(proveedor);
        }
        public DataTable Proveedores()
        {
            return metodos.Proveedores();
        }
        public DataTable SolicitudCotizaciones()
        {
            return metodos.SolicitudCotizacion();
        }
        public DataTable Localidades(int id)
        { 
            return metodos.Localidades(id);
        }
        public int CodigoPostal(int id)
        {
            return metodos.CodigoPostal(id);
        }
        public DataTable ProductosStockMin()
        {
            return metodos.ProductosStockMin();
        }
        public DataTable TipoProductos(string tabla)
        {
            return metodos.TipoProductos(tabla);
        }
        public DataTable DetallePR(int idpr)
        { 
            return metodos.DetallePR(idpr);
        }
        public DataTable TraerTodo(string tabla)
        {
            return metodos.TraerTodo(tabla);
        }
        public DataTable PRpedidos()
        { 
            return metodos.PRpedidos();
        }
        public string ActualizarTipoProducto(int id, string nombre, string estado)
        {
            return metodos.ActualizarTipoProducto(id,nombre, estado);
        }
        public int BorrardetallePR(int iddetallepr)
        {
            return metodos.BorrardetallePR(iddetallepr);
        }
        public int ActualizarDetallPR(int iddetallepr, int IdPR, int CantidadNueva, int Usuariomodificacion, DateTime Fechamodificacion)
        {
            return metodos.ActualizarDetallPR(iddetallepr, IdPR, CantidadNueva, Usuariomodificacion, Fechamodificacion);
        }
        public int ActualizarUsuario(string usuario, string nombre, string apellido, string dni, int rol, int bloqueado,string correo)
        {
            return metodos.ActualizarUsuario(usuario, nombre, apellido, dni, rol, bloqueado,correo);
        }
        public string Bitacora(int usuario, string tabla, string descripcion)
        { 
            return metodos.Bitacora(usuario, tabla, descripcion);
        }
        public string InsertarCate(string nombre)
        {
            return metodos.InsertarCate(nombre);
        }
        public string InsertarMarca(string nombre)
        {
            return metodos.InsertarMarca(nombre);
        }
        public string ActualizarCate(int id,string nombre,string estado)
        {
            return metodos.ActualizarCate(id,nombre, estado);
        }
        public string InsertarProducto(ProductoNuevo productoNuevo)
        {
            return metodos.InsertarProducto(productoNuevo);
        }
        public string ActualizarProducto(ProductoNuevo producto)
        { 
            return metodos.ActualizarProducto(producto);
        }

        public string Registro(UsuarioNuevo usuarioNuevo)
        {
            return metodos.Registro(usuarioNuevo);
        }

        public int StatusBloq(string Usuario)
        { 
            return metodos.StatusBloq(Usuario);
        }
        public int InsertarVentas(decimal total)
        {
            return metodos.InsertarVentas(total);
        }
        public int BorrarUsuario(string usuario)
        {
            return metodos.BorrarUsuario(usuario);
        }
        public string InsertarPR(int idusuario, DataTable detallepr)
        {
            return metodos.InsertarPR(idusuario,detallepr);
        }
        public string RestablecerContraseña(int idusuario,string contraseña)
        { 
            return metodos.RestablecerContraseña(idusuario,contraseña);
        }
        public string VerificarIngreso(string usuario, string contraseña)
        {
            return metodos.VerificarIngreso(usuario, contraseña);
        }
        public DataTable SeleccionarClientes()
        { 
            return metodos.SeleccionarClientes();
        }
        #endregion
    }
}
