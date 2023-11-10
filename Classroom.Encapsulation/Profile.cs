using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Encapsulation
{
    internal class Profile
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Profile(string name, int age)
        {
            SetProfile(name, age);
            UpdateProfile(name, age);
        }
        private void SetProfile(string name, int age)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter a valid name");
                }
                if (age <= 0)
                {
                    Console.WriteLine("Age must be greater than 0");
                }
                Name = name;
                Age = age;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void UpdateProfile(string updatedName, int updatedAge)
        {
            try
            {
                if (string.IsNullOrEmpty(updatedName))
                {
                    throw new ArgumentNullException(nameof(updatedName), "Please enter a valid name");
                }
                if (updatedAge <= 0)
                {
                    throw new ArgumentException("Age must be greater than 0", nameof(updatedAge));
                }
                Console.WriteLine("Updating profile...\r\n");
                Name = updatedName;
                Console.WriteLine($"Setting name to '{Name}'. Name updated successfully.\r\n");

                Age = updatedAge;
                Console.WriteLine($"Setting age to {Age}. Age updated successfully.\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
