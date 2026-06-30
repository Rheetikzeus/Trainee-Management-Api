using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class TaskAssignmentCreateRequest
{
    [Required]
    public int TraineeId { get; set; }

    [Required]
    public int MentorId { get; set; }

    [Required]
    public int LearningTaskId { get; set; }

    [Required]
    public DateTime AssignedDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    [AllowedValues([StringConstants.STATUS_ASSIGNED, StringConstants.STATUS_IN_PROGRESS, StringConstants.STATUS_SUBMITTED, StringConstants.STATUS_REVIEWED, StringConstants.STATUS_COMPLETED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Remarks { get; set; } = null!;
    
}