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
    } 
}
