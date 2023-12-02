namespace Classroom.ConcurrentFileProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the operation (countlines/findword): \r\n");
            var operation = Console.ReadLine();
            Console.WriteLine("Enter file paths (separated by a comma): ");
            var chooseFile = Console.ReadLine();

        }
    }
}