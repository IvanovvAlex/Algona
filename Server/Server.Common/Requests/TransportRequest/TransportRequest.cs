namespace Server.Common.Requests.TransportRequest
{
    using System.ComponentModel.DataAnnotations;

    using Server.Common.Constants;

    /// <summary>
    /// Transport view model
    /// </summary>
    public class TransportRequest
    {
        /// <summary>
        /// Sender's address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Transport.FromAddressMinLength)]
        [MaxLength(EntityValidationConstants.Transport.FromAddressMaxLength)]
        public string FromAddress { get; set; } = null!;

        /// <summary>
        /// Receiver's address
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Transport.ToAddressMinLength)]
        [MaxLength(EntityValidationConstants.Transport.ToAddressMaxLength)]
        public string ToAddress { get; set; } = null!;

        /// <summary>
        /// Date from which the transport is available
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Date to which the transport is available
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Number of pallets
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Transport.NumberOfPalletsMinValue, EntityValidationConstants.Transport.NumberOfPalletsMaxValue)]
        public int NumberOfPallets { get; set; }

        /// <summary>
        /// Total weight of the pallets
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Transport.TotalWeightMinValue, EntityValidationConstants.Transport.TotalWeightMaxValue)]
        public int TotalWeight { get; set; }

        /// <summary>
        /// Name of the sender
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Transport.NameMinLength)]
        [MaxLength(EntityValidationConstants.Transport.NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number of the sender
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Email of the sender
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}