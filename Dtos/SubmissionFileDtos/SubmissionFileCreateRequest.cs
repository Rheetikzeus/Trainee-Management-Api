

using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Dtos;

public class SubmissionFileCreateRequest
{
    [Required]
    public IFormFile File { get; set; } = null!;

}