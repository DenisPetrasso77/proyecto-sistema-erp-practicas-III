using CapaEntities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos:CD_Conexion
    {
        public DataTable SeleccionarProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ProductosStockMin()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_StockMinimo", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable CategoriasProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarCategoriasProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable TipoProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarTipoProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable MedidasProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarMedidasProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable MarcasProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarMarcasProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable UnidadProductos()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarUnidadProductos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable TraerDetalleProductos(string idproducto)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosProducto", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public string InsertarProducto(ProductoNuevo producto)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProducto", AbrirConexion()))
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

                    string resultado = cmd.ExecuteScalar().ToString();
                    return resultado;
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
        public string ActualizarProducto(ProductoNuevo producto)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarDatosProducto", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string ActualizarCategoria(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarCate", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string ActualizarMarca(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarMarca", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string ActualizarTipoProducto(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarTipoProducto", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string InsertarCate(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarCate", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string InsertarMarca(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarMarca", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Marca", nombre);
                    cmd.ExecuteNonQuery();
                    return "Marca Cargada";
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
        public string InsertarMedidas(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarMedidas", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string ActualizarMedidas(int id, string nombre, string estado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarMedidas", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Medida", nombre);
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
                CerrarConexion();
            }
        }
        public DataTable ProductoSeleccionado(string codigo)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProductosVender", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", codigo);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable SeleccionarDescuentos(string codigo)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SelecionarDescuentos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", codigo);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
