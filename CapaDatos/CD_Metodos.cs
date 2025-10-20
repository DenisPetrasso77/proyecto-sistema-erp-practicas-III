using CapaEntities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class CD_Metodos:CD_Conexion
    {
        public int CodigoPostal(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarCodigoPostal", AbrirConexion()))
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
                CerrarConexion();
            }
        }
        public DataTable Localidades(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarLocalidad", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable SeleccionarProvincias()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProvincias", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable SeleccionarMotivosDevolucion()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarMotivosDevolucion", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable TraerTipoFacturas()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarTipoFacturas", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}