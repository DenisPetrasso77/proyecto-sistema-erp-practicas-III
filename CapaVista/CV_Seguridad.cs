using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CapaVista
{
    public class CV_Seguridad
    {
        public static string Hasheo(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public static string ObtenerPalabra()
        {
            return "PAPELERAGAUCHITO";
        }
        public static bool VertificarHasheo(string storedHash, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }
        public static string HashearSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static int CalcularDVH(string texto)
        {
            return texto.Sum(c => (int)c);
        }
    }
}