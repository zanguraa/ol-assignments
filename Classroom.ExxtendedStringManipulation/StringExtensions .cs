using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.ExxtendedStringManipulation
{
    public static class StringExtensions
    {
        public static string Reverse(this string word)
        {
            var reversedWord = "";
            if (word.Length == 0)
            {
                Console.WriteLine("please enter some word!");
            }
            for (var i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += word[i];
            }
            return reversedWord;
        }
        public static string ToTitleCase(this string word)
        {
            var titleWord = "";
            var splitedWords = word.Split(' ');

            for (var i = 0; i < splitedWords.Length; i++)
            {
                var currentWord = splitedWords[i];
                if (!String.IsNullOrEmpty(currentWord))
                {
                    var capitalizedWord = char.ToUpper(currentWord[0]) + currentWord.Substring(1).ToLower();
                    titleWord += capitalizedWord;
                    if (i < splitedWords.Length - 1) { titleWord += " "; }
                }
            }
            return titleWord;
        }
        public static string WordCount(this string word)
        {
            var wordSplit = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var count = 0;
            for(int i = 0; i < wordSplit.Length; i++)
            {
                count++;
            }
            return count.ToString();
        }
    }
}
