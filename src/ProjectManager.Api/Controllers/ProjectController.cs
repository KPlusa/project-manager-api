using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.Services.ProjectService;

namespace ProjectManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return await _projectService.GetAllProjects();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetSingleProject(int id)
        {
            var result = await _projectService.GetSingleProject(id);
            if (result is null)
                return NotFound("Project not found.");

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Project>>> UpdateProject(int id, ProjectDto request)
        {
            var result = await _projectService.UpdateProject(id, request);
            if (result is null)
                return NotFound("Project not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);
            if (result is null)
                return NotFound("Project not found.");

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(ProjectDto project)
        {
            var result = await _projectService.AddProject(project);
            return Ok(result);
        }
    }
}