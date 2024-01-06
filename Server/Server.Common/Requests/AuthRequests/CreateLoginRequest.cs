using System.ComponentModel.DataAnnotations;

using static Server.Common.Constants.EntityValidationConstants;


namespace Server.Common.Requests.AuthRequests
{
    public class CreateLoginRequest
    {
        /// <summary>
        /// User's email address
        /// </summary>
        [Required, EmailAddress]
        [MinLength(Login.EmailMinLength)]
        [MaxLength(Login.EmailMaxLength)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User's password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [MinLength(Login.PasswordMinLength)]
        [MaxLength(Login.PasswordMaxLength)]
        public string Password { get; set; } = null!;
    }
}
