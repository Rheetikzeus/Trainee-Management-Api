using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class ReviewCreateRequest
{
    [Required]
    public int SubmissionId { get; set; }

    [Required]
    public int MentorId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Feedback { get; set; } = null!;

    public int Score { get; set; }

    [Required]
    [AllowedValues([StringConstants.STATUS_ACCEPTED, StringConstants.STATUS_CHANGES_REQUIRED, StringConstants.STATUS_REJECTED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string ReviewStatus { get; set; } = null!;  

    [Required]
    public DateTime ReviewedDate { get; set; }  
    
}