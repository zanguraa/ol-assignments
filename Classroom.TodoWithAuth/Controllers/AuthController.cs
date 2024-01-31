using Classroom.TodoWithAuth.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.TodoWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private static List<TodoModel> todos = new List<TodoModel>();

        public AuthController(JwtTokenGenerator tokenGenerator)
        {
            _jwtTokenGenerator = tokenGenerator;
        }

        [HttpGet]
        [Route("generate-token")]

        public IActionResult GenerateToken()
        {
            var jwt = _jwtTokenGenerator.Generate("1");
            return Ok(jwt);
        }


        [HttpGet]
        [Route("test")]
        [Authorize("MyApiUserPolicy", AuthenticationSchemes = "Bearer")]


        public IActionResult Test()
        {
            return Ok("ok");
        }

        [HttpGet]
        [Route("GetTodos")]
        [Authorize("MyApiUserPolicy", AuthenticationSchemes = "Bearer")]

        public IActionResult GetTodos() 
        {
            foreach (var todo in todos)
            {
                Console.WriteLine($"Todo Id: {todo.Id}, Title: {todo.Title}, Description: {todo.IsCompleted}");
            }
            return Ok(todos);
            

        }

        [HttpPost]
        [Route("todos")]
        [Authorize("MyApiUserPolicy", AuthenticationSchemes = "Bearer")]

        public IActionResult AddTodos([FromBody] TodoModel todo)
        {
            if (todo == null)
            {
                return BadRequest("can not be empty!");
            }

            //todo.Id = Guid.NewGuid().ToString();
            //todo.Title = "Test";
            //todo.IsCompleted = true;
            //todo.CreatedAt = DateTime.Now;

            todos.Add(todo);

            return Ok(todo);

        }
    }
}
