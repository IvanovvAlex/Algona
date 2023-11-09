using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class TruckRepository : Repository<Truck>, ITruckRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;

        public TruckRepository(AlgonaDbContext context) : base(context) { }

        public override async Task<IEnumerable<Truck>> GetAllAsync()
        {
            return await AlgonaDbContext.Trucks
                .Include(t => t.Cargo)
                .ToListAsync();
        }

        public override async ValueTask<Truck?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext.Trucks
                .Include(t => t.Cargo)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
