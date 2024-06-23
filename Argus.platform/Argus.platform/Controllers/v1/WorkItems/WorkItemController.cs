using Argus.Platform.Application.Packages;
using Argus.Platform.Application.WorkItems;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Packages.Dtos;
using Argus.Platform.Controllers.v1.Workflows.Dtos;
using Argus.Platform.Core.WorkItems;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.WorkItems
{
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;
        public WorkItemController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet(ApiRoutes.WorkItem.GetAll)]
        public async Task<IActionResult> GetAlWorkItem()
        {
            var workItem = await _workItemService.GetAllWorkItemAsync();
            return Ok(workItem);
        }

        [HttpGet(ApiRoutes.WorkItem.Get)]
        public async Task<IActionResult> GetWorkItem(Guid id)
        {
            var workItem = await _workItemService.GetWorkItemAsync(id);
            if (workItem == null)
            {
                return NotFound();
            }
            return Ok(workItem);
        }

        [HttpPost(ApiRoutes.WorkItem.Create)]
        public async Task<IActionResult> AddWorkItem(WorkItemDto workItemDto)
        {

            var workItem = workItemDto.Adapt<WorkItem>();

            var addedWorkItem = await _workItemService.AddWorkItemAsync(workItem);
            return CreatedAtAction(nameof(GetWorkItem), new { id = addedWorkItem.Id }, addedWorkItem);
        }

        [HttpPut(ApiRoutes.WorkItem.Create)]
        public async Task<IActionResult> UpdateWorkItem(Guid id, WorkItemDto workItemDto)
        {
            var existingWorkItem = await _workItemService.GetWorkItemAsync(id);
            if (existingWorkItem == null)
            {
                return NotFound();
            }

            existingWorkItem = workItemDto.Adapt<WorkItem>();

            var updatedWorkItem = await _workItemService.UpdateWorkItemAsync(existingWorkItem);
            return Ok(updatedWorkItem);
        }
    }
}
