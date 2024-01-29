using Microsoft.AspNetCore.Mvc;

namespace Assignments.DateAndTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentDateController : ControllerBase
    {
        [HttpGet("/CurrentDateTime")]

        public string GetDate()
        {
            var date =  DateTime.Now;
            string formattedDate = date.ToString("yyyy-MM-dd HH:mm");

            return formattedDate;
        }

    }
}
