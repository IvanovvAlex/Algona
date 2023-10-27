using Server.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    public class Truck
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public Brand Brand { get; set; }

        [Required]
        public Model Model { get; set; }

        [Required]
        public decimal Kilometers { get; set; }

        [Required]
        public decimal Expenses { get; set; }

        [Required]
        public decimal Income { get; set; }

        [Required]
        public decimal CleanIncome { get; set; }
    }
}
