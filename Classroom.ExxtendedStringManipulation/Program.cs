namespace Classroom.ExxtendedStringManipulation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please enter some word: ");
            var userResponse = Console.ReadLine();
            PrintUserResponse(userResponse);
        }
        public static void PrintUserResponse(string userResponse)
        {
            Console.WriteLine($"Original String: {userResponse} ");
            Console.WriteLine($"Reversed: {userResponse.Reverse()}");
            Console.WriteLine($"Word Count: {userResponse.WordCount()}");
        }
    }
}