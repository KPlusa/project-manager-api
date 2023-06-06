using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProjectManager.Api.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly ProjectManagerDataContext _context;

    public ProjectService(ProjectManagerDataContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        var projects = await _context.Projects.ToListAsync();
        return projects;
    }

    public async Task<Project?> GetSingleProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        return project ?? null;
    }

    public async Task<List<Project>?> AddProject(ProjectDto request)
    {
        var status = await _context.Statuses.FirstOrDefaultAsync(s => s.StatusName == request.Status);
        var type = await _context.Types.FirstOrDefaultAsync(s => s.TypeName == request.Type);
        if (status is null || type is null)
            return null;
        var project = new Project()
        {
            ProjectNo = request.ProjectNo!,
            ProjectTitle = request.ProjectTitle!,
            Amount = (decimal)request.Amount!,
            Comments = request.Comments,
            StartDate = (DateTime)request.StartDate!,
            EndDate = request.EndDate,
            IdStatus = status.IdStatus,
            IdType = type.IdType
        };
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return await _context.Projects.ToListAsync();
    }

    public async Task<List<Project>?> UpdateProject(int id, ProjectDto request)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null)
            return null;
        var status = await _context.Statuses.FirstOrDefaultAsync(s => s.StatusName == request.Status);
        var type = await _context.Types.FirstOrDefaultAsync(s => s.TypeName == request.Type);
        project.ProjectNo = request.ProjectNo ?? project.ProjectNo;
        project.ProjectTitle = request.ProjectTitle ?? project.ProjectTitle;
        project.Amount = request.Amount ?? project.Amount;
        project.Comments = request.Comments ?? project.Comments;
        project.StartDate = request.StartDate ?? project.StartDate;
        project.EndDate = request.EndDate ?? project.EndDate;
        project.IdStatus = status?.IdStatus ?? project.IdStatus;
        project.IdType = type?.IdType ?? project.IdType;
        await _context.SaveChangesAsync();
        return await _context.Projects.ToListAsync();
    }

    public async Task<List<Project>?> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null)
            return null;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return await _context.Projects.ToListAsync();
    }
}