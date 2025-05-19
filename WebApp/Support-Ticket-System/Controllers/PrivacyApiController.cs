using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Support_Ticket_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivacyApiController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Private data accessible via JWT.");
        }
    }
}
