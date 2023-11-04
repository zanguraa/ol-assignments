namespace Classroom.SeatReservation
{
    internal class Program
    {
        static int[,] seatArray = new int[5, 3];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DisplaySeats(seatArray);
        }

        static void DisplaySeats(int[,] seatArray)
        {
            Console.WriteLine("Seat Reservation System\n");
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