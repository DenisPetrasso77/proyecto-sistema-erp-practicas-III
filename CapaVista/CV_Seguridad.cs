using System.Linq;

namespace CapaVista
{
    public class CV_Seguridad
    {
        public static string Hasheo(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public static bool VertificarHasheo(string storedHash, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }

        public static int CalcularDVH(string texto)
        {
            return texto.Sum(c => (int)c);
        }
    }
}