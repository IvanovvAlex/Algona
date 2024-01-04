using Server.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Server.Common.Requests.SpeditionRequest
{
    /// <summary>
    /// Request Spedition ViewModel
    /// </summary>
    public class SpeditionRequest
    {
        /// <summary>
        /// From address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.FromAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.FromAddressMaxLength)]
        public string FromAddress { get; set; } = null!;

        /// <summary>
        /// To address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.ToAddressMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.ToAddressMaxLength)]
        public string ToAddress { get; set; } = null!;

        /// <summary>
        /// From date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// To date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Number of pallets
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Spedition.NumberOfPalletsMinValue, EntityValidationConstants.Spedition.NumberOfPalletsMaxValue)]
        public int NumberOfPallets { get; set; }

        /// <summary>
        /// Total weight
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Spedition.TotalWeightMinValue, EntityValidationConstants.Spedition.TotalWeightMaxValue)]
        public int TotalWeight { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Spedition.NameMinLength)]
        [MaxLength(EntityValidationConstants.Spedition.NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
