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
    public class CD_Clientes:CD_Conexion
    {
        public string InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarCliente", AbrirConexion()))
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

                    detalle.Rows.Add(
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.Dni,
                        cliente.Correo,
                        cliente.CodigoArea,
                        cliente.Telefono,
                        cliente.DireccionCalle,
                        cliente.DireccionAltura,
                        cliente.DireccionProvincia,
                        cliente.DireccionLocalidad,
                        cliente.DireccionCodigoPostal,
                        cliente.Observaciones,
                        cliente.IdUsuario
                    );

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
                CerrarConexion();
            }
        }
        public string ModificarCliente(Cliente cliente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("[sp_ActualizarCliente]", AbrirConexion()))
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

                    detalle.Rows.Add(
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.Dni,
                        cliente.Correo,
                        cliente.CodigoArea,
                        cliente.Telefono,
                        cliente.DireccionCalle,
                        cliente.DireccionAltura,
                        cliente.DireccionProvincia,
                        cliente.DireccionLocalidad,
                        cliente.DireccionCodigoPostal,
                        cliente.Observaciones,
                        cliente.IdUsuario,
                        cliente.IdCliente
                    );

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
                CerrarConexion();
            }
        }
        public DataTable SeleccionarClientes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarClientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarClienteMod(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarClienteMod", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SeleccionarListadoClientes()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sp_SeleccionarListadoClientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
