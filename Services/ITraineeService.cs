using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface ITraineeService
{
    public Task<List<TraineeResponse>> GetAll(string? search);

    public Task<TraineeResponse?> GetById(int id);

    public Task<TraineeResponse> Create(TraineeCreateRequest traineeCreateRequest);

    public Task<TraineeResponse?> Update(int Id, TraineeUpdateRequest traineeUpdateRequest);

    public Task<bool> Delete(int Id);


}