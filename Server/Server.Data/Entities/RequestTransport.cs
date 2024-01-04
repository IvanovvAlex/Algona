namespace Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using Server.Common.Constants;

    /// <summary>
    /// Request for transport entity
    /// </summary>
    public class RequestTransport
    {
        /// <summary>
        /// Primary key of the RequestTransport
        /// </summary>
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

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
        /// Total weight of the transport
        /// </summary>
        [Required]
        [Range(EntityValidationConstants.Transport.TotalWeightMinValue, EntityValidationConstants.Transport.TotalWeightMaxValue)]
        public int TotalWeight { get; set; }

        /// <summary>
        /// Name of sender
        /// </summary>
        [Required]
        [MinLength(EntityValidationConstants.Transport.NameMinLength)]
        [MaxLength(EntityValidationConstants.Transport.NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Phone number of sender
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Email of sender
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Soft delete of the RequestTransport
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
