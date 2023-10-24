namespace Classroom.TempConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose 'F' for Celsius to Farenheit, or 'C', if you wont Farenheit to Celsius");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "f")
                    {
                        Console.WriteLine("Please enter the amount of temperature to convert in Fahrenheit: ");
                        var temp = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"{temp} Celsius in Farenheit is: {ConvertTemperatureToFarenheit(temp)}");
                    }
                    else if (userInput == "c")
                    {
                        Console.WriteLine("Please enter the amount of Farenheit to convert in Celsius: ");
                        var temp = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"{temp} Farenheit in Celsius is: {ConvertFarenheitToCelsius(temp)}");
                    }
                    else
                    {
                        Console.WriteLine("Please enter only 'F' or 'C' ");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter only integers! let's start from the begining");
                    Console.WriteLine(" - - - - - - - - - - - ");

                }

            }

           

           
        }

        static double ConvertTemperatureToFarenheit(double  temperature)
        {
            double farenheit;
            if (temperature < 0)
            {
                farenheit = 0;
            }
            else
            {
                farenheit = (temperature * 9) / 5 + 32; 
            }
            return farenheit;
        }

        static double ConvertFarenheitToCelsius(double temperature)
        {
            double celsius;
            if (temperature < 0)
            {
                return 0;
            }
            else
            {
                celsius = (temperature - 32) * 5 / 9;
            }
            return celsius;
        }
    }
}