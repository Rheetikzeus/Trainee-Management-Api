using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface IProcessingJobService
{
    public Task<ProcessingJobResponse> GetById(int id);
}