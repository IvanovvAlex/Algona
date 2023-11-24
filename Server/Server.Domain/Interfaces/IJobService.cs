namespace Server.Domain.Interfaces
{
    using Server.Common.Requests.JobRequest;
    using Server.Data.Entites;

    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();
        Task<Job?> GetById(string id);
    }
}
