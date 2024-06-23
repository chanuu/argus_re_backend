using Argus.Platform.Application.Customers;
using Argus.Platform.Application.JobEvents;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Customers.Dtos;
using Argus.Platform.Controllers.v1.JobEvents.Dtos;
using Argus.Platform.Core.JobEvents;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.JobEvents
{
    [ApiController]
    public class JobEventController : Controller
    {
        private readonly IJobEventService _jobEventService;
        public JobEventController(IJobEventService jobEventService)
        {
            _jobEventService = jobEventService;
        }

        [HttpGet(ApiRoutes.JobEvent.GetAll)]
        public async Task<IActionResult> GetAlJobEvents()
        {
            var jobEvent = await _jobEventService.GetAllJobEventsAsync();
            return Ok(jobEvent);
        }

        [HttpGet(ApiRoutes.JobEvent.Get)]
        public async Task<IActionResult> GetJobEvent(Guid id)
        {
            var jobEvent = await _jobEventService.GetJobEventAsync(id);
            if (jobEvent == null)
            {
                return NotFound();
            }
            return Ok(jobEvent);
        }

        [HttpPost(ApiRoutes.JobEvent.Create)]
        public async Task<IActionResult> AddJobEvent(JobEventDto jobEventDto)
        {

            var jobEvent = jobEventDto.Adapt<JobEvent>();

            var addedJobEvent = await _jobEventService.AddJobEventAsync(jobEvent);
            return CreatedAtAction(nameof(GetJobEvent), new { id = addedJobEvent.Id }, addedJobEvent);
        }

        [HttpPut(ApiRoutes.JobEvent.Create)]
        public async Task<IActionResult> UpdateJobEvent(Guid id, JobEventDto jobEventDto)
        {
            var existingJobEvent = await _jobEventService.GetJobEventAsync(id);
            if (existingJobEvent == null)
            {
                return NotFound();
            }

            existingJobEvent = jobEventDto.Adapt<JobEvent>();

            var updatedJobEvent = await _jobEventService.UpdateJobEventAsync(existingJobEvent);
            return Ok(updatedJobEvent);
        }
    }
}
