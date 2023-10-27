using System.Security.Cryptography.X509Certificates;

namespace Classroom.DayPlanner
{
    internal class Program
    {

        public enum WeekDays
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6,
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please, Enter day of the week: ");
            var dayOfTheWeek = Enum.TryParse(Console.ReadLine(), out WeekDays day);

            switch(day)
            {
               case WeekDays.Monday:
                    Console.WriteLine("Working");
                    break;
               case WeekDays.Tuesday:
                    Console.WriteLine("Go to Cinema");
                    break;
               case WeekDays.Wednesday:
                    Console.WriteLine("Working hard");
                    break;
               case WeekDays.Thursday:
                    Console.WriteLine("Go to Luka's Birthday");
                    break;
            case WeekDays.Friday:
                    Console.WriteLine("Drink");
                    break;
                    case WeekDays.Saturday:
                case WeekDays.Sunday:
                    Console.WriteLine("Rest");
                    break;
                 default:
                    Console.WriteLine("Invalid day of the week");
                    break;
            }

        }

    
    }
}