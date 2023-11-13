using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.BurgerBuilder
{
    internal class Burger
    {
        public string Name { get; set; }
        public List<string> Description { get; set; }
        public Burger(string name, List<string> description) 
        {
            Name = name;
            Description = description; 
        }
        public void UpdateBurger(string newName, List<string> newDescription)
        {
            Name = newName;
            Description = newDescription;
        }

    }
}
