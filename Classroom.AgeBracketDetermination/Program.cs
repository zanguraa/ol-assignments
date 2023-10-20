namespace Classroom.AgeBracketDetermination
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while(true)
            {

                try
                {
                    Console.WriteLine("Please enter your age:");
                    var age = int.Parse(Console.ReadLine());
                    Console.WriteLine($"You are in the {AgeBracket(age)} age bracket.");
                }
                catch(Exception)
                {
                    Console.WriteLine($"Error: please enter integers");
                }
            }
           
           
        }

        static string AgeBracket(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            else if (age < 3)
            {
                return "infant";
            }
            else if (age < 6)
            {
                return "toddler";
            }
            else if (age < 13)
            {
                return "child";
            }
            else if (age < 18)
            {
                return "teenager";
            }
            else if (age < 65)
            {
                return "adult";
            }
            else
            {
                return "senior";
            }
        }
    }
}