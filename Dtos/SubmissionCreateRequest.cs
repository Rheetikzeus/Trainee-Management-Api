using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;


public class SubmissionCreateRequest
{
    [Required(ErrorMessage = "TaskAssignmentId is Required.")]
    public int TaskAssignmentId { get; set; }

    [Required(ErrorMessage = "SubmissionUrl is Required.")]
    public string SubmissionUrl { get; set; } = "";

    [Required(ErrorMessage = "Notes is Required.")]
    public string Notes { get; set; } = "";

    [Required(ErrorMessage = "SubmittedDate is Required.")]
    public DateTime SubmittedDate { get; set; }

    [Required(ErrorMessage = "Status is Required.")]
    [AllowedValues(["Submitted", "Resubmitted"], ErrorMessage = "Invalid status value.")]
    public string Status { get; set; } = "";    
    
}