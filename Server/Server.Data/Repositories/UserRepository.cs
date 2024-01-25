using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using System.Linq.Expressions;

namespace Server.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AlgonaDbContext AlgonaContext => (Context as AlgonaDbContext)!;

        public UserRepository(AlgonaDbContext context) : base(context) { }

        public override async Task AddAsync(User entity)
        {
            await this.AlgonaContext.AddAsync(entity);
            await this.AlgonaContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.AlgonaContext.Users
                .Include(u => u.Cargos)
                .ToListAsync();
        }

        public override async ValueTask<User?> GetByIdAsync(string id)
        {
            return await this.AlgonaContext.Users
                .FindAsync(id);
        }


        public override async void Remove(User entity)
        {
            this.AlgonaContext.Remove(entity);
            await this.AlgonaContext.SaveChangesAsync();
        }

        public async Task<User?> GetAsync(Expression<Func<User?, bool>> predicate) 
        {
            return await this.AlgonaContext.Users
                .FirstOrDefaultAsync(predicate);
        }
    }
}
