

namespace TraineeManagement.Models;

public class SubmissionFileProcessingRequest
{
    public string MessageId { get; set; } = null!;
    public string CorrelationId { get; set; } = null!;
    public int SubmissionId  { get; set; } 
    public int FileId  {get; set; } 
    public DateTime RequestedAt  { get; set; }
    public string ContractVersion  { get; set; } = null!;

    

}