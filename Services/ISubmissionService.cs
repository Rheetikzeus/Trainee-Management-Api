using TraineeManagement.Dtos;
using TraineeManagement.Models;

namespace TraineeManagement.Services;


public interface ISubmissionService
{
    public Task<List<SubmissionResponse>> GetAll();

    public Task<SubmissionResponse> GetById(int id);

    public Task<SubmissionResponse> Create(SubmissionCreateRequest submissionCreateRequest);

    public Task<SubmissionFileResponse> UploadFile(int userId, int submissionId, SubmissionFileCreateRequest submissionFileCreateRequest);
    public Task<FileStream> DownloadFile(int submissionFileId);
    public Task<bool> DeleteFile(int submissionFileId);

}