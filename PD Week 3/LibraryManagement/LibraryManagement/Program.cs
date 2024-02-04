using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Book book = null;
            while (true)
            {
                Console.Clear();
                string option = menu();
                Console.Clear();
                if (option=="1")
                {
                    book = new Book();
                    Console.Write("Enter the title of the book: ");
                    book.title = Console.ReadLine();
                    Console.Write("Enter the author of the book: ");
                    book.author = Console.ReadLine();
                    Console.Write("Enter the publication year of the book: ");
                    book.publicationYear = Console.ReadLine();
                    Console.Write("Enter the price of the book: ");
                    book.price = double.Parse(Console.ReadLine());
                    Console.Write("Enter the quantity of the book: ");
                    book.quantityStock = double.Parse(Console.ReadLine());
                    Book book1 = new Book(book);
                    books.Add(book1);
                }
                else if(option=="2")
                {
                    viewBooks(books);
                    Console.ReadKey();  
                }
                if(option=="3"||option=="4"||option=="5")
                {
                    book = new Book();
                    Console.Write("Enter the title of the book: ");
                    string title = Console.ReadLine();
                    book = searchByTitle(books, title);
                    if (book != null)
                    {
                        if (option == "3")
                        {
                            Console.WriteLine(book.getAuthor());
                            Console.ReadKey();
                        }
                        else if (option == "4")
                        {
                            Console.Write("Enter the number of copies to sell: ");
                            int numberOfCopies = int.Parse(Console.ReadLine());
                            double total = book.sellCopies(numberOfCopies);
                            if (total > 0)
                            {
                                Console.WriteLine($"Total Price: {total}");
                                Console.ReadKey();
                            }
                        }
                        else if (option == "5")
                        {
                            Console.Write("Enter the number of copies to add: ");
                            int numberOfCopies = int.Parse(Console.ReadLine());
                            book.addCopies(numberOfCopies);
                        }
                    }
                }
                else if (option == "6")
                {
                    Console.WriteLine("Total Books: " + books.Count);
                    Console.ReadKey();
                }
                else if(option=="7")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
        }

        static string menu()
        {
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. View books info");
            Console.WriteLine("3. Get author details of a specific book");
            Console.WriteLine("4. Sell copies of a specific book");
            Console.WriteLine("5. Restock a specific book");
            Console.WriteLine("6. Total Books");
            Console.WriteLine("7. Exit");
            Console.Write("Enter an option: ");
            string option = Console.ReadLine();
            return option;
        }

        static void viewBooks(List<Book> books)
        {
            for (int i=0;i<books.Count;i++)
            {
                books[i].bookDetails();
            }
        }

        static Book searchByTitle(List<Book> books, string title)
        {
            foreach (Book book in books)
            {
                if (book.title == title)
                {
                    return book;
                }
            }
           return null;
        }
    }
}
