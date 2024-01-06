using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    /// <summary>
    /// Job Table
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Job Identifier
        /// </summary>
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        [Required]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Job Description
        /// </summary>
        [Required]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Job Salary
        /// </summary>
        [Required]
        public decimal Salary { get; set; }
    }
}
