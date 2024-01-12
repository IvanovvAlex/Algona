namespace Server.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Data.Interfaces;
    using Server.Domain.Interfaces;

    /// <summary>
    /// Request transport service
    /// </summary>
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork unitOfWork;
        
        public TransportService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Creates a new request for transport
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        public async Task<Transport> Add(TransportRequest transport)
        {
            Transport request = new Transport()
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

            await unitOfWork.Transports.AddAsync(request);
            await unitOfWork.CommitAsync();

            return request;
        }

        /// <summary>
        /// Gets all requests for transport
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Transport>> GetAll()
        {
            var requests = await unitOfWork.Transports.GetAllAsync();
            return requests;
        }

        /// <summary>
        /// Gets a request for transport by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transport?> GetById(string id)
        {
            var request = await unitOfWork.Transports.GetByIdAsync(id);
            
            if (request == null)
            {
                return null;
            }
            
            return request;
        }
    }
}
