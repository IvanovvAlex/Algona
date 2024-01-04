namespace Server.Common.Requests.JobRequest
{
    public class AllJobsRequest
    {
        /// <summary>
        /// Primary key of the job
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the job
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Salary of the job
        /// </summary>
        public decimal Salary { get; set; }
    }
}