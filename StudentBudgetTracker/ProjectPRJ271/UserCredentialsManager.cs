using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjectPRJ271
{
    internal class UserCredentialsManager
    {
        private static Dictionary<string, string> _userCredentials = new Dictionary<string, string>();

        static UserCredentialsManager()
        {
            
            AddUser("admin", "admin123");
            AddUser("admin", "dire");
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void AddUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            _userCredentials[username] = hashedPassword;
        }

        public static bool Authenticate(string username, string password)
        {
            if (_userCredentials.TryGetValue(username, out string storedHash))
            {
                return storedHash == HashPassword(password);
            }
            return false;
        }

        public static bool UserExists(string username)
        {
            return _userCredentials.ContainsKey(username);
        }
    }
}
