

using System.ComponentModel.DataAnnotations;
using TraineeManagement.Models;

namespace TraineeManagement.Dtos;

public class SubmissionFileResponse
{
    public int Id { get; set; }
    public int SubmissionId { get; set; }
    public string OriginalFileName { get; set; } = "";
    public string GeneratedStorageName {get; set; } = "";
    public string ContentType { get; set; } = "";
    public long Size { get; set; }
    public string CheckSum { get; set; } = "";
    public string UploadedBy { get; set; } = "";
    public DateTime CreatedDate { get; set; }

    public SubmissionFileResponse(SubmissionFile submissionFile, string userName)
    {
        Id = submissionFile.Id;
        SubmissionId = submissionFile.SubmissionId;
        OriginalFileName = submissionFile.OriginalFileName;
        GeneratedStorageName = submissionFile.GeneratedStorageName;
        CheckSum = submissionFile.CheckSum;
        Size = submissionFile.Size;
        ContentType = submissionFile.ContentType;
        UploadedBy = userName;
        CreatedDate = submissionFile.CreatedDate;
    }
}