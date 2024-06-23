using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Workflows
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;
        public WorkflowService(IWorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }

        public async Task<Workflow> AddWorkflowAsync(Workflow workflow)
        {
            var _workflow = _workflowRepository.Add(workflow);
            await _workflowRepository.UnitOfWork.SaveChangesAsync();
            return _workflow;
        }

        public async Task<IEnumerable<Workflow>> GetAllWorkflowsAsync()
        {
            return await _workflowRepository.GetAllAsync();
        }

        public async Task<Workflow> GetWorkflowAsync(Guid workflowId)
        {
            return await _workflowRepository.GetAsync(workflowId);
        }

        public async  Task<Workflow> UpdateWorkflowAsync(Workflow Workflow)
        {
            var _workflow = await _workflowRepository.Update(Workflow);
            await _workflowRepository.UnitOfWork.SaveChangesAsync();
            return _workflow;
        }
    }
}
