namespace ProjectManager.Api;

public class Type
{
    public int IdType { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
