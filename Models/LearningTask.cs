
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

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
        DateTime dt = DateTime.Now;
        DateTime cleanDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        CreatedDate = cleanDt;
        UpdatedDate = cleanDt;
    }


public LearningTask() {}

}