using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Workflows
{
    public interface IWorkflowService : ITransientService
    {
        Task<IEnumerable<Workflow>> GetAllWorkflowsAsync();
        Task<Workflow> GetWorkflowAsync(Guid workflowId);
        Task<Workflow> AddWorkflowAsync(Workflow workflow);
        Task<Workflow> UpdateWorkflowAsync(Workflow Workflow);

    }
}
