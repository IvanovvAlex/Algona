namespace Server.Domain.Interfaces
{
    using Server.Data.Entities;

    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAll();
        Task<Request?> GetById(string id);
        Task<Request?> CreateRequestForTransport(Request request);
    }
}
