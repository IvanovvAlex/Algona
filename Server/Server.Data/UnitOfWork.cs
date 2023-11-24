using Server.Data.Interfaces;
using Server.Data.Interfaces.Repositories;
using Server.Data.Repositories;

namespace Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlgonaDbContext context;

        private readonly ITruckRepository truckRepository;

        private readonly ICargoRepository cargoRepository;

        private readonly IJobRepository jobRepository;

        public UnitOfWork(AlgonaDbContext context,
            ICargoRepository cargoRepository,
            ITruckRepository truckRepository,
            IJobRepository jobRepository)
        {
            this.context = context;
            this.cargoRepository = cargoRepository;
            this.truckRepository = truckRepository;
            this.jobRepository = jobRepository;
        }

        public ITruckRepository Trucks => truckRepository ?? new TruckRepository(context);

        public ICargoRepository Cargoes => cargoRepository ?? new CargoRepository(context);

        public IJobRepository Jobs => jobRepository ?? new JobRepository(context);

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
