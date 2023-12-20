namespace Assignments.ExtensionFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var number = "01.2020";
            number.IsNumber();
            Console.WriteLine($"Is number or not: {number.IsNumber()} ");
            Console.WriteLine($"Is Date or not: {number.IsDate()}");

        }
    }
}