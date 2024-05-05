using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesConversion.BL
{
    internal class Order
    {
        public int Id;
        public string CustomerName;
        public int ClothesId;
        public int Quantity;

        public Order(int id, string customerName, int clothesId, int quantity)
        {
            Id = id;
            CustomerName = customerName;
            ClothesId = clothesId;
            Quantity = quantity;
        }
    }
}
