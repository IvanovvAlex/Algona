using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Data.Entites;

namespace Server.Data.Configurations
{
    public class TruckEntityTypeConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder
                .HasOne(t => t.Cargo)
                .WithOne(c => c.Truck)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
