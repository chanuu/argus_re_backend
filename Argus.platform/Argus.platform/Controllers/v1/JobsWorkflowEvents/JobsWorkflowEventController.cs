using Argus.Platform.Application.JobsWorkflowEvents;
using Argus.Platform.Application.Packages;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.JobsWorkflowEvents.Dtos;
using Argus.Platform.Controllers.v1.Packages.Dtos;
using Argus.Platform.Core.JobsWorkflowEvents;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.JobsWorkflowEvents
{
    [ApiController]
    public class JobsWorkflowEventController : ControllerBase
    {
        private readonly IJobsWorkflowEventService _jobsWorkflowEventService;
        public JobsWorkflowEventController(IJobsWorkflowEventService jobsWorkflowEventService)
        {
            _jobsWorkflowEventService = jobsWorkflowEventService;
        }

        [HttpGet(ApiRoutes.JobsWorkflowEvent.GetAll)]
        public async Task<IActionResult> GetAlJobsWorkflowEvents()
        {
            var jobsWorkflowEvent = await _jobsWorkflowEventService.GetAllJobsWorkflowEventsAsync();
            return Ok(jobsWorkflowEvent);
        }

        [HttpGet(ApiRoutes.JobsWorkflowEvent.Get)]
        public async Task<IActionResult> GetJobsWorkflowEvent(Guid id)
        {
            var jobsWorkflowEvent = await _jobsWorkflowEventService.GetJobsWorkflowEventAsync(id);
            if (jobsWorkflowEvent == null)
            {
                return NotFound();
            }
            return Ok(jobsWorkflowEvent);
        }

        [HttpPost(ApiRoutes.JobsWorkflowEvent.Create)]
        public async Task<IActionResult> AddJobsWorkflowEvent(JobsWorkflowEventDto jobsWorkflowEventDto)
        {

            var jobsWorkflowEvent = jobsWorkflowEventDto.Adapt<JobsWorkflowEvent>();

            var addedJobsWorkflowEvent = await _jobsWorkflowEventService.AddJobsWorkflowEventAsync(jobsWorkflowEvent);
            return CreatedAtAction(nameof(GetJobsWorkflowEvent), new { id = addedJobsWorkflowEvent.Id }, addedJobsWorkflowEvent);
        }

        [HttpPut(ApiRoutes.JobsWorkflowEvent.Update)]
        public async Task<IActionResult> UpdateJobsWorkflowEvent(Guid id, JobsWorkflowEventDto jobsWorkflowEventDto)
        {
            var existingJobsWorkflowEvent = await _jobsWorkflowEventService.GetJobsWorkflowEventAsync(id);
            if (existingJobsWorkflowEvent == null)
            {
                return NotFound();
            }

            existingJobsWorkflowEvent = jobsWorkflowEventDto.Adapt< JobsWorkflowEvent>();

            var updatedJobsWorkflowEvent = await _jobsWorkflowEventService.UpdateJobsWorkflowEventAsync(existingJobsWorkflowEvent);
            return Ok(updatedJobsWorkflowEvent);
        }
    }
}
