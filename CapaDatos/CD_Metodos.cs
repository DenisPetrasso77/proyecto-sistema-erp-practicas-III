using CapaEntities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Metodos
    {
        CD_Conexion conexion = new CD_Conexion();
        #region METODOS

        public string Bitacora(int usuario,string tabla,string descripcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarBitacora", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Tabla", tabla);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    return (string)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int Intentos(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_IntentosFallidos", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int BorrardetallePR(int iddetallepr)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarProductoPR", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public int InsertarVentas(decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarVentas", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("Total", total);
                    SqlParameter Idventa = new SqlParameter("@IdVenta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(Idventa);

                    cmd.ExecuteNonQuery();

                    return (int)Idventa.Value;
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int ActualizarUsuario(string usuario, string nombre, string apellido, string dni, int rol, int bloqueado,string correo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    cmd.Parameters.AddWithValue("Nombre", nombre);
                    cmd.Parameters.AddWithValue("Apellido", apellido);
                    cmd.Parameters.AddWithValue("Dni", dni);
                    cmd.Parameters.AddWithValue("Rol", rol);
                    cmd.Parameters.AddWithValue("Bloqueado", bloqueado);
                    cmd.Parameters.AddWithValue("Correo", correo);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int ActualizarDetallPR(int iddetallepr, int IdPR, int CantidadNueva, int Usuariomodificacion, DateTime Fechamodificacion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizardetallePR", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public int ActualizarDetalleCotizaciones(int idsolicitud,string idproducto,string proveedor,decimal precio)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCotizaciones", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public int CodigoPostal(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarCodigoPostal", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int BorrarDetalleBitacora(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarDetalleBitacora", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdBitacora", id);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int InsertarFacturas(int recepcion,int puesto,int factura, int tipo,string cuit,string razonsocial,decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarFacturas", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public string InsertarComprobanteNotaCredito(int recepcion, int puesto, int notacredito, int tipo, string cuit, string razonsocial, decimal total)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarComprobanteNotaCredito", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public int BorrarBitacora()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarBitacora", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int InsertarComprobantePago(int idorden, string transaccion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarComprobantePago", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public int StatusBloq(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoBloqueo", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public int BorrarUsuario(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarUsuario", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarOrdendeCompra(OrdendeCompra ordendeCompra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarOrdenDeCompra", conexion.Abrir()))
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
                        detalle.Rows.Add(desc.IdProducto, desc.Producto,desc.IdDetalleCoti,desc.Precio);
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
                conexion.Cerrar();
            }
        }
        public string Registro(UsuarioNuevo usuarioNuevo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuarioNuevo.Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuarioNuevo.Contraseña);
                    cmd.Parameters.AddWithValue("@Nombre", usuarioNuevo.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuarioNuevo.Apellido);
                    cmd.Parameters.AddWithValue("@Dni", usuarioNuevo.Dni);
                    cmd.Parameters.AddWithValue("@IdRol", usuarioNuevo.Rol);
                    cmd.Parameters.AddWithValue("@Pregunta", usuarioNuevo.Pregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", usuarioNuevo.Respuesta);
                    cmd.Parameters.AddWithValue("@Correo", usuarioNuevo.Correo);
                    cmd.ExecuteNonQuery();
                    return "Usuario Registrado con Exito";
                }
            }
            catch (SqlException ex)
            {
                return "Error" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarProducto(ProductoNuevo producto)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProducto", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idproducto", producto.CodigoProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Categoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@Marca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@Medidas", producto.IdMedida);
                    cmd.Parameters.AddWithValue("@UnidadReferencia", producto.IdUnidadVenta);
                    cmd.Parameters.AddWithValue("@StockMin", producto.StockMin);
                    cmd.Parameters.AddWithValue("@StockMax", producto.StockMax);
                    cmd.Parameters.AddWithValue("@StockActual", producto.StockActual);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@FechaAlta", producto.FechaAlta);
                    cmd.Parameters.AddWithValue("@IdUsuarioAlta", producto.IdUsuarioAlta);
                    cmd.Parameters.AddWithValue("@Dvh", producto.DVH);
                    DataTable dtDescuentos = new DataTable();

                    dtDescuentos.Columns.Add("CantidadMin", typeof(int));
                    dtDescuentos.Columns.Add("PorcentajeDesc", typeof(int));
                    foreach (var desc in producto.Descuentos)
                    {
                        dtDescuentos.Rows.Add(desc.CantidadMinima, desc.Porcentaje);
                    }
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Descuentos", dtDescuentos);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.TipoDescuentoProducto";
                    cmd.ExecuteNonQuery();
                    return "Producto Guardado";
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string ActualizarProducto(ProductoNuevo producto)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarDatosProducto", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idproducto", producto.CodigoProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Categoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@Marca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@Medidas", producto.IdMedida);
                    cmd.Parameters.AddWithValue("@UnidadReferencia", producto.IdUnidadVenta);
                    cmd.Parameters.AddWithValue("@StockMin", producto.StockMin);
                    cmd.Parameters.AddWithValue("@StockMax", producto.StockMax);
                    cmd.Parameters.AddWithValue("@StockActual", producto.StockActual);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado);
                    cmd.Parameters.AddWithValue("@FechaUltActualizacion", producto.FechaAlta);
                    cmd.Parameters.AddWithValue("@IdUsuarioUltActualizacion", producto.IdUsuarioAlta);
                    cmd.Parameters.AddWithValue("@Dvh", producto.DVH);
                    DataTable dtDescuentos = new DataTable();

                    dtDescuentos.Columns.Add("CantidadMin", typeof(int));
                    dtDescuentos.Columns.Add("PorcentajeDesc", typeof(int));
                    foreach (var desc in producto.Descuentos)
                    {
                        dtDescuentos.Rows.Add(desc.CantidadMinima, desc.Porcentaje);
                    }
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Descuentos", dtDescuentos);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.TipoDescuentoProducto";
                    cmd.ExecuteNonQuery();
                    return "Producto Actualizado";
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarProveedor(Proveedor proveedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProveedor", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreComercial", (object)proveedor.NombreComercial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@TipoIdentificacion", proveedor.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("@NumeroDeIdentificacion", proveedor.NumeroDeIdentificacion);
                    cmd.Parameters.AddWithValue("@Correo", (object)proveedor.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoArea", (object)proveedor.CodigoArea ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DireccionCalle", (object)proveedor.DireccionCalle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DireccionAltura", (object)proveedor.DireccionAltura ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DireccionProvincia", (object)proveedor.DireccionProvincia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DireccionLocalidad", (object)proveedor.DireccionLocalidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DireccionCodigoPostal", (object)proveedor.DireccionCodigoPostal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observaciones", (object)proveedor.Observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdUsuarioAlta", proveedor.IdUsuarioAlta);
                    cmd.ExecuteNonQuery();
                    return "Proveedor guardado correctamente.";
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarCate(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarCate", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Categoria", nombre);
                    cmd.ExecuteNonQuery();
                    return "Categoria Cargada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarMarca(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarMarca", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Marca", nombre);
                    cmd.ExecuteNonQuery();
                    return "Categoria Cargada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarMedidas(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarMedidas", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Medida", nombre);
                    cmd.ExecuteNonQuery();
                    return "Medida Cargada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string BorrarPR(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarPR", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public string ActualizarCate(int id,string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCate", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Categoria", nombre);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                    return "Categoria Actualizada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string ActualizarMarca(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarMarca", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Marca", nombre);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                    return "Marca Actualizada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string ActualizarMedidas(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarMedidas", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@@Medida", nombre);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                    return "Medida Actualizada";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string ActualizarTipoProducto(int id, string nombre,string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarTipoProducto", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TipoProducto", nombre);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                    return "Tipo de Producto Actualizado";
                }
            }
            catch (SqlException sqlex)
            {
                return sqlex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarPR(int idusuario, DataTable detallepr)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarPR", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public string InsertarSolicitudCotizacion(PedidoCotizacion pedidoCotizacion, DataTable detalle)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarSolicitudCotizacion", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }       
        public string InsertarInformeRecepcion(InformesRecepcion informesRecepcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarRecepcionMercaderia", conexion.Abrir()))
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
                        detalle.Rows.Add(desc.Idproducto, desc.Producto, desc.CantidadPedida, desc.CantidadRecibida,desc.Diferencia,desc.IdProveedor,desc.Motivo);
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
                conexion.Cerrar();
            }
        }
        public string InsertarDevolucion(Devoluciones devoluciones)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarDevoluciones", conexion.Abrir()))
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
                conexion.Cerrar();
            }
        }
        public string InsertarVentas(Ventas ventas)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarVentas", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FormadePago", ventas.FormaPago);
                    cmd.Parameters.AddWithValue("@IdUsuario", ventas.IdUsuario);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Total", ventas.total);
                    cmd.Parameters.AddWithValue("@IdCliente", ventas.cliente);
                    cmd.Parameters.AddWithValue("@Comprobante", ventas.comprobante);
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("IdProducto", typeof(string));
                    detalle.Columns.Add("Producto", typeof(string));
                    detalle.Columns.Add("Cantidad", typeof(int));
                    detalle.Columns.Add("Descuento", typeof(int));
                    detalle.Columns.Add("Precio", typeof(decimal));

                    foreach (var desc in ventas.Detalle)
                    {

                        detalle.Rows.Add(desc.Idproducto, desc.Producto, desc.Cantidad, desc.Descuento, desc.precio);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalles", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleVentas";
                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarCliente", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("Nombre", typeof(string));
                    detalle.Columns.Add("Apellido", typeof(string));
                    detalle.Columns.Add("Dni", typeof(string));
                    detalle.Columns.Add("Correo", typeof(string));
                    detalle.Columns.Add("CodArea", typeof(int));
                    detalle.Columns.Add("Telefono", typeof(string));
                    detalle.Columns.Add("Calle", typeof(string));
                    detalle.Columns.Add("Altura", typeof(int));
                    detalle.Columns.Add("Provincia", typeof(int));
                    detalle.Columns.Add("Localidad", typeof(int));
                    detalle.Columns.Add("CodigoPostal", typeof(int));
                    detalle.Columns.Add("Observaciones", typeof(string));
                    detalle.Columns.Add("IdUsuario", typeof(int));

                    detalle.Rows.Add(cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Correo, cliente.CodigoArea,cliente.Telefono,cliente.DireccionCalle,cliente.DireccionAltura,cliente.DireccionProvincia,cliente.DireccionLocalidad,cliente.DireccionCodigoPostal,cliente.Observaciones,cliente.IdUsuario);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleCliente";
                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string ModificarCliente(Cliente cliente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[sp_ActualizarCliente]", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable detalle = new DataTable();

                    detalle.Columns.Add("Nombre", typeof(string));
                    detalle.Columns.Add("Apellido", typeof(string));
                    detalle.Columns.Add("Dni", typeof(string));
                    detalle.Columns.Add("Correo", typeof(string));
                    detalle.Columns.Add("CodArea", typeof(int));
                    detalle.Columns.Add("Telefono", typeof(string));
                    detalle.Columns.Add("Calle", typeof(string));
                    detalle.Columns.Add("Altura", typeof(int));
                    detalle.Columns.Add("Provincia", typeof(int));
                    detalle.Columns.Add("Localidad", typeof(int));
                    detalle.Columns.Add("CodigoPostal", typeof(int));
                    detalle.Columns.Add("Observaciones", typeof(string));
                    detalle.Columns.Add("IdUsuario", typeof(int));
                    detalle.Columns.Add("IdCliente", typeof(int));

                    detalle.Rows.Add(cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Correo, cliente.CodigoArea, cliente.Telefono, cliente.DireccionCalle, cliente.DireccionAltura, cliente.DireccionProvincia, cliente.DireccionLocalidad, cliente.DireccionCodigoPostal, cliente.Observaciones, cliente.IdUsuario,cliente.IdCliente);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetalleCliente";
                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                return "Error:" + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public string InsertarOrdenesPago(OrdenesPago OrdenesPago)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarOrdenesPago", conexion.Abrir()))
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

                        detalle.Rows.Add(desc.IdRecepcion, desc.RazonSocial.Trim(), desc.Cuit, desc.NroFactura.Trim(), desc.NroNC,desc.FormaPago,desc.FechaAlta,desc.IdUsuarioAlta,desc.Estado);
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
                conexion.Cerrar();
            }
        }
        public DataTable SolcitudesCotizacion()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarSolicitudCotizaciones", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable Localidades(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarLocalidad", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable Provincias()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProvincias", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_DetalleCotizaciones", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarSolicitudCotizaciones", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable Proveedores(int? id = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProveedores", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_PRpedidos", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ProductosStockMin()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_StockMinimo", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TipoProductos(string tabla)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerTodo", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tabla",tabla);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable DetallePR(int idpr)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_DetallePR", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_CotizacionProveedores", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable Usuarios(int? idusuario = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarUsuarios", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (idusuario.HasValue)
                    cmd.Parameters.AddWithValue("@IdUsuario", idusuario.Value);
                else
                    cmd.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public UsuarioActual DatosIngreso(string Usuario)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_Datosingreso", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                var UsuarioActual  = new UsuarioActual
                {
                    IdUsuario = Convert.ToInt32(dt.Rows[0]["IdUsuario"]),
                    Usuario = dt.Rows[0]["Usuario"].ToString(),
                    Contraseña = dt.Rows[0]["Contraseña"].ToString(),
                    Nombre = dt.Rows[0]["Nombre"].ToString(),
                    Apellido = dt.Rows[0]["Apellido"].ToString(),
                    Intentos = dt.Rows[0]["Intentos"].ToString(),
                    Bloqueado = dt.Rows[0]["Bloqueado"].ToString(),
                    Rol = dt.Rows[0]["NombreRol"].ToString(),
                    dni = Convert.ToInt32(dt.Rows[0]["Dni"])
                };
                int idRol = Convert.ToInt32(dt.Rows[0]["IdRol"]);
                using (SqlCommand cmdPermisos = new SqlCommand(@"SELECT p.NombrePermiso 
                                                         FROM RolPermisos rp 
                                                         JOIN Permisos p ON p.IdPermiso = rp.IdPermiso 
                                                         WHERE rp.IdRol = @IdRol", conexion.Abrir()))
                {
                    cmdPermisos.Parameters.AddWithValue("@IdRol", idRol);
                    using (SqlDataReader reader = cmdPermisos.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioActual.Permisos.Add(reader["NombrePermiso"].ToString());
                        }
                    }
                }
                Sesion.Usuario = UsuarioActual;
                return UsuarioActual;
            }

            return null;
        }
        public DataTable TraerTodo(string tabla)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerTodo", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tabla", tabla);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarListadoClientes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarListadoClientes", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerPresupuestos(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_CargarPresupuestos", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idsolicitud", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarDatosUsuario(int usuario)
        { 
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosUsuario", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDetalleOrdenesCompra(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerDetalleOrdenCompra", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_RecepcionPedidos", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDetalleDevolucionesPendientes", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosFacturas", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proveedor", proveedor);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public int VerificarRespuesta(string dato,string respuesta)
        {
            using (SqlCommand cmd = new SqlCommand("sp_VerificarPregunta", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dato", dato);
                cmd.Parameters.AddWithValue("@Respuesta", respuesta);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public string CambiarContraseña(string dato, string respuesta)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarContraseña", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dato", dato);
                cmd.Parameters.AddWithValue("@Contraseña", respuesta);
                return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
            } 
        }
        public DataTable RecepcionOrdenes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_RecepcionOrdenes", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ProductosVenta()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarDatosProductoVenta", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_TraerSolicitudesCotizaciones", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarOrdenesdeCompra", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerBitacora()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarBitacora", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDevolucionesPendientes", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosPendientesDocumentacion", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosPendientes", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerTipoFacturas()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarTipoFacturas", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProductos", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPagosRealizados", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDetalleMercaderia", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRecepcion", recepcion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerDetalleProductos(string idproducto)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("[sp_SelecionarDatosProducto]", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable TraerPregunta(string dato)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_TraerPregunta", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dato", dato);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarClienteMod(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarClienteMod", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ProductoSeleccionado(string codigo)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProductosVender", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", codigo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarDescuentos(string codigo)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarDescuentos", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", codigo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarClientes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarClientes", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarCobros(DateTime? desde = null, DateTime? hasta = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarCobros", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desde", (object)desde ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hasta", (object)hasta ?? DBNull.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public string RestablecerContraseña(int idusuario,string contraseña)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_RestablecerContraseña", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", idusuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
            }
        }
        public string VerificarIngreso(string usuario,string contraseña)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_VerificarDatosIngreso", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
            }
        }
        #endregion
    }
}