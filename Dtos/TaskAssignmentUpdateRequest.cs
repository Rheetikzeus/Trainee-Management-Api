using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;


public class TaskAssignmentUpdateRequest
{

    [Required(ErrorMessage = "Status is Required.")]
    [AllowedValues(["Assigned", "InProgress", "Submitted", "Reviewed", "Completed"], ErrorMessage = "Invalid status value.")]
    public string Status { get; set; } = "";

    
}