namespace Classroom.WeekdayOrWeekend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var weekdays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var month = DateTime.Now.Month;
            Console.WriteLine("Hello, please enter one of the day of weekend: ");
            var day = Console.ReadLine();
            Weekday(day);
            Console.WriteLine("This months is in ");
            MonthQuarter(month);
        }
        static void Weekday(string day)
        {
            switch (day.ToLower())
            {
                case "saturday":
                case "sunday":
                    Console.WriteLine("It is weekend");
                    break;
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                    Console.WriteLine("It is weekday");
                    break;
                default:
                    Console.WriteLine("Please enter a valid day");
                    break;
            }
        }
        static void MonthQuarter(int month)
        {
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("Q1");
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine("Q2");
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine("Q3");
                    break;
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Q4");
                    break;
                default:
                    Console.WriteLine("Please enter a valid month");
                    break;
            }
        }
    }
}