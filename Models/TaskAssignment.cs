
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class TaskAssignment
{
    [Key]
    public int Id { get; set; }

    public int TraineeId { get; set; }
    public int MentorId { get; set; }
    public int LearningTaskId { get; set; }
    public DateTime AssignedDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "";
    public string Remarks { get; set; } = "";

    public TaskAssignment(TaskAssignmentCreateRequest taskAssignmentCreateRequest)
    {
        TraineeId = taskAssignmentCreateRequest.TraineeId;
        MentorId = taskAssignmentCreateRequest.MentorId;
        LearningTaskId = taskAssignmentCreateRequest.LearningTaskId;
        AssignedDate = taskAssignmentCreateRequest.AssignedDate;
        DueDate = taskAssignmentCreateRequest.DueDate;
        Status = taskAssignmentCreateRequest.Status;
        Remarks = taskAssignmentCreateRequest.Remarks;
    }


public TaskAssignment() {}

}