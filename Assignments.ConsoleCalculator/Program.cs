namespace Assignments.ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                double first;
                double second;

                Console.WriteLine("Enter first number: ");
                double firstNumber = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number: ");
                var secondNumber = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Match operation: + - * \\:");
            }
            catch 
            {
                Console.WriteLine("Text is not a number");
            }

           

        }
    }
}