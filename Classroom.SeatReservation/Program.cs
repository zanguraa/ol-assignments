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
            Console.WriteLine("Select an option:\r\n");
           
            var userChoice = Console.ReadLine();
            var choosedSeats = userChoice.Split(",", StringSplitOptions.RemoveEmptyEntries);
            DisplaySeats(seatArray);
            
        }
        static void DisplaySeats(int[,] seatArray)
        {
            Console.WriteLine("Initial Seating Chart:\r\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(seatArray[i, j] + "");
                }
                Console.WriteLine();
            }
        }
    }
}