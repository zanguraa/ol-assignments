namespace Classroom.TextAnalyzerMedium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\zangura\Downloads\test.txt";
            Console.WriteLine("Please enter the file Path: ");
            var filePath = Console.ReadLine();

            if(!File.Exists(filePath))
            {
               throw new FileNotFoundException("file path is not correct");
            }

            var content1 = File.ReadAllText(filePath);

            Console.WriteLine(content1);

            //using (StreamReader reader = new StreamReader(filePath))
            //{

            //    string content = reader.ReadToEnd();

            //    Console.WriteLine("File content:\n" + content);
            //}
            CountWords(content1);
        }

        static void CountWords(string word)
        {
            string[] filteredWords = word.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($" words: {filteredWords.Length} ");
        }
    }
}