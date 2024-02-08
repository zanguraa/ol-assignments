using System;

namespace Classroom.AgeBracketDetermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your age:");
                    var age = int.Parse(Console.ReadLine());
                    Console.WriteLine($"You are in the {AgeBracket(age)} age bracket.");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error: please enter integers");
                }
            }
        }

        static string AgeBracket(int age)
        {
            return age switch
            {
                < 0 => throw new ArgumentException("Age cannot be negative."),
                < 3 => "infant",
                < 6 => "toddler",
                < 13 => "child",
                < 18 => "teenager",
                < 65 => "adult",
                _ => "senior"
            };
        }
    }
}
