using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entites;

namespace Server.Data
{
    public class AlgonaDbContext : DbContext
    {
        public AlgonaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
