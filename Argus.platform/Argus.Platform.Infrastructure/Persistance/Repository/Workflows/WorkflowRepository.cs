using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Workflows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Workflows
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly ApiContext _context;

        public WorkflowRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Workflow Add(Workflow workflow)
        {
            return _context.Workflows.Add(workflow).Entity;
        }


        public async Task<IEnumerable<Workflow>> GetAllAsync()
        {
            return await _context.Workflows.ToListAsync();
        }

        public async Task<Workflow> GetAsync(Guid workflowId)
        {
            return await _context.Workflows.SingleOrDefaultAsync();
        }

        public async Task<Workflow> Update(Workflow workflow)
        {
            _context.Workflows.Update(workflow);

            await _context.SaveChangesAsync();

            return workflow;
        }
    }
}
