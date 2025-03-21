using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using ReadyForDispatchAPI.ReadyForDispatch.Models;

namespace ReadyForDispatchAPI.Services.ReadyForDispatch
{    

    public class DispatchValidation : IDispatchValidation
    {
        private readonly RequestDbContext _dbContext;

        public DispatchValidation(RequestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ValidateRequest(DispatchRequest dispatchRequest)
        {
            //Check if the order exists

            //If yes, check the control number. If matches, same payload and stop

            //If the control number doesnt match, contiue

            //Check the payload size
                //If greater than the maximum, break
        }

        /// <summary>
        /// Validate if the dispatch request exists
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<bool> DispatchRequestExistsAsync(string requestId)
        {
            if (await _dbContext.ProcessedRequests.AnyAsync(r => r.RequestId == requestId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}