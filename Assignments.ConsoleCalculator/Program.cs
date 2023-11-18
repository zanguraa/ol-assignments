namespace Assignments.ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                try
                {
                    Console.WriteLine("Enter first number: ");
                    string firstNumber = Console.ReadLine();
                    double parsedNumber = ParseToDouble(firstNumber);
                    Console.WriteLine("Enter second number: ");
                    string secondNumber = Console.ReadLine();
                    double parsedSecond = ParseToDouble(secondNumber);
                    Console.WriteLine("Enter Match operation: + - * \\:");
                    string operation = Console.ReadLine();
                    Calculate(parsedNumber, parsedSecond, operation);
                }
                catch
                {
                    Console.WriteLine("Text is not a number");
                }
            }
        }

        static double ParseToDouble(string input)
        {
            double result;
            while (!double.TryParse(input, out result))
            {
                Console.WriteLine("Text is not a number");
                input = Console.ReadLine();
            }
            return result;
        }
        static void Calculate(double first, double second, string op)
        {
            double result = 0;

            if (op == "-")
            {
                result = first - second;
                Console.WriteLine($" {first} - {second} = {result} ");
            }
            if (op == "+")
            {
                result = first + second;
                Console.WriteLine($"{first} + {second} = {result}");
            }
            if (op == "*")
            {
                result = first * second;
                Console.WriteLine($"{first} * {second} = {result}");
            }
            if (op == "/" && second != 0)
            {
                result = first / second;
                Console.WriteLine($"{first} / {second} = {result.ToString("0.00")}");
            }
            if (op == "/" && second == 0)
            {
                Console.WriteLine("Can not divide by zero");
            }
        }
    }
}