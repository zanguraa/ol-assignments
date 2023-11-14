namespace Classroom.AnimalHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Cat myCat = new Cat("Fluffy", 3, "Persian");

            Console.WriteLine($"{myCat.Breed}");
        }
    }
}