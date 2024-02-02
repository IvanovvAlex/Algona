using Server.Common.Constants;
using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    /// <summary>
    /// Spedition service
    /// </summary>
    public class SpeditionService : ISpeditionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeditionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds a spedition request
        /// </summary>
        /// <param name="spedition"></param>
        /// <returns></returns>
        public async Task<Spedition?> Add(SpeditionRequest spedition)
        {
            Spedition request = new Spedition()
            {
                PhoneNumber = spedition.PhoneNumber,
                Name = spedition.Name,
                NumberOfPallets = spedition.NumberOfPallets,
                TotalWeight = spedition.TotalWeight,
                FromAddress = spedition.FromAddress,
                ToAddress = spedition.ToAddress,
                FromDate = spedition.FromDate,
                ToDate = spedition.ToDate,
                Email = spedition.Email,
            };

            await unitOfWork.Speditions.AddAsync(request);
            await unitOfWork.CommitAsync();

            return request;
        }

        /// <summary>
        /// Gets all requests for spedition
        /// </summary>
        public Task<IEnumerable<Spedition>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a request for spedition by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Spedition?> GetById(string id)
        {
            var request = await unitOfWork.Speditions.GetByIdAsync(id);
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
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<Spedition?> UpdateStatus(string id, string status)
        {
            var requestTransport = await GetById(id);
            if (requestTransport == null)
            {
                return null;
            }

            if (status == EntityValidationConstants.Spedition.StatusApproved)
            {
                requestTransport.Status = EntityValidationConstants.Spedition.StatusApproved;
            }
            else if (status == EntityValidationConstants.Spedition.StatusRejected)
            {
                requestTransport.Status = EntityValidationConstants.Spedition.StatusRejected;
            }
            else
            {
                requestTransport.Status = EntityValidationConstants.Spedition.StatusComplete;
            }

            await unitOfWork.CommitAsync();
            return requestTransport;
        }

    }
}
