namespace ProjectManager.Api.Models.Dto;

public class ProjectDto
{
    public string? Type { get; set; }

    public string? Status { get; set; }

    public string? ProjectNo { get; set; }

    public string? ProjectTitle { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Amount { get; set; }

    public string? Comments { get; set; }
}