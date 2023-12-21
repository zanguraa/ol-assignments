using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.ExtensionFunctions
{
    public static class StringExtensions
    {
        public static bool IsNumber(this string str)
        {
            return double.TryParse(str, out  var number);   
        }

        public static bool IsDate(this string str)
        {
            return DateTime.TryParse(str, out var date);
        }

        public static string[] ToWords(this string words)
        {
            string[] stringArray = words.Split(' ');
            return stringArray;
        }

        public static string CalculateHash(this string str)
        {
            var algo = HashAlgorithm.Create("sha256");
            var hash = algo.ComputeHash(Encoding.UTF8.GetBytes(str));
            var output = BitConverter.ToString(hash);
            return output;
        }
    }
}
