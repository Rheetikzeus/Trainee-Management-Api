using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;


public class ReviewCreateRequest
{
    [Required(ErrorMessage = "SubmissionId is Required.")]
    public int SubmissionId { get; set; }

    [Required(ErrorMessage = "MentorId is Required.")]
    public int MentorId { get; set; }

    [Required(ErrorMessage = "Feedback is Required.")]
    [StringLength(200, ErrorMessage = "Must be atnost 200 characters.")]
    public string Feedback { get; set; } = "";

    public int Score { get; set; }

    [Required(ErrorMessage = "Status is Required.")]
    [AllowedValues(["Accepted", "ChangesRequired", "Rejected"], ErrorMessage = "Invalid status value.")]
    public string ReviewStatus { get; set; } = "";  

    [Required(ErrorMessage = "ReviewedDate is Required.")]
    public DateTime ReviewedDate { get; set; }  
    
}