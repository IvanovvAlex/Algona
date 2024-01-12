
using Microsoft.EntityFrameworkCore;
using Server.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    /// <summary>
    /// Request Spedition Table
    /// </summary>
    public class Spedition
    {
        /// <summary>
        /// Spedition identifier
        /// </summary>
        [Key]
        [Comment("Spedition id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// From address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.FromAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.FromAddressMaxLength)]
        [Comment("From address")]
        public string FromAddress { get; set; } = null!;

        /// <summary>
        /// To address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.ToAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.ToAddressMaxLength)]
        [Comment("To address")]
        public string ToAddress { get; set; } = null!;

        /// <summary>
        /// From date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Comment("From date")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// To date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Comment("To date")]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Number of pallets
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Spedition.NumberOfPalletsMinValue, EntityValidationConstants.Spedition.NumberOfPalletsMaxValue)]
        [Comment("Number of pallets")]
        public int NumberOfPallets { get; set; }

        /// <summary>
        /// Total weight
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Spedition.TotalWeightMinValue, EntityValidationConstants.Spedition.TotalWeightMaxValue)]
        [Comment("Total weight")]
        public int TotalWeight { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.NameMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.NameMaxLength)]
        [Comment("Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [Phone]
        [Comment("Phone number")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [EmailAddress]
        [Comment("Email address")]
        public string Email { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

    }
}
