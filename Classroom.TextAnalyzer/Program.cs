using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace Classroom.TextAnalyzer
{
    

    internal class Program
    {
        private static Dictionary<string, int> wordsDictionary = new();
        static void Main(string[] args)
        {
          
            while (true)
            {
                var pattern = @"[.,:#*^&<>\\]";
                Console.WriteLine("Please enter a block of text for analysis:\r\n");
                var userInput = Console.ReadLine();
                var words = Regex
                                        .Replace(userInput, pattern, " ")
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine();
                Console.WriteLine("Analyzing...\r\n");
                Console.WriteLine();
                CountWords(words);
                FindMostCommonWord(words);
                FindLongestWord(words);
                FindShortestWord(words);
                AverageWordLength(words);

                Console.WriteLine("Would you like to analyze another block of text? (yes/no):");
                var exitOrNo = Console.ReadLine();
                if (exitOrNo.ToLower() == "no")
                {
                    break;
                }
            } 
        }
        static void CountWords(string[] words)
        {
            if (words.Length == 0) return;
            var count = 0;
            foreach (var word in words)
            {
                count++;
            }
            Console.WriteLine($"Word Count: {count}");
        }
        static void FindMostCommonWord(string[] words)
        {
            if(words.Length == 0) return;
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
            if (words.Length == 0) return;
            var longestWord = words.OrderByDescending(word => word.Length).FirstOrDefault();
            Console.WriteLine($"Longest word: {longestWord}");
        }
        static void FindShortestWord(string[] words)
        {
            var shortestWord = words[0];
            if (words.Length == 0) return;
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
            if (words.Length == 0) return;

            var totalWords = 0;
            for (int i = 0; i < words.Length; i++)
            {
                totalWords += words[i].Length;
            }
            double average = (double)totalWords / (double)words.Length;
            Console.WriteLine($"Average word length: {average.ToString("0.00")} characters");
        }
        static void SentenceCountWords(string[] words)
        {
           
        }
    }
}