using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Entites
{
    /// <summary>
    /// Cargo entity
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// Primary key for cargo
        /// </summary>
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Cargo loading city
        /// </summary>
        [Required]
        public string FromCity { get; set; } = null!;

        /// <summary>
        /// Cargo delivery city
        /// </summary>
        [Required]
        public string ToCity { get; set; } = null!;

        /// <summary>
        /// Cargo loading country
        /// </summary>
        [Required]
        public string FromCountry { get; set; } = null!;

        /// <summary>
        /// Cargo delivery country
        /// </summary>
        [Required]
        public string ToCountry { get; set; } = null!;

        /// <summary>
        /// Date and time of cargo loading
        /// </summary>
        [Required]
        public DateTime FromDateTime { get; set; }

        /// <summary>
        /// Date and time of cargo delivery
        /// </summary>
        [Required]
        public DateTime ToDateTime { get; set; }

        /// <summary>
        /// Cargo distance in kilometers
        /// </summary>
        [Required]
        public double Kilometer { get; set; }

        /// <summary>
        /// Cargo price per kilometer
        /// </summary>
        [Required]
        public decimal PricePerKm { get; set; }

        /// <summary>
        /// Cargo total price
        /// </summary>
        [Required]
        public double TotalPrice { get; set; }

        /// <summary>
        /// Truck id
        /// </summary>
        [ForeignKey(nameof(Truck))]
        public string TruckId { get; set; } = null!;

        /// <summary>
        /// User id
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Truck
        /// </summary>
        public Truck Truck { get; set; } = null!;

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Is cargo deleted. Default value is false. Soft delete.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
