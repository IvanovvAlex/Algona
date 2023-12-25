using System.ComponentModel.DataAnnotations;
using Server.Common.Constants;

namespace Server.Common.Requests.ContactRequests
{
    public class CreateContactRequest
    {
        [Required]
        [MinLength(EntityValidationConstants.Contact.NameMinLength)]
        [MaxLength(EntityValidationConstants.Contact.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(EntityValidationConstants.Contact.CompanyNameMinLength)]
        [MaxLength(EntityValidationConstants.Contact.CompanyNameMaxLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        [Required]
        [MinLength(EntityValidationConstants.Contact.DescriptionMinLength)]
        [MaxLength(EntityValidationConstants.Contact.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}