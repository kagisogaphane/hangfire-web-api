using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hangfire_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hangfire API is running.");
        }
    }
}
