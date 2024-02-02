namespace Server.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Server.Common.Constants;
    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Domain.Interfaces;

    /// <summary>
    /// Transport controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly ITransportService requestTransportService;
        private readonly ISharedService sharedService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestTransportService"></param>
        public TransportsController(ITransportService requestTransportService, ISharedService sharedService)
        {
            this.requestTransportService = requestTransportService;
            this.sharedService = sharedService;
        }

        /// <summary>
        /// Adds transport
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<TransportRequest> Add(TransportRequest request)
        {
            Transport requestTransport = await requestTransportService.Add(request);

            return request;
        }

        /// <summary>
        /// Gets all transports
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IEnumerable<Transport>> All()
        {
            IEnumerable<Transport> requests = await requestTransportService.GetAll();

            return requests;
        }

        /// <summary>
        /// Sends an infornation email to the user and updates the status of the request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        [HttpPost("Send")]
        public async Task<RequestTransportApproval> Send(RequestTransportApproval request)
        {
            var id = request.Id;
            var status = request.Status;
            var requestTransport = await requestTransportService.UpdateStatus(id, status);
            if (requestTransport == null)
            {
                throw new HttpRequestException($"Transport request with id {id} not found");
            }

            await this.sharedService.SendStatusRequestEmail(requestTransport.Email, EntityValidationConstants.Transport.RequestFor, status, requestTransport.Name);

            return request;
        }
    }
}