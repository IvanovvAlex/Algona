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
        
        public DbSet<RequestTransport> RequestTransports { get; set; }
        
        public DbSet<RequestSpedition> RequestSpeditions { get; set; }

    }
}
