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
    public class CD_Ventas:CD_Conexion
    {
        public DataTable ProductosVenta()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelecionarDatosProductoVenta", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los productos para venta.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public string InsertarVentas(Ventas ventas)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarVentas", AbrirConexion()))
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
                CerrarConexion();
            }
        }
    }

}
