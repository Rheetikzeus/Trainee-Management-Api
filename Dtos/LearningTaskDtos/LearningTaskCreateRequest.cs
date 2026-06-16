using System.ComponentModel.DataAnnotations;
using TraineeManagement.Models;

namespace TraineeManagement.Dtos;


public class LearningTaskCreateRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(50, ErrorMessage = "Must be atmost 50 characters.")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(200, ErrorMessage = "Must be atmost 200 characters.")]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Expected Tech Stack is Required.")]
    public string ExpectedTechStack { get; set; } = "";

    [Required(ErrorMessage = "Due Date is required.")]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [AllowedValues(["Draft", "Published", "Closed"], ErrorMessage = "Invalid status value.")]
    public string Status { get; set; } = "";
    
}