namespace Assignments.BookLibraryApi.Requests
{
    public class MoveToShelfRequest
    {
        public int BookId { get; set; }
        public int DestinationShelfId { get; set; }
    }
}
