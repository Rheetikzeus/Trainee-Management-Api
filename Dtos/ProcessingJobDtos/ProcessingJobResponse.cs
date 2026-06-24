

using TraineeManagement.Models;

namespace TraineeManagement.Dtos;

public class ProcessingJobResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public int Attempts { get; set; }
    public string ErrorSummary { get; set; } = string.Empty;
    public string CorrelationId { get; set; } = null!;
    public DateTime StartedTime { get; set; }
    public DateTime CompletedTime { get; set; }
    
    public ProcessingJobResponse(ProcessingJob processingJob)
    {
        Id = processingJob.Id;
        Status = processingJob.Status;
        Attempts = processingJob.Attempts;
        ErrorSummary = processingJob.ErrorSummary;
        CorrelationId = processingJob.CorrelationId;
        StartedTime = processingJob.StartedTime;
        CompletedTime = processingJob.CompletedTime;
    }

}