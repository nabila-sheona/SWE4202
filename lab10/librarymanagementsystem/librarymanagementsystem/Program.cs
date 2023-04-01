using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static librarymanagementsystem.Book;

using static librarymanagementsystem.Program.Book;
using static librarymanagementsystem.Program;
//using static librarymanagementsystem.Program.Book;
//using librarymanagementsystem.librarymanagementsystem;

namespace librarymanagementsystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Library Management System");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Add new item");
                Console.WriteLine("2. Remove an item");
                Console.WriteLine("3. Search for an item");
                Console.WriteLine("4. Borrow an item");
                Console.WriteLine("5. Return an item");
                Console.WriteLine("6. Display all available items");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\nEnter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter item details:");

                        Console.Write("ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Category (book, dvd, or cd): ");
                        string category = Console.ReadLine();

                        Console.WriteLine();

                        if (category == "book")
                        {
                            Console.Write("ISBN: ");
                            string isbn = Console.ReadLine();

                            Console.Write("Number of pages: ");
                            int numPages = int.Parse(Console.ReadLine());

                            Book book = new Book(id, title, author, category, isbn, numPages);
                            library.addItem(book);
                        }
                        else if (category == "dvd")
                        {
                            Console.Write("Director: ");
                            string director = Console.ReadLine();

                            Console.Write("Length (in minutes): ");
                            int length = int.Parse(Console.ReadLine());

                            DVD dvd = new DVD(id, title, author, category, director, length);
                            library.addItem(dvd);
                        }
                        else if (category == "cd")
                        {
                            Console.Write("Artist: ");
                            string Artist = Console.ReadLine();

                            Console.Write("Number of tracks: ");
                            int NumTracks = int.Parse(Console.ReadLine());

                            CD cd = new CD(id, title, author, category, Artist, NumTracks);

                            library.addItem(cd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid category!");
                        }

                        break;
                    case 2:
                        Console.Write("\nEnter ID of item to remove: ");
                        string idToRemove = Console.ReadLine();

                        try
                        {
                            Item itemToRemove = library.findItemById(idToRemove);
                            library.removeItem(itemToRemove);
                            Console.WriteLine("Item removed successfully!");
                        }
                        catch (LibraryException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.Write("\nEnter search query: ");
                        string query = Console.ReadLine();

                        try
                        {
                            var SearchResults = library.searchItems(query);
                            Console.WriteLine("\nSearch results:");

                            foreach (Item item in SearchResults)
                            {
                                item.displayDetails();
                            }
                        }
                        catch (LibraryException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 4:
                        Console.Write("\nEnter ID of item to borrow: ");
                        string idToBorrow = Console.ReadLine();

                        try
                        {
                            library.borrowItem(idToBorrow);
                            Console.WriteLine("Item borrowed successfully!");
                        }
                        catch (LibraryException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 5:
                        Console.Write("\nEnter ID of item to return: ");
                        string idToReturn = Console.ReadLine();

                        try
                        {
                            library.returnItem(idToReturn);
                            Console.WriteLine("Item returned successfully!");
                        }
                        catch (LibraryException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 6:
                        Console.WriteLine("\nAvailable items:");
                        library.displayAvailableItems();
                        



                        break;
                    case 7:
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;

                }

                
                Console.WriteLine("\nPress any key to continue or 'q' to exit");
                var key2 = Console.ReadKey().KeyChar;
                if (key2 == 'q')
                {
                    Console.WriteLine("\nExiting library management system...");
                 
                    break;
                }






            }
        }
        
    public abstract class Item
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Category { get; set; }
            public bool IsAvailable { get; set; }


            public Item(string id, string title, string author, string category)
            {
                Id = id;
                Title = title;
                Author = author;
                Category = category;
                IsAvailable = true;

            }

            public virtual void displayDetails()
            {

                Console.WriteLine("ID: " + Id);

                Console.WriteLine("Title: " + Title);

                Console.WriteLine("Author: " + Author);

                Console.WriteLine("Categoty: " + Category);

                Console.WriteLine("Avaibility: " + (IsAvailable ? "Available" : "Not Available"));
            }

            public virtual void borrowItem()
            {

                if (IsAvailable)
                {

                    IsAvailable = false;
                    Console.WriteLine("Item " + Id + " borrowed successfully.");
                }

                else
                {
                    throw new LibraryException("Item " + Id + " is not available.");
                }

            }

            public virtual void ReturnItem()
            {

                if (!IsAvailable)
                {

                    IsAvailable = true;
                    Console.WriteLine("Item " + Id + " returned successfully.");

                }
                else
                {

                    throw new LibraryException("Item " + Id + " is already available.");
                }
            }


        }


        public class Book : Item
        {

            public string Isbn { get; set; }
            public int Numpages { get; set; }

            public Book(string id, string title, string author, string category, string isbn, int numPages)
            : base(id, title, author, category)
            {
                Isbn = isbn;
                Numpages = numPages;
            }
            public override void displayDetails()
            {
                base.displayDetails();
                Console.WriteLine("ISBN: " + Isbn);
                Console.WriteLine("Number of Pages: " + Numpages);
            }

            public class DVD : Item
            {
                public string Director { get; set; }
                public int Length { get; set; }

                public DVD(string id, string title, string author, string category, string director, int length) 
                    : base(id, title, author, category)
                {
                    Director = director;
                    Length = length;
                }

                public override void displayDetails()
                {
                    base.displayDetails();
                    Console.WriteLine("Director: " + Director);
                    Console.WriteLine("Length: " + Length + " minutes");
                }


            }
        }
        public class CD : Item
        {
            public string Artist { get; set; }
            public int NumTracks { get; set; }

            public CD(string id, string title, string author, string category, string artist, int numTracks)
    : base(id, title, author, category)
            {
                Artist = artist;
                NumTracks = numTracks;
            }
            public override void displayDetails()
            {
                base.displayDetails();
                Console.WriteLine("Artist: " + Artist);
                Console.WriteLine("Number of Tracks: " + NumTracks);
            }
        }

    
class Library
    {
        public List<Item> items = new List<Item>();

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public void removeItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
            else
            {
                throw new LibraryException("Item not found in library collection.");
            }
        }

        public List<Item> searchItems(string query)
        {
            List<Item> results = new List<Item>();

            foreach (Item item in items)
            {
                if (item.Title.Contains(query) || item.Author.Contains(query) || item.Category.Contains(query))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public void borrowItem(string itemId)
        {
            Item item = findItemById(itemId);

            if (item != null && item.IsAvailable)
            {
                item.borrowItem();
            }
            else
            {
                throw new LibraryException("Item not available for borrowing.");
            }
        }

        public void returnItem(string itemId)
        {
            Item item = findItemById(itemId);

            if (item != null && !item.IsAvailable)
            {
                item.ReturnItem();
            }
            else
            {
                throw new LibraryException("Item cannot be returned as it is not currently borrowed.");
            }
        }

        public void displayAvailableItems()
        {
            Console.WriteLine("Available items:");

            foreach (Item item in items)
            {
                if (item.IsAvailable)
                {
                    item.displayDetails();
                }
            }
        }

        public Item findItemById(string itemId)
        {
            foreach (Item item in items)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }

            throw new LibraryException("Item not found in library collection.");
        }
    }




    class LibraryException : Exception
{
    public LibraryException(string message) : base(message)
    {
    }
}



    }
}







