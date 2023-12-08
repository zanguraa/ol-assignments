using LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.LibrarySystem
{
    public class BookRepository
    {
        public void AddBook(Library library)
        {
            Console.WriteLine("Enter book details - Title, Author, ISBN");
            var details = GetBookDetails();
            if (details.Length == 3)
            {
                library.AddBook(new Book(details[0], details[1], details[2]));
                Console.WriteLine("Book added successfully");
            }
            else
            {
                Console.WriteLine("Invalid details");
            }
        }

        public void RemoveBook(Library library)
        {
            Console.WriteLine("Enter ISBN of the book to remove"); var isbn = Console.ReadLine();
            if (library.RemoveBook(isbn))
            {
                Console.WriteLine("Book removed successfully");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public void ListAllBook(Library library)
        {
            var books = library.ListBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }

        public string[] GetBookDetails()
        {
            return Console.ReadLine().Split(',');
        }
    }
}
