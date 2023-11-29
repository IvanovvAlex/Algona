using Server.Data.Entites;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork unitOfWork;
        public JobService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Job>> GetAll()
        {
            return await unitOfWork.Jobs.GetAllAsync();
        }

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
