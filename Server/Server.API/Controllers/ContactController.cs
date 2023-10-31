using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromBody] string info)
        {
            throw new NotImplementedException();
        }
    }
}
