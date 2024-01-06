using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    /// <summary>
    /// Cargo repository
    /// </summary>
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        private AlgonaDbContext AlgonaDbContext => Context as AlgonaDbContext;

        public CargoRepository(AlgonaDbContext context) : base(context) { }

        /// <summary>
        /// Get cargo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask<Cargo> GetByIdAsync(string id)
        {
            return await AlgonaDbContext.Cargoes
                .Include(c => c.Truck)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Get all cargoes
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await AlgonaDbContext.Cargoes
                .Include(c => c.Truck)
                .ToListAsync();
        }

        /// <summary>
        /// Add cargo
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove cargo
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(Cargo entity)
        {
            Context.Remove(entity);
            Context.SaveChangesAsync();
        }
    }
}
