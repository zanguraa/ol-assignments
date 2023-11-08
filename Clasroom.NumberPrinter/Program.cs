namespace Clasroom.NumberPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Hello, Enter your number: ");
            var isParsed = int.TryParse(Console.ReadLine(), out num);
            if(!isParsed)
            {
                Console.WriteLine("Error! please enter number");
                return;
            }
            NumberPrinter(num);
        }
        static int NumberPrinter(int num)
        {
            for (int i = 0; i <= num; i++)
            {
                Console.WriteLine(i.ToString());
            }
            return num;
        }
    }
}