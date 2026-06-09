using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;

namespace TraineeManagement.Services;

public class TraineeService : ITraineeService
{
    private readonly TraineeContext _databaseContext;

    public TraineeService(TraineeContext traineeContext)
    {
        _databaseContext = traineeContext;
    }
    

    public async Task<List<TraineeResponse>> GetAll(string? search) 
    {
        IQueryable<Trainee> query = _databaseContext.Trainees.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(t => t.FirstName.ToLower().Contains(search) ||
                t.LastName.ToLower().Contains(search) || 
                t.Email.ToLower().Contains(search) || 
                t.TechStack.ToLower().Contains(search)
            );
        }
        return await query.Select(t => new TraineeResponse(t)).ToListAsync();
    }
  
    public async Task<TraineeResponse?> GetById(int Id)
    {
        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null) return null;
        return new TraineeResponse(trainee);
    }

    public async Task<TraineeResponse> Create(TraineeCreateRequest traineeCreateRequest)
    {
        Trainee trainee = new Trainee(traineeCreateRequest);
        await _databaseContext.Trainees.AddAsync(trainee);
        await _databaseContext.SaveChangesAsync();
        return new TraineeResponse(trainee);
    }

    public async Task<TraineeResponse?> Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null) return null;
        trainee.FirstName = traineeUpdateRequest.FirstName;
        trainee.LastName = traineeUpdateRequest.LastName;
        trainee.Email = traineeUpdateRequest.Email;
        trainee.TechStack = traineeUpdateRequest.TechStack;
        trainee.Status = traineeUpdateRequest.Status;
        DateTime dt = DateTime.Now;
        DateTime cleanDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        trainee.UpdatedDate = cleanDt;
        await _databaseContext.SaveChangesAsync();
        return new TraineeResponse(trainee);
    }

    public async Task<bool> Delete(int Id)
    {
        Trainee? trainee = await _databaseContext.Trainees.FindAsync(Id);
        if(trainee == null) return false;
        _databaseContext.Trainees.Remove(trainee);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}