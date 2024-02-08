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

        [HttpGet("{shelfId}")]
        public IActionResult GetShelf(int shelfId)
        {
            try
            {
                var books = _dataContext.GetBooksByShelfId(shelfId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting shelf: {ex.Message}");
                return StatusCode(500, "An error occurred while getting the shelf.");
            }
        }


        [HttpPost("create")]
        public IActionResult CreateShelf([FromBody] CreateShelfRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Shelf name is required.");
            }

            try
            {
                Shelf newShelf = new Shelf
                {
                    Name = request.Name
                };
                _dataContext.AddShelf(newShelf); 
                return Ok("Shelf created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the shelf.");
            }
        }

        [HttpDelete("{shelfId}")]
        public IActionResult DeleteShelf(int shelfId)
        {
            try
            {
                _dataContext.RemoveShelf(shelfId);
                return Ok("Shelf deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the shelf.");
            }
        }

        [HttpPut("{shelfId}")]
        public IActionResult UpdateShelf(int shelfId, [FromBody] RenameShelfRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Shelf name is required.");
            }

            try
            {
                _dataContext.RenameShelf(shelfId, request.Name);
                return Ok("Shelf updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the shelf.");
            }
        }

    }
}
