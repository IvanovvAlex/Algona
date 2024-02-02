using Server.Data.Interfaces.Repositories;

namespace Server.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITruckRepository Trucks { get; }
        
        Task<int> CommitAsync();
        
        IJobRepository Jobs { get; }
        
        ITransportRepository Transports { get; }
        
        ISpeditionRepository Speditions { get; }

        IAdminRepository Admins { get; }

        IUserRepository Users { get; }
    }
}
