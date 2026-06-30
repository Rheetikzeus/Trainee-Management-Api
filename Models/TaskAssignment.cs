
using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class TaskAssignment
{
    [Key]
    public int Id { get; set; }

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
    public string Status { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Remarks { get; set; } = null!;

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