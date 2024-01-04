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
    public class RequestSpeditionController : ControllerBase
    {
        private readonly IRequestSpeditionService _requestSpeditionService;
        public RequestSpeditionController(IRequestSpeditionService requestSpeditionService)
        {
            _requestSpeditionService= requestSpeditionService;
        }

        [HttpPost("Create")]
        public async Task<SpeditionRequest> Create(SpeditionRequest request)
        {
            RequestSpedition requestSpedition = await _requestSpeditionService.Create(request);

            return request;
        }
    }
}
