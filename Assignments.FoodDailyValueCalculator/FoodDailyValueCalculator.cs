using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.FoodDailyValueCalculator
{
    public class FoodDailyValueCalculator
    {
        public DailyValue Calculate(Food food, int dailyCalories)
        {
            double calorieRatio = (double)dailyCalories / food.Calories;

            return new DailyValue
            {
                Calories = food.Calories * calorieRatio,
                Fat = food.Fat * calorieRatio,
                Protein = food.Protein * calorieRatio,
                Carbohydrates = food.Carbohydrates * calorieRatio,
                Fiber = food.Fiber * calorieRatio,
                Sugar = food.Sugar * calorieRatio,
                VitaminC = food.VitaminC * calorieRatio,
                Calcium = food.Calcium * calorieRatio,
                Iron = food.Iron * calorieRatio
            };
        }
    }
}
