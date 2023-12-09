namespace Classroom.BookingManager
{
    internal partial class Program
    {

        public class BookingManager
        {
            public void CreateBooking(CreateBookingRequest request)
            {
                User user = GetUserById(request.UserId);
                Room room = GetRoomById(request.RoomId);

                if (user == null)
                {
                    throw new Exception("User not found");
                }
                if (room == null)
                {
                    throw new Exception("Room not found");
                }
                if (request.EndDate <= request.StartDate)
                {
                    throw new Exception("End date must be after start date");
                }



                List<DateTime> bookedDates = GetBookedDatesForRoom(request.RoomId);
                foreach (var date in bookedDates)
                {
                    if ((date >= request.StartDate) && (date <= request.EndDate))
                    {
                        throw new Exception("Room is not available for the selected dates");
                    }
                }

                Booking newBooking = new Booking()
                {
                    UserId = request.UserId,
                    RoomId = request.RoomId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    IncludeBreakfast = request.IncludeBreakfast
                };

                if (request.UseLoyaltyPoints)
                {

                    if (user.LoyaltyPoints >= 100)
                    {
                        newBooking.Price =
                            CalculatePrice(request.RoomId, request.StartDate, request.EndDate) - 10; // Discount for loyalty points
                        user.LoyaltyPoints -= 100;
                    }
                    else
                    {
                        throw new Exception("Not enough loyalty points");
                    }
                }
                
                {
                    newBooking.Price = CalculatePrice(request.RoomId, request.StartDate, request.EndDate);
                }

                SaveBooking(newBooking); // Assume this saves the booking to the database

            }

            private User GetUserById(string userId)
            {
                return new User();
            }

            private Room GetRoomById(int roomId)
            {
                return new Room();
            }

            private List<DateTime> GetBookedDatesForRoom(int roomId)
            {
                return new List<DateTime>();
            }

            private decimal CalculatePrice(int roomId, DateTime startDate, DateTime endDate)
            {
                return 0;
            }

            private void SaveBooking(Booking booking)
            {

            }
        }
    }
}
