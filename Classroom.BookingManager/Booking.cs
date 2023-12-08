namespace Classroom.BookingManager
{
    internal partial class Program
    {
        public class Booking
        {
            public string UserId { get; set; }
            public int RoomId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool IncludeBreakfast { get; set; }

            public decimal Price { get; set; }
        }
    }
}
