using Argus.Platform.Application.Customers;
using Argus.Platform.Application.Workflows;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Customers.Dtos;
using Argus.Platform.Core.Workflows;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Workflows
{
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        public WorkflowController(IWorkflowService workflowService)
        {
           _workflowService = workflowService;
        }

        [HttpGet(ApiRoutes.Workflow.GetAll)]
        public async Task<IActionResult> GetAlWorkflows()
        {
            var workflow = await _workflowService.GetAllWorkflowsAsync();
            return Ok(workflow);
        }

        [HttpGet(ApiRoutes.Workflow.Get)]
        public async Task<IActionResult> GetWorkflow(Guid id)
        {
            var workflow = await _workflowService.GetWorkflowAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }
            return Ok(workflow);
        }

        [HttpPost(ApiRoutes.Workflow.Create)]
        public async Task<IActionResult> AddCustomer(WorkflowDto workflowDto)
        {

            var workflow = workflowDto.Adapt<Workflow>();

            var addedWorkflow = await _workflowService.AddWorkflowAsync(workflow);
            return CreatedAtAction(nameof(GetWorkflow), new { id = addedWorkflow.Id }, addedWorkflow);
        }

        [HttpPut(ApiRoutes.Workflow.Create)]
        public async Task<IActionResult> UpdateWorkflow(Guid id, WorkflowDto workflowDto)
        {
            var existingWorkflow = await _workflowService.GetWorkflowAsync(id);
            if (existingWorkflow == null)
            {
                return NotFound();
            }

            existingWorkflow = workflowDto.Adapt<Workflow>();

            var updatedWorkflow = await _workflowService.UpdateWorkflowAsync(existingWorkflow);
            return Ok(updatedWorkflow);
        }

    }
}
