using System.ComponentModel.DataAnnotations;

namespace Server.Common.Requests.ContactRequests
{
    public class CreateContactRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}