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
    }
}