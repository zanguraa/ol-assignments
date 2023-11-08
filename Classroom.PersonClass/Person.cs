using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.PersonClass
{
    internal class Person
    {       
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public Person(string name, int age, string address, int phoneNumber) 
        {
            Name = name;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
        }      
    }
}
