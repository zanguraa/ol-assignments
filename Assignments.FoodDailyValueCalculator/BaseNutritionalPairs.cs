using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.FoodDailyValueCalculator
{
    internal abstract class BaseNutritionalPairs
    {
        public double Calories { get; set; } = 2000;
        public double Fat { get; set; } = 65;
        public double Protein { get; set; } = 50;
        public double Carbohydrates { get; set; } = 300;
        public double Fiber { get; set; } = 25;
        public double Sugar { get; set; } = 25;
        public double VitaminC { get; set; } = 90;
        public double Calcium { get; set; } = 1000;
        public double Iron { get; set; } = 18;
    }
}
