using CapaEntities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class CD_Usuarios:CD_Conexion
    {
        public string Registro(UsuarioNuevo usuarioNuevo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuarioNuevo.Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuarioNuevo.Contraseña);
                    cmd.Parameters.AddWithValue("@Nombre", usuarioNuevo.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuarioNuevo.Apellido);
                    cmd.Parameters.AddWithValue("@Dni", usuarioNuevo.Dni);
                    cmd.Parameters.AddWithValue("@IdRol", usuarioNuevo.Rol);
                    cmd.Parameters.AddWithValue("@Pregunta", usuarioNuevo.Pregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", usuarioNuevo.Respuesta);
                    cmd.Parameters.AddWithValue("@Correo", usuarioNuevo.Correo);
                    cmd.Parameters.AddWithValue("@PalabraSegura", usuarioNuevo.PalabraSecreta);

                    cmd.ExecuteNonQuery();
                    return "Usuario registrado con éxito.";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar usuario en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable SeleccionarRoles()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelecionarRoles", AbrirConexion()))
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
                throw new Exception("Error al obtener los roles desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }
        public DataTable SeleccionarPreguntas()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelecionarPreguntasSeg", AbrirConexion()))
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
                throw new Exception("Error al obtener las preguntas de seguridad desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }
        public DataTable Usuarios(int? idusuario = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarUsuarios", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idusuario.HasValue)
                        cmd.Parameters.AddWithValue("@IdUsuario", idusuario.Value);
                    else
                        cmd.Parameters.AddWithValue("@IdUsuario", DBNull.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los usuarios desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }
        public DataTable SeleccionarDatosUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosUsuario", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", idUsuario);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los datos del usuario desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }
        public string RestablecerContraseña(int idUsuario, string contraseña)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_RestablecerContraseña", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al restablecer la contraseña del usuario en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int EliminarIdRol(int idRol)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarIdRol", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idRol);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el rol en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int ObtenerIdPermiso(string permiso)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerIdPermiso", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Permiso", permiso);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el ID del permiso desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string InsertarRolPermiso(int idRol, int idPermiso)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarRolPermiso", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idRol);
                    cmd.Parameters.AddWithValue("@IdPermiso", idPermiso);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0 ? "OK" : "No se insertó ningún registro.";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar la relación rol-permiso en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable SeleccionaDatosPerfil(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarDatosPerfil", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al seleccionar los datos del perfil desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public DataTable SeleccionaPermisos()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelecionarPermisos", AbrirConexion()))
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
                throw new Exception("Error al seleccionar los permisos desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public UsuarioActual DatosLogin(string usuario)
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("sp_Datosingreso", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                var usuarioActual = new UsuarioActual
                {
                    IdUsuario = Convert.ToInt32(dt.Rows[0]["IdUsuario"]),
                    Usuario = dt.Rows[0]["Usuario"].ToString(),
                    Contraseña = dt.Rows[0]["Contraseña"].ToString(),
                    Nombre = dt.Rows[0]["Nombre"].ToString(),
                    Apellido = dt.Rows[0]["Apellido"].ToString(),
                    Intentos = dt.Rows[0]["Intentos"].ToString(),
                    Bloqueado = dt.Rows[0]["Bloqueado"].ToString(),
                    Rol = dt.Rows[0]["NombreRol"] == DBNull.Value ? "" : dt.Rows[0]["NombreRol"].ToString(),
                    dni = Convert.ToInt32(dt.Rows[0]["Dni"]),
                    PrimerIngreso = Convert.ToInt32(dt.Rows[0]["PrimerIngreso"])
                };

                string permisosRolStr = dt.Rows[0]["PermisosRol"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(permisosRolStr))
                {
                    usuarioActual.PermisosRol = permisosRolStr
                        .Split(',')
                        .Select(p => p.Trim())
                        .ToList();
                }

                string permisosUsuarioStr = dt.Rows[0]["PermisosIndividuales"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(permisosUsuarioStr))
                {
                    usuarioActual.PermisosUsuario = permisosUsuarioStr
                        .Split(',')
                        .Select(p => p.Trim())
                        .ToList();
                }

                Sesion.Usuario = usuarioActual;
                return usuarioActual;
            }

            return null;
        }
        public string InsertarPermisoUsuario(int idusuario, Permisos permisos)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarPermisoUsuario", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idusuario);

                    DataTable detalle = new DataTable();
                    detalle.Columns.Add("IdPermiso", typeof(int));

                    foreach (int desc in permisos.Detalle)
                    {
                        detalle.Rows.Add(desc);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetallePermisosUsuario";

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
        public DataTable SeleccionaPermisos(int idrol)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPermisosRol", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idrol);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al seleccionar los permisos del rol desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public DataTable SeleccionaPermisosUsuario(int idusuario)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SeleccionarPermisosUsuario", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idusuario);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al seleccionar los permisos del usuario desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public string CambiarContraseña(string dato, string respuesta, string palabra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarContraseña", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", dato);
                    cmd.Parameters.AddWithValue("@Contraseña", respuesta);
                    cmd.Parameters.AddWithValue("@Palabra", palabra);

                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al cambiar la contraseña en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int VerificarRespuesta(string dato, string respuesta)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_VerificarPregunta", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", dato);
                    cmd.Parameters.AddWithValue("@Respuesta", respuesta);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al verificar la respuesta en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable TraerPregunta(string dato)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_TraerPregunta", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", dato);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al traer la pregunta desde la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }
        public string InsertarPermisoRol(int idrol, Permisos permisos)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarPermisoRol", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdRol", idrol);

                    DataTable detalle = new DataTable();
                    detalle.Columns.Add("IdPermiso", typeof(int));

                    foreach (int desc in permisos.Detalle)
                    {
                        detalle.Rows.Add(desc);
                    }

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", detalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.t_DetallePermisosRol";

                    return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar permisos en la base de datos.", ex);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public string ActualizarPregunta(int idpregunta, string respuesta)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarPreguntaSeguridad", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", Sesion.Usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdPregunta", idpregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", respuesta);

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
        public int Intentos(string usuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_IntentosFallidos", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);

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
        public string ActualizarUsuario(int idusuario,string usuario, string nombre, string apellido, string dni, int bloqueado,int rol, string correo,string palabra)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.Parameters.AddWithValue("@IdRol", rol);
                    cmd.Parameters.AddWithValue("@Bloqueado", bloqueado);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@PalabraSegura", palabra);

                    return cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                return "Error"+ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
