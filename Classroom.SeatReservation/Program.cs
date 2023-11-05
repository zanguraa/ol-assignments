using Spectre.Console;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace Classroom.SeatReservation
{
    internal class Program
    {
        static int[,] seatArray = new int[5, 3];
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                var operation = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                         .Title("Select an option:\r\n")
                         .PageSize(3)
                         .HighlightStyle("red")
                         .AddChoices(new[] {
            "1) Reserve a seat", "2) View available seats"
                         }));
                Console.WriteLine($"Your choice: {operation}");
                
                if(operation == "1) Reserve a seat")
                {
                    ReserveSeats(seatArray);
                    DisplaySeats(seatArray);
                }
                else
                {
                    var avialableSeats = AvailableSeats(seatArray);
                    Console.WriteLine($"Avialable seats: {avialableSeats}");
                }
            }          
        }
        static void DisplaySeats(int[,] seatArray )
        {
            if(CheckIfAllZeros(seatArray))
            {
                Console.WriteLine("Initial Seating Chart: ");
            } else
            {
                Console.WriteLine("Updated Seating Chart: ");
            }
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
            try
            {
                Console.WriteLine("Enter the row number: ");
                var num1Input = Console.ReadLine();
                if (!int.TryParse(num1Input, out int ParsedNum1) || ParsedNum1 < 0 || ParsedNum1 >= seatArray.GetLength(0))
                {
                    Console.WriteLine("Invalid input for the row number.");
                    return;
                }

                Console.WriteLine("Enter the Column number: ");
                var num2Input = Console.ReadLine();
                if (!int.TryParse(num2Input, out int ParsedNum2) || ParsedNum2 < 0 || ParsedNum2 >= seatArray.GetLength(1))
                {
                    Console.WriteLine("Invalid input for the column number.");
                    return;
                }

                if (seatArray[ParsedNum1, ParsedNum2] == 0)
                {
                    seatArray[ParsedNum1, ParsedNum2] = 1;
                    Console.WriteLine("Seat reserved.");
                }
                else
                {
                    Console.WriteLine("Seat is already reserved, try a different position.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static bool CheckIfAllZeros(int[,] seatArray)
        {
            for (int i = 0; i < seatArray.GetLength(0); i++)
            {
                for (int j = 0; j < seatArray.GetLength(1); j++)
                {
                    if (seatArray[i, j] != 0)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
        static int AvailableSeats(int[,] seatArray)
        {
            int num = 0;
            for (int i = 0;i < seatArray.GetLength(0);i++)
            {
                for(int j = 0;j < seatArray.GetLength(1);j++)
                {
                    if (seatArray[i, j] == 0)
                    {
                        num++;
                    }
                }
            }
            return num;
        }
    }
}