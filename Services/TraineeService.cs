using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;
using TraineeManagement.Extensions;



namespace TraineeManagement.Services;

public class TraineeService : ITraineeService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<TraineeService> _logger;
    private readonly RedisCacheService _cache;


    public TraineeService(AppDbContext appDbContext, ILogger<TraineeService> logger, RedisCacheService cache)
    {
        _logger = logger;
        _databaseContext = appDbContext;
        _cache = cache;
    }
    

    public async Task<PagedResponse<TraineeResponse>> GetAll(TraineesSearchParameters traineesSearchParameters) 
    {
        IQueryable<Trainee> query = _databaseContext.Trainees.AsQueryable();
        string search = traineesSearchParameters.Search!;
        string status = traineesSearchParameters.Status!;
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(t => t.FirstName.ToLower().Contains(search) ||
                t.LastName.ToLower().Contains(search) || 
                t.Email.ToLower().Contains(search) || 
                t.TechStack.ToLower().Contains(search)
            );
        }
        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(t => t.Status == status);
        }

        int totalRecords = await query.CountAsync();
        List<TraineeResponse> trainees = await query.Skip((traineesSearchParameters.PageNumber - 1) * traineesSearchParameters.PageSize)
                            .Take(traineesSearchParameters.PageSize).Select(t => new TraineeResponse(t))
                            .ToListAsync();
        return new PagedResponse<TraineeResponse>(trainees, totalRecords, traineesSearchParameters.PageNumber, traineesSearchParameters.PageSize);
    }
  
    public async Task<TraineeResponse> GetById(int Id)
    {
        string cacheKey = $"Trainee:{Id}";
        TraineeResponse? cachedTraineeResponse = await _cache.GetKeyAsync<TraineeResponse>(cacheKey);
        if (cachedTraineeResponse != null)
        {
            _logger.LogInformation($"Trainee cache hit Id: {Id}");
            return cachedTraineeResponse;
        }

        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null)
        {
            _logger.LogInformation("Trainee not found with {Id}", Id);
            throw new NotFoundException($"Trainee not found with Id: {Id}");
        }
        TraineeResponse traineeResponse = new TraineeResponse(trainee);
        await _cache.SetKeyAsync(cacheKey, traineeResponse);
        return traineeResponse;
    }

    public async Task<TraineeResponse> Create(TraineeCreateRequest traineeCreateRequest)
    {
        Trainee trainee = new Trainee(traineeCreateRequest);
        await _databaseContext.Trainees.AddAsync(trainee);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Trainee: {Id} ", trainee.Id);
        return new TraineeResponse(trainee);
    }

    public async Task<TraineeResponse> Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null)
        {
            _logger.LogInformation("Trainee not found with Id: {Id}", Id);
            throw new NotFoundException($"Trainee not found with Id: {Id}");
        }
        trainee.FirstName = traineeUpdateRequest.FirstName;
        trainee.LastName = traineeUpdateRequest.LastName;
        trainee.Email = traineeUpdateRequest.Email;
        trainee.TechStack = traineeUpdateRequest.TechStack;
        trainee.Status = traineeUpdateRequest.Status;
        trainee.UpdatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
        await _databaseContext.SaveChangesAsync();

        TraineeResponse traineeResponse = new TraineeResponse(trainee);
        string cacheKey = $"Trainee:{Id}";
        
        if(await _cache.ExistKeyAsync(cacheKey))
        {
            await _cache.SetKeyAsync(cacheKey, traineeResponse);
        }

        _logger.LogInformation("Successfully Updated Trainee: {Id} ", trainee.Id);
        return traineeResponse;
    }

    public async Task<bool> Delete(int Id)
    {
        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null)
        {
            _logger.LogInformation("Trainee not found with Id: {Id}", Id);
            throw new NotFoundException($"Trainee not found with Id: {Id}");
        }
        _databaseContext.Trainees.Remove(trainee);
        await _databaseContext.SaveChangesAsync();

        string cacheKey = $"Trainee:{Id}";
        await _cache.DeleteKeyAsync(cacheKey);
        _logger.LogInformation("Successfully Deleted Trainee: {Id} ", trainee.Id);
        return true;
    }
}