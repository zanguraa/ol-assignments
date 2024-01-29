using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.DateAndTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentLondonDateController
    {
        [HttpGet("/CurrentLondonDate")]

        public string CurrentLondonDate()
        {
            var tbilisiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tbilisi");
            var tbilisiTime = TimeZoneInfo.ConvertTime(DateTime.Now, tbilisiTimeZone);

            var londonTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"); 
            var londonTime = TimeZoneInfo.ConvertTime(tbilisiTime, londonTimeZone);

            return londonTime.ToString();
        }
    }
}
