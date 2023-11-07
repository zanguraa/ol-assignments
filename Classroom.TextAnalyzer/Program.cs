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
            FindLongestWord(words);
            FindShortestWord(words);
            AverageWordLength(words);
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
            var longestWord = words.OrderByDescending(word => word.Length).FirstOrDefault();
            Console.WriteLine($"Longest word: {longestWord}");
        }
        static void FindShortestWord(string[] words)
        {
            var shortestWord = words[0];
            foreach (var word in words)
            {
                if(word.Length < shortestWord.Length)
                {
                    shortestWord = word;
                }
            }
            Console.WriteLine($"Shortest word: {shortestWord}");
        }
        static void AverageWordLength(string[] words)
        {
            var totalWords = 0;
            for (int i = 0; i < words.Length; i++)
            {
                totalWords += words[i].Length;
            }
            double average = (double)totalWords / (double)words.Length;
            Console.WriteLine($"Average word length: {average}");
        }
        static void SentenceCountWords(string[] words)
        {
           
        }
    }
}