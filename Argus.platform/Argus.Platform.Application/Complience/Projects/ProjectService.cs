using Argus.Platform.Core.Complience.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetProjectAsync(Guid projectId)
        {
            return await _projectRepository.GetAsync(projectId);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            var addedProject = _projectRepository.Add(project);
            await _projectRepository.UnitOfWork.SaveChangesAsync();
            return addedProject;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var updatedProject = await _projectRepository.Update(project);
            await _projectRepository.UnitOfWork.SaveChangesAsync();
            return updatedProject;
        }
    }
}
