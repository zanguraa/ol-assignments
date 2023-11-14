namespace Classroom.AnimalHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat("Whiskers", 3, "Siamese");
            Dog myDog = new Dog("Buddy", 5, "Labrador Retriever");
            Bird myBird = new Bird("Tweety", 2, "Canary");

            List<Animal> animals = new List<Animal>
            {
                 myDog, myCat, myBird,
            };
            foreach (Animal animal in animals)
            {
                Console.WriteLine();
                Console.WriteLine(animal);
                Console.WriteLine();
            }
        }
    }
}