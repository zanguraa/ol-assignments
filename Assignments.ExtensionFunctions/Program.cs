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
            string filePath = @"C:\Users\Zangura\Downloads\newCreated\tests.txt";
            stringExample.SaveToFile(filePath);
            Console.WriteLine($"File saved successfully at: {filePath}");

            double percent = 3.9;
            Console.WriteLine(percent.ToPercent());
            Console.WriteLine($"rounded to down: {percent.RoundDown()}");

        }


    }
}