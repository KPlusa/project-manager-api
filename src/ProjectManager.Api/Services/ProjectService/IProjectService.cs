namespace ProjectManager.Api.Services.ProjectService;

public interface IProjectService
{
    Task<List<Project>> GetAllProjects();
    Task<Project?> GetSingleProject(int id);
    Task<List<Project>?> AddProject(ProjectDto project);
    Task<List<Project>?> UpdateProject(int id, ProjectDto project);
    Task<List<Project>?> DeleteProject(int id);
}