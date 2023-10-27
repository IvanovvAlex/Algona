using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entites
{
    public class Cargo
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string FromCity { get; set; } 
        
        [Required]
        public string ToCity { get; set; }

        [Required]
        public string FromCountry { get; set; }

        [Required]
        public string ToCountry { get; set; }

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

        [Required]
        [ForeignKey("Truck")]
        public string TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}
