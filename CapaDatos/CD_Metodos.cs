using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;
using Entities;

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
        public int Registro(string usuario,string clave, string nombre, string apellido, string dni,int autorizante)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Registro", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    cmd.Parameters.AddWithValue("Contraseña", clave);
                    cmd.Parameters.AddWithValue("Nombre", nombre);
                    cmd.Parameters.AddWithValue("Apellido", apellido);
                    cmd.Parameters.AddWithValue("Dni", dni);
                    cmd.Parameters.AddWithValue("FechaAlta", DateTime.Now);
                    cmd.Parameters.AddWithValue("Autorizante", autorizante);
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
        public int InsertarProductos(string codigo,string descripcion,int cate,int stock,int cantminima,decimal preciobulto, decimal preciounidad, decimal preciox10, decimal preciox25, decimal preciox50, decimal preciox100)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProductos", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Codigo", codigo);
                    cmd.Parameters.AddWithValue("Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("Categoria", cate);
                    cmd.Parameters.AddWithValue("Stock", stock);
                    cmd.Parameters.AddWithValue("Cantimin", cantminima);
                    cmd.Parameters.AddWithValue("Preciobulto", preciobulto);
                    cmd.Parameters.AddWithValue("Preciounidad", preciounidad);
                    cmd.Parameters.AddWithValue("Preciox10", preciox10);
                    cmd.Parameters.AddWithValue("Preciox25", preciox25);
                    cmd.Parameters.AddWithValue("Preciox50", preciox50);
                    cmd.Parameters.AddWithValue("Preciox100", preciox100);
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
        public int InsertarCate(string nombre)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarCate", conexion.Abrir()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Cate", nombre);
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

        //public bool InsertarDetalles()
        //{
        //    string sSql = "INSERT INTO Detalleventas (Idventas, Idproducto,Cantidad,Preciounidad) VALUES " +
        //                  "('" + Id + "', '" + Idproducto + "','" + Cantidad + "','" + Precioxunidad + "')";
        //    Ejecutar(sSql);
        //    return true;
        //}

        //public int ContarUsuarios()
        //{
        //    string sSql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario='" + Usuario + "'";
        //    return EjecutarNroFilas(sSql);
        //}
        //public int ContarCorreo()
        //{
        //    string sSql = "SELECT COUNT(*) FROM Usuarios WHERE Correo='" + Usuario + "'";
        //    return EjecutarNroFilas(sSql);
        //}

        //}
        //public int InsertarCliente()
        //{
        //    string sSql = "INSERT INTO Usuarios (Usuario, Contraseña) VALUES " +
        //                  "('" + Usuario + "', '" + Contraseña + "')";
        //    return Ejecutar(sSql);
        //}
        //public int EliminarCliente()
        //{
        //    string sSql = "DELETE FROM Usuarios WHERE  Usuario='" + Usuario + "'";
        //    return Ejecutar(sSql);
        //}
        //public int ActualizarClave()
        //{
        //    string sSql = "UPDATE Usuarios SET Contraseña='" + Contraseña + "' WHERE Usuario='" + Usuario + "'";
        //    return Ejecutar(sSql);
        //}
        //public int ActualizarCliente()
        //{
        //    string sSql = "UPDATE Usuarios SET Nombre='" + Nombre + "',Apellido='" + Apellido + "',Usuario='" + Usuario + "',Tipo='" + Tipo + "',Correo='" + Correo + "' WHERE Id=" + Id;
        //    return Ejecutar(sSql);

        //}

        public Usuarioactual DatosIngreso(string Usuario)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_Datosingreso", conexion.Abrir()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", Usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    return new Usuarioactual()
                    {
                        id = Convert.ToInt32(dt.Rows[0]["Id"].ToString()),
                        usuario = dt.Rows[0]["Usuario"].ToString(),
                        contraseña = dt.Rows[0]["Contraseña"].ToString(),
                        bloqueado = Convert.ToInt32(dt.Rows[0]["Bloqueado"].ToString()),
                    };     
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion
    }
}