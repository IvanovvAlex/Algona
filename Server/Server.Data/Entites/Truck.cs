using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    public class Truck
    {
        public Truck()
        {
            Id = new Guid().ToString();
        }
        
        [Key]
        public string Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
