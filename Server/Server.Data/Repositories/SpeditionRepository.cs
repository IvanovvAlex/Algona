using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class SpeditionRepository : Repository<Spedition>, ISpeditionRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;

        public SpeditionRepository(AlgonaDbContext context) : base(context) { }

        public async override Task AddAsync(Spedition entity)
        {
            Spedition spedition = new Spedition
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

        public async override Task<IEnumerable<Spedition>> GetAllAsync()
        {
            return await AlgonaDbContext
                .Speditions
                .ToListAsync();
        }

        public async override ValueTask<Spedition?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .Speditions
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async override void Remove(Spedition entity)
        {
            AlgonaDbContext.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
