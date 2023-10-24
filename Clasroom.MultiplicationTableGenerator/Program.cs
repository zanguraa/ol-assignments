namespace Clasroom.MultiplicationTableGenerator
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
                    var a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter second number: ");
                    var b = double.Parse(Console.ReadLine());
                    MultiplicationTableGenerator(a, b);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, please enter valid number!");
                }
            }

        }

        static void MultiplicationTableGenerator(double a, double b)
        {
           for (int i = 1; i <= a; i++)
            {
                Console.Write(i + "\t");
                for (int j = 1; j <= b; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.WriteLine("\n");
                }
           

        }
    }
}