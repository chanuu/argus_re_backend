using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Documents
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApiContext _context;

        public ProjectRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Project Add(Project project)
        {
            return _context.Projects.Add(project).Entity;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.ProjectTasks).ToListAsync();
        }

        public async Task<Project> GetAsync(Guid projectId)
        {
            return await _context.Projects
                                 .Include(p => p.ProjectTasks)
                                 .SingleOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<Project> Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
