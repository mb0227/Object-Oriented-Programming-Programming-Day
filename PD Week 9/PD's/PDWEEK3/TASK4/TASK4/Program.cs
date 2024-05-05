using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK4.BL;

namespace TASK4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            int option = 0;
            while (option != 7)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO THE BOOKS MENU");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All the Books information");
                Console.WriteLine("3. Get the Author details of a specific book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the count of the Books present in your bookList");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Publication Year: ");
                    int publicationYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter Quantity in Stock: ");
                    int quantityInStock = int.Parse(Console.ReadLine());
                    bookList.Add(new Book(title, author, publicationYear, price, quantityInStock));
                    Console.WriteLine("Book added successfully.");
                }
                else if (option == 2)
                {
                    Console.WriteLine("All Books Information:");
                    int i = 0;
                    while (i <= bookList.Count)
                    {
                        Console.WriteLine(bookList[i].BookDetails());
                        i++;
                    }
                }
                else if (option == 3)
                {
                    Console.Write("Enter Title of the book: ");
                    string bookTitle = Console.ReadLine();
                    Book selectedBook = null;
                    int i = 0;
                    while (i < bookList.Count)
                    {
                        if (bookList[i].Title == bookTitle)
                        {
                            selectedBook = bookList[i];
                            break;
                        }
                        i++;
                    }
                    if (selectedBook != null)
                    {
                        Console.WriteLine(selectedBook.GetAuthor());
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter Title of the book: ");
                    string sellTitle = Console.ReadLine();
                    Book selectedBook = null;
                    int i = 0;
                    while (i < bookList.Count)
                    {
                        if (bookList[i].Title == sellTitle)
                        {
                            selectedBook = bookList[i];
                            break;
                        }
                        i++;
                    }
                    if (selectedBook != null)
                    {
                        Console.Write("Enter number of copies to sell: ");
                        int sellCopies = int.Parse(Console.ReadLine());
                        selectedBook.SellCopies(sellCopies);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (option == 5)
                {
                    Console.Write("Enter Title of the book: ");
                    string restockTitle = Console.ReadLine();
                    Book selectedBook = null;
                    int i = 0;
                    while (i < bookList.Count)
                    {
                        if (bookList[i].Title == restockTitle)
                        {
                            selectedBook = bookList[i];
                            break;
                        }
                        i++;
                    }
                    if (selectedBook != null)
                    {
                        Console.Write("Enter number of copies to restock: ");
                        int restockCopies = int.Parse(Console.ReadLine());
                        selectedBook.Restock(restockCopies);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (option == 6)
                {
                    Console.WriteLine($"Count of Books in bookList: {bookList.Count}");
                }
                else if (option == 7)
                {
                    Console.WriteLine("Exiting...");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
