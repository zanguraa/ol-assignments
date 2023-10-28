using System;
using System.Collections.Generic;

namespace Classroom.WeatherAdviser
{
    internal class Program
    {
        public enum WeatherConditions
        {
            sunny,
            rainy,
            cloudy,
            windy,
            snowy
        }

        public static Dictionary<WeatherConditions, string[]> ConditionsDictionary = new()
        {
            {WeatherConditions.sunny, new[] { "Wear a t-shirt and sunglasses", "Go for a hike"} },
            {WeatherConditions.rainy, new[] { "Wear an umbrella", "Walk and listen to your fav musics" } },
            {WeatherConditions.windy, new[] { "Tights or wind pants and long socks will protect your legs", "Avoid going to Didi Dighomi!" } },
            {WeatherConditions.snowy, new[] { "Wear a heavy coat and boots", "Build a snowman" } },
            {WeatherConditions.cloudy, new[] { "Free Dresscode, Wear what you want", "Perfect day for a photo session" } }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Weather condition here: ");
            var userWeather = Console.ReadLine().ToLower();

            if (Enum.TryParse(userWeather, out WeatherConditions condition))
            {
                var conditionSentences = ConditionsDictionary[condition];
                Console.WriteLine("Outfit Suggestion: " + conditionSentences[0]);
                Console.WriteLine("Activity Suggestion: " + conditionSentences[1]);
            }
            else
            {
                Console.WriteLine("Invalid weather condition entered.");
            }
        }
    }
}
