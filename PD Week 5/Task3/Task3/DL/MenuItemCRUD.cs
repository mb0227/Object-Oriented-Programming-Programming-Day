using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class MenuItemCRUD
    {
        public static List<MenuItem> Items = new List<MenuItem> ();

        public static void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public static void StoreData(string path,MenuItem item)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(item.Name + "," + item.Price + "," + item.Type);
            writer.Close();
        }

        public static void ReadData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string record;
            while((record = reader.ReadLine())!= null)
            {
                string[] split = record.Split(',');
                string name = split[0];
                string price = split[1];
                string type = split[2];

                MenuItem item = new MenuItem(name, type,int.Parse(price));
                Items.Add(item);
            }
            reader.Close();
        }
    }
}
