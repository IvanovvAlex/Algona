namespace Server.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class RequestTransportController : ControllerBase
    {
        private readonly IRequestTransportService requestTransportService;
        public RequestTransportController(IRequestTransportService requestTransportService)
        {
            this.requestTransportService = requestTransportService;
        }

        [HttpPost("Create")]
        public async Task<TransportRequest> Create(TransportRequest request)
        {
            RequestTransport requestTransport = await requestTransportService.Create(request);

            return request;
        }
    }
}

