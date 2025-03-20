using ReadyForDispatchAPI.ReadyForDispatch.Models;

namespace ReadyForDispatchAPI.Services.ReadyForDispatch
{
    public interface IReadyForDispatchService
    {
        void ProcessDispatchRequest(DispatchRequest dispatchRequest);
    }

}