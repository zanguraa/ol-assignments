using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.FoodDailyValueCalculator
{
    public class Food
    {
        public double Calories { get; }
        public double Fat { get; }
        public double Protein { get; }
        public double Carbohydrates { get; }
        public double Fiber { get; }
        public double Sugar { get; }
        public double VitaminC { get; }
        public double Calcium { get; }
        public double Iron { get; }

        public Food(double calories, double fat, double protein, double carbohydrates, double fiber, double sugar, double vitaminC, double calcium, double iron)
        {
            Calories = calories;
            Fat = fat;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Fiber = fiber;
            Sugar = sugar;
            VitaminC = vitaminC;
            Calcium = calcium;
            Iron = iron;
        }
    }
}
