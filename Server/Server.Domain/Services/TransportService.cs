namespace Server.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Server.Common.Constants;
    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;
    using Server.Data.Interfaces;
    using Server.Domain.Interfaces;

    /// <summary>
    /// Transport service
    /// </summary>
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork unitOfWork;
        
        public TransportService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Adds a new request for transport
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

        /// <summary>
        /// Updates the status of the request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isApproved"></param>
        /// <returns></returns>
        public async Task<Transport?> UpdateStatus(string id, bool isApproved)
        {
            var requestTransport = await GetById(id);
            if (requestTransport == null)
            {
                return null;
            }
            
            if(isApproved)
            {
                requestTransport.Status = EntityValidationConstants.Transport.StatusApproved;
            }
            else
            {
                requestTransport.Status = EntityValidationConstants.Transport.StatusRejected;
            }

            await unitOfWork.CommitAsync();
            return requestTransport;
        }
    }
}
