using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITruckRepository Trucks { get; }
        Task<int> CommitAsync();
    }
}
