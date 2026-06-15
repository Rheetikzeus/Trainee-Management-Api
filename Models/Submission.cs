
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class Submission
{
    [Key]
    public int Id { get; set; }

    public int TaskAssignmentId { get; set; }
    public string SubmissionUrl { get; set; } = "";
    public string Notes { get; set; } = "";
    public DateTime SubmittedDate { get; set; }
    public string Status { get; set; } = "";
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