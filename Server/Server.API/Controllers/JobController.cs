using Microsoft.AspNetCore.Mvc;

using Server.Common.Requests.JobRequest;
using Server.Data.Entites;
using Server.Domain.Interfaces;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService  jobService;
        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet("Index")]
        public async Task<IEnumerable<AllJobsRequest>> Index()
        {
            IEnumerable<Job> jobs = await jobService.GetAll();

            List<AllJobsRequest> allJobsRequests = new List<AllJobsRequest>();
            foreach (Job job in jobs)
            {
                var result = new AllJobsRequest();
                result.Id = Guid.Parse(job.Id);
                result.Title = job.Title;
                result.Salary = job.Salary;
                allJobsRequests.Add(result);
            }
            return allJobsRequests;
        }

        [HttpGet("details/{id}")]
        public async Task<Job> Details(string id)
        {
            var job = await jobService.GetById(id);
            if (job == null)
            {
                throw new HttpRequestException("Job not found");
            }
            return job;
        }
    }
}