using System;
using System.IO;
using System.Linq;
using System.Net;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option, username, password, role;
            int totalUsers = 0, maxUsers = 100, currentItems = 0, maxItems = 50, totalSuggestions = 0, maxSuggestions = 100;
            string[] usernames = new string[maxUsers];
            string[] passwords = new string[maxUsers];
            string[] genders = new string[maxUsers];
            string[] ages = new string[maxUsers];
            string[] phoneNumbers = new string[maxUsers];
            string[] roles = new string[maxUsers];
            string[] ids = new string[maxUsers];
            string[] foodMenu = new string[maxItems];
            string[] suggestions = new string[maxSuggestions];
            int[] foodMenuPrices = new int[maxItems];
            readData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, ref totalUsers);
            DeleteRowsWithOnlyCommas("A:\\University Related\\UET Lahore\\2nd Semester\\Programming Day\\PD Week 1\\AppWeek1\\Credentials.txt");
            while (true)
            {
                Console.Write("Do you want to Sign In (1) or Sign Up (2)?: ");
                option = Console.ReadLine();
                if (option == "1")
                {
                    while (true)
                    {
                        Console.Write("Enter Username: ");
                        username = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();

                        Console.Write("Enter Role: ");
                        role = Console.ReadLine();
                        role = role.ToLower();

                        if (SignIn(username, password, role, usernames, passwords, roles, totalUsers))
                        {
                            Console.WriteLine(role + " Login Successfull.");
                            Console.WriteLine("Welcome {0}", username);
                            if (role == "customer")
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.CursorVisible = false;
                                    option = customerMenu();
                                    Console.CursorVisible = true;
                                    if (option == "1")
                                    {
                                        Console.Clear();
                                        orderFood(foodMenu, foodMenuPrices, currentItems);
                                    }
                                    else if (option == "2")
                                    {
                                        Console.Clear();
                                        takeSuggestion(suggestions, ref totalSuggestions, ref maxSuggestions);
                                    }
                                    else if (option == "3")
                                    {
                                        Console.Clear();
                                        if (changeUsername(usernames, username, ref totalUsers))
                                            writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
                                    }
                                    else if (option == "4")
                                    {
                                        Console.Clear();
                                        if (changePassword(usernames, passwords, username, ref totalUsers))
                                            writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
                                    }
                                    else if (option == "5")
                                    {
                                        Console.Clear();
                                        if (deleteUser(ids, usernames, passwords, ages, genders, phoneNumbers, roles, ref totalUsers, username))
                                            writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
                                    }
                                    else if (option == "6")
                                    {
                                        Console.Clear();
                                        if (LogOut())
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else if (option == "7")
                                    {
                                        Console.Clear();
                                        Environment.Exit(0);
                                    }

                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.CursorVisible = false;
                                    option = adminMenu();
                                    Console.CursorVisible = true;
                                    if (option == "1")
                                    {
                                        Console.Clear();
                                        viewUsersData(ids, usernames, passwords, ages, genders, phoneNumbers, roles, ref totalUsers);
                                    }
                                    else if (option == "2")
                                    {
                                        Console.Clear();
                                        viewSuggestions(suggestions, ref totalSuggestions);
                                    }
                                    else if (option == "3")
                                    {
                                        Console.Clear();
                                        manageShopMenu(foodMenu, foodMenuPrices, ref currentItems, ref maxItems);
                                    }
                                    else if (option == "4")
                                    {
                                        Console.Clear();
                                        if (changeUsername(usernames, username, ref totalUsers))
                                            writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
                                    }
                                    else if (option == "5")
                                    {
                                        Console.Clear();
                                        if (changePassword(usernames, passwords, username, ref totalUsers))
                                            writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
                                    }
                                    else if (option == "6")
                                    {
                                        Console.Clear();
                                        if (LogOut())
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else if (option == "7")
                                    {
                                        Console.Clear();
                                        Environment.Exit(0);
                                    }
                                }
                            }
                        }
                        else
                        {
                            cls();
                            continue;
                        }
                    }
                }
                else if (option == "2")
                {
                    SignUpInput(usernames, passwords, phoneNumbers, ages, genders, roles, ids, ref totalUsers, maxUsers);
                }
                else
                {
                    Console.WriteLine("Wrong Input. Enter 1 or 2.");
                    cls();
                }
            }
        }

        static bool SignIn(string username, string password, string role, string[] usernames, string[] passwords, string[] roles, int totalUsers)
        {
            for (int i = 0; i < totalUsers; i++)
            {
                if (username == usernames[i] && password == passwords[i] && role == roles[i])
                {
                    return true;
                }
            }
            return false;
        }

        static void SignUpInput(string[] usernames, string[] passwords, string[] phoneNumbers, string[] ages, string[] genders, string[] roles, string[] ids, ref int totalUsers, int maxUsers)
        {
            bool signUpSuccess = false;
            if (totalUsers < maxUsers)
            {
                string username, password, phoneNumber, age, gender, role;
                int id;

                username = getUsername(usernames, ref totalUsers);
                password = getPassword();
                phoneNumber = getPhoneNumber();
                age = getAge();
                gender = getGender();
                role = getRole();
                id = totalUsers + 1;

                usernames[totalUsers] = username;
                passwords[totalUsers] = password;
                phoneNumbers[totalUsers] = phoneNumber;
                ages[totalUsers] = age;
                genders[totalUsers] = gender;
                roles[totalUsers] = role;
                ids[totalUsers] = id.ToString();
                totalUsers++;
                signUpSuccess = true;
            }
            else
            {
                Console.WriteLine("Maximum Users Reached.");
                cls();
            }
            if (signUpSuccess)
            {
                writeData(usernames, passwords, phoneNumbers, genders, ages, roles, ids, totalUsers);
            }
        }


        static string getUsername(string[] usernames, ref int totalUsers)
        {
            string username;
            while (true)
            {
                Console.Write("Enter Username: ");
                username = Console.ReadLine();
                if (username.Length > 12 || empty(ref username) || hasTabs(ref username) || !noComma(ref username) || !isUniqueUser(usernames, totalUsers, ref username))
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return username;
        }

        static string getPassword()
        {
            string password, checkPassword;
            while (true)
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                if (validPassword(ref password))
                {
                    Console.Write("Enter Password Again: ");
                    checkPassword = Console.ReadLine();

                    if (passwordsMatched(ref password, ref checkPassword))
                    {
                        return password;
                    }
                    else
                    {
                        Console.WriteLine("Passwords Do not Match");
                        cls();
                        continue;
                    }
                }
                else
                {
                    cls();
                    continue;
                }
            }

        }

        static string getPhoneNumber()
        {
            string phoneNumber;
            while (true)
            {
                Console.Write("Enter Phone Number: +92 3");
                phoneNumber = Console.ReadLine();
                if (!validPhoneNumber(ref phoneNumber))
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return phoneNumber;
        }

        static string getAge()
        {
            string age;
            while (true)
            {
                Console.Write("Enter Age: ");
                age = Console.ReadLine();
                if (!validAge(ref age))
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return age;
        }

        static string getGender()
        {
            string gender;
            while (true)
            {
                Console.Write("Enter Gender: ");
                gender = Console.ReadLine();
                if (gender != "M" && gender != "m" && gender != "f" && gender != "F")
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return gender;
        }

        static string getRole()
        {
            string role;
            while (true)
            {
                Console.Write("Enter Role (Customer or Admin): ");
                role = Console.ReadLine();
                role = role.ToLower();
                if (role != "customer" && role != "admin")
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }
            return role;
        }

        //validations
        static bool passwordsMatched(ref string password, ref string checkPassword)
        {
            if (password == checkPassword)
                return true;
            return false;
        }



        static bool validAge(ref string age)
        {
            if (age == "0" || age.Length == 0 || age.Length > 2)
            {
                return false;
            }

            foreach (char c in age)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool validPhoneNumber(ref string phoneNumber)
        {
            if (phoneNumber.Length == 9 && phoneNumber.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        static bool validPassword(ref string password)
        {
            int characters = 0, capitalCharacters = 0, specialCharacters = 0, numbers = 0;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    numbers++;
                }
                else if (char.IsUpper(c))
                {
                    capitalCharacters++;
                }
                else if (char.IsLower(c))
                {
                    characters++;
                }
                else if (char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    specialCharacters++;
                }
            }

            if (characters >= 0 &&
                   numbers >= 1 &&
                   specialCharacters >= 1 &&
                   capitalCharacters >= 1 &&
                   !password.Contains(' ') &&
                   !password.Contains(',') &&
                   password.Length <= 12 &&
                   password.Length != 0)
                return true;
            return false;
        }

        static bool empty(ref string check)
        {
            if (check == "" || check == " " || check == "  " || check == "   " || check == "    " || check == "     " || check == "      " ||
                check == "       " || check == "        " || check == "         " || check == "          " || check == "          " || check == "          " || check == "          " || check == "           " || check == "            " || check == "             " || check == "                   ")
            {
                return true;
            }
            return false;
        }
        static bool hasTabs(ref string input)
        {
            // Check if the input string contains tabs ('\t')
            if (input.Contains('\t'))
            {
                return true; // Found a tab
            }
            return false; // No tabs found
        }

        static bool noComma(ref string newUser)
        {
            for (int i = 0; i < newUser.Length; i++)
            {
                if (newUser[i] == ',')
                {
                    return false;
                }
            }
            return true;
        }

        static bool isUniqueUser(string[] usernames, int totalUsers, ref string newUser)
        {
            for (int i = 0; i < totalUsers; ++i)
            {
                if (usernames[i] == newUser)
                {
                    return false;
                }
            }
            return true;
        }

        static void cls()
        {
            Console.WriteLine("Wrong Input. Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void readData(string[] usernames, string[] passwords, string[] phoneNumbers, string[] genders, string[] ages, string[] roles, string[] ids, ref int totalUsers)
        {
            string record;
            string path = "A:\\University Related\\UET Lahore\\2nd Semester\\Programming Day\\PD Week 1\\AppWeek1\\Credentials.txt";
            StreamReader data = new StreamReader(path);
            if (File.Exists(path))
            {
                while ((record = data.ReadLine()) != null)
                {
                    // assgin the data according to their respective arrays
                    ids[totalUsers] = getField(record, 1);
                    usernames[totalUsers] = getField(record, 2);
                    passwords[totalUsers] = getField(record, 3);
                    phoneNumbers[totalUsers] = getField(record, 4);
                    genders[totalUsers] = getField(record, 5);
                    ages[totalUsers] = getField(record, 6);
                    roles[totalUsers] = getField(record, 7);
                    totalUsers++;
                }
                data.Close();
            }
            else
            {
                Console.WriteLine("Wrong Path");
            }
        }

        static string getField(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        // Function for updating data in file from parallel arrays
        static void writeData(string[] usernames, string[] passwords, string[] phoneNumbers, string[] genders, string[] ages, string[] roles, string[] ids, int totalUsers)
        {
            string path = "A:\\University Related\\UET Lahore\\2nd Semester\\Programming Day\\PD Week 1\\AppWeek1\\Credentials.txt";
            StreamWriter data = new StreamWriter(path);
            for (int i = 0; i < totalUsers; i++)
            {
                data.WriteLine((ids[i]) + "," + usernames[i] + "," + passwords[i] + "," + phoneNumbers[i] + "," + genders[i] + ","
                    + ages[i] + "," + roles[i] + "\n");
            }
            data.Flush();
            data.Close();
        }

        static string customerMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\tOrder Food");
            Console.WriteLine("\t\t\t\t\t\tGive Feedback");
            Console.WriteLine("\t\t\t\t\t\tChange Userame");
            Console.WriteLine("\t\t\t\t\t\tChange Password");
            Console.WriteLine("\t\t\t\t\t\tDelete Account");
            Console.WriteLine("\t\t\t\t\t\tLog Out");
            Console.WriteLine("\t\t\t\t\t\tExit");
            int option = movementOfArrow(45, 7, 1, 7);
            return option.ToString();
        }

        static string adminMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\tView Users Data");
            Console.WriteLine("\t\t\t\t\t\tView Feedback");
            Console.WriteLine("\t\t\t\t\t\tUpdate Menu");
            Console.WriteLine("\t\t\t\t\t\tChange Userame");
            Console.WriteLine("\t\t\t\t\t\tChange Password");
            Console.WriteLine("\t\t\t\t\t\tLog Out");
            Console.WriteLine("\t\t\t\t\t\tExit");
            int option = movementOfArrow(45, 7, 1, 7);
            return option.ToString();
        }

        static int movementOfArrow(int x, int y, int minOption, int maxOption)
        {
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write("->");

                key = Console.ReadKey(true);

                Console.SetCursorPosition(x, y);
                Console.Write("  ");

                if (key.Key == ConsoleKey.UpArrow && minOption > 1)
                {
                    minOption--;
                    y--;
                }
                else if (key.Key == ConsoleKey.DownArrow && minOption < maxOption)
                {
                    minOption++;
                    y++;
                }
                Console.SetCursorPosition(x, y);
                Console.Write("->");
            } while (key.Key != ConsoleKey.Enter);
            return minOption;
        }

        static void viewUsersData(string[] ids, string[] usernames, string[] passwords, string[] roles, string[] phoneNumbers, string[] genders, string[] ages, ref int totalUsers)
        {
            Console.WriteLine("\t\t\t\t\t\tUsers Data:");

            for (int i = 0; i < totalUsers; i++)
            {
                Console.WriteLine("\t\t\t\t\t\t" + ids[i] + ". Username: " + usernames[i] +
                                  "\n\t\t\t\t\t\t   Password: " + passwords[i] +
                                  "\n\t\t\t\t\t\t   Roles: " + roles[i] +
                                  "\n\t\t\t\t\t\t   Phone Number: " + phoneNumbers[i] +
                                  "\n\t\t\t\t\t\t   Gender: " + genders[i] +
                                  "\n\t\t\t\t\t\t   Age: " + ages[i]);

            }
            Console.Read();
            Console.Clear();
        }

        static void viewSuggestions(string[] suggestions, ref int totalSuggestions)
        {
            Console.WriteLine("\t\t\t\t\t\tSuggestions:");

            for (int i = 0; i < totalSuggestions; ++i)
            {
                Console.WriteLine("\t\t\t\t\t\t" + (i + 1) + ". " + suggestions[i]);
            }

            Console.Read();
            Console.Clear();
        }

        static void manageShopMenu(string[] foodMenuShop, int[] foodMenuPricesShop, ref int totalShopItems, ref int maxItems)
        {
            bool isUpdated = false;

            Console.WriteLine("\t\t\t\t\t\tMENU LIST ");

            for (int i = 0; i < totalShopItems; i++)
            {
                Console.WriteLine($"\t\t\t\t\t\t{i + 1}. {foodMenuShop[i]}");
            }

            while (true)
            {
                string action = "";
                Console.Write("\t\t\t\t\t\tDo you want to add (a) or remove (r) an item? ");
                action = Console.ReadLine();
                action = action.ToLower();

                if (action == "a")
                {
                    addShopMenu(foodMenuShop, foodMenuPricesShop, ref totalShopItems, ref maxItems);
                    isUpdated = true;
                    break;
                }
                else if (action == "r")
                {
                    removeShopMenu(foodMenuShop, foodMenuPricesShop, ref totalShopItems);
                    isUpdated = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\t\tInvalid action. Enter either 'a' or 'r'.");
                    Console.Clear();
                    continue;
                }
            }

            if (isUpdated)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tUpdated Shop List: ");

                for (int i = 0; i < totalShopItems; i++)
                {
                    Console.WriteLine($"\t\t\t\t\t\t{i + 1}. {foodMenuShop[i]}");
                }

                Console.Clear();
            }
        }

        static void addShopMenu(string[] foodMenuShop, int[] foodMenuPricesShop, ref int totalShopItems, ref int maxItems)
        {
            if (totalShopItems < maxItems)
            {
                string newItem = "";
                string newItemPrice = "";
                for (int i = 0; i < totalShopItems; i++)
                {
                    Console.WriteLine($"\t\t\t\t\t\t{i + 1}). {foodMenuShop[i],-23} | {foodMenuPricesShop[i],5} Rupees");
                }
                while (true)
                {
                    Console.Write("\t\t\t\t\t\tEnter the name of the new item to add: ");
                    newItem = Console.ReadLine();
                    newItem = newItem.ToLower();

                    if (newItem.Length == 0 || newItem.Contains('\t') || newItem.Contains(','))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.Write("\t\t\t\t\t\tEnter the price of the new item to add: ");
                    newItemPrice = Console.ReadLine();

                    if (!isNumeric(ref newItemPrice))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                foodMenuShop[totalShopItems] = newItem;
                foodMenuPricesShop[totalShopItems] = int.Parse(newItemPrice);
                totalShopItems++;

                Console.WriteLine("\t\t\t\t\t\tItem added successfully!");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\tMaximum items limit reached. Cannot add more items.");
                Console.Clear();
                Console.Read();
                return;
            }
        }

        static void removeShopMenu(string[] foodMenuShop, int[] foodMenuPricesShop, ref int totalShopItems)
        {
            bool found = false;
            string index;
            for (int i = 0; i < totalShopItems; i++)
            {
                Console.WriteLine($"\t\t\t\t\t\t{i + 1}). {foodMenuShop[i],-23} | {foodMenuPricesShop[i],5} Rupees");
            }

            while (true)
            {
                Console.Write("\t\t\t\t\t\tEnter the number of the item to remove: ");
                index = Console.ReadLine();
                for (int i = 1; i <= totalShopItems; i++)
                {
                    if (index == i.ToString())
                    {
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    break;
                }
            }

            for (int i = int.Parse(index) - 1; i < totalShopItems - 1; i++)
            {
                foodMenuShop[i] = foodMenuShop[i + 1];
                foodMenuPricesShop[i] = foodMenuPricesShop[i + 1];
            }
            totalShopItems--;

            Console.WriteLine("\t\t\t\t\t\tItem removed successfully!");
            Console.Clear();
        }

        static bool changePassword(string[] usernames, string[] passwords, string username, ref int totalUsers)
        {
            Console.Clear();
            string newPassword = "", checkNewPassword = "";
            while (true)
            {
                Console.Write("\t\t\t\t\t\tEnter a new password: ");
                newPassword = Console.ReadLine();


                if (!validPassword(ref newPassword))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t\tPassword is invalid. Please try again.");
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }

            Console.Write("\t\t\t\t\t\tEnter the new password again: ");
            checkNewPassword = Console.ReadLine();

            if (newPassword != checkNewPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t\tPasswords do not match. Please try again.");
                Console.Clear();
                changePassword(usernames, passwords, username, ref totalUsers);
            }

            for (int i = 0; i < totalUsers; ++i)
            {
                if (usernames[i] == username)
                {
                    passwords[i] = newPassword;
                    Console.WriteLine($"\t\t\t\t\t\tPassword changed successfully for user: {username}");
                    Console.Read();
                    Console.Clear();
                    return true;
                }
            }
            return false;
        }

        static bool changeUsername(string[] usernames, string username, ref int totalUsers)
        {
            Console.Clear();
            string newUsername = "";

            while (true)
            {
                Console.Write("Enter Username: ");
                newUsername = Console.ReadLine();
                if (newUsername.Length > 12 || empty(ref newUsername) || hasTabs(ref newUsername) || !noComma(ref newUsername) || !isUniqueUser(usernames, totalUsers, ref newUsername))
                {
                    cls();
                    continue;
                }
                else
                {
                    break;
                }
            }


            for (int i = 0; i < totalUsers; ++i)
            {
                if (usernames[i] == username)
                {
                    usernames[i] = newUsername;
                    Console.WriteLine($"\t\t\t\t\t\tUsername changed successfully for user from {username} to {newUsername}");
                    Console.Read();
                    Console.Clear();
                    return true;
                }
            }
            return false;
        }

        static void orderFood(string[] foodMenuShop, int[] foodMenuPricesShop, int totalShopItems)
        {
            int totalOrderPrice = 0;
            bool found = false;
            Console.WriteLine("\t\t\t\t\t\tMENU LIST ");
            if (totalShopItems == 0)
            {
                Console.WriteLine("\t\t\t\t\t\tNothing To Order Right now");
            }
            for (int i = 0; i < totalShopItems; i++)
            {
                Console.WriteLine($"\t\t\t\t\t\t{i + 1}. {foodMenuShop[i],-23} | {foodMenuPricesShop[i],5} Rupees");
            }

            while (true)
            {
                Console.Write("\t\t\t\tEnter the item number you want to add to your order (or 'done' to finish ordering): ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "done")
                {
                    break;
                }

                for (int i = 1; i <= totalShopItems; i++)
                {
                    if (userInput == i.ToString())
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    totalOrderPrice += foodMenuPricesShop[int.Parse(userInput) - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\t\tInvalid item number. Please try again.");
                    continue;
                }
            }

            Console.WriteLine("\t\t\t\t\t\t---------------------------");
            Console.WriteLine($"\t\t\t\t\t\tTotal Price: {totalOrderPrice} Rupees");
            Console.Read();
            Console.Clear();
        }

        static bool deleteUser(string[] ids, string[] usernames, string[] passwords, string[] ages, string[] genders, string[] phoneNumbers, string[] roles, ref int totalUsers, string currentUser)
        {
            // initialize as -1
            int index = -1;

            for (int i = 0; i < totalUsers; ++i)
            {
                // finding index
                if (usernames[i] == currentUser)
                {
                    index = i;
                    break;
                }
            }

            // to delete user
            if (index != -1)
            {
                // delete all info related to user
                for (int i = index; i < totalUsers - 1; ++i)
                {
                    usernames[i] = usernames[i + 1];
                    passwords[i] = passwords[i + 1];
                    ages[i] = ages[i + 1];
                    phoneNumbers[i] = phoneNumbers[i + 1];
                    genders[i] = genders[i + 1];
                    roles[i] = roles[i + 1];
                    ids[i] = ids[i + 1];
                }

                totalUsers--;
                Console.WriteLine("\t\t\t\t\t\tUser " + currentUser + " removed successfully!");
                Console.Read();
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\tUser not found or unable to delete account.");
            }
            return false;
        }

        static void takeSuggestion(string[] suggestions, ref int totalSuggestions, ref int maxSuggestions)
        {
            Console.Write("\t\t\t\t\t\tEnter a suggestion: ");
            string userInput = Console.ReadLine();

            if (userInput.Length == 0 || userInput.Contains('\t'))
            {
                return;
            }
            if (totalSuggestions < maxSuggestions)
            {
                suggestions[totalSuggestions++] = userInput;
                Console.WriteLine("\t\t\t\t\t\tThank you for your suggestion! We will do our best to accommodate this suggestion.");
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\tMaximum limit reached for suggestions. Unable to submit more.");
                return;
            }
        }

        static bool LogOut()
        {
            Console.WriteLine("\t\t\t\t\t\tDo you want to Log Out (Yes or No)?");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (input == "yes")
            {
                return true;
            }
            return false;
        }
        static bool isNumeric(ref string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static void DeleteRowsWithOnlyCommas(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            StreamWriter writer = new StreamWriter(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!IsOnlyCommas(lines[i]))
                {
                    writer.WriteLine(lines[i]);
                }
            }

        }

        static bool IsOnlyCommas(string line)
        {
            // Check if the line contains only commas
            return line.Trim() == ",";
        }
    }
}
