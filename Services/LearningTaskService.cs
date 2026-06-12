using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;

namespace TraineeManagement.Services;

public class LearningTaskService : ILearningTaskService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<LearningTaskService> _logger;


    public LearningTaskService(AppDbContext appDbContext, ILogger<LearningTaskService> logger)
    {
        _logger = logger;
        _databaseContext = appDbContext;
    }
    

    public async Task<PagedResponse<LearningTaskResponse>> GetAll(LearningTasksSearchParameters learningTasksSearchParameters) 
    {
        IQueryable<LearningTask> query = _databaseContext.LearningTasks.AsQueryable();
        string search = learningTasksSearchParameters.Search!;
        string status = learningTasksSearchParameters.Status!;
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(t => t.Title.ToLower().Contains(search) ||
                t.Description.ToLower().Contains(search) || 
                t.ExpectedTechStack.ToLower().Contains(search)
            );
        }
        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(t => t.Status == status);
        }

        int totalRecords = await query.CountAsync();
        List<LearningTaskResponse> Mentors = await query.Skip((learningTasksSearchParameters.PageNumber - 1) * learningTasksSearchParameters.PageSize)
                            .Take(learningTasksSearchParameters.PageSize).Select(t => new LearningTaskResponse(t))
                            .ToListAsync();
        return new PagedResponse<LearningTaskResponse>(Mentors, totalRecords, learningTasksSearchParameters.PageNumber, learningTasksSearchParameters.PageSize);
    }
  
    public async Task<LearningTaskResponse?> GetById(int Id)
    {
        LearningTask? learningTask = await _databaseContext.LearningTasks.FindAsync(Id);
        if(learningTask == null)
        {
            _logger.LogInformation("Learning Task not found with {Id}", Id);
            return null;
        }
        return new LearningTaskResponse(learningTask);
    }

    public async Task<LearningTaskResponse> Create(LearningTaskCreateRequest learningTaskCreateRequest)
    {
        LearningTask learningTask = new LearningTask(learningTaskCreateRequest);
        await _databaseContext.LearningTasks.AddAsync(learningTask);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Learning Task: {Id} ", learningTask.Id);
        return new LearningTaskResponse(learningTask);
    }

    public async Task<LearningTaskResponse?> Update(int Id, LearningTaskUpdateRequest learningTaskUpdateRequest)
    {
        LearningTask? learningTask = await _databaseContext.LearningTasks.FindAsync(Id);
        if(learningTask == null)
        {
            _logger.LogInformation("learningTask not found with Id: {Id}", Id);
            return null;
        }
        learningTask.Title = learningTaskUpdateRequest.Title;
        learningTask.Description = learningTaskUpdateRequest.Description;
        learningTask.ExpectedTechStack = learningTaskUpdateRequest.ExpectedTechStack;
        learningTask.DueDate = learningTaskUpdateRequest.DueDate;
        learningTask.Status = learningTaskUpdateRequest.Status;
        DateTime dt = DateTime.Now;
        DateTime cleanDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        learningTask.UpdatedDate = cleanDt;
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Updated Learning Task: {Id} ", learningTask.Id);
        return new LearningTaskResponse(learningTask);
    }

    public async Task<bool> Delete(int Id)
    {
        LearningTask? learningTask = await _databaseContext.LearningTasks.FindAsync(Id);
        if(learningTask == null)
        {
            _logger.LogInformation("learningTask not found with Id: {Id}", Id);
            return false;
        }
        _databaseContext.LearningTasks.Remove(learningTask);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Deleted Learning Task: {Id} ", learningTask.Id);
        return true;
    }
}