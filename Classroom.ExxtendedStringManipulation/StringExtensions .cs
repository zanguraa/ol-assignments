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

    }
}
