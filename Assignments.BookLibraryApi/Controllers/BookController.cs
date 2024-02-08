using Assignments.BookLibraryApi.Models;
using Assignments.BookLibraryApi.DataContextDapper;
using Assignments.BookLibraryApi.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignments.BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BookController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("{shelfId}/AddToShelf")]
        public IActionResult AddToShelf(int shelfId, [FromBody] AddToShelfRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.ISBN))
            {
                return BadRequest("Invalid request. Title and ISBN are required.");
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

                return Ok("Book added to the shelf successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the book to the shelf.");
            }
        }

        [HttpPost("{shelfId}/MoveTo")]
        public IActionResult MoveTo(int shelfId, [FromBody] MoveToShelfRequest request)
        {
            if (request == null || request.BookId <= 0 || request.DestinationShelfId <= 0)
            {
                return BadRequest("Invalid move request. Book ID and destination shelf ID are required.");
            }

            try
            {
                var book = _dataContext.GetBookById(request.BookId);
                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                _dataContext.MoveBookToShelf(book.Id, request.DestinationShelfId);

                return Ok("Book moved to the destination shelf successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while moving the book to the shelf.");
            }
        }
    }
}
