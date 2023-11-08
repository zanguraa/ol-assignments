namespace Classroom.PersonClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person ("Valeri", 32,"Chavchavadze #25", 591926322 );
            var person2 = new Person("Irakli", 17, "Chavchavadze #25", 591926322);
            Greet(person1);
            Greet(person2);
            IsAdult(person1);
            IsAdult(person2);
        }
        static void Greet(Person person)
        {
            ValidateAge(person);
            Console.WriteLine($"Hello, my name is {person.Name} and I am {person.Age} years old");
        }
        static void IsAdult(Person person)
        {
            ValidateAge(person);
            if (person.Age >= 18)
            {
                Console.WriteLine($"This Person {person.Name} is adult ");
            } 
        }
        static void ValidateAge(Person person)
        {
            if (person.Age < 0)
            {
                throw new Exception("Age can not be less than 0");
            }
        }
    }

}