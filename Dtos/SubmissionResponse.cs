using TraineeManagement.Models;
namespace TraineeManagement.Dtos;

public class SubmissionResponse
{
    public int Id { get; set; }

    public int TaskAssignmentId { get; set; }
    public string SubmissionUrl { get; set; }
    public string Notes { get; set; } 
    public DateTime SubmittedDate { get; set; }
    public string Status { get; set; }

    public SubmissionResponse(Submission submission)
    {
        Id = submission.Id;
        TaskAssignmentId = submission.TaskAssignmentId;
        SubmissionUrl = submission.SubmissionUrl;
        Notes = submission.Notes;
        SubmittedDate = submission.SubmittedDate;
        Status = submission.Status;
    }

    // public MentorResponse(){}

}