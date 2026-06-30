using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class SubmissionCreateRequest
{
    [Required]
    public int TaskAssignmentId { get; set; }

    [Required]
    [MaxLength(200)]
    public string SubmissionUrl { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string Notes { get; set; } = null!;

    [Required]
    public DateTime SubmittedDate { get; set; }

    [Required]
    [AllowedValues([StringConstants.STATUS_SUBMITTED, StringConstants.STATUS_RESUBMITTED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = null!;    
    
}