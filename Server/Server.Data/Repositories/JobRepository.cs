using Microsoft.EntityFrameworkCore;

using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;
        public JobRepository(AlgonaDbContext context) : base(context){}

        public override async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await AlgonaDbContext
                .Jobs
                .ToListAsync();
        }

        public override async ValueTask<Job?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .Jobs
                .FirstOrDefaultAsync(j => j.Id == id);
        }
    }
}
