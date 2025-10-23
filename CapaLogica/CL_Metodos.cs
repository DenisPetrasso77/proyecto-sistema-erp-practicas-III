using CapaDatos;
using CapaEntities;
using System;
using System.Data;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();
        CD_Productos productos = new CD_Productos();
        CD_Proveedores proveedores = new CD_Proveedores();
        CD_Usuarios usuarios = new CD_Usuarios();
        CD_Administracion administracion = new CD_Administracion();
        CD_Ventas ventas = new CD_Ventas();
        CD_Clientes clientes = new CD_Clientes();
        CD_Reabastecimiento reabastecimiento = new CD_Reabastecimiento();

        #region METODOS
        public DataTable SeleccionaDatosPerfil(int idusuario)
        {
        return usuarios.SeleccionaDatosPerfil(idusuario);
        }
        public string ActualizarProveedor(Proveedor proveedor)
        { 
            return proveedores.ActualizarProveedor(proveedor);
        }
        public string ArreglarDV(string palabra)
        { 
            return administracion.ArreglarDV(palabra);
        }
        public string InsertarPermisoUsuario(int idusuario, Permisos permisos)
        { 
            return usuarios.InsertarPermisoUsuario(idusuario, permisos);
        }
        public string InsertarPermisoRol(int idrol, Permisos permisos)
        { 
            return usuarios.InsertarPermisoRol(idrol, permisos);
        }
        public int VerificarIntegridad(string palabra)
        { 
            return administracion.VerificarIntegridad(palabra);
        }
        public string EliminarRol(int rol)
        { 
            return administracion.EliminarRol(rol);
        }
        public DataTable SeleccionaPermisosUsuario(int idusuario)
        {
            return usuarios.SeleccionaPermisosUsuario(idusuario);
        }
        public string InsertarRol(string rol)
        {
            return administracion.InsertarRol(rol);
        }
        public DataTable SeleccionaPermisos(int idrol)
        { 
            return usuarios.SeleccionaPermisos(idrol);
        }
        public int EliminarIdRol(int idrol)
        {
            return usuarios.EliminarIdRol(idrol);
        }
        public int ObtenerIdPermiso(string permiso)
        {
            return usuarios.ObtenerIdPermiso(permiso);
        }
        public string InsertarRolPermiso(int idrol, int idpermiso)
        {
            return usuarios.InsertarRolPermiso(idrol,idpermiso);
        }

        public int Intentos(string usuario)
        { 
            return usuarios.Intentos(usuario);
        }
        public int InsertarFacturas(int recepcion, int puesto, int factura, int tipo, string cuit, string razonsocial, decimal total)
        {  
            return reabastecimiento.InsertarFacturas(recepcion, puesto, factura, tipo, cuit, razonsocial, total);
        }
        public int InsertarComprobantePago(int idorden, string transaccion)
        { 
            return reabastecimiento.InsertarComprobantePago(idorden, transaccion);
        }
        public string InsertarComprobanteNotaCredito(int recepcion, int puesto, int notacredito, int tipo, string cuit, string razonsocial, decimal total)
        { 
            return reabastecimiento.InsertarComprobanteNotaCredito(recepcion, puesto, notacredito, tipo, cuit, razonsocial, total);
        }
        public DataTable SeleccionarPagosCompletados()
        { 
            return reabastecimiento.SeleccionarPagosCompletados();
        }
        public string InsertarOrdenesPago(OrdenesPago OrdenesPago)
        { 
            return reabastecimiento.InsertarOrdenesPago(OrdenesPago);
        }
        public DataTable TraerDetalleProductos(string idproducto)
        { 
            return productos.TraerDetalleProductos(idproducto);
        }
        public DataTable SeleccionarProductos()
        { 
            return productos.SeleccionarProductos();
        }
        public DataTable TraerPregunta(string dato)
        {
            return usuarios.TraerPregunta(dato);
        }
        public DataTable SeleccionarDescuentos(string codigo)
        { 
            return productos.SeleccionarDescuentos(codigo);
        }
        public DataTable Provincias()
        { 
            return metodos.SeleccionarProvincias();
        }
        public DataTable SeleccionarClienteMod(int id)
        { 
            return clientes.SeleccionarClienteMod(id);
        }
        public string ModificarCliente(Cliente cliente)
        {
            return clientes.ModificarCliente(cliente);
        }
        public DataTable Proveedores(int id)
        { 
            return proveedores.Proveedores(id);
        }

        public string InsertarCliente(Cliente cliente)
        { 
            return clientes.InsertarCliente(cliente);
        }
        public DataTable SeleccionarDatosUsuario(int usuario)
        { 
            return usuarios.SeleccionarDatosUsuario(usuario);
        }
        public int VerificarRespuesta(string dato, string respuesta)
        { 
            return usuarios.VerificarRespuesta(dato, respuesta);
        }
        public DataTable ProductosVenta()
        { 
            return ventas.ProductosVenta();
        }
        public string CambiarContraseña(string dato, string respuesta,string palabra)
        { 
            return usuarios.CambiarContraseña(dato, respuesta,palabra);
        }
        public string InsertarDevolucion(Devoluciones devoluciones)
        {
            return reabastecimiento.InsertarDevolucion(devoluciones);
        }
        public DataTable SeleccionarListadoClientes()
        { 
            return clientes.SeleccionarListadoClientes();
        }
        public DataTable TraerDetalleMercaderia(int recepcion)
        {
            return reabastecimiento.TraerDetalleMercaderia(recepcion);
        }
        public DataTable TraerTipoFacturas()
        { 
            return metodos.TraerTipoFacturas();
        }
        public DataTable TraerDatosProveedorFactura(string proveedor)
        { 
            return reabastecimiento.TraerDatosProveedorFactura(proveedor);
        }
        public DataTable TraerPagosPendientesDocumentacion()
        { 
            return reabastecimiento.TraerPagosPendientesDocumentacion();
        }
        public DataTable SeleccionarPagosPendientes()
        { 
            return reabastecimiento.SeleccionarPagosPendientes();
        }
        public DataTable TraerDevoluciones()
        { 
            return reabastecimiento.TraerDevoluciones();
        }
        public DataTable TraerDetalleDevoluciones(int id)
        {
            return reabastecimiento.TraerDetalleDevoluciones(id);
        }
        public int ActualizarDetalleCotizaciones(int idsolicitud, string idproducto, string proveedor, decimal precio)
        {
            return reabastecimiento.ActualizarDetalleCotizaciones(idsolicitud, idproducto, proveedor, precio);
        }
        public string InsertarInformeRecepcion(InformesRecepcion informesRecepcion)
        {
            return reabastecimiento.InsertarInformeRecepcion(informesRecepcion);
        }
        public DataTable TraerBitacora()
        { 
            return administracion.TraerBitacora();
        }
        public DataTable RecepcionPedidos(int id)
        {
            return reabastecimiento.RecepcionPedidos(id);
        }
        public DataTable RecepcionOrdenes()
        {
            return reabastecimiento.RecepcionOrdenes();
        }
        public DataTable ProductoSeleccionado(string codigo)
        { 
            return productos.ProductoSeleccionado(codigo);
        }
        public string InsertarVentas(Ventas ventas)
        { 
            return this.ventas.InsertarVentas(ventas);
        }
        public DataTable SeleccionarCobros(DateTime? desde = null, DateTime? hasta = null)
        {
            return reabastecimiento.SeleccionarCobros(desde, hasta);
        }
        public DataTable TraerDetalleOrdenesCompra(int id)
        {
            return reabastecimiento.TraerDetalleOrdenesCompra(id);
        }
        public DataTable TraerPresupuestos(int id)
        {
            return reabastecimiento.TraerPresupuestos(id);
        }
        public DataTable TraerOrdenesdeCompra()
        {
            return reabastecimiento.TraerOrdenesdeCompra();
        }
        public string InsertarOrdendeCompra(OrdendeCompra ordendeCompra)
        {
            return reabastecimiento.InsertarOrdendeCompra(ordendeCompra);
        }

        public DataTable TraerSolicitudesCotizaciones()
        {
            return reabastecimiento.TraerSolicitudesCotizaciones();
        }
        public int BorrarDetalleBitacora(int id)
        {
            return administracion.BorrarDetalleBitacora(id);
        }
        public int BorrarBitacora()
        { 
            return administracion.BorrarBitacora();
        }
        public UsuarioActual DatosIngreso(string Usuario)
        {
            return usuarios.DatosLogin(Usuario);
        }
        public DataTable DetalleCotizaciones(int id)
        {
            return reabastecimiento.DetalleCotizaciones(id);
        }
        public DataTable ProveedoresCotizacion(int id)
        {
            return reabastecimiento.ProveedoresCotizacion(id);
        }
        public DataTable SolcitudesCotizacion()
        { 
            return reabastecimiento.SolcitudesCotizacion();
        }
        public string BorrarPR(int id)
        { 
            return reabastecimiento.BorrarPR(id);
        }
        public DataTable Proveedores(int? id = null)
        { 
            return proveedores.Proveedores(id);
        }
        public DataTable Usuarios(int? idusuario = null)
        {
            return usuarios.Usuarios(idusuario);
        }
        public string ActualizarMarca(int id, string nombre, string estado)
        {
            return productos.ActualizarMarca(id,nombre,estado);
        }
        public string ActualizarMedidas(int id, string nombre, string estado)
        {
            return productos.ActualizarMedidas(id, nombre, estado);
        }
        public string InsertarMedidas(string nombre)
        { 
            return productos.InsertarMedidas(nombre);
        }
        public string InsertarSolicitudCotizacion(PedidoCotizacion pedidoCotizacion, DataTable detalle)
        {
            return reabastecimiento.InsertarSolicitudCotizacion(pedidoCotizacion,detalle);
        }
        public string InsertarProveedor(Proveedor proveedor)
        {
            return proveedores.InsertarProveedor(proveedor);
        }
        public DataTable Proveedores()
        {
            return proveedores.Proveedores();
        }
        public DataTable SolicitudCotizaciones()
        {
            return reabastecimiento.SolicitudCotizacion();
        }
        public DataTable Localidades(int id)
        { 
            return metodos.Localidades(id);
        }
        public string ActualizarPregunta(int idpregunta, string respuesta)
        {
            return usuarios.ActualizarPregunta(idpregunta,respuesta);
        }

        public int CodigoPostal(int id)
        {
            return metodos.CodigoPostal(id);
        }
        public DataTable ProductosStockMin()
        {
            return productos.ProductosStockMin();
        }
        public DataTable SeleccionarMotivosDevolucion()
        { 
            return metodos.SeleccionarMotivosDevolucion();
        }
        public DataTable DetallePR(int idpr)
        { 
            return reabastecimiento.DetallePR(idpr);
        }
        public DataTable SeleccionarPermisos()
        {
            return usuarios.SeleccionaPermisos();
        }
        public DataTable SeleccionarRoles()
        {
            return usuarios.SeleccionarRoles();
        }
        public DataTable SeleccionarPreguntas()
        {
            return usuarios.SeleccionarPreguntas();
        }
        public DataTable SeleccionarProvincias()
        {
            return metodos.SeleccionarProvincias();
        }

        public DataTable CategoriaProductos()
        {
            return productos.CategoriasProductos();
        }
        public DataTable TipoProductos()
        {
            return productos.TipoProductos();
        }
        public DataTable MedidasProductos()
        {
            return productos.MedidasProductos();
        }
        public DataTable MarcasProductos()
        {
            return productos.MarcasProductos();
        }
        public DataTable UnidadProductos()
        {
            return productos.UnidadProductos();
        }
        public DataTable PRpedidos()
        { 
            return reabastecimiento.PRpedidos();
        }
        public string ActualizarTipoProducto(int id, string nombre, string estado)
        {
            return productos.ActualizarTipoProducto(id,nombre, estado);
        }
        public int BorrardetallePR(int iddetallepr)
        {
            return reabastecimiento.BorrardetallePR(iddetallepr);
        }
        public int ActualizarDetallPR(int iddetallepr, int IdPR, int CantidadNueva, int Usuariomodificacion, DateTime Fechamodificacion)
        {
            return reabastecimiento.ActualizarDetallPR(iddetallepr, IdPR, CantidadNueva, Usuariomodificacion, Fechamodificacion);
        }
        public string ActualizarUsuario(int idusuario, string usuario, string nombre, string apellido, string dni, int bloqueado, int rol, string correo,string palabra)
        {
            return usuarios.ActualizarUsuario(idusuario,usuario, nombre, apellido, dni,bloqueado, rol,correo,palabra);
        }
        public string Bitacora(int usuario, string tabla, string descripcion)
        { 
            return administracion.Bitacora(usuario, tabla, descripcion);
        }
        public string InsertarCate(string nombre)
        {
            return productos.InsertarCate(nombre);
        }
        public string InsertarMarca(string nombre)
        {
            return productos.InsertarMarca(nombre);
        }
        public string ActualizarCate(int id,string nombre,string estado)
        {
            return productos.ActualizarCategoria(id,nombre, estado);
        }
        public string InsertarProducto(ProductoNuevo productoNuevo)
        {
            return productos.InsertarProducto(productoNuevo);
        }
        public string ActualizarProducto(ProductoNuevo producto)
        { 
            return productos.ActualizarProducto(producto);
        }

        public string Registro(UsuarioNuevo usuarioNuevo)
        {
            return usuarios.Registro(usuarioNuevo);
        }

        public int StatusBloq(string Usuario)
        { 
            return administracion.StatusBloq(Usuario);
        }
        public int BorrarUsuario(string usuario)
        {
            return administracion.BorrarUsuario(usuario);
        }
        public string InsertarPR(int idusuario, DataTable detallepr)
        {
            return productos.InsertarPR(idusuario,detallepr);
        }
        public string RestablecerContraseña(int idusuario,string contraseña)
        { 
            return usuarios.RestablecerContraseña(idusuario,contraseña);
        }
        public string VerificarIngreso(string usuario, string contraseña)
        {
            return administracion.VerificarIngreso(usuario, contraseña);
        }
        public DataTable SeleccionarClientes()
        { 
            return clientes.SeleccionarClientes();
        }
        #endregion
    }
}
