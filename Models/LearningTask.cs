
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class LearningTask
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string ExpectedTechStack { get; set; } = null!;

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public string Status { get; set; } = null!;
    
    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

    public LearningTask(LearningTaskCreateRequest learningTaskCreateRequest)
    {
        Title = learningTaskCreateRequest.Title;
        Description = learningTaskCreateRequest.Description;
        ExpectedTechStack = learningTaskCreateRequest.ExpectedTechStack;
        DueDate = learningTaskCreateRequest.DueDate;
        Status = learningTaskCreateRequest.Status;
        CreatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
        UpdatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
    }


    public LearningTask() {}

}