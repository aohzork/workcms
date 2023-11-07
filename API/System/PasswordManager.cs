namespace API.System
{
    public class PasswordManager
    {
        public static (string passwordHash, string salt) HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(salt, password);
            return (passwordHash, salt);
        }

        public static bool VerifyPassword(string password, string storedPasswordHash, string salt)
        {
            string providedPasswordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return (providedPasswordHash == storedPasswordHash);
        }
    }
}
