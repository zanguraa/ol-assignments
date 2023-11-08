using System.Text.RegularExpressions;

namespace Classroom.PalindromeChecker
{
    internal class Program
    {
        static string regex = "\\W";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please enter text here: ");
            var userInput = Console.ReadLine();
            var regExInput = Regex.Replace(userInput, regex, "").ToLower();
            IsPalindromeChecker(regExInput);
        }
        static void IsPalindromeChecker(string input)
        {
            string first = input.Substring(0, input.Length / 2);

            char[] charArray = input.ToCharArray();

            Array.Reverse(charArray);

            string temp = new string(charArray);
            var second = temp.Substring(0, temp.Length / 2);

            if (first.Equals(second))
            {
                Console.WriteLine("Is Palindrome");
            }
            else
            {
                Console.WriteLine("Is not a Palindrome");
            }
        }
    }
}