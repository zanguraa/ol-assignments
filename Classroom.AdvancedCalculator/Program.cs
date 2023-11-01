using Spectre.Console;
using System.ComponentModel;

namespace Classroom.AdvancedCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            // Ask for the user's favorite fruit
            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Hello, Choose the [red]Math operation![/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
            "Add", "Subtract", "Multiply",
            "Divide", "Square", "SquareRoot",
            "Power"
                    }));

            // Echo the fruit back to the terminal
            MathOperate(operation);

        }

        public static void Add()
        {
            double result;
            Console.WriteLine("Please enter first number: ");
            var firstNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number: ");
            var secondNum = double.Parse(Console.ReadLine());
            result = firstNum + secondNum;
            Console.WriteLine($" the result {firstNum} + {secondNum} is: {result} ");
        }

        public static void Subtract()
        {
            double result;
            Console.WriteLine("Please enter first number: ");
            var firstNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number: ");
            var secondNum = double.Parse(Console.ReadLine());
            result = firstNum - secondNum;
            Console.WriteLine($" the result {firstNum} - {secondNum} is: {result} ");
        }

        private static void MathOperate(string operation)
        {

            {
                switch (operation)
                {


                    case "Add":
                        Add();
                        break;
                    case "Subtract":
                       Subtract();
                        break;
                    // Add other cases for different operations as needed


                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
            }

        }


    }

       
}