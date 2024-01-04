
using Microsoft.EntityFrameworkCore;
using Server.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    /// <summary>
    /// Request Spedition Table
    /// </summary>
    public class RequestSpedition
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

        [Required]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        [Required]
        [Range(EntityValidationConstants.Spedition.NumberOfPalletsMinValue, EntityValidationConstants.Spedition.NumberOfPalletsMaxValue)]
        public int NumberOfPallets { get; set; }

        [Required]
        [Range(EntityValidationConstants.Spedition.TotalWeightMinValue, EntityValidationConstants.Spedition.TotalWeightMaxValue)]
        public int TotalWeight { get; set; }

        [Required]
        [MinLength(EntityValidationConstants.Spedition.NameMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

    }
}
