using Classroom.LibrarySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            while (true)
            {
                PrintMenuOptions();

                var book = new BookRepository();

                var choice = GetMenuOption();
                switch (choice)
                {
                    case MenuOption.AddBook:
                        book.AddBook(library);
                        break;

                    case MenuOption.RemoveBook:
                        book.RemoveBook(library);
                        break;

                    case MenuOption.ListBooks:
                        book.ListAllBook(library);
                        break;

                    case MenuOption.Exit:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        static MenuOption GetMenuOption()
        {
            var option = (MenuOption)int.Parse(Console.ReadLine());
            return option;
        }

        static void PrintMenuOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Add a book");
            Console.WriteLine("2: Remove a book");
            Console.WriteLine("3: List all books");
            Console.WriteLine("4: Exit");
        }
    }
}