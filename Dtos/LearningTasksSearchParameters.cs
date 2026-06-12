using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;

public class LearningTasksSearchParameters
{
    public string? Search { get; set; }

    public string? Status { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Pagenumber must be greater than 0.")]
    public int PageNumber { get; set; } = 1;

    [Range(1, int.MaxValue, ErrorMessage = "Pagesize must be greater than 0.")]
    public int PageSize { get; set; } = 10;
}
