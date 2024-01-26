using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        [HttpGet("/Add")]

        public int Add([FromForm]int a, [FromForm]int b)
        {
            int sum = a + b;
            return sum;
        }


        [HttpPost("subtract")]

        public int Subtract([FromBody]SubtractRequest request)
        {
            return request.A - request.B;
        }


    }


}
