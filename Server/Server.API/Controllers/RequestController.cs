namespace Server.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Server.Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
