using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class AdminCRUD
    {
        public static List <Admin> Admins = new List <Admin> ();

        public static void AddAdmin(Admin admin)
        {
            Admins.Add(admin);
        }

        public static bool AdminExists(Admin a)
        {
            foreach (Admin admin in Admins)
            {
                if(admin.Username == a.Username && admin.Password== a.Password)
                { 
                    return true; 
                }
            }
            return false;
        }

    }
}
