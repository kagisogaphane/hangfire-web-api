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

    [HttpPost]
    [Route("[action]")]
    public IActionResult Discount()
    {
        int secondsScheduled = 30;
        //Create a job and assign a job id to the jobId variable
        var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("You have a discount available"), TimeSpan.FromSeconds(secondsScheduled));

        return Ok($"Job ID{jobId} discount email will be sent {secondsScheduled} second later");
    }
    public void SendWelcomeEmail(string text)
    {
        Console.WriteLine(text);
    }
}
