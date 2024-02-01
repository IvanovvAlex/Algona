using Server.Data.Entites;

namespace Server.Domain.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
