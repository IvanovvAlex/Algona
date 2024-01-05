﻿using Microsoft.AspNetCore.Mvc;

using Server.Common.Requests.ContactRequests;
using Server.Domain.Interfaces;

namespace Server.API.Controllers
{
    /// <summary>
    /// Contact controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ISharedService sharedService;

        public ContactController(ISharedService sharedService)
        {
            this.sharedService = sharedService;
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Send(CreateContactRequest request)
        {
            await this.sharedService.EmailSender(request);
        }
    }
}