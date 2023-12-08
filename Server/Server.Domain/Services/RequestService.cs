namespace Server.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Server.Data.Entities;
    using Server.Domain.Interfaces;

    public class RequestService : IRequestService
    {
        public Task<Request?> CreateRequestForTransport(Request request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Request?> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
