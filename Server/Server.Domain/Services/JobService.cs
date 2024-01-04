using Server.Data.Entites;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    /// <summary>
    /// Job service
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IUnitOfWork unitOfWork;
        public JobService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns all jobs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Job>> GetAll()
        {
            return await unitOfWork.Jobs.GetAllAsync();
        }

        /// <summary>
        /// Returns a job by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Job?> GetById(string id)
        {
            var job = await unitOfWork.Jobs.GetByIdAsync(id);
            if (job == null)
            {
                return null;
            }
            return job;
        }
    }
}
