using CapaDatos;
using CapaEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();

        #region METODOS
        //public Usuarioactual DatosIngreso(string Usuario)
        //{
        //    return metodos.DatosIngreso(Usuario);
        //}
        public DataTable Proveedores(int? id = null)
        { 
            return metodos.Proveedores(id);
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
        public DataTable Provincias()
        { 
            return metodos.Provincias();
        }
        public DataTable TipoProductos()
        {
            return metodos.TipoProductos();
        }
        public DataTable DetallePR(int idpr)
        { 
            return metodos.DetallePR(idpr);
        }
        public DataTable PRpedidos()
        { 
            return metodos.PRpedidos();
        }
        public DataTable Medidas()
        {
            return metodos.Medidas();
        }
        public DataTable UnidadVenta()
        {
            return metodos.UnidadVenta();
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
        public int ActualizarUsuario(string usuario, string nombre, string apellido, string dni, int rol, int bloqueado)
        {
            return metodos.ActualizarUsuario(usuario, nombre, apellido, dni, rol, bloqueado);
        }
        public int Bitacora(string descripcion, DateTime fecha)
        { 
            return metodos.Bitacora(descripcion, fecha);
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
        public DataTable Categorias()
        {
            return metodos.Categorias();
        }
        public DataTable Marcas()
        {
            return metodos.Marcas();
        }
        public string InsertarProducto(ProductoNuevo productoNuevo)
        {
            return metodos.InsertarProducto(productoNuevo);
        }

        public string Registro(string usuario, string clave, string nombre, string apellido)
        {
            return metodos.Registro(usuario,clave,nombre, apellido);
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
        #endregion
    }
}
