namespace Classroom.ConcurrentFileProcessing
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var file1 = @"C:\Users\zangura\Downloads\text.txt";
            var file2 = @"C:\Users\zangura\Downloads\text2.txt";

            Console.WriteLine("Please enter the operation (countlines/findword): \r\n");
            var operation = Console.ReadLine();
            Console.WriteLine("Enter file paths (separated by a comma): ");
            var filePath = Console.ReadLine();
            ChooseOperation(filePath, operation);

        }
        static void ChooseOperation(string operation, string filePath)
        {
            if (operation.ToLower() == "countlines")
            {
            CountLines(filePath);
            }
            else if(operation.ToLower() == "findword")
            {
                Console.WriteLine("enter the word to find: ");
                var wordToFind = Console.ReadLine();
            }
        }
        static void CountLines(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int linesCount = lines.Length;
            Console.WriteLine($"{filePath} - Lines Counted: {linesCount}");
        }
        static void FindWord(string filePath, string wordToFind)
        {
            string words = File.ReadAllText(filePath);
            
        }
    }

}