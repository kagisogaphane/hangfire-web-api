using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace hangfire_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HangfireController : ControllerBase
{
    //Fire and forget job that send confirmation email to user after registration
    [HttpPost]
    [Route("[action]")]
    public IActionResult Welcome()
    {
        //Create a job and assign a job id to the jobId variable
        var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
       
        return Ok($"Job ID{jobId} welcome email was sent to the user");
    }

    //Delayed job endpoint to send a discount email to the user after certain seconds
    [HttpPost]
    [Route("[action]")]
    public IActionResult Discount()
    {
        int secondsScheduled = 30;
        //Create a job and assign a job id to the jobId variable
        var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("You have a discount available"), TimeSpan.FromSeconds(secondsScheduled));

        return Ok($"Job ID{jobId} discount email will be sent {secondsScheduled} second later");
    }

    //Recurring job endpoint to check the database for recent data each and every minute
    [HttpPost]
    [Route("[action]")]
    public IActionResult DatabaseUpdate()
    {
        RecurringJob.AddOrUpdate(()=> Console.WriteLine("Checking the database for recent data"), Cron.Minutely);

        return Ok("Database check job has been scheduled to run every minute");
    }

    public void SendWelcomeEmail(string text)
    {
        Console.WriteLine(text);
    }
}
