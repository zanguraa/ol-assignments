using Spectre.Console;
using System.ComponentModel;
using System.Numerics;

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

        public static void Addition()
        {
             
            try
            {
                double result;
                Console.WriteLine("You choice is Addition!");
                Console.WriteLine("Please enter first number: ");
                var firstInput = Console.ReadLine();
                double firstN = double.Parse(firstInput);

                Console.WriteLine("Please enter second number: ");
                var secondInput = Console.ReadLine();
                double secondN = double.Parse(secondInput);
                result = firstN + secondN;
                Console.WriteLine($" the result {firstN} + {secondN} is: {result} ");
            }
            catch(Exception ex)  
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public static void Subtraction()
        {
            try
            {
                double result;
                Console.WriteLine("You choice is Subtract!");

                Console.WriteLine("Please enter first number: ");
                var firstInput = Console.ReadLine();
                double firstN = double.Parse(firstInput);

                Console.WriteLine("Please enter second number: ");
                var secondInput = Console.ReadLine();
                double secondN = double.Parse(secondInput);
                result = firstN - secondN;
                Console.WriteLine($" the result {firstN} - {secondN} is: {result} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void  Multiplication()
        {
            try
            {
                double result;
                Console.WriteLine("Your choice is Multiply!");
                Console.WriteLine("Please enter first number: ");
                var firstInput = Console.ReadLine();
                double firstN = double.Parse(firstInput);

                Console.WriteLine("Please enter second number: ");
                var secondInput = Console.ReadLine();
                double secondN = double.Parse(secondInput);
                result = firstN * secondN;
                Console.WriteLine($" the result {firstN} * {secondN} is: {result} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static void Division ()
        {
            try
            {
                double result;
                Console.WriteLine("Your choice is Multiply!");
                Console.WriteLine("Please enter first number: ");
                var firstInput = Console.ReadLine();
                double firstN = double.Parse(firstInput);

                Console.WriteLine("Please enter second number: ");
                var secondInput = Console.ReadLine();
                double secondN = double.Parse(secondInput);
                if(secondN == 0)
                {
                    Console.WriteLine("can not divide by zero!");
                }
                else
                {
                    result = firstN / secondN;
                    Console.WriteLine($" the result {firstN} / {secondN} is: {result.ToString("0.00")} ");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MathOperate(string operation)
        {

            {
                switch (operation)
                {


                    case "Add":
                        Addition(); break;
                    case "Subtract":
                        Subtraction(); break;
                    case "Multiply":
                        Multiplication(); break;
                    case "Divide":
                        Division();
                        break;


                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
            }

        }


    }

       
}