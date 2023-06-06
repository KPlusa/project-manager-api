namespace ProjectManager.Api.Models;

public sealed class Status
{
    public int IdStatus { get; set; }

    public string StatusName { get; set; } = null!;

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
