using Assignments.FoodDailyValueCalculator;

internal class Food : BaseNutritionalPairs
{
    public Food(double cal, double fat, double protein, double carbohydrates, double fiber, double sugar, double vitamin_c, double calcium, double iron)
    {
        Calories = cal; Fat = fat; Protein = protein; Carbohydrates = carbohydrates;
        Fiber = fiber; Sugar = sugar; VitaminC = vitamin_c; Calcium = calcium;
        Iron = iron;
    }
}