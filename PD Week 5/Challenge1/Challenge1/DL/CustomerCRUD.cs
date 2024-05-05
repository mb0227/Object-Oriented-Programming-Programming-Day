using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class CustomerCRUD
    {
        public static List <Customer> Customers = new List<Customer> ();

        public static void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public static bool CustomerExists(Customer c)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.Username == c.Username && customer.Password == c.Password)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
