using System.ComponentModel.DataAnnotations;

using static Server.Common.Constants.EntityValidationConstants;

namespace Server.Common.Requests.AuthRequests
{
    public class CreateRegisterRequest
    {
        [Required]
        [MinLength(Register.FirstNameMinLength)]
        [MaxLength(Register.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(Register.LastNameMinLength)]
        [MaxLength(Register.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        [MinLength(Register.EmailMinLength)]
        [MaxLength(Register.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(Register.PasswordMinLength)]
        [MaxLength(Register.PasswordMaxLength)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(Register.ConfirmPasswordMinLength)]
        [MaxLength(Register.ConfirmPasswordMaxLength)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
