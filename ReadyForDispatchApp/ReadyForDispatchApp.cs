using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace assessment.ReadyForDispatchApp
{
    public class ReadyForDispatchApp
    {
        private readonly ILogger<ReadyForDispatchApp> _logger;
        private readonly HttpClient _httpClient;

        public ReadyForDispatchApp(ILogger<ReadyForDispatchApp> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [Function("ReadyForDispatch")]
        public async Task<IActionResult> PostDispatchRequest(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            FunctionContext context)
        {
            var logger = context.GetLogger("ReadyForDispatch");
            logger.LogInformation("ReadyForDispatch App Triggers");

            // Read input
            var requestBody = await req.ReadAsStringAsync();
            var requestData = JsonSerializer.Deserialize<dynamic>(requestBody);
            string input = requestData?.input;

            // Call the API Controller
            var response = await _httpClient.GetAsync($"http://localhost:5134/api/dispatch/ReadyForDispatch");
            string responseBody = await response.Content.ReadAsStringAsync();

            return new OkObjectResult(responseBody);
        }
    }
}
