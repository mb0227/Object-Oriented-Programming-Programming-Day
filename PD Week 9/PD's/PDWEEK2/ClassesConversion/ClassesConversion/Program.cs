using System;
using System.Collections.Generic;
using System.IO;
using ClassesConversion.BL;
using System.Threading;

namespace ClassesConversion
{
    internal class Program
    {
        static List<User> users = new List<User>();
        static List<Clothes> clothesList = new List<Clothes>();
        static List<Order> orders = new List<Order>();
        static User currentUser;

        static void Main(string[] args)
        {
            LoadUsers();
            LoadClothes();
            LoadOrders();
            title();
            Console.WriteLine("Welcome to the Program!");
            SignInSignUp();

            while (true)
            {
                if (currentUser.Role.ToLower() == "admin")
                {
                    if (!AdminMenu())
                    {
                        currentUser = null;
                        SaveDataToFile();
                        LoadUsers();
                        LoadClothes();
                        LoadOrders();
                        SignInSignUp();
                    }
                }
                else
                {
                    if (!CustomerMenu())
                    {
                        currentUser = null;
                        SaveDataToFile();
                        LoadUsers();
                        LoadClothes();
                        LoadOrders();
                        SignInSignUp();
                    }
                }
            }
        }

        static void title()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 $$$$$$\  $$\   $$\  $$$$$$\  $$$$$$$\  
$$  __$$\ $$ |  $$ |$$  __$$\ $$  __$$\ 
$$ /  \__|$$ |  $$ |$$ /  $$ |$$ |  $$ |
\$$$$$$\  $$$$$$$$ |$$ |  $$ |$$$$$$$  |
 \____$$\ $$  __$$ |$$ |  $$ |$$  ____/ 
$$\   $$ |$$ |  $$ |$$ |  $$ |$$ |      
\$$$$$$  |$$ |  $$ | $$$$$$  |$$ |      
 \______/ \__|  \__| \______/ \__|      
                                        
                                     ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void SignIn()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            currentUser = GetUserByUsernameAndPassword(username, password);

            if (currentUser != null)
            {
                Console.WriteLine($"Welcome, {currentUser.Username}! You are signed in as {currentUser.Role}.");
            }
            else
            {
                Console.WriteLine("Invalid username or password. Exiting program.");
                Environment.Exit(0);
            }
            Thread.Sleep(200);
            Console.Clear();
        }

        static void SignUp()
        {
            Console.Write("Enter a new username: ");
            string username = Console.ReadLine();
            Console.Write("Enter a new password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your role (admin/customer): ");
            string role = Console.ReadLine();

            User newUser = new User(username, password, role);
            users.Add(newUser);

            Console.WriteLine($"User {username} has been created with role {role}.");
            SignIn();
            Console.Clear();
        }

