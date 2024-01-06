using System.ComponentModel.DataAnnotations;
using Server.Common.Constants;

namespace Server.Common.Requests.ContactRequests
{
    /// <summary>
    /// Request Contact ViewModel
    /// </summary>
    public class CreateContactRequest
    {
        /// <summary>
        /// Name of the client
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Contact.NameMinLength)]
        [MaxLength(EntityValidationConstants.Contact.NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Company name of the client
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Contact.CompanyNameMinLength)]
        [MaxLength(EntityValidationConstants.Contact.CompanyNameMaxLength)]
        public string CompanyName { get; set; } = null!;

        /// <summary>
        /// Email of the client
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Phone of the client
        /// </summary>
        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Description message from the client
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Contact.DescriptionMinLength)]
        [MaxLength(EntityValidationConstants.Contact.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}