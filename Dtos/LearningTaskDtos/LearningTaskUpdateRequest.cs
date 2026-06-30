using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class LearningTaskUpdateRequest
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = null!;

    [Required]
    public string ExpectedTechStack { get; set; } = null!;

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    [AllowedValues([StringConstants.STATUS_DRAFT, StringConstants.STATUS_PUBLISHED, StringConstants.STATUS_CLOSED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = null!;
    
}