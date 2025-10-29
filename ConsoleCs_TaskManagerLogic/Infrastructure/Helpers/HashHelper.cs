using System.Security.Cryptography;
using System.Text;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Helpers
{
    internal static class HashHelper
    {
        internal static byte[] GetHash(string text)
        {
            byte[] hash;
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(textBytes);
            }

            return hash;
        }

        internal static byte[] GetHashFromString(string textHash)
        {
            byte[] hash = Convert.FromBase64String(textHash);
            return hash;
        }
    }
}
