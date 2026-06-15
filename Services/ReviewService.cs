using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;

namespace TraineeManagement.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<ReviewService> _logger;


    public ReviewService(AppDbContext appDbContext, ILogger<ReviewService> logger)
    {
        _logger = logger;
        _databaseContext = appDbContext;
    }
    

    public async Task<List<ReviewResponse>> GetAll() 
    {
        return await _databaseContext.Reviews.Select(r => new ReviewResponse(r)).ToListAsync();
    }
  
    public async Task<ReviewResponse> GetById(int Id)
    {
        Review? review = await _databaseContext.Reviews.FindAsync(Id);
        if(review == null)
        {
            _logger.LogInformation("Review not found with {Id}", Id);
            throw new NotFoundException($"Review not found with Id: {Id}");
        }
        return new ReviewResponse(review);
    }

    public async Task<ReviewResponse> Create(ReviewCreateRequest reviewCreateRequest)
    {
        bool mentorExists = await _databaseContext.Mentors.AnyAsync(m => m.Id == reviewCreateRequest.MentorId);
        if(!mentorExists) throw new NotFoundException($"Mentor not found with Id: {reviewCreateRequest.MentorId}");

        bool submissionExists = await _databaseContext.Submissions.AnyAsync(s => s.Id == reviewCreateRequest.SubmissionId);
        if(!submissionExists) throw new NotFoundException($"Submission not found with Id: {reviewCreateRequest.SubmissionId}");

        Review review = new Review(reviewCreateRequest);
        await _databaseContext.Reviews.AddAsync(review);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Review: {Id} ", review.Id);
        return new ReviewResponse(review);
    }

}