using TraineeManagement.Models;
using TraineeManagement.Dtos;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;

namespace TraineeManagement.Services;

public class ProcessingJobService : IProcessingJobService
{
    private readonly AppDbContext _databaseContext;


    public ProcessingJobService(AppDbContext appDbContext)
    {
        _databaseContext = appDbContext;
    }
    

  
    public async Task<ProcessingJobResponse> GetById(int Id)
    {
        ProcessingJob? processingJob = await _databaseContext.ProcessingJobs.FindAsync(Id) ?? throw new NotFoundException($"Review not found with Id: {Id}");
        return new ProcessingJobResponse(processingJob);
    }

}