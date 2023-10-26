using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class TruckRepository : Repository<Truck>, ITruckRepository
    {
        private AlgonaDbContext AlgonaDbContext => Context as AlgonaDbContext;

        public TruckRepository(AlgonaDbContext context) : base(context) { }

        public ValueTask<Truck> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Truck>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Truck entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Truck entity)
        {
            throw new NotImplementedException();
        }
    }
}
