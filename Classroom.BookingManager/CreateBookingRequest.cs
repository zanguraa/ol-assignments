using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.BookingManager
{
    internal class CreateBookingRequest
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeBreakfast { get; set; }
        public bool UseLoyaltyPoints { get; set; }
    }
}
