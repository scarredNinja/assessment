using ReadyForDispatchAPI.ReadyForDispatch.Models;

namespace ReadyForDispatchAPI.Services.ReadyForDispatch
{    
    public class ReadyForDispatchService : IReadyForDispatchService
    {
        private readonly ILogger<ReadyForDispatchService> _logger;
        private readonly IDispatchValidation _dispatchValidation;

        public ReadyForDispatchService(ILogger<ReadyForDispatchService> logger, IDispatchValidation dispatchValidation)
        {
            _logger = logger;
            _dispatchValidation = dispatchValidation;
        }

        public void ProcessDispatchRequest(DispatchRequest dispatchRequest)
        {
            _logger.LogInformation("Started Processing Dispatch Request: " + dispatchRequest.ToString());
            
            try
            {
                // Validation - this could return a boolean to indicate if validation passed or throws an exception and we handle the exception in a try catch
                _dispatchValidation.ValidateRequest(dispatchRequest);

                //Process Request
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception Thrown: " + ex.Message);
            }
        }
    }
}