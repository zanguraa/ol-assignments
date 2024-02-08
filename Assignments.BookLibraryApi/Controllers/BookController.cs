using Assignments.BookLibraryApi.Models;
using Assignments.BookLibraryApi.DataContextDapper;
using Assignments.BookLibraryApi.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext? _dataContext;


        [HttpPost("{shelfId}")]
        public IActionResult AddToShelf(int shelfId, [FromBody] AddToShelfRequest request)
        {
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
                var bookToAdd = new Book
                {
                    ShelfId = shelfId,
                    Title = request.Title,
                    ISBN = request.ISBN,
                    Description = request.Description
                };

                _dataContext.AddBook(bookToAdd);

                return Ok("Book added to shelf successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book to shelf: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the book to the shelf.");
            }
        }
    }
}
