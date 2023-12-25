using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;
using Server.Data.Entities;

namespace Server.Data
{
    public class AlgonaDbContext : IdentityDbContext<User>
    {
        public AlgonaDbContext(DbContextOptions<AlgonaDbContext> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Cargo> Cargoes { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<RequestTransport> RequestTransport { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cargo>(e =>
            {
                e.HasOne(c => c.Truck)
                .WithOne(t => t.Cargo)
                .OnDelete(DeleteBehavior.NoAction);
            });

        }
    }
}
