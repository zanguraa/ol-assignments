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



    }
}