        static void SignInSignUp()
        {
            title();
            Console.WriteLine("WELCOME TO THE PROGRAM");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SignIn();
                    break;
                case 2:
                    SignUp();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting program.");
                    Environment.Exit(0);
                    break;
            }
        }

        static bool AdminMenu()
        {
            title();
            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Clothes");
                Console.WriteLine("2. Show Clothes");
                Console.WriteLine("3. Update Clothes");
                Console.WriteLine("4. Delete Clothes");
                Console.WriteLine("5. View Orders");
                Console.WriteLine("6. Log Out");
                Console.Write("Enter you choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddClothes();
                        break;
                    case 2:
                        ShowClothes();
                        break;
                    case 3:
                        UpdateClothes();
                        break;
                    case 4:
                        DeleteClothes();
                        break;
                    case 5:
                        ViewOrders();
                        break;
                    case 6:
                        return false; // Log Out
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void ShowClothes()
        {
            title();
            Console.WriteLine("List of Clothes:");
            foreach (var clothes in clothesList)
            {
                DisplayClothesInfo(clothes);
            }
            SaveDataToFile();
        }

        static void AddClothes()
        {
            title();
            Console.Write("Enter Clothes ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Clothes Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Clothes Price: ");
            double price = double.Parse(Console.ReadLine());

            Clothes newClothes = new Clothes(id, name, price);
            clothesList.Add(newClothes);

            Console.WriteLine($"Clothes {name} has been added successfully.");
            SaveDataToFile();
        }

        static void UpdateClothes()
        {
            title();
            Console.Write("Enter the ID of the Clothes to update: ");
            int id = int.Parse(Console.ReadLine());

            Clothes clothesToUpdate = null;
            foreach (var clothes in clothesList)
            {
                if (clothes.Id == id)
                {
                    clothesToUpdate = clothes;
                    break;
                }
            }

            if (clothesToUpdate != null)
            {
                Console.Write("Enter updated Clothes Name: ");
                clothesToUpdate.Name = Console.ReadLine();
                Console.Write("Enter updated Clothes Price: ");
                clothesToUpdate.Price = double.Parse(Console.ReadLine());

                Console.WriteLine($"Clothes with ID {id} has been updated successfully.");
                SaveDataToFile();
            }
            else
            {
                Console.WriteLine($"Clothes with ID {id} not found.");
            }
        }

        static void DeleteClothes()
        {
            title();
            Console.Write("Enter the ID of the Clothes to delete: ");
            int id = int.Parse(Console.ReadLine());

            Clothes clothesToDelete = null;
            foreach (var clothes in clothesList)
            {
                if (clothes.Id == id)
                {
                    clothesToDelete = clothes;
                    break;
                }
            }

            if (clothesToDelete != null)
            {
                clothesList.Remove(clothesToDelete);
                Console.WriteLine($"Clothes with ID {id} has been deleted successfully.");
                SaveDataToFile();
            }
            else
            {
                Console.WriteLine($"Clothes with ID {id} not found.");
            }
        }


        static void ViewOrders()
        {
            title();
            Console.WriteLine("List of Orders:");
            foreach (var order in orders)
            {
                DisplayOrderInfo(order);
            }
            SaveDataToFile();
        }

        static bool CustomerMenu()
        {
            title();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Customer Menu:");
                Console.WriteLine("1. Place Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Log Out");
                Console.Write("Enter you choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PlaceOrder();
                        break;
                    case 2:
                        UpdateOrder();
                        break;
                    case 3:
                        DeleteOrder();
                        break;
                    case 4:
                        ViewOrders();
                        break;
                    case 5:
                        return false; // Log Out
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void PlaceOrder()
        {
            title();
            Console.Write("Enter Order ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Clothes ID: ");
            int clothesId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Order newOrder = new Order(id, customerName, clothesId, quantity);
            orders.Add(newOrder);

            Console.WriteLine($"Order for {quantity} units of Clothes ID {clothesId} has been placed successfully.");
            SaveDataToFile();

        }

        static void UpdateOrder()
        {
            title();
            Console.Write("Enter the ID of the Order to update: ");
            int id = int.Parse(Console.ReadLine());

            Order orderToUpdate = null;
            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    orderToUpdate = order;
                    break;
                }
            }

            if (orderToUpdate != null)
            {
                Console.Write("Enter updated Quantity: ");
                orderToUpdate.Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine($"Order with ID {id} has been updated successfully.");
                SaveDataToFile();
            }
            else
            {
                Console.WriteLine($"Order with ID {id} not found.");
            }
        }

        static void DeleteOrder()
        {
            title();
            Console.Write("Enter the ID of the Order to delete: ");
            int id = int.Parse(Console.ReadLine());

            Order orderToDelete = null;
            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    orderToDelete = order;
                    break;
                }
            }

            if (orderToDelete != null)
            {
                orders.Remove(orderToDelete);
                Console.WriteLine($"Order with ID {id} has been deleted successfully.");
                SaveDataToFile();
            }
            else
            {
                Console.WriteLine($"Order with ID {id} not found.");
            }
        }


        static void SaveDataToFile()
        {
            using (StreamWriter userWriter = new StreamWriter("users.txt"))
            using (StreamWriter clothesWriter = new StreamWriter("clothes.txt"))
            using (StreamWriter ordersWriter = new StreamWriter("orders.txt"))
            {
                foreach (var user in users)
                {
                    userWriter.WriteLine($"{user.Username},{user.Password},{user.Role}");
                }

                foreach (var clothes in clothesList)
                {
                    clothesWriter.WriteLine($"{clothes.Id},{clothes.Name},{clothes.Price}");
                }

                foreach (var order in orders)
                {
                    ordersWriter.WriteLine($"{order.Id},{order.CustomerName},{order.ClothesId},{order.Quantity}");
                }
            }
        }
        static void LoadUsers()
        {
            if (File.Exists("users.txt"))
            {
                string[] lines = File.ReadAllLines("users.txt");

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    string username = parts[0];
                    string password = parts[1];
                    string role = parts[2];

                    User user = new User(username, password, role);
                    users.Add(user);
                }
            }
        }

        static void LoadClothes()
        {
            if (File.Exists("clothes.txt"))
            {
                string[] lines = File.ReadAllLines("clothes.txt");

                for (int i = users.Count; i < lines.Length - orders.Count; i++)
                {
                    string[] parts = lines[i].Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    double price = double.Parse(parts[2]);

                    Clothes clothes = new Clothes(id, name, price);
                    clothesList.Add(clothes);
                }
            }
        }

        static void LoadOrders()
        {
            if (File.Exists("orders.txt"))
            {
                string[] lines = File.ReadAllLines("orders.txt");

                for (int i = users.Count + clothesList.Count; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    int id = int.Parse(parts[0]);
                    string customerName = parts[1];
                    int clothesId = int.Parse(parts[2]);
                    int quantity = int.Parse(parts[3]);

                    Order order = new Order(id, customerName, clothesId, quantity);
                    orders.Add(order);
                }
            }
        }

        static void DisplayClothesInfo(Clothes clothes)
        {
            Console.WriteLine($"ID: {clothes.Id}");
            Console.WriteLine($"Name: {clothes.Name}");
            Console.WriteLine($"Price: {clothes.Price:C}");
            Console.WriteLine();
        }

        static void DisplayOrderInfo(Order order)
        {
            Console.WriteLine($"ID: {order.Id}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"Clothes ID: {order.ClothesId}");
            Console.WriteLine($"Quantity: {order.Quantity}");
            Console.WriteLine();
        }


        static User GetUserByUsernameAndPassword(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}