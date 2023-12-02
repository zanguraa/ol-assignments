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
            ChooseOperation(operation);
        }
        static void ChooseOperation(string operation)
        {
            if (operation.ToLower() == "countlines")
            {
                Console.WriteLine("Enter file paths (separated by a comma): ");
                var filePath = Console.ReadLine();
                CountLines(filePath);
            }
            else if (operation.ToLower() == "findword")
            {
                Console.WriteLine("Enter file paths (separated by a comma): ");
                var filePath = Console.ReadLine().ToLower();
                Console.WriteLine("enter the word to find: ");
                var wordToFind = Console.ReadLine().ToLower();
                FindWord(filePath, wordToFind);
            }
            else
            {
                Console.WriteLine("Invalid operation");
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
            var wordCount = 0;
            int index = words.IndexOf(wordToFind);
            while (index != -1)
            {
                wordCount++;
                index = words.IndexOf(wordToFind, index + 1);
            }
            Console.WriteLine($"{filePath} - Words counted: {wordCount}");
        }
    }

}