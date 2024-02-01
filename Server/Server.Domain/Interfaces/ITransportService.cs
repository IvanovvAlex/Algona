
namespace Server.Domain.Interfaces
{
    using Server.Data.Entities;
    using Server.Common.Requests.TransportRequest;

    public interface ITransportService
    {
        Task<IEnumerable<Transport>> GetAll();
        Task<Transport?> GetById(string id);
        Task<Transport?> Add(TransportRequest request);
        Task<Transport?> UpdateStatus(string id, bool isApproved);
    }
}
