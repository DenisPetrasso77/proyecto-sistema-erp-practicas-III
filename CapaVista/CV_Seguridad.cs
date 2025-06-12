using System.Linq;

namespace CapaVista
{
    public class CV_Seguridad
    {
        public string Hasheo(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public bool VertificarHasheo(string storedHash, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }

        public int CalcularDVH(string texto)
        {
            return texto.Sum(c => (int)c);
        }
    }
}