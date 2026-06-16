using TraineeManagement.Models;
namespace TraineeManagement.Dtos;

public class LearningTaskResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ExpectedTechStack { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public LearningTaskResponse(LearningTask learningTask)
    {
        Id = learningTask.Id;
        Title = learningTask.Title;
        Description = learningTask.Description;
        ExpectedTechStack = learningTask.ExpectedTechStack;
        DueDate = learningTask.DueDate;
        Status = learningTask.Status;
        CreatedDate = learningTask.CreatedDate;
        UpdatedDate = learningTask.UpdatedDate;
    }

    // public LearningTaskResponse(){}

}