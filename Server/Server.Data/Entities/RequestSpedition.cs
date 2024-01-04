
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
        [Comment("Spedition Id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// From Address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.FromAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.FromAddressMaxLength)]
        [Comment("From Address")]
        public string FromAddress { get; set; } = null!;


        [Required]
        [MinLength(EntityValidationConstants.Spedition.ToAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.ToAddressMaxLength)]
        public string ToAddress { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
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
