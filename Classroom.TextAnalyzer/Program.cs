using System.Text.RegularExpressions;

namespace Classroom.TextAnalyzer
{
    

    internal class Program
    {
        private static Dictionary<string, int> wordsDictionary = new();
        static void Main(string[] args)
        {
            var pattern = @"[.,:#*^&<>\\]";
            Console.WriteLine("Please enter a block of text for analysis:\r\n");
            var userInput = Console.ReadLine();
            var words = Regex
                                    .Replace(userInput, pattern, " ")
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CountWords(words);
            FindMostCommonWord(words);
        }
        static void CountWords(string[] words)
        {
            var count = 0;
            foreach (var word in words)
            {
                count++;
            }
            Console.WriteLine($"Word Count: {count}");
        }
        static void FindMostCommonWord(string[] words)
        {
            foreach (var word in words)
            {
                if(!wordsDictionary.ContainsKey(word))
                {
                    wordsDictionary.Add(word, 1);
                }
                else
                {
                    wordsDictionary[word]++;
                }
            }
            Console.WriteLine($"Most common word: {wordsDictionary.OrderByDescending(x => x.Value).First().Key}");
        }
        static void FindLongestWord(string[] words)
        {


        }
    }
}