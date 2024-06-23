using Argus.Platform.Application.Complience;
using Argus.Platform.Application.Jobs;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Documents.DTOs;
using Argus.Platform.Controllers.v1.Jobs.Dtos;
using Argus.Platform.Controllers.v1.Packages.Dtos;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Jobs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Jobs
{
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
           _jobService = jobService;
        }

        [HttpGet(ApiRoutes.Job.GetAll)]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet(ApiRoutes.Job.Get)]
        public async Task<IActionResult> GetJob(Guid id)
        {
            var job = await _jobService.GetJobAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost(ApiRoutes.Job.Create)]
        public async Task<IActionResult> AddJob(JobDto jobDto)
        {
           
            var job = jobDto.Adapt<Job>();
            var addedJob = await _jobService.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJob), new { id = addedJob.Id }, addedJob);
        }

        [HttpPut(ApiRoutes.Job.Update)]
        public async Task<IActionResult> UpdateJob(Guid id, JobDto jobDto)
        {
            var existingJob = await _jobService.GetJobAsync(id);
            if (existingJob == null)
            {
                return NotFound();
            }


            existingJob = jobDto.Adapt<Job>();
            var updatedJob = await _jobService.UpdateJobAsync(existingJob);
            return Ok(updatedJob);
        }

       
    }
}
