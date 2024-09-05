using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRJ271
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
