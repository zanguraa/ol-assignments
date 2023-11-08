namespace EvenNumberFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, enter your number: ");
            var parsedNum = int.Parse(Console.ReadLine());
           GetEvenNumber(parsedNum);
        }
        static void GetEvenNumber(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("----");
                    Console.WriteLine(i);
                }
            }
        }
    }
}