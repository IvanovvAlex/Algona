﻿namespace Server.API.Controllers
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
    public class TransportsController : ControllerBase
    {
        private readonly ITransportService requestTransportService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestTransportService"></param>
        public TransportsController(ITransportService requestTransportService)
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
            Transport requestTransport = await requestTransportService.Create(request);

            return request;
        }

        /// <summary>
        /// Gets all requests for transport
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IEnumerable<Transport>> All()
        {
            IEnumerable<Transport> requests = await requestTransportService.GetAll();

            return requests;
        }
    }
}