using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSample.Controllers
{
    [Authorize]
    [Route("secure")]
    public class SecureController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Authenticated!");
        }
    }
}
