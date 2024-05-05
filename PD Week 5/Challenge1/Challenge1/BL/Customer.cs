using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Customer
    {
        public Customer() { }
        public Customer(string username, string password, string email, string address, int contact)
        {
            Username = username;
            Password = password;
            Email = email;
            Address = address;
            Contact = contact;
        }

        public string Username;
        public string Password;
        public string Email;
        public string Address;
        public int Contact;
    }
}
