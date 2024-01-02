namespace Server.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Data.Interfaces;
    using Server.Domain.Interfaces;

    public class RequestTransportService : IRequestTransportService
    {
        private readonly IUnitOfWork unitOfWork;
        
        public RequestTransportService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<RequestTransport> Create(TransportRequest transport)
        {
            RequestTransport request = new RequestTransport()
            {
                PhoneNumber = transport.PhoneNumber,
                Name = transport.Name,
                NumberOfPallets = transport.NumberOfPallets,
                TotalWeight = transport.TotalWeight,
                FromAddress = transport.FromAddress,
                ToAddress = transport.ToAddress,
                FromDate = transport.FromDate,
                ToDate = transport.ToDate,
                Email = transport.Email,
            };

            await unitOfWork.RequestTransport.AddAsync(request);
            await unitOfWork.CommitAsync();

            return request;
        }

        public Task<IEnumerable<RequestTransport>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RequestTransport?> GetById(string id)
        {
            var request = await unitOfWork.RequestTransport.GetByIdAsync(id);
            
            if (request == null)
            {
                return null;
            }
            
            return request;
        }
    }
}
