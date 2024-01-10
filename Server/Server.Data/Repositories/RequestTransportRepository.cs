namespace Server.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Server.Data.Entities;
    using Server.Data.Interfaces.Repositories;
    /// <summary>
    /// Request transport repository
    /// </summary>
    public class RequestTransportRepository : Repository<RequestTransport>, IRequestTransportRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;

        public RequestTransportRepository(AlgonaDbContext context) : base(context) { }

        /// <summary>
        /// Returns all requests for transport
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<RequestTransport>> GetAllAsync()
        {
            return await AlgonaDbContext
                .RequestTransports
                .ToListAsync();
        }

        /// <summary>
        /// Returns a request for transport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async ValueTask<RequestTransport?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .RequestTransports
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Add a new request for transport
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task AddAsync(RequestTransport entity)
        {
            RequestTransport request = new RequestTransport()
            {
                Id = entity.Id,
                FromAddress = entity.FromAddress,
                ToAddress = entity.ToAddress,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                NumberOfPallets = entity.NumberOfPallets,
                TotalWeight = entity.TotalWeight,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                IsDeleted = false
            };

            await Context.AddAsync(request);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove a request for transport
        /// </summary>
        /// <param name="entity"></param>
        public override async void Remove(RequestTransport entity)
        {
            AlgonaDbContext.Remove(entity);
            await AlgonaDbContext.SaveChangesAsync();
        }

    }
}
