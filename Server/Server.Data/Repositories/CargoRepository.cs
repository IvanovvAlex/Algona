using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        private AlgonaDbContext AlgonaDbContext => Context as AlgonaDbContext;

        public CargoRepository(AlgonaDbContext context) : base(context) { }

        public async ValueTask<Cargo> GetByIdAsync(string id)
        {
            return await AlgonaDbContext.Cargoes
                .Include(c => c.Truck)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await AlgonaDbContext.Cargoes
                .Include(c => c.Truck)
                .ToListAsync();
        }

        public override async Task AddAsync(Cargo entity)
        {
            Cargo cargo = new Cargo()
            {
                Id = entity.Id,
                FromCity = entity.FromCity,
                ToCity = entity.ToCity,
                FromCountry = entity.FromCountry,
                ToCountry = entity.ToCountry,
                FromDateTime = entity.FromDateTime,
                ToDateTime = entity.ToDateTime,
                Kilometer = entity.Kilometer,
                PricePerKm = entity.PricePerKm,
                TotalPrice = entity.TotalPrice,
                TruckId = entity.TruckId,
                Truck = entity.Truck,
            };

            await Context.AddAsync(cargo);
            await Context.SaveChangesAsync();
        }

        public void Remove(Cargo entity)
        {
            Context.Remove(entity);
            Context.SaveChangesAsync();
        }
    }
}
