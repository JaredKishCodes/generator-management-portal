
using System.Text;

namespace ReecsPortal.Infrastructure.Auth.Helper
{
    public static class PasswordHasher
    {
        public static string HashPasswordSHA256(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash); // Compare with stored hash
        }
    }
}
