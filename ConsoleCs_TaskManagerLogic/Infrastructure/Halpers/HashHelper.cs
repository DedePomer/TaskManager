using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Halpers
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
    }
}
