using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;


public class TaskAssignmentCreateRequest
{
    [Required(ErrorMessage = "TraineeId is Required.")]
    public int TraineeId { get; set; }

    [Required(ErrorMessage = "MentorId is Required.")]
    public int MentorId { get; set; }

    [Required(ErrorMessage = "LearningTaskId is Required.")]
    public int LearningTaskId { get; set; }

    [Required(ErrorMessage = "AssignedDate is Required.")]
    public DateTime AssignedDate { get; set; }

    [Required(ErrorMessage = "DueDate is Required.")]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "Status is Required.")]
    [AllowedValues(["Assigned", "InProgress", "Submitted", "Reviewed", "Completed"], ErrorMessage = "Invalid status value.")]
    public string Status { get; set; } = "";

    [Required(ErrorMessage = "Remarks is Required.")]
    [StringLength(100, ErrorMessage = "Must be atmost 100 characters.")]
    public string Remarks { get; set; } = "";
    
}