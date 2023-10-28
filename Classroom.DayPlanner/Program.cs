using System.Security.Cryptography.X509Certificates;

namespace Classroom.DayPlanner
{
    internal class Program
    {

        public enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

        private static Dictionary<WeekDays, string[]> ActivityDictionary = new()
            {
            {WeekDays.Monday, new[] {"Working Hard", "Sleep "} },
            {WeekDays.Tuesday, new[] {"Working", "Meeting"} },
            {WeekDays.Wednesday, new[] {"Working Hard", "GYM", "Healthy Food"}},
            {WeekDays.Thursday, new[] {"Meeting", "Contract sign"} },
            {WeekDays.Friday, new[] {"Drink", "Club"} },
            {WeekDays.Saturday, new[] {"Football", "Rest"} },
            {WeekDays.Sunday, new[] {"Hiking", "Rest"} }
            };
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, Enter day of the week: ");
                var dayOfTheWeek = Enum.TryParse(Console.ReadLine(), out WeekDays day);

                var activities = ActivityDictionary[day];


                foreach (var activity in activities)
                {
                    Console.WriteLine($"Suggested Activity: {activity}");
                }
            }
            catch 
            {
                Console.WriteLine("error! Please enter numbers from 0 to 6, or weekdays!");
            }
           

        }

       


    }
}