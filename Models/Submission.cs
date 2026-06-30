
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class Submission
{
    [Key]
    public int Id { get; set; }

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
    public string Status { get; set; } = null!; 

    public Submission(SubmissionCreateRequest submissionCreateRequest)
    {
        TaskAssignmentId = submissionCreateRequest.TaskAssignmentId;
        SubmissionUrl = submissionCreateRequest.SubmissionUrl;
        Notes = submissionCreateRequest.Notes;
        SubmittedDate = submissionCreateRequest.SubmittedDate;
        Status = submissionCreateRequest.Status;
    }


    public Submission() {}

}