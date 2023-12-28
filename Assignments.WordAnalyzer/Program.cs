using System.Diagnostics.Tracing;

namespace Assignments.WordAnalyzer
{
    internal class Program
    {
        static async Task Main()
        {
            string fileName = "words_alpha.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            try
            {
                string fileContent = await File.ReadAllTextAsync(filePath);
                string[] words = fileContent.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var processingTask = new List<Task>();
                processingTask.Add(ShortestWord(words));
                processingTask.Add(LongestWord(words));
                processingTask.Add(TopVowelWords(words));

                await Task.WhenAll(processingTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static async Task ShortestWord(string[] words)
        {
            string shortestWord = await Task.Run(() => words.OrderBy(x => x.Length).FirstOrDefault());
            Console.WriteLine($"shortest word in file is: {shortestWord}");
        }

        static async Task LongestWord(string[] words)
        {
            string longestWord = await Task.Run(() => words.OrderByDescending(x => x.Length).FirstOrDefault());
            Console.WriteLine($"longest word in file is: {longestWord}");
        }

        static bool ContainVowels(string words)
        {
            return words.Any(char.IsLetter) && "aeiouAEIOU".Any(words.Contains);
        }

        static async Task TopVowelWords(string[] words)
        {
            var topVowelWords = await Task.Run(() =>
            {
                return words
                 .AsParallel()
                 .Where(word => ContainVowels(word))
                 .GroupBy(word => word)
                 .OrderByDescending(group => group.Count())
                 .Take(100)
                 .Select(group => group.Key)
                 .ToList();
            });
            Console.WriteLine("\nTop 100 Words with Vowels:");
            foreach (var word in topVowelWords)
            {
                Console.WriteLine(word);
            }
        }

    }
}