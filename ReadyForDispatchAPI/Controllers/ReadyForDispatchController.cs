using Microsoft.AspNetCore.Mvc;
using ReadyForDispatchAPI.ReadyForDispatch.Models;
using ReadyForDispatchAPI.Services.ReadyForDispatch;

namespace ReadyForDispatchAPI.ReadyForDispatch.Controllers;

[ApiController]
[Route("api/dispatch")]
public class ReadyForDispatchController : ControllerBase
{
    private readonly IReadyForDispatchService _readForDispatchService;

    private readonly ILogger<ReadyForDispatchController> _logger;

    public ReadyForDispatchController(ILogger<ReadyForDispatchController> logger, IReadyForDispatchService readyForDispatchService)
    {
        _logger = logger;
        _readForDispatchService = readyForDispatchService;
    }

    [HttpPost("ReadyForDispatch")]
    public IActionResult ReadyForDispatch([FromBody] DispatchRequest dispatchRequest)
    {
        _logger.LogInformation("Request Received: " + dispatchRequest);
        _readForDispatchService.ProcessDispatchRequest(dispatchRequest);
        _logger.LogInformation("Request Finished: " + dispatchRequest);
        
        return Ok();
    }
}
