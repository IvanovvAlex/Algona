using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Configurations;
using Server.Data.Entites;
using Server.Data.Entities;

using static Server.Common.Constants.GlobalConstants;

namespace Server.Data
{
    public class AlgonaDbContext : IdentityDbContext<User>
    {
        public AlgonaDbContext(DbContextOptions<AlgonaDbContext> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Cargo> Cargoes { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Spedition> Speditions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TruckEntityTypeConfiguration());

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new UserConfuguration());

            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>() { RoleId = AdminRoleId, UserId = AdminId }
               );
        }
    }
}
