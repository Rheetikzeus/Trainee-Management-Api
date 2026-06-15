using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;

namespace TraineeManagement.Services;

public class SubmissionService : ISubmissionService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<SubmissionService> _logger;


    public SubmissionService(AppDbContext appDbContext, ILogger<SubmissionService> logger)
    {
        _logger = logger;
        _databaseContext = appDbContext;
    }
    

    public async Task<List<SubmissionResponse>> GetAll() 
    {
        return await _databaseContext.Submissions.Select(t => new SubmissionResponse(t)).ToListAsync();
    }
  
    public async Task<SubmissionResponse> GetById(int Id)
    {
        Submission? submission = await _databaseContext.Submissions.FindAsync(Id);
        if(submission == null)
        {
            _logger.LogInformation("Submission not found with {Id}", Id);
            throw new NotFoundException($"Submission not found with Id: {Id}");
        }
        return new SubmissionResponse(submission);
    }

    public async Task<SubmissionResponse> Create(SubmissionCreateRequest submissionCreateRequest)
    {
        bool taskAssignmentExists = await _databaseContext.TaskAssignments.AnyAsync(t => t.Id == submissionCreateRequest.TaskAssignmentId);
        if(!taskAssignmentExists) throw new NotFoundException($"TaskAssignment not found with Id: {submissionCreateRequest.TaskAssignmentId}");

        Submission submission = new Submission(submissionCreateRequest);
        await _databaseContext.Submissions.AddAsync(submission);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Submission: {Id} ", submission.Id);
        return new SubmissionResponse(submission);
    }

}