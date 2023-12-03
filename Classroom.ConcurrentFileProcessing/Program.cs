namespace Classroom.ConcurrentFileProcessing
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            string file1 = @"C:\Users\zangura\Downloads\text.txt";
            var file2 = @"C:\Users\zangura\Downloads\text2.txt";

            Console.WriteLine("Please enter the operation (countlines/findword): \r\n");
            var operation = Console.ReadLine();
            Console.WriteLine("Enter file paths (separated by a comma): ");
            var filePathsInput = Console.ReadLine();

            string[] filePaths = filePathsInput?.Split(',');

            if (filePaths != null && filePaths.Length == 2)
            {
                await ChooseOperation(operation, filePaths[0].Trim(), filePaths[1].Trim());
            }
            else
            {
                Console.WriteLine("Invalid input. Please provide exactly two file paths separated by a comma.");
            }
        }
        static async Task ChooseOperation(string operation, string filePath1, string filePath2)
        {
            if (operation.ToLower() == "countlines")
            {
                Task<int> task1 = CountLines(filePath1);
                Task<int> task2 = CountLines(filePath2);

                await Task.WhenAll(task1, task2);

                Console.WriteLine($"{filePath1} - Lines Counted: {task1.Result}");
                Console.WriteLine($"{filePath2} - Lines Counted: {task2.Result}");

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
        static async Task<int> CountLines(string filePath)
        {
            return await Task.Run(() =>
            {
                int linesCount = 0;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.ReadLine() != null)
                    {
                        linesCount++;
                    }
                }
                return linesCount;
            });
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