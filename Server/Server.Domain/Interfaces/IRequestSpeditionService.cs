using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;

namespace Server.Domain.Interfaces
{
    public interface IRequestSpeditionService
    {
        Task<IEnumerable<RequestSpedition>> GetAll();
        Task<RequestSpedition?> GetById(string id);
        Task<RequestSpedition?> Create(SpeditionRequest request);
    }
}
