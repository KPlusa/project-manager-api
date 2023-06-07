using System.Text.Json.Serialization;

namespace ProjectManager.Api.Models;

public sealed class Project
{
    public int IdProject { get; set; }

    public int IdType { get; set; }

    public int IdStatus { get; set; }

    public string ProjectNo { get; set; } = null!;

    public string ProjectTitle { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Amount { get; set; }

    public string? Comments { get; set; }
    [JsonIgnore] public Status IdStatusNavigation { get; set; } = null!;
    [JsonIgnore] public Type IdTypeNavigation { get; set; } = null!;
}