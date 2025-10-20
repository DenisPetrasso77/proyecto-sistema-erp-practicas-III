using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Administracion:CD_Conexion
    {
        public string ArreglarDV(string palabra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArreglarDV", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Palabra", palabra);
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
        public string EliminarRol(int rol)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarRol", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", rol);
                    return cmd.ExecuteScalar().ToString();
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
        public string InsertarRol(string rol)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarRol", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rol", rol);
                    return cmd.ExecuteNonQuery().ToString();
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
        public string Bitacora(int usuario, string tabla, string descripcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarBitacora", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public int VerificarIntegridad(string palabra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_VerificarDVHUsuarios", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Palabra", palabra);
                    return Convert.ToInt32(cmd.ExecuteScalar());
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
        public int BorrarBitacora()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarBitacora", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public int BorrarUsuario(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_BorrarUsuario", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public string VerificarIngreso(string usuario, string contraseña)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_VerificarDatosIngreso", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
            }
        }
        public DataTable TraerBitacora()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarBitacora", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public int BorrarDetalleBitacora(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarDetalleBitacora", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public int StatusBloq(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoBloqueo", AbrirConexion()))
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
                CerrarConexion();
            }
        }
    }
}
