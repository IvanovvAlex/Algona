using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Data.Entites;

using static Server.Common.Constants.GlobalConstants;

namespace Server.Data.Configurations
{
    internal class UserConfuguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUser());
        }

        private User CreateUser()
        {
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = AdminId,
                FirstName = AdminFirstName,
                LastName = AdminLastName,
                Email = MainEmail,
                NormalizedEmail = MainEmail.ToUpper(),
                UserName = MainEmail,
                NormalizedUserName = MainEmail.ToUpper(),
                ConcurrencyStamp = AdminConcurrencyStamp
            };
            user.PasswordHash = hasher.HashPassword(user, AdminPassword);

            return user;
        }
    }
}
