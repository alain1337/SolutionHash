using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHash
{
    public static class HashHelper
    {
        public static string HashFile(string filename)
        {
            return HashObject(File.ReadAllText(filename));
        }

        public static string HashObject(object o)
        {
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(Convert.ToString(o))));
            }
        }
    }
}
