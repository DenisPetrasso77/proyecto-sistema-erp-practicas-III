using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Metodos
    {
        CD_Conexion conexion = new CD_Conexion();


        #region METODOS
        public DataTable MostrarTodo(string NombreBD)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_Mostrartodo", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombretabla", NombreBD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
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
        public string InsertarProducto(string codigo,string descripcion,string cate,int stockmin,int stockmax,string unidadcarga,int cantunicarga,int cantporunicarga,int vendeporunidades, int vendeporkilo, int vendeporpack,decimal precioporunidad, decimal precioporkilo, decimal precioporpack,int usuarioalta, string usuarioreferencia, List<(int cantidadMinima, int porcentaje)> descuentos)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProducto", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idproducto", codigo);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Categoria", cate);
                    cmd.Parameters.AddWithValue("@StockMin", stockmin);
                    cmd.Parameters.AddWithValue("@StockMax", stockmax);
                    cmd.Parameters.AddWithValue("@UnidadCarga", unidadcarga);
                    cmd.Parameters.AddWithValue("@CantUnidadCarga", cantunicarga);
                    cmd.Parameters.AddWithValue("@CantPorUnidadCarga", cantporunicarga);
                    cmd.Parameters.AddWithValue("@StockActual", (cantunicarga * cantporunicarga));
                    cmd.Parameters.AddWithValue("@VendePorUnidades", vendeporunidades);
                    cmd.Parameters.AddWithValue("@VendePorKilo", vendeporkilo);
                    cmd.Parameters.AddWithValue("@VendePorPack", vendeporpack);
                    cmd.Parameters.AddWithValue("@PrecioUnidad", precioporunidad);
                    cmd.Parameters.AddWithValue("@PrecioKilo", precioporkilo);
                    cmd.Parameters.AddWithValue("@PrecioPack", precioporpack);
                    cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdUsuarioAlta", usuarioalta);
                    cmd.Parameters.AddWithValue("@UnidadReferencia", usuarioreferencia);
                    DataTable dtDescuentos = new DataTable();
                    dtDescuentos.Columns.Add("CantidadMinima", typeof(int));
                    dtDescuentos.Columns.Add("PorcentajeDescuento", typeof(int));
                    foreach (var desc in descuentos)
                    {
                        dtDescuentos.Rows.Add(desc.cantidadMinima, desc.porcentaje);
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
        public string ActualizarCate(int id,string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCate", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Categoria", nombre);
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