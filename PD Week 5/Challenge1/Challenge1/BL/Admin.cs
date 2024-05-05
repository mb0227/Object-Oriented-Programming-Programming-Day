using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Admin
    {
        public Admin() { }
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username;
        public string Password;
    }
}
