using ReadyForDispatchAPI.ReadyForDispatch.Models;

namespace ReadyForDispatchAPI.Services.ReadyForDispatch
{
    public interface IDispatchValidation
    {
        void ValidateRequest(DispatchRequest dispatchRequest);
    }
}