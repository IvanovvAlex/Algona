using Microsoft.AspNetCore.Mvc;
using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Domain.Interfaces;

namespace Server.API.Controllers
{
    /// <summary>
    /// Request spedition controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeditionsController : ControllerBase
    {

        private readonly ISpeditionService _requestSpeditionService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestSpeditionService"></param>
        public SpeditionsController(ISpeditionService requestSpeditionService)
        {
            _requestSpeditionService= requestSpeditionService;
        }

        /// <summary>
        /// Creates a new request for spedition
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<SpeditionRequest> Create(SpeditionRequest request)
        {
            Spedition requestSpedition = await _requestSpeditionService.Create(request);

            return request;
        }
    }
}
