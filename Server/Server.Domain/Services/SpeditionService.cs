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
                CurrentTime = DateTime.UtcNow,
                Status = "Waiting for approval"
            };

            await unitOfWork.Speditions.AddAsync(request);
            await unitOfWork.CommitAsync();

            return request;
        }

        /// <summary>
        /// Gets all requests for spedition
        /// </summary>
        public async Task<IEnumerable<Spedition>> GetAll()
        {
            var requests = await unitOfWork.Speditions.GetAllAsync();
            return requests;
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
    }
}
