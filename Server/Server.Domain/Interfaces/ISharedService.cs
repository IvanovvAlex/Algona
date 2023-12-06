using Server.Common.Requests.ContactRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Interfaces
{
    public interface ISharedService
    {
        Task EmailSender(CreateContactRequest request);
    }
}
