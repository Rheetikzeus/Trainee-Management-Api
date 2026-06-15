using TraineeManagement.Dtos;
using TraineeManagement.Models;

namespace TraineeManagement.Services;


public interface ITaskAssignmentService
{
    public Task<List<TaskAssignmentResponse>> GetAll();

    public Task<TaskAssignmentResponse> GetById(int id);

    public Task<TaskAssignmentResponse> Create(TaskAssignmentCreateRequest taskAssignmentCreateRequest);

    public Task<TaskAssignmentResponse> UpdateStatus(int Id, TaskAssignmentUpdateRequest taskAssignmentUpdateRequest);



}