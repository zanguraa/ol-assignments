using System;

namespace Assignments.FoodDailyValueCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new FoodDailyValueCalculator();
            var apple = new Apple();
            var dailyValue = calculator.Calculate(apple, 2400);

            ShowReport(dailyValue);
        }

        private static void ShowReport(DailyValue dailyValue)
        {
            foreach (var prop in dailyValue.GetType().GetProperties())
            {
                var propValue = prop.GetValue(dailyValue, null);

                if (propValue != null)
                    Console.WriteLine($"{prop.Name}: {(double)propValue:0.00}%");
            }
        }
    }
}