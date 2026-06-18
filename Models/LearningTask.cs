
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class LearningTask
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string ExpectedTechStack { get; set; } = "";
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "";
    public DateTime CreatedDate { get; set; }
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