using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    /// <summary>
    /// Request spedition service
    /// </summary>
    public class SpeditionService : ISpeditionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeditionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a spedition request
        /// </summary>
        /// <param name="spedition"></param>
        /// <returns></returns>
        public async Task<Spedition?> Create(SpeditionRequest spedition)
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
    }
}
