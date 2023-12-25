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

        private IRequestTransportRepository requestTransportRepository;

        private IRequestSpeditionRepository requestSpeditionRepository;

        public UnitOfWork(AlgonaDbContext context,
            ICargoRepository cargoRepository,
            ITruckRepository truckRepository,
            IJobRepository jobRepository,
            IRequestTransportRepository requestTransportRepository,
            IRequestSpeditionRepository requestSpeditionRepository)
        {
            this.context = context;
            this.cargoRepository = cargoRepository;
            this.truckRepository = truckRepository;
            this.jobRepository = jobRepository;
            this.requestTransportRepository = requestTransportRepository;
            this.requestSpeditionRepository = requestSpeditionRepository;
        }

        public ITruckRepository Trucks => truckRepository ?? new TruckRepository(context);

        public ICargoRepository Cargoes => cargoRepository ?? new CargoRepository(context);

        public IJobRepository Jobs => jobRepository ?? new JobRepository(context);

        public IRequestTransportRepository RequestTransport => requestTransportRepository ?? new RequestTransportRepository(context);

        public IRequestSpeditionRepository RequestSpedition => requestSpeditionRepository ?? new RequestSpeditionRepository(context);

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
