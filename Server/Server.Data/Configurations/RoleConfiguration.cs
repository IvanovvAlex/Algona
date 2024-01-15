using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Server.Common.Constants.GlobalConstants;

namespace Server.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            var roles = new List<IdentityRole>();

            var role = new IdentityRole()
            {
                Id = AdminRoleId,
                Name = AdminRole,
                ConcurrencyStamp = AdminRoleConcurrencyStamp,
                NormalizedName = AdminRole.ToUpper()
            };
            roles.Add(role);

            role = new IdentityRole()
            {
                Id = ClientRoleId,
                Name = ClientRole,
                ConcurrencyStamp = ClientRoleConcurrencyStamp,
                NormalizedName = ClientRole.ToUpper()
            };

            roles.Add(role);
            return roles;
        }
    }
}