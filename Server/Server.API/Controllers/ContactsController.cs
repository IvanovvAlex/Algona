using Microsoft.AspNetCore.Mvc;

using Server.Common.Requests.ContactRequests;
using Server.Domain.Interfaces;

namespace Server.API.Controllers
{
    /// <summary>
    /// Contact controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private ISharedService sharedService;

        public ContactsController(ISharedService sharedService)
        {
            this.sharedService = sharedService;
        }

   
        [HttpPost("Send")]
        public async Task Send(CreateContactRequest request)
        {
            await this.sharedService.EmailSender(request);
        }
    }
}