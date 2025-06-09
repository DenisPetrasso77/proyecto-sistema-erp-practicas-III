using CapaEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Xml;

namespace CapaDatos
{
    public class CD_Metodos
    {
        CD_Conexion conexion = new CD_Conexion();


        #region METODOS
        public int Bitacora(string descripcion, DateTime fecha)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Bitacora", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("Fecha", fecha);
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
        public string Registro(string usuario,string clave, string nombre, string apellido)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", clave);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.ExecuteNonQuery();
                    return "ok";
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
        public int ActualizarDetallPR(int iddetallepr, int IdPR, int  CantidadNueva, int Usuariomodificacion, DateTime Fechamodificacion )
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
        public DataTable Categorias()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarCate", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable Marcas()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarMarca", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable Medidas()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarMedidas", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable UnidadVenta()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarFormaVenta", conexion.Abrir()))
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
        public DataTable TipoProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarTipoProductos", conexion.Abrir()))
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
            using (SqlCommand cmd = new SqlCommand("sp_DetallePR", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idpr", idpr);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
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
        //public Usuarioactual DatosIngreso(string Usuario)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlCommand cmd = new SqlCommand("sp_Datosingreso", conexion.Abrir()))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@usuario", Usuario);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //    }
        //    try
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            return new Usuarioactual()
        //            {
        //                id = Convert.ToInt32(dt.Rows[0]["Id"].ToString()),
        //                usuario = dt.Rows[0]["Usuario"].ToString(),
        //                contraseña = dt.Rows[0]["Contraseña"].ToString(),

        //            };     
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return null;
        //}
        #endregion
    }
}