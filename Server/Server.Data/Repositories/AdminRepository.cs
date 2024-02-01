using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using static Server.Common.Constants.GlobalConstants;

namespace Server.Data.Repositories
{
    public class AdminRepository : Repository<User>, IAdminRepository
    {
        private AlgonaDbContext AlgonaContext => (Context as AlgonaDbContext)!;

        public AdminRepository(AlgonaDbContext context) : base(context) { }

        public async void Remove(User entity)
        {
            //TODO
        }

        public async void Add(User entity)
        {
            //TODO
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.AlgonaContext.Users
                    .Include(u => u.Cargos)
                    .ToListAsync();
        }
    }
}