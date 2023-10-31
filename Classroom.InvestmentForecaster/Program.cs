namespace Classroom.InvestmentForecaster
{
    internal class Program
    {
       static double principalAmount = 0;
       static double annualAmount = 0;
       static double timeInYears = 0;
       static readonly double n = 12;
        static void Main(string[] args)
        {
             

             ParseInputs();
            CalculateFutureValue();
        }

        public static void ParseInputs()
        {
            Console.WriteLine("Hello, Please enter your principal amount: ");
            principalAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter annual interest rate: ");
            annualAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number of year: ");
            timeInYears = double.Parse(Console.ReadLine());
        }

        public static void CalculateFutureValue()
        {
            var rate = annualAmount / 100;
            var futureValue = principalAmount * Math.Pow(1 + rate /n, (n * timeInYears));


            Console.WriteLine($"Future value of your investment: ${futureValue.ToString("0.00")}");
        }

    }
}