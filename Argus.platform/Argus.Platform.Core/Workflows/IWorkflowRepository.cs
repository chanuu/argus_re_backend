using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Workflows
{
    public interface IWorkflowRepository : IRepository<Workflow>, ITransientService
    {
        Workflow Add(Workflow workflow);
        Task<IEnumerable<Workflow>> GetAllAsync();
        Task<Workflow> GetAsync(Guid workflowId);
        Task<Workflow> Update(Workflow workflow);
    }
}
