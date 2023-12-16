namespace Server.Domain.Interfaces
{
    using Server.Common.Requests.TransportRequest;
    using Server.Data.Entities;

    public interface IRequestTransportService
    {
        Task<IEnumerable<RequestTransport>> GetAll();
        Task<RequestTransport?> GetById(string id);
        Task<RequestTransport> Create(TransportRequest request);
    }
}
