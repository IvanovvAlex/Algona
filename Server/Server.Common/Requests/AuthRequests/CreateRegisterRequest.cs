using System.ComponentModel.DataAnnotations;

using static Server.Common.Constants.EntityValidationConstants;

namespace Server.Common.Requests.AuthRequests
{
    public class CreateRegisterRequest
    {
        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        [MinLength(Register.FirstNameMinLength)]
        [MaxLength(Register.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User's last name
        /// </summary>
        [Required]
        [MinLength(Register.LastNameMinLength)]
        [MaxLength(Register.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// User's email address
        /// </summary>
        [Required, EmailAddress]
        [MinLength(Register.EmailMinLength)]
        [MaxLength(Register.EmailMaxLength)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User's password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [MinLength(Register.PasswordMinLength)]
        [MaxLength(Register.PasswordMaxLength)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// User's confirm password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(Register.ConfirmPasswordMinLength)]
        [MaxLength(Register.ConfirmPasswordMaxLength)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
