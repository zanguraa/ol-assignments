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

        public abstract void MakeSound();
    }

    internal class Dog: Animal 
    {
        public string Breed { get; set; }
        public Dog(string name, int age) : base(name, age) => Breed = breed;
       
    }

    internal class Cat : Animal
    {
        public string Breed {  set; get; }
        public Cat(string name, int age) : base(name, age) => Breed = breed;
     
    }

    internal class Bird : Animal
    {
        public string Species { get; set; }
        public Bird(string name, int age) : base(name, age) => Species = species;

        public override void MakeSound() => Console.WriteLine("");
        

    }


}
