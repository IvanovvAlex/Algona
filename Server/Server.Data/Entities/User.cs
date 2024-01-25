using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Type = Server.Core.Enums.Type;

namespace Server.Data.Entites
{
    /// <summary>
    /// User Table
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User's last name
        /// </summary>
        [Required]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// User's email
        /// </summary>
        [Required, EmailAddress]
        public override string Email { get; set; } = null!;

        public string? ResetPasswordToken { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ResetPasswordTokenExpiration { get; set; }

        /// <summary>
        /// Type of user
        /// </summary>
        [Required]
        public Type Type { get; set; }

        public ICollection<Cargo> Cargos { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
