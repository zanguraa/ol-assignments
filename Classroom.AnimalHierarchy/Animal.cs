using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Classroom.AnimalHierarchy
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
       
        public Animal(string name, int age) 
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"A {GetType().Name.ToLower()} named {Name} is created. It is {Age} years old.";
        }
        public abstract void MakeSound();
    }

    internal class Dog: Animal 
    {
        public string Breed { get; set; }
        public Dog(string name, int age, string breed) : base(name, age) => Breed = breed;
        public override void MakeSound() => Console.WriteLine(" Woof!");
        public override string ToString()
        {
            return base.ToString() + $" It is a {Breed}.";
        }
    }

    internal class Cat : Animal
    {
        public string Breed {  set; get; }
        public Cat(string name, int age, string breed) : base(name, age) => Breed = breed;
        public override void MakeSound() => Console.WriteLine("Meoow");
        public override string ToString()
        {
            return base.ToString() + $" It is a {Breed}.";
        }
    }

    internal class Bird : Animal
    {      
        public string Species { get; set; }
        public Bird(string name, int age, string species) : base(name, age) => Species = species;
        public override void MakeSound() => Console.WriteLine("Tweet tweet!");
        public override string ToString()
        {
            return base.ToString() + $" It is a {Species}.";
        }
    }
}
