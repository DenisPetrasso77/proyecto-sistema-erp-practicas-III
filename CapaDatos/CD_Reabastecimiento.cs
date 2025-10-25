using CapaEntities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Reabastecimiento:CD_Conexion
    {
        public int BorrardetallePR(int iddetallepr)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarProductoPR", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IddetallePR", iddetallepr);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int ActualizarDetallPR(int iddetallepr, int IdPR, int CantidadNueva, int Usuariomodificacion, DateTime Fechamodificacion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizardetallePR", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IddetallePR", iddetallepr);
                    cmd.Parameters.AddWithValue("@IdPR", IdPR);
                    cmd.Parameters.AddWithValue("@CantidadNueva", CantidadNueva);
                    cmd.Parameters.AddWithValue("@Usuariomodificacion", Usuariomodificacion);
                    cmd.Parameters.AddWithValue("@Fechamodificacion", Fechamodificacion);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int ActualizarDetalleCotizaciones(int idsolicitud, string idproducto, string proveedor, decimal precio)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCotizaciones", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSolicitud", idsolicitud);
                    cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                    cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int InsertarFacturas(int recepcion, int puesto, int factura, int tipo, string cuit, string razonsocial, decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarFacturas", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRecepcion", recepcion);
                    cmd.Parameters.AddWithValue("@NPuesto", puesto);
                    cmd.Parameters.AddWithValue("@NFactura", factura);
                    cmd.Parameters.AddWithValue("@TipoFactura", tipo);
                    cmd.Parameters.AddWithValue("@Cuit", cuit);
                    cmd.Parameters.AddWithValue("@RazonSocial", razonsocial);
                    cmd.Parameters.AddWithValue("@Total", total);
                    return Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarComprobanteNotaCredito(int recepcion, int puesto, int notacredito, int tipo, string cuit, string razonsocial, decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarComprobanteNotaCredito", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRecepcion", recepcion);
                    cmd.Parameters.AddWithValue("@NPuesto", puesto);
                    cmd.Parameters.AddWithValue("@NNotaCredito", notacredito);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Cuit", cuit);
                    cmd.Parameters.AddWithValue("@RazonSocial", razonsocial);
                    cmd.Parameters.AddWithValue("@Total", total);
                    return (string)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
               CerrarConexion();
            }
        }
        public int InsertarComprobantePago(int idorden, string transaccion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarComprobantePago", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdOrdenPago", idorden);
                    cmd.Parameters.AddWithValue("@NroTransaccion", transaccion);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarOrdendeCompra(OrdendeCompra ordendeCompra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarOrdenDeCompra", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", ordendeCompra.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdSolicitud", ordendeCompra.IdSolicitud);
                    cmd.Parameters.AddWithValue("@Fecha", ordendeCompra.Fecha);
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("IdProducto", typeof(string));
                    detalle.Columns.Add("Producto", typeof(string));
                    detalle.Columns.Add("IdCoti", typeof(int));
                    detalle.Columns.Add("Precio", typeof(decimal));

                    foreach (var desc in ordendeCompra.Detalle)
                    {
                        detalle.Rows.Add(desc.IdProducto, desc.Producto, desc.IdDetalleCoti, desc.Precio);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalles", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleOrdenCompra";
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "Error desconocido al crear la orden de compra.";
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string BorrarPR(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarPR", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IddetallePR", id);
                    cmd.ExecuteNonQuery();
                    return "Pedido Borrado Completamente";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarPR(int idusuario, DataTable detallepr)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarPR", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idusuario", idusuario);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detallepr);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "t_DetallePR";

                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    return "Pedido Generado Correctamente";
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public string InsertarSolicitudCotizacion(PedidoCotizacion pedidoCotizacion, DataTable detalle)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarSolicitudCotizacion", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPR", pedidoCotizacion.IdPR);
                    cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdUsuarioAlta", Sesion.Usuario.IdUsuario);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@DetallesCotizacion", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "DetalleCotizacionesTipo";

                    cmd.ExecuteNonQuery();
                    return "Solicitud de cotización generada correctamente";
                }
            }
            catch (SqlException ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarInformeRecepcion(InformesRecepcion informesRecepcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarRecepcionMercaderia", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", informesRecepcion.IdOrdenCompra);
                    cmd.Parameters.AddWithValue("@IdUsuario", informesRecepcion.IdUsuario);
                    cmd.Parameters.AddWithValue("@Estado", informesRecepcion.Estado);
                    cmd.Parameters.AddWithValue("@PuestoVenta", informesRecepcion.puestonumero);
                    cmd.Parameters.AddWithValue("@NumeroRemito", informesRecepcion.numeroremito);
                    cmd.Parameters.AddWithValue("@Cuit", informesRecepcion.cuit);
                    cmd.Parameters.AddWithValue("@RazonSocial", informesRecepcion.razonsocial);
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("IdProducto", typeof(string));
                    detalle.Columns.Add("Producto", typeof(string));
                    detalle.Columns.Add("CantidadPedida", typeof(int));
                    detalle.Columns.Add("CantidadRecibida", typeof(int));
                    detalle.Columns.Add("Diferencia", typeof(int));
                    detalle.Columns.Add("IdProveedor", typeof(string));
                    detalle.Columns.Add("Motivo", typeof(int));

                    foreach (var desc in informesRecepcion.Detalle)
                    {
                        detalle.Rows.Add(desc.Idproducto, desc.Producto, desc.CantidadPedida, desc.CantidadRecibida, desc.Diferencia, desc.IdProveedor, desc.Motivo);
                    }
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalles", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleRecepcionMercaderia";
                    return (string)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarDevolucion(Devoluciones devoluciones)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarDevoluciones", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("IdRecepcion", typeof(int));
                    detalle.Columns.Add("IdProducto", typeof(string));
                    detalle.Columns.Add("Cantidad", typeof(int));
                    detalle.Columns.Add("Estado", typeof(string));
                    detalle.Columns.Add("IdUsuario", typeof(int));

                    foreach (var desc in devoluciones.Detalle)
                    {

                        detalle.Rows.Add(desc.IdRecepcion, desc.IdProducto.Trim(), desc.Cantidad, desc.Estado.Trim(), desc.IdUsuario);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleDevoluciones";
                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarOrdenesPago(OrdenesPago OrdenesPago)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarOrdenesPago", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("IdRecepcion", typeof(int));
                    detalle.Columns.Add("RazonSocial", typeof(string));
                    detalle.Columns.Add("Cuit", typeof(string));
                    detalle.Columns.Add("NroFactura", typeof(string));
                    detalle.Columns.Add("NroNC", typeof(string));
                    detalle.Columns.Add("FormaPago", typeof(string));
                    detalle.Columns.Add("FechaAlta", typeof(DateTime));
                    detalle.Columns.Add("IdUsuarioAlta", typeof(int));
                    detalle.Columns.Add("Estado", typeof(string));

                    foreach (var desc in OrdenesPago.Detalle)
                    {

                        detalle.Rows.Add(desc.IdRecepcion, desc.RazonSocial.Trim(), desc.Cuit, desc.NroFactura.Trim(), desc.NroNC, desc.FormaPago, desc.FechaAlta, desc.IdUsuarioAlta, desc.Estado);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_OrdenesdePago";
                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable SolcitudesCotizacion()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarSolicitudCotizaciones", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable DetalleCotizaciones(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_DetalleCotizaciones", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SolicitudCotizacion()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarSolicitudCotizaciones", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable PRpedidos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_PRpedidos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable DetallePR(int idpr)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_DetallePR", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idpr", idpr);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ProveedoresCotizacion(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_CotizacionProveedores", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerPresupuestos(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_CargarPresupuestos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idsolicitud", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDetalleOrdenesCompra(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerDetalleOrdenCompra", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idorden", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable RecepcionPedidos(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_RecepcionPedidos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idorden", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDetalleDevoluciones(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDetalleDevolucionesPendientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRecepcion", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDatosProveedorFactura(string proveedor)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosFacturas", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable RecepcionOrdenes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_RecepcionOrdenes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerSolicitudesCotizaciones()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerSolicitudesCotizaciones", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerOrdenesdeCompra()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarOrdenesdeCompra", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDevoluciones()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDevolucionesPendientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerPagosPendientesDocumentacion()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosPendientesDocumentacion", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarPagosPendientes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosPendientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarPagosCompletados()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosRealizados", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDetalleMercaderia(int recepcion)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDetalleMercaderia", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRecepcion", recepcion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarCobros(DateTime? desde = null, DateTime? hasta = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarCobros", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desde", (object)desde ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hasta", (object)hasta ?? DBNull.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
