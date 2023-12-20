using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class RequestSpeditionRepository : Repository<RequestSpedition>, IRequestSpeditionRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;
        public RequestSpeditionRepository(AlgonaDbContext context) : base(context) { }

        public async override Task AddAsync(RequestSpedition entity)
        {
            RequestSpedition spedition = new RequestSpedition
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

            await Context.AddAsync(spedition);
            await Context.SaveChangesAsync();
        }

        public async override Task<IEnumerable<RequestSpedition>> GetAllAsync()
        {
            return await AlgonaDbContext
                .RequestSpeditions
                .ToListAsync();
        }

        public async override ValueTask<RequestSpedition?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .RequestSpeditions
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async override void Remove(RequestSpedition entity)
        {
            AlgonaDbContext.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
