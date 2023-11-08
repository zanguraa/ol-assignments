namespace Classroom.DiscountCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, Engter your age: ");
            var age = int.Parse(Console.ReadLine());
            DiscountCalculator(age);
        }
        static void DiscountCalculator(int age)
        {
            int price = 100;
            if (age > 0)
            {
                var discount = (age < 18) ? price * 0.75 : (age >= 65) ? price * 0.85 : price;
                Console.WriteLine($"your discounted price is {discount}");
            }
            else
            {
                Console.WriteLine("Invalid input please enter valid age");
            }
        }
    }
}