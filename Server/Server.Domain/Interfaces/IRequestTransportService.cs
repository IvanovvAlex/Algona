
namespace Server.Domain.Interfaces
{
    using Server.Data.Entities;
    using Server.Common.Requests.TransportRequest;

    public interface IRequestTransportService
    {
        Task<IEnumerable<RequestTransport>> GetAll();
        Task<RequestTransport?> GetById(string id);
        Task<RequestTransport?> Create(TransportRequest request);
    }
}
