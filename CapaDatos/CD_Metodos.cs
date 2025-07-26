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

        public int Bitacora(string usuario,string tabla,string descripcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarBitacora", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Tabla", tabla);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
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
        public int ActualizarUsuario(string usuario, string nombre, string apellido, string dni, int rol, int bloqueado)
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
                    cmd.Parameters.AddWithValue("@dv", usuarioNuevo.dv);
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
                using (SqlCommand cmd = new SqlCommand("sp_GuardarPR", conexion.Abrir()))
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
        #endregion
    }
}