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

        public async Task MakeAdminAsync(string userId)
        {
            try
            {
                User? user = await unitOfWork.Users.GetByIdAsync(userId);

                await this.unitOfWork.Admins.AddAsync(user);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ioe.Message);
            }
        }

        public async Task RemoveFromAdminAsync(string userId)
        {
            try
            {
                User? user = await unitOfWork.Users.GetByIdAsync(userId);

                this.unitOfWork.Admins.Remove(user);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ioe.Message);
            }
        }
    }
}
