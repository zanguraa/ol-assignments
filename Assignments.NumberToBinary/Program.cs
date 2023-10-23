namespace Assignments.NumberToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long binary;
            Console.WriteLine("Hello, Please enter your number and output will be in binary!");
            var tryToBinary = Console.ReadLine();
           var parsedBinary = long.TryParse(tryToBinary, out binary);
            Console.WriteLine(ToBinary(binary));
        }

        static string ToBinary(long value)
        {
            if (value == 0) return "0";
            if (value == 1) return "1";
            else
            {
                return ToBinary(value / 2) + (value % 2).ToString();
            }
        }
    }
}