using Assignments.BookLibraryApi.DataContextDapper;
using Assignments.BookLibraryApi.Requests;
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
            return Ok();
        }



    }
}
