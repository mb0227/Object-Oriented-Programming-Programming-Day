using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Admin admin = new Admin();
            Product product = new Product();
            while(true)
            {
                Console.Clear();
                string option = ConsoleUtility.MainMenu();
                Console.Clear();

                if(option =="1")
                {
                    Console.WriteLine("Sign up as Admin or Customer");
                    string type = Console.ReadLine();

                    if(type == "customer") {
                        customer = CustomerUI.TakeCustomerInput();
                        CustomerCRUD.AddCustomer(customer);
                    }
                    else if(type == "admin") {
                        admin = AdminUI.TakeAdminInput();
                        AdminCRUD.AddAdmin(admin);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(option =="2")
                {
                    Console.WriteLine("Sign in as Admin or Customer");
                    string type = Console.ReadLine();

                    if (type == "customer")
                    {
                        customer = CustomerUI.TakeCustomerInput();
                        if (CustomerCRUD.CustomerExists(customer))
                        {
                            while (true)
                            {
                                Console.Clear();
                                option = ConsoleUtility.CustomerMenu();
                                Console.Clear();
                                if (option == "1")
                                {
                                    ProductUI.ShowProducts();
                                }
                                else if (option == "2")
                                {
                                    product = ProductUI.TakeProductInput();
                                    ProductCRUD.BuyProduct(product);
                                }
                                else if (option == "3")
                                {
                                    product = ProductUI.TakeProductInput();
                                    Console.WriteLine(ProductCRUD.GenerateInvoice(product));
                                }
                                else if (option == "4")
                                {
                                    CustomerUI.DisplayData(customer);
                                }
                                else if (option == "5")
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else if (type == "admin")
                    {
                        Console.Clear();
                        admin = AdminUI.TakeAdminInput();
                        Console.Clear();
                        if (AdminCRUD.AdminExists(admin))
                        {
                            while (true)
                            {
                                option = ConsoleUtility.AdminMenu();
                                if (option == "1")
                                {
                                    product = ProductUI.TakeProductInput();
                                    ProductCRUD.AddProduct(product);
                                }
                                else if (option == "2")
                                {
                                    ProductUI.ShowProducts();
                                }
                                else if (option == "3")
                                {
                                    product = ProductCRUD.HigestPrice();
                                    Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Stock: {product.Stock}");
                                    Console.ReadKey();
                                }
                                else if (option == "4")
                                {
                                    Console.WriteLine(ProductCRUD.ReturnTax());
                                }
                                else if (option == "5")
                                {
                                    ProductUI.ShowProducts();
                                }
                                else if (option == "6")
                                {
                                    AdminUI.DisplayData(admin);
                                }
                                else if (option == "7")
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
