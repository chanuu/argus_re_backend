using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.Projects
{
   public interface IProjectService : ITransientService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectAsync(Guid projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
    }
}
