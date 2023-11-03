namespace Classroom.ArrayOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please enter series of numbers!");
            var userInput = Console.ReadLine();
            var userInputArray = userInput.Split(",", StringSplitOptions.RemoveEmptyEntries);

            int[] arrayNumbers = new int[userInputArray.Length];

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                var parsedInputs = int.TryParse(userInputArray[i], out arrayNumbers[i]);
            }
            var sum = CalculateSum(arrayNumbers);
            var average = CalculateAverage(arrayNumbers);
            var min = FindMin(arrayNumbers);
            Console.WriteLine($"sum is: {sum}");
            Console.WriteLine($"average is: {average}");
            Console.WriteLine($"The min is: {min}");
        }

        static int CalculateSum(int[] arrayNumbers)
        {
            var sum = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                sum += arrayNumbers[i];
            }
            return sum;
        }
        static double CalculateAverage(int[] arrayNumbers)
        {
            var sum = 0;
            var average = 0;
            for (int j = 0; j < arrayNumbers.Length; j++)
            {
                sum += arrayNumbers[j];
            }

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                average = sum / arrayNumbers.Length;
            }
            return average;
        }
        static int FindMin(int[] arrayNumbers)
        {
            var min = arrayNumbers[0];
            foreach (int i in arrayNumbers)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;

        }
        
    }
}