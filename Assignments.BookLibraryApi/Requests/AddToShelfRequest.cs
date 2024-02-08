using System.ComponentModel.DataAnnotations;

namespace Assignments.BookLibraryApi.Requests
{
    public class AddToShelfRequest
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"^\d{10}|\d{13}$", ErrorMessage = "ISBN must be 10 or 13 digits")]
        public string ISBN { get; set; }

        public string Description { get; set; }
    }
}
