using Assignments.FoodDailyValueCalculator;

internal class FoodDailyValueCalculatorr : BaseNutritionalPairs
{
    private static Food? _myFood;
    private static int _dailyCalories;
    public DailyValue Calculate(Food food, int dailyCalories)
    {
        _myFood = food;
        _dailyCalories = dailyCalories;

        return new DailyValue
        {
            Calories = CalculateCalories(),
            Fat = CalculateFat(),
            Protein = CalculateProtein(),
            Carbohydrates = CalculateCarbohydrates(),
            Fiber = CalculateFiber(),
            Sugar = CalculateSugar(),
            VitaminC = CalculateVitaminC(),
            Calcium = CalculateCalcium(),
            Iron = CalculateIron()
        };
    }
    private double CalculateCalories() => double.Parse((_myFood.Calories * 100 / _dailyCalories).ToString("0.00"));
    private double CalculateFat()
    {
        double fat = (double)Fat * _dailyCalories / Calories;
        return _myFood.Fat * 100 / fat;
    }
    private double CalculateProtein()
    {
        double protein = (double)Protein * _dailyCalories / (double)Calories;
        return _myFood.Protein * 100 / protein;
    }
    private double CalculateCarbohydrates()
    {
        double carb = (double)Carbohydrates * _dailyCalories / Calories;
        return _myFood.Carbohydrates * 100 / carb;
    }
    private double CalculateFiber()
    {
        double fiber = (double)Fiber * _dailyCalories / Calories;
        return _myFood.Fiber * 100 / fiber;
    }
    private double CalculateSugar()
    {
        double sugar = (double)Sugar * _dailyCalories / Calories;
        return _myFood.Sugar * 100 / sugar;
    }
    private double CalculateVitaminC()
    {
        double vitaminC = (double)VitaminC * _dailyCalories / Calories;
        return _myFood.VitaminC * 100 / vitaminC;
    }
    private double CalculateCalcium()
    {
        double calcium = Calcium * _dailyCalories / Calories;
        return _myFood.Calcium * 100 / calcium;
    }
    private double CalculateIron()
    {
        double iron = (double)Iron * _dailyCalories / Calories;
        return _myFood.Iron * 100 / iron;
    }
}