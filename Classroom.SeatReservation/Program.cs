using Spectre.Console;
using System.ComponentModel;
using System.Numerics;

namespace Classroom.SeatReservation
{
    internal class Program
    {
        static int[,] seatArray = new int[5, 3];
        static void Main(string[] args)
        {
            Console.WriteLine();

            DisplaySeats(seatArray);
            var operation = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                     .Title("Select an option:\r\n")
                     .PageSize(3)
                     .HighlightStyle("red")
                     .AddChoices(new[] {
            "1) Reserve a seat", "2) View available seats"
                     }));
            Console.WriteLine($"Your choice: {operation}");
            ReserveSeats(seatArray);
            DisplaySeats(seatArray);
        }
        static void DisplaySeats(int[,] seatArray)
        {
           
            Console.WriteLine("Initial Seating Chart:\r\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + seatArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void ReserveSeats(int[,] seatArray)
        {
            Console.WriteLine("Enter the row number: ");
            var num1 = int.TryParse(Console.ReadLine(), out int ParsedNum1);
            Console.WriteLine("Enter the Column number: ");
            var num2 = int.TryParse(Console.ReadLine(),out int ParsedNum2);

           seatArray[ParsedNum1, ParsedNum2] = 1;
           
        }
        
    }
}