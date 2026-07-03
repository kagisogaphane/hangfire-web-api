using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace hangfire_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HangfireController : ControllerBase
{
    [HttpPost]
    [Route("[action]")]
    public IActionResult Welcome()
    {
        //Create a job and assign a job id to the jobId variable
        var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
       
        return Ok($"Job ID{jobId} welcome email was sent to the user");
    }

    public void SendWelcomeEmail(string text)
    {
        Console.WriteLine(text);
    }
}
