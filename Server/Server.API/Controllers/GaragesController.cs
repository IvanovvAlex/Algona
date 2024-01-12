using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Photos()
        {
            return NotFound();
        }
    }
}
