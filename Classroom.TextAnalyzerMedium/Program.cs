using System;
using System.IO;

namespace Classroom.TextAnalyzerMedium
{
    internal class Program
    {
        static int totalWords = 0;
        static string longestWord = "";
        static void Main(string[] args)
        {
            var file = @"C:\Users\zangura\Downloads\test.txt";
            Console.WriteLine("Please enter the file Path: ");
            var filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File path is not correct");
            }
            var content = File.ReadAllLines(filePath);            

            foreach (var line in content)
            {
                int wordsInLine = CountWords(line);
                totalWords += wordsInLine;

                string longestWordInLine = FindLongestWord(line);
                if (longestWordInLine.Length > longestWord.Length)
                {
                    longestWord = longestWordInLine;
                }
            }
            Console.WriteLine($"Total words: {totalWords}");
            Console.WriteLine($"Longest word across all lines is: {longestWord}");
        }

        static int CountWords(string line)
        {
            string[] words = line.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static string FindLongestWord(string line)
        {
            string[] words = line.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

            string longestWordInLine = words.Length > 0 ? words[0] : "";

            foreach (var word in words)
            {
                if (word.Length > longestWordInLine.Length)
                {
                    longestWordInLine = word;
                }
            }
            return longestWordInLine;
        }
    }
}
