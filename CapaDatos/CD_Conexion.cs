using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=DATOS;Integrated Security=True;";
        private SqlConnection conexion;

        public SqlConnection Abrir()
        {
            if (conexion == null)
                conexion = new SqlConnection(cadenaConexion);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            return conexion;
        }

        public void Cerrar()
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
