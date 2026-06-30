using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;

public class MentorsSearchParameters
{
    public string? Search { get; set; }

    public string? Status { get; set; }

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; } = 1;

    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = 10;
}
