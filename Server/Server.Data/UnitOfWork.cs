using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Interfaces;
using Server.Data.Interfaces.Repositories;
using Server.Data.Repositories;

namespace Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlgonaDbContext context;

        private readonly ITruckRepository truckRepository;

        public UnitOfWork(AlgonaDbContext context, ITruckRepository truckRepository)
        {
            this.context = context;
            this.truckRepository = truckRepository;
        }

        public ITruckRepository Trucks => truckRepository ?? new TruckRepository(context);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
