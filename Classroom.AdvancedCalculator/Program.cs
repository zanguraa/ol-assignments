using Spectre.Console;

namespace Classroom.AdvancedCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

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
            catch (Exception ex)
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
        public static void Multiplication()
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
        public static void Division()
        {
            try
            {
                double result;
                Console.WriteLine("Your choice is Divide!");
                Console.WriteLine("Please enter first number: ");
                var firstInput = Console.ReadLine();
                double firstN = double.Parse(firstInput);

                Console.WriteLine("Please enter second number: ");
                var secondInput = Console.ReadLine();
                double secondN = double.Parse(secondInput);
                if (secondN == 0)
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
        public static void Square()
        {
            try
            {
                Console.WriteLine("Your choice is Square!");
                Console.WriteLine("Please enter number: ");
                var userInput = Console.ReadLine();
                double squareNumber = Math.Sqrt(double.Parse(userInput));
                Console.WriteLine($"square {squareNumber.ToString("0.00")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public static void SquareRoot()
        {
            try
            {
                Console.WriteLine("Your choice is SquareRoot!");
                Console.WriteLine("Please enter number: ");
                var userInput = Console.ReadLine();
                double squareNumber = double.Parse(userInput);
                var result = squareNumber * squareNumber;
                Console.WriteLine($"The squareRoot of {userInput}  is {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public static void Power()
        {
            try
            {
                Console.WriteLine("Your choice is Power!");
                Console.WriteLine("Please enter base: ");
                var userInput = Console.ReadLine();
                double baseParsed = double.Parse(userInput);
                Console.WriteLine("Please enter exponent: ");
                var userExponent = Console.ReadLine();
                double exponentParsed = double.Parse(userExponent);
                var power = Math.Pow(baseParsed, exponentParsed);
                Console.WriteLine($"The power of numbers {baseParsed} and {exponentParsed} is {power}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
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
                        Division(); break;
                    case "Square":
                        Square(); break;
                    case "SquareRoot":
                        SquareRoot(); break;
                    case "Power":
                        Power(); break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }
            }
        }
    }
}