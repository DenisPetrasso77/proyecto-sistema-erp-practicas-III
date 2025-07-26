using System.Collections.Generic;

namespace CapaEntities
{

    public class UsuarioActual
    {
        public  int IdUsuario { get; set; }
        public  string Usuario { get; set; }
        public  string Contraseña { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Intentos { get; set; }
        public  string Bloqueado { get; set; }
        public  string Rol { get; set; }
        public  int dni { get; set; }
        public  List<string> Permisos { get; set; } = new List<string>();
    }
}
