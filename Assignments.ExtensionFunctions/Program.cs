namespace Assignments.ExtensionFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var number = "01.2020";
            string stringExample = "extension functions";
            number.IsNumber();
            Console.WriteLine($"Is number or not: {number.IsNumber()} ");
            Console.WriteLine($"Is Date or not: {number.IsDate()}");

            string[] stringArrayExample = stringExample.ToWords();
            foreach ( string words in stringArrayExample )
            {
                Console.WriteLine( words );
            }

            var hash = stringExample.CalculateHash();
            Console.WriteLine($"This is HASH256: {hash}");
        }
    }
}