namespace Classroom.WeatherAdviser
{
    internal class Program
    {

       public enum WeatherConditions
        {
            Sunny,
            Rainy,
            Cloudy,
            Windy,
            Snowy
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Weather condition here: ");
            var userWeather = Console.ReadLine();
            var parsedWeather = Enum.TryParse(userWeather, out WeatherConditions condition);

        }

        public Dictionary<WeatherConditions, string> Conditions = new()
        {
            {WeatherConditions.Sunny, "Wear a t-shirt and sunglasses" },
            {WeatherConditions.Rainy, "Take Umbrella and go for a walk" },
            {WeatherConditions.Windy, "Stay at home, Avoid going to Didi Dighomi" },
            {WeatherConditions.Snowy, "Go to Bakuriani, or Gudauri" },
            {WeatherConditions.Cloudy, "Take Camera ond go to Photosession" }


        };


    }
}