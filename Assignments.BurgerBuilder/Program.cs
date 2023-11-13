using Spectre.Console;


namespace Assignments.BurgerBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the order mode: ");
            Console.WriteLine("1) Premade Burger");
            Console.WriteLine("2) Burger Builder");
            var userChoice = Console.ReadLine();

            var updatedBurger = new Burger("Burger Max", new List<string> { "rame", "rume"} );
            DisplayBurger(updatedBurger);

        }

        static void DisplayBurger(Burger burger)
        {
            Console.WriteLine($"burger name: {burger.Name}");

            Console.WriteLine("Burger Ingredients");
            foreach (var item in burger.Description)
            {              
                Console.WriteLine(item);
            }
            
        }
    }
}