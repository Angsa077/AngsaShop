using System;
using System.Security.Cryptography;
using System.Text;

namespace onlineGrocery.Helpers
{
    public static class Cryptography
    {
        public static string HashPassword(string Password)
        {
            using (SHA256 sha562hash = SHA256.Create())
            {
                byte[] bytes = sha562hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}