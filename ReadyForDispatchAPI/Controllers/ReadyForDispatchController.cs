using Microsoft.AspNetCore.Mvc;
using ReadyForDispatchAPI.ReadyForDispatch.Models;

namespace ReadyForDispatchAPI.ReadyForDispatch.Controllers;

[ApiController]
[Route("api/dispatch")]
public class ReadyForDispatchController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ReadyForDispatchController> _logger;

    public ReadyForDispatchController(ILogger<ReadyForDispatchController> logger)
    {
        _logger = logger;
    }

    [HttpPost("ReadyForDispatch")]
    public IActionResult ReadyForDispatch([FromBody] DispatchRequest dispatchRequest)
    {
        _logger.LogInformation("Request Received: " + dispatchRequest);
        return Ok();
    }
}
