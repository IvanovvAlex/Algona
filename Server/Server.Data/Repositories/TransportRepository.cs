namespace Server.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Server.Data.Entities;
    using Server.Data.Interfaces.Repositories;
    /// <summary>
    /// Transport repository
    /// </summary>
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;

        public TransportRepository(AlgonaDbContext context) : base(context) { }

        /// <summary>
        /// Returns all transport requests
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Transport>> GetAllAsync()
        {
            return await AlgonaDbContext
                .Transports
                .ToListAsync();
        }

        /// <summary>
        /// Returns transport entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async ValueTask<Transport?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .Transports
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Add transport entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task AddAsync(Transport entity)
        {
            Transport request = new Transport()
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
        /// Removes transport entity
        /// </summary>
        /// <param name="entity"></param>
        public override async void Remove(Transport entity)
        {
            AlgonaDbContext.Remove(entity);
            await AlgonaDbContext.SaveChangesAsync();
        }

    }
}
