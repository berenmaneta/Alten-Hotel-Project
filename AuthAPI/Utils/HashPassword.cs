using System.Security.Cryptography;
using System.Text;

namespace AltenAPI.Utils
{
    public static class HashPassword
    {
        public static string HashUserPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashed = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashed);
        }
    }
}
