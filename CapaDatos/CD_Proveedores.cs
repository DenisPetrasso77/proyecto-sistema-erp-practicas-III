using CapaEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedores:CD_Conexion
    {
        public DataTable Proveedores(int? id = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProveedores", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable Proveedores(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarProveedoresMod", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public string InsertarProveedor(Proveedor proveedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarProveedor", AbrirConexion()))
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
                CerrarConexion();
            }
        }
    }
}
