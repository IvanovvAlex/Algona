using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using static Server.Common.Constants.GlobalConstants;

namespace Server.Data.Repositories
{
    public class AdminRepository : Repository<User>, IAdminRepository
    {
        private AlgonaDbContext AlgonaContext => (Context as AlgonaDbContext)!;

        private readonly UserManager<User> userManager;

        public AdminRepository(AlgonaDbContext context, UserManager<User> userManager) 
            : base(context) 
        {
            this.userManager = userManager;
        }

        public override async void Remove(User entity)
        {
            var result = await this.userManager.RemoveFromRoleAsync(entity, AdminRole);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errorMessage);
            }
        }

        public override async Task AddAsync(User entity)
        {
            var result = await this.userManager.AddToRoleAsync(entity, AdminRole);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errorMessage);
            }
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.AlgonaContext.Users
                    .Include(u => u.Cargos)
                    .ToListAsync();
        }
    }
}