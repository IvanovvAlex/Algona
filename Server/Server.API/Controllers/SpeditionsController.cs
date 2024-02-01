using Microsoft.AspNetCore.Mvc;
using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Domain.Interfaces;

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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestSpeditionService"></param>
        public SpeditionsController(ISpeditionService requestSpeditionService)
        {
            _requestSpeditionService= requestSpeditionService;
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
    }
}
