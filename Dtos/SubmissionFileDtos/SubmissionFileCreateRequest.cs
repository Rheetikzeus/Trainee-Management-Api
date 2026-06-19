

using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;

public class SubmissionFileCreateRequest
{
    [Required(ErrorMessage = "File is required.")]
    public IFormFile File { get; set; } = null!;

}