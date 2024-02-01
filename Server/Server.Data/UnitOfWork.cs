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

        private ITransportRepository transportRepository;

        private ISpeditionRepository speditionRepository;

        private IAdminRepository adminRepository;

        public UnitOfWork(AlgonaDbContext context,
            ICargoRepository cargoRepository,
            ITruckRepository truckRepository,
            IJobRepository jobRepository,
            ITransportRepository transportRepository,
            ISpeditionRepository speditionRepository,
            IAdminRepository adminRepository)
        {
            this.context = context;
            this.cargoRepository = cargoRepository;
            this.truckRepository = truckRepository;
            this.jobRepository = jobRepository;
            this.transportRepository = transportRepository;
            this.speditionRepository = speditionRepository;
            this.adminRepository = adminRepository;

        }

        public ITruckRepository Trucks => truckRepository ?? new TruckRepository(context);

        public ICargoRepository Cargoes => cargoRepository ?? new CargoRepository(context);

        public IJobRepository Jobs => jobRepository ?? new JobRepository(context);

        public ITransportRepository Transports => transportRepository ?? new TransportRepository(context);

        public ISpeditionRepository Speditions => speditionRepository ?? new SpeditionRepository(context);

        public IAdminRepository Admins => adminRepository ?? new AdminRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
