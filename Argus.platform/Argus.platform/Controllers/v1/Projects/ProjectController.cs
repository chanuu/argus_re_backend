using Argus.Platform.Application.Complience.Projects;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Projects.DTOs;
using Argus.Platform.Core.Complience.Project;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Projects
{
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;


        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet(ApiRoutes.Project.GetAll)]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet(ApiRoutes.Project.Get)]
        public async Task<IActionResult> GetProject([FromRoute] Guid id)
        {
            var project = await _projectService.GetProjectAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }


        [HttpPost(ApiRoutes.Project.Create)]
        public async Task<IActionResult> AddProject([FromBody] ProjectDto projectDto)
        {
            // Using Mapster to map from ProjectDto to Project entity
            var project = projectDto.Adapt<Project>();

            var createdProject = await _projectService.AddProjectAsync(project);
            // Assuming the service layer returns the entity, adapt it back to DTO for the response if needed
            var projectResource = createdProject.Adapt<ProjectDto>();

            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, projectResource);
        }

        [HttpPut(ApiRoutes.Project.Update)]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectDto projectDto)
        {
            var existingProject = await _projectService.GetProjectAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            // Mapster allows for adapting directly onto an existing object, which is perfect for updates
            projectDto.Adapt(existingProject);

            var updatedProject = await _projectService.UpdateProjectAsync(existingProject);
            // Adapt the updated entity back to DTO for the response
            var projectResource = updatedProject.Adapt<ProjectDto>();

            return Ok(projectResource);
        }

    }
}
