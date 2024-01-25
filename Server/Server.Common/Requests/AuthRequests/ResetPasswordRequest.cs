using System.ComponentModel.DataAnnotations;
using static Server.Common.Constants.EntityValidationConstants;

namespace Server.Common.Requests.AuthRequests
{
    public class ResetPasswordRequest
    {
        /// <summary>
        /// User's email address
        /// </summary>
        [Required, EmailAddress]
        [MinLength(Register.EmailMinLength)]
        [MaxLength(Register.EmailMaxLength)]
        public string Token { get; set; } = null!;

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
