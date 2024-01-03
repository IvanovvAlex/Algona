namespace Server.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Domain.Interfaces;

    /// <summary>
    /// Request transport controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTransportController : ControllerBase
    {
        private readonly IRequestTransportService requestTransportService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestTransportService"></param>
        public RequestTransportController(IRequestTransportService requestTransportService)
        {
            this.requestTransportService = requestTransportService;
        }

        /// <summary>
        /// Creates a new request for transport
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<TransportRequest> Create(TransportRequest request)
        {
            RequestTransport requestTransport = await requestTransportService.Create(request);

            return request;
        }

        /// <summary>
        /// Gets all requests for transport
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IEnumerable<RequestTransport>> All()
        {
            IEnumerable<RequestTransport> requests = await requestTransportService.GetAll();

            return requests;
        }
    }
}