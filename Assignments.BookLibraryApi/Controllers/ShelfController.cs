using Assignments.BookLibraryApi.DataContextDapper;
using Assignments.BookLibraryApi.Requests;
using Assignments.BookLibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ShelfController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("s{helfId}")]
        public IActionResult AddToShelf(int shelfId, [FromBody] AddToShelfRequest request)
        {
            // Validate request
            if (request == null)
            {
                return BadRequest("Request body cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.ISBN))
            {
                return BadRequest("Title and ISBN are required.");
            }

            try
            {
                // Create a new Book object based on the request
                var bookToAdd = new Book
                {
                    ShelfId = shelfId,
                    Title = request.Title,
                    ISBN = request.ISBN,
                    Description = request.Description
                };

                // Add the book to the database
                _dataContext.AddBook(bookToAdd);

                return Ok("Book added to shelf successfully.");
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error adding book to shelf: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the book to the shelf.");
            }
        }



    }
}
