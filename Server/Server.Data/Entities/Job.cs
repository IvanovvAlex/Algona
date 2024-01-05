using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    /// <summary>
    /// Job entity
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Primary key for job
        /// </summary>
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Is job active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is job deleted. Default value is false. Soft delete.
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Job title
        /// </summary>
        [Required]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Job description
        /// </summary>
        [Required]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Job salary
        /// </summary>
        [Required]
        public decimal Salary { get; set; }
    }
}
