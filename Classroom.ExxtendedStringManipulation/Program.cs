namespace Classroom.ExxtendedStringManipulation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please enter some word: ");
            var userResponse = Console.ReadLine().Reverse();
            Console.WriteLine(userResponse);

        }
    }
}