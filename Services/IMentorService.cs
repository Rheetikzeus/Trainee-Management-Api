using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface IMentorService
{
    public Task<PagedResponse<MentorResponse>> GetAll(MentorsSearchParameters mentorsSearchParameters);

    public Task<MentorResponse> GetById(int id);

    public Task<MentorResponse> Create(MentorCreateRequest mentorCreateRequest);

    public Task<MentorResponse> Update(int Id, MentorUpdateRequest mentorUpdateRequest);

    public Task<bool> Delete(int Id);


}