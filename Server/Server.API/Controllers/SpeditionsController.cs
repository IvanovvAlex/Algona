using Microsoft.AspNetCore.Mvc;
using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Domain.Interfaces;
using Server.Common.Constants;

namespace Server.API.Controllers
{
    /// <summary>
    /// Spedition controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeditionsController : ControllerBase
    {

        private readonly ISpeditionService _requestSpeditionService;
        private readonly ISharedService sharedService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestSpeditionService"></param>
        public SpeditionsController(ISpeditionService requestSpeditionService, ISharedService sharedService)
        {
            _requestSpeditionService = requestSpeditionService;
            this.sharedService = sharedService;
        }

        /// <summary>
        /// Adds spedition
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<SpeditionRequest> Add(SpeditionRequest request)
        {
            Spedition requestSpedition = await _requestSpeditionService.Add(request);

            return request;
        }

        /// <summary>
        /// Gets all speditions
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IEnumerable<Spedition>> All()
        {
            IEnumerable<Spedition> requests = await _requestSpeditionService.GetAll();

            return requests;
        }
        /// <summary>
        /// Sends an infornation email to the user and updates the status of the request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        [HttpPost("Send")]
        public async Task<RequestSpeditionApproval> Send(RequestSpeditionApproval request)
        {
            var id = request.Id;
            var isApproved = request.IsApproved;
            var requestSpedition = await _requestSpeditionService.UpdateStatus(id, isApproved);
            if (requestSpedition == null)
            {
                throw new HttpRequestException($"Spedition request with id {id} not found");
            }

            await this.sharedService.SendStatusRequestEmail(requestSpedition.Email, EntityValidationConstants.Spedition.RequestFor, isApproved, requestSpedition.Name);

            return request;
        }
    }
}