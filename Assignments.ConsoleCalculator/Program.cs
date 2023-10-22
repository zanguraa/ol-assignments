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
                }
                catch
                {
                   
                }

            }

        }

         static double ParseToDouble(string input)
        {
            double result;
            while(!double.TryParse(input, out result))
            {
                Console.WriteLine("Text is not a number");
                input = Console.ReadLine();
            }
            return result;
        }
    }
}