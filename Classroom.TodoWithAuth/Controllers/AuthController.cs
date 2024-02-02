using Classroom.TodoWithAuth.Auth;
using Classroom.TodoWithAuth.Auth.Db;
using Classroom.TodoWithAuth.Auth.Db.Entities;
using Classroom.TodoWithAuth.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.TodoWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private static List<TodoModel> todos = new List<TodoModel>();


        public AuthController(
       AppDbContext db,
       UserManager<UserEntity> userManager,
       JwtTokenGenerator tokenGenerator)
        {
            db.Database.EnsureCreated();
            _userManager = userManager;
            _jwtTokenGenerator = tokenGenerator;
        }

        [HttpGet]
        [Route("generate-token")]

        public IActionResult GenerateToken()
        {
            var jwt = _jwtTokenGenerator.Generate("1");
            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var entity = new UserEntity
            {
                UserName = request.Email,
                Email = request.Email
            };

            // მომხმარებლის რეგისტრაცია
            var result = await _userManager.CreateAsync(entity, request.Password);

            if (!result.Succeeded)
            {
                var firstError = result.Errors.First();
                return BadRequest(firstError.Description);
            }

            // მომხმარებლისთვის api-user როლის მინიჭება
            var addToRoleResult = await _userManager.AddToRoleAsync(entity, "user");

            return Ok();
        }

        // ავტორიზაცია
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("მომხმარებელი ვერ მოიძებნა");
            }

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isCorrectPassword)
            {
                return BadRequest("ელ.ფოსტა ან პაროლი არასწორია");
            }
            var isApiUser = await _userManager.IsInRoleAsync(user, "api-user");

            var jwt = _jwtTokenGenerator.Generate(user.Id.ToString());
            return Ok(jwt);
        }


        // პაროლის დარესეტების token-ის გენერაცია
        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetRequest request)
        {
            // 1. მომხმარებლის ბაზაში პოვნა 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("მომხმარებელი ვერ მოიძებნა");
            }

            // 2. პაროლის დარესეტების token-ის გენერაცია
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // // 3. მომხმარებლის ელ. ფოსტაზე token-ის გაგზავნა
            // var url = $"https://myapp.com/reset-passowrd/{user.Id.ToString()}/{token}";
            // var emailBody = $"<a href=\"{url}\">Reset password</a>";
            // var emailTitle = $"გამარჯობა, პაროლის შესაცვლელად მიყევით ბმულს: {resetUrl}";
            // _emailSender.Send(emailTitle, emailBody);

            return Ok();
        }

        // პაროლის დარესეტება
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound("მომხმარებელი ვერ მოიძებნა");
            }
            var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            if (!resetResult.Succeeded)
            {
                var firstError = resetResult.Errors.First();
                return StatusCode(500, firstError.Description);
            }

            return Ok();
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
