using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK4.BL
{
    internal class Book
    {
        public string Title;
        public string Author;
        public int PublicationYear;
        public double Price;
        public int QuantityInStock;
        public Book(string title, string author, int publicationYear, double price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public string GetTitle()
        {
            return $"Title: {Title}";
        }
        public string GetAuthor()
        {
            return $"Author: {Author}";
        }

        public string GetPublicationYear()
        {
            return $"Publication Year: {PublicationYear}";
        }

        public string GetPrice()
        {
            return $"Price: {Price:C2}";
        }

        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies <= QuantityInStock)
            {
                QuantityInStock -= numberOfCopies;
                Console.WriteLine($"Sold {numberOfCopies} copies of '{Title}'.");
            }
            else
            {
                Console.WriteLine($"Error: Not enough copies of '{Title}' in stock.");
            }
        }

        public void Restock(int additionalCopies)
        {
            QuantityInStock += additionalCopies;
            Console.WriteLine($"Restocked {additionalCopies} copies of '{Title}'.");
        }

        public string BookDetails()
        {
            return $"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, Price: {Price}, Quantity in Stock: {QuantityInStock}";
        }
    }
}
