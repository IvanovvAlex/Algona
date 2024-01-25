using Server.Data.Entites;
using System.Linq.Expressions;

namespace Server.Data.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetAsync(Expression<Func<User?,bool>> predicate);
    }
}
