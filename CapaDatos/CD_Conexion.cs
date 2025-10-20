using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class CD_Conexion
    {
        private readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=DATOS;Integrated Security=True;";
        private SqlConnection conexion;

        protected SqlConnection AbrirConexion()
        {
            if (conexion == null)
                conexion = new SqlConnection(cadenaConexion);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();  
            return conexion;
        }

        protected void CerrarConexion()
        {
            if (conexion != null && conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
                conexion.Dispose();
                conexion = null;
            }
        }
    }
}
