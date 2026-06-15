using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface ILearningTaskService
{
    public Task<PagedResponse<LearningTaskResponse>> GetAll(LearningTasksSearchParameters learningTasksSearchParameters);

    public Task<LearningTaskResponse> GetById(int id);

    public Task<LearningTaskResponse> Create(LearningTaskCreateRequest learningTaskCreateRequest);

    public Task<LearningTaskResponse> Update(int Id, LearningTaskUpdateRequest learningTaskUpdateRequest);

    public Task<bool> Delete(int Id);


}