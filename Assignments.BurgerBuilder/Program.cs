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
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                try
                {
                    Console.WriteLine("Choose the order mode: ");
                    Console.WriteLine("1) Premade Burger");
                    Console.WriteLine("2) Burger Builder");
                    if (!int.TryParse(Console.ReadLine(), out var choice) || choice > 2 || choice < 1)
                    {
                        throw new ArgumentException("Invalid input. Please enter a number between 1 and 2.");
                    }
                    ShowUserVariant(choice);
                    isValidChoice = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    isValidChoice = false;
                }
            }
        }
        static void DisplayBurger(List<string> ingredients)
        {
            Console.WriteLine($"You ordered a burger with the following ingredients: {string.Join(", ", ingredients)}");
        }
        static void ShowUserVariant(int variant)
        {
            List<string> userIngredients = new List<string>();
            if (variant == 1)
            {
                Console.WriteLine("Your variant is Premade burger, please choose wich one do you want:");
                Console.WriteLine("1. Cheesburger");
                Console.WriteLine("2. Hamburger");
                Console.WriteLine("3. BrandedBurger");
                var userBurger = int.TryParse(Console.ReadLine(), out var burgerChoice);
                userIngredients.AddRange(BurgerMenu(burgerChoice));
            }
            else if (variant == 2)
            {
                Console.WriteLine("Burger builder: ");
                Console.WriteLine("Have melted cheese?");
                Console.WriteLine("1. yes");
                Console.WriteLine("2. no");
                var meltedCheese = int.TryParse(Console.ReadLine(), out var parsedCheese);
                if (parsedCheese == 1)
                    userIngredients.Add("melted cheese");

                Console.WriteLine("Have sour cucumber?");
                Console.WriteLine("1. yes");
                Console.WriteLine("2. no");
                var cucumber = int.TryParse(Console.ReadLine(), out var parsedCucumber);
                if (parsedCucumber == 1)
                    userIngredients.Add("sour cucumber");

                Console.WriteLine("Choose the meat: ");
                Console.WriteLine("1. chicken");
                Console.WriteLine("2. beef");
                Console.WriteLine("3. none");
                var meat = int.TryParse(Console.ReadLine(), out var meatResponse);
                if (meatResponse == 1)
                    userIngredients.Add("chicken");
                else if (meatResponse == 2)
                    userIngredients.Add("beef");
                Console.WriteLine("Choose a sauce: ");
                Console.WriteLine("1. spicy");
                Console.WriteLine("2. sweet");
                Console.WriteLine("3. branded");
                Console.WriteLine("4. none");
                var sauce = int.TryParse(Console.ReadLine(), out var parsedSauce);
                if (parsedSauce == 1)
                    userIngredients.Add("spicy sauce");
                else if (parsedSauce == 2)
                    userIngredients.Add("sweet sauce");
                else if (parsedSauce == 3)
                    userIngredients.Add("branded sauce");
            }
            DisplayBurger(userIngredients);
        }
        static List<string> BurgerMenu(int burger)
        {
            List<string> ingredients = new List<string>();

            if (burger == 1)
            {
                ingredients.AddRange(new List<string> { "bun", "melted cheese", "lettuce", "pickles", "hot sauce" });
            }
            else if (burger == 2)
            {
                ingredients.AddRange(new List<string> { "bun", "lettuce", "sour cucumber", "beef", "sweet sauce" });
            }
            else if (burger == 3)
            {
                ingredients.AddRange(new List<string> { "bun", "lettuce", "pickles", "chicken", "branded sauce" });
            }
            return ingredients;
        }
    }
}