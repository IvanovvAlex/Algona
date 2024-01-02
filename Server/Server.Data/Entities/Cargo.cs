using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Entites
{
    public class Cargo
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string FromCity { get; set; } = null!;

        [Required]
        public string ToCity { get; set; } = null!;

        [Required]
        public string FromCountry { get; set; } = null!;

        [Required]
        public string ToCountry { get; set; } = null!;

        [Required]
        public DateTime FromDateTime { get; set; }

        [Required]
        public DateTime ToDateTime { get; set; }

        [Required]
        public double Kilometer { get; set; }

        [Required]
        public decimal PricePerKm { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [ForeignKey(nameof(Truck))]
        public string TruckId { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public Truck Truck { get; set; } = null!;
        
        public User User { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
