using System.ComponentModel.DataAnnotations;

namespace Server.Common.Requests.AuthRequests
{
    public class CreateLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
