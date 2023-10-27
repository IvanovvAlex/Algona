using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    public class Truck
    {
        
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
