using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Project
{
   public interface IProjectRepository : IRepository<Project>, ITransientService
    {
        Project Add(Project project);
        Task<Project> Update(Project project);
        Task<Project> GetAsync(Guid projectId);
        Task<IEnumerable<Project>> GetAllAsync();
    }

}
