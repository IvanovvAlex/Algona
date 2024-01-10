using Server.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Entites
{
    /// <summary>
    /// Truck Table
    /// </summary>
    public class Truck
    {
        /// <summary>
        /// Truck identifier
        /// </summary>
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Truck's brand
        /// </summary>
        [Required]
        public Brand Brand { get; set; }

        /// <summary>
        /// Truck's model
        /// </summary>
        [Required]
        public Model Model { get; set; }

        /// <summary>
        /// Kilometers of truck
        /// </summary>
        [Required]
        public decimal Kilometers { get; set; }

        /// <summary>
        /// Truck's expenses
        /// </summary>
        [Required]
        public decimal Expenses { get; set; }

        /// <summary>
        /// Truck's income
        /// </summary>
        [Required]
        public decimal Income { get; set; }

        /// <summary>
        /// Truck's clean income
        /// </summary>
        [Required]
        public decimal CleanIncome { get; set; }

        [ForeignKey(nameof(Cargo))]
        public string CargoId { get; set; } = null!;

        public Cargo Cargo { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
