namespace Server.Common.Requests.JobRequest
{
    public class AllJobsRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}