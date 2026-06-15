using TraineeManagement.Dtos;
using TraineeManagement.Models;

namespace TraineeManagement.Services;


public interface IReviewService
{
    public Task<List<ReviewResponse>> GetAll();

    public Task<ReviewResponse> GetById(int id);

    public Task<ReviewResponse> Create(ReviewCreateRequest reviewCreateRequest);

}