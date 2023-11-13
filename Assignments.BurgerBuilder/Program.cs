using Spectre.Console;
using System.Collections.Generic;


namespace Assignments.BurgerBuilder
{
    internal class Program
    {
        static Burger cheeseBurger = new Burger("CheeseBurger", new List<string> { "bun", "melted", "cheese", "lettuce", "pickles", "hot sauce" });
        static Burger hamburger = new Burger("Hamburger", new List<string> { "bun", "lettuce", "sour cucumber", "beef", "sweet sauce" });
        static Burger branded = new Burger("BrandedBurger", new List<string> { "bun", "lettuce", "pickles", "chicken", "branded sauce" });
        static void Main(string[] args)
        {

            Console.WriteLine("Choose the order mode: ");
            Console.WriteLine("1) Premade Burger");
            Console.WriteLine("2) Burger Builder");
            var userChoiceSuccess = int.TryParse(Console.ReadLine(), out var choice);
            if (!userChoiceSuccess)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            ShowUserVariant(choice);
        }

        static void DisplayBurger(Burger burger)
        {
            Console.WriteLine($"You ordered a {burger.Name} with the following ingredients: {string.Join(", ", burger.Description)}");
        }
        static void ShowUserVariant(int variant)
        {
            if (variant == 1)
            {
                Console.WriteLine("Your variant is Premade burger, please choose wich one do you want:");
                Console.WriteLine("1. Cheesburger");
                Console.WriteLine("2. Hamburger");
                Console.WriteLine("3. BrandedBurger");
                var userBurger = int.TryParse(Console.ReadLine(), out var burgerChoice);
                BurgerMenu(burgerChoice);
            }
            else if (variant == 2)
            {
                Console.WriteLine("Burger builder: ");
                Console.WriteLine("Have melted cheese?");
                Console.WriteLine("yes");
                Console.WriteLine("no");
                var meltedCheese = Console.ReadLine();
                Console.WriteLine("Have sour cucumber?");
                Console.WriteLine("yes");
                Console.WriteLine("no");
                var cucumber = Console.ReadLine();
                Console.WriteLine("Choose the meat: ");
                Console.WriteLine("1. chicken");
                Console.WriteLine("2. beef");
                Console.WriteLine("3. none");
                var meat = int.TryParse(Console.ReadLine(), out var meatResponse);
                Console.WriteLine("Choose a sauce: ");
                Console.WriteLine("spicy");
                Console.WriteLine("sweet");
                Console.WriteLine("branded");
                Console.WriteLine("none");
                var sauce = Console.ReadLine();

            }
        }
        static void BurgerMenu(int burger)
        {
            if (burger == 1)
            {
                DisplayBurger(cheeseBurger);
            }
            else if (burger == 2)
            {
                DisplayBurger(hamburger);
            }
            else if (burger == 3)
            {
                DisplayBurger(branded);
            }
            else
            {
                Console.WriteLine("Invalid burger choice. Please choose 1, 2, or 3.");
            }
        }
    }
}