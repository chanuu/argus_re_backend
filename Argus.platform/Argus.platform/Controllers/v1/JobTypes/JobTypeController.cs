using Argus.Platform.Application.Complience.DocumentTypes;
using Argus.Platform.Application.Jobs;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.DocumentTypes.DTOs;
using Argus.Platform.Controllers.v1.Jobs.Dtos;
using Argus.Platform.Controllers.v1.JobTypes.Dtos;
using Argus.Platform.Core.Jobs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.JobTypes
{
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }



        [HttpPost(ApiRoutes.JobType.Create)]
        public async Task<IActionResult> AddJobType(JobTypeDto jobTypeDto)
        {

            var jobType = jobTypeDto.Adapt<JobType>();
            var addedJobType = await _jobTypeService.AddJobTypeAsync(jobType);
            return CreatedAtAction(nameof(GetJobType), new { id = addedJobType.Id }, addedJobType);
        }

        [HttpPut(ApiRoutes.JobType.Update)]
        public async Task<IActionResult> UpdateJobType(Guid id, JobTypeDto jobTypeDto)
        {
            var existingJobType = await _jobTypeService.GetJobTypeAsync(id);
            if (existingJobType == null)
            {
                return NotFound();
            }


            existingJobType = jobTypeDto.Adapt<JobType>();
            var updatedJobType = await _jobTypeService.UpdateJobTypeAsync(existingJobType);
            return Ok(existingJobType);
        }

        [HttpGet(ApiRoutes.JobType.GetAll)]
        public async Task<IActionResult> GetAllJobTypes()
        {
            var jobType = await _jobTypeService.GetAllJobTypesAsync();

            return Ok(jobType);
        }

        [HttpGet(ApiRoutes.JobType.Get)]
        public async Task<IActionResult> GetJobType(Guid id)
        {
            var jobType = await _jobTypeService.GetJobTypeAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }
            return Ok(jobType);
        }

    }
}
