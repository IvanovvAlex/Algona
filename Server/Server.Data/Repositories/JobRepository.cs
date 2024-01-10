using Microsoft.EntityFrameworkCore;

using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;

namespace Server.Data.Repositories
{
    /// <summary>
    /// Job repository
    /// </summary>
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;

        public JobRepository(AlgonaDbContext context) : base(context){}

        /// <summary>
        /// Returns all jobs
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await AlgonaDbContext
                .Jobs
                .ToListAsync();
        }

        /// <summary>
        /// Returns a job by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async ValueTask<Job?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .Jobs
                .FirstOrDefaultAsync(j => j.Id == id);
        }
    }
}
