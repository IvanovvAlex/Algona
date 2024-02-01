using Microsoft.AspNetCore.Identity;
using Server.Data.Entites;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await unitOfWork.Admins.GetAllAsync();
        }
    }
}
