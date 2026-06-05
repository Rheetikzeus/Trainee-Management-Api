using System.ComponentModel.DataAnnotations;


namespace TraineeManagement.Dtos;

public class TraineeUpdateRequest
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "Must be atmost 50 characters.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Must be atmost 50 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is Required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Techstack is required.")]
    public string? TechStack { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [AllowedValues(["Active", "Inactive", "Completed"], ErrorMessage = "Invalid status value")]
    public string? Status { get; set; }
}