using TraineeManagement.Dtos;
using TraineeManagement.Models;

namespace TraineeManagement.Services;


public interface ISubmissionService
{
    public Task<List<SubmissionResponse>> GetAll();

    public Task<SubmissionResponse> GetById(int id);

    public Task<SubmissionResponse> Create(SubmissionCreateRequest submissionCreateRequest);

}