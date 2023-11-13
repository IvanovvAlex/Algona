using System.ComponentModel.DataAnnotations;
using Type = Server.Core.Enums.Type;

namespace Server.Data.Entites
{
    public class User
    {

        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Type Type { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
    }
}
