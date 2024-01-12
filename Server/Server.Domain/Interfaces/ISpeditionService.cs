using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;

namespace Server.Domain.Interfaces
{
    public interface ISpeditionService
    {
        Task<IEnumerable<Spedition>> GetAll();
        Task<Spedition?> GetById(string id);
        Task<Spedition?> Create(SpeditionRequest request);
    }
}
