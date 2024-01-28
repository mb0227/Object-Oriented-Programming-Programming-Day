using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using AppWeek2;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxUsers = 10;
            List<User> users = new List<User>();
            List<Shop> shops = new List<Shop>();
            readData(users);
            while (true)
            {
                Console.Clear();
                string option = menu();
                if (option == "1")
                {
                    Console.Clear();
                    inputData(users, maxUsers);
                }
                else if (option == "2")
                {
                    Console.Clear();
                    printData(users);
                }
                else if (option == "3")
                {
                    Console.Clear();
                    string role = signIn(users);
                    if (role == "admin")
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Create New Item");
                            Console.WriteLine("Retrieve Items");
                            Console.WriteLine("Update Previous Item");
                            Console.WriteLine("Delete Previous Item");
                            Console.Write("Which operation you want to perform (CRUD)? ");
                            string operation = Console.ReadLine();
                            operation = operation.ToLower();
                            if (operation == "c")
                            {
                                Console.Clear();
                                addMenu(shops);
                            }
                            else if (operation == "r")
                            {
                                Console.Clear();
                                displayMenu(shops);
                            }
                            else if (operation == "u")
                            {
                                Console.Clear();
                                updateMenu(shops);
                            }
                            else if (operation == "d")
                            {
                                Console.Clear();
                                removeMenu(shops);
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        static string menu()
        {
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Show Data");
            Console.WriteLine("3. Sign In");
            Console.Write("Input: ");
            string option = Console.ReadLine();
            return option;
        }

        static void inputData(List<User> users, int maxUsers)
        {
            if (users.Count < maxUsers)
            {
                User newUser = new User();
                Console.Write("Enter Userame: ");
                newUser.username = Console.ReadLine();
                Console.Write("Enter Password: ");
                newUser.password = Console.ReadLine();
                Console.Write("Enter Role: ");
                newUser.role = Console.ReadLine();
                newUser.role.ToLower();
                users.Add(newUser);
                writeData(users, "A:\\University Related\\UET Lahore\\2nd Semester\\Programming Day\\PD Week 2\\AppWeek2\\Credentials.txt");
            }
            else
            {
                Console.WriteLine("Max Users Reached");
                Console.ReadKey();
            }
        }

        static void printData(List<User> users)
        {
            if (users.Count != 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine("Username: {0}\nPassword: {1}\nRole: {2}\n", users[i].username, users[i].password, users[i].role);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No Users Available");
                Console.ReadKey();
            }
        }

        static void writeData(List<User> users, string path)
        {
            StreamWriter record = new StreamWriter(path);
            if (File.Exists(path))
            {
                for (int i = 0; i < users.Count; i++)
                {
                    record.WriteLine("{0},{1},{2}", users[i].username, users[i].password, users[i].role);
                }
                record.Flush();
                record.Close();
            }
            else
            {
                Console.WriteLine("File Does not exist");
                Console.ReadKey();
            }
        }

        static string parseData(string record, int field)
        {
            int commaCount = 1;
            string data = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                    continue;
                }
                if (commaCount == field)
                {
                    data += record[i];
                }
                else
                {
                    continue;
                }
            }
            return data;

        }

        static void readData(List<User> users)
        {
            string path = "A:\\University Related\\UET Lahore\\2nd Semester\\Programming Day\\PD Week 2\\AppWeek2\\Credentials.txt";
            StreamReader reader = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = reader.ReadLine()) != null)
                {
                    User newUser = new User();
                    newUser.username = parseData(record, 1);
                    newUser.password = parseData(record, 2);
                    newUser.role = parseData(record, 3);
                    users.Add(newUser);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("File Does not exist");
                Console.ReadKey();
            }
        }

        static string signIn(List<User> users)
        {
            string username, password, role;
            Console.Write("Enter Userame: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.Write("Enter Role: ");
            role = Console.ReadLine();
            role.ToLower();
            if (userExists(ref username, ref password, ref role, users))
            {
                Console.WriteLine("Login Successfull.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Login Unsuccessfull.");
                Console.ReadKey();
            }
            return role;
        }

        static bool userExists(ref string username, ref string password, ref string role, List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].username && password == users[i].password && role == users[i].role)
                    return true;
            }
            return false;
        }

        static void addMenu(List<Shop> shops)
        {
            Shop shop = new Shop();
            Console.Write("Enter name of Item to add in menu: ");
            shop.item = Console.ReadLine();
            Console.Write("Enter price of " + shop.item + ": ");
            shop.price = int.Parse(Console.ReadLine());
            shops.Add(shop);
        }

        static void displayMenu(List<Shop> shops)
        {
            if (shops.Count != 0)
            {
                for (int i = 0; i < shops.Count; i++)
                {
                    Console.WriteLine("{0}. {1} {2}", i + 1, shops[i].item, shops[i].price);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nothing to show");
                Console.ReadKey();
                return;
            }
        }

        static void removeMenu(List<Shop> shops)
        {
            displayMenu(shops);
            Console.WriteLine();
            Console.Write("Enter index of Item to remove from menu: ");
            int option = int.Parse(Console.ReadLine());
            shops.RemoveAt(option - 1);
        }

        static void updateMenu(List<Shop> shops)
        {
            displayMenu(shops);
            Console.WriteLine();
            Console.Write("Do you want to change Item Name or Price: ");
            string choice = Console.ReadLine();
            choice = choice.ToLower();
            if (choice == "name")
            {
                Console.Write("Enter Name of Item you want to change: ");
                string item = Console.ReadLine();
                editMenuData(shops, item, -1, "item");
            }
            else if (choice == "price")
            {
                Console.Write("Enter new Price for Item: ");
                int price = int.Parse(Console.ReadLine());
                editMenuData(shops, "none", price, "price");
            }
            else
            {
                return;
            }
        }

        static void editMenuData(List<Shop> shops, string editItem, int editPrice, string changeType)
        {
            int index = 0;
            Shop menu = new Shop();
            for (int i = 0; i < shops.Count; i++)
            {
                if (editItem == shops[i].item)
                {
                    index = i;
                    break;
                }
                else if (editPrice == shops[i].price)
                {
                    index = i;
                    break;
                }
            }

            if (changeType == "item")
            {
                Console.Write("Enter new name for " + editItem + ": ");
                menu.item = Console.ReadLine();
                menu.price = shops[index].price;
            }
            else if (changeType == "price")
            {
                Console.Write("Enter new price for " + editItem + ": ");
                menu.price = int.Parse(Console.ReadLine());
                menu.item = shops[index].item;
            }
            shops.RemoveAt(index);
            shops.Insert(index, menu);
        }
    }
}
