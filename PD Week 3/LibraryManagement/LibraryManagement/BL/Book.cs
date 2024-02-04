using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class Book
    {
        public Book()
        {
        }

        public Book(Book book)
        {
            title=book.title;
            author=book.author;
            publicationYear = book.publicationYear;
            price = book.price;
            quantityStock = book.quantityStock;
        }

        public string title;
        public string author;
        public string publicationYear;
        public double price;
        public double quantityStock;

        public string getTitle()
        {
            return "Title: "+ title;
        }

        public string getAuthor()
        {
            return "Author: "+ author;
        }

        public string getPublicationYear()
        {
            return "Publication Year: "+ publicationYear;
        }

        public string getPrice()
        {
            return "Price: "+ price;
        }

        public double sellCopies(int numberOfCopies)
        {
            if(numberOfCopies > quantityStock)
            {
                Console.WriteLine("Not enough copies in stock");
                return 0;
            }
            else
            {
                quantityStock -= numberOfCopies;
                return numberOfCopies * price;
            }
        }

        public void addCopies(int numberOfCopies)
        {
            quantityStock += numberOfCopies;            
        }

        public void bookDetails()
        {
            Console.WriteLine(getTitle());
            Console.WriteLine(getAuthor());
            Console.WriteLine(getPublicationYear());
            Console.WriteLine(getPrice());
            Console.WriteLine("Quantity in stock: "+ quantityStock);
        }
    }
}
