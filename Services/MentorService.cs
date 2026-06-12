using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;

namespace TraineeManagement.Services;

public class MentorService : IMentorService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<MentorService> _logger;


    public MentorService(AppDbContext appDbContext, ILogger<MentorService> logger)
    {
        _logger = logger;
        _databaseContext = appDbContext;
    }
    

    public async Task<PagedResponse<MentorResponse>> GetAll(MentorsSearchParameters mentorsSearchParameters) 
    {
        IQueryable<Mentor> query = _databaseContext.Mentors.AsQueryable();
        string search = mentorsSearchParameters.Search!;
        string status = mentorsSearchParameters.Status!;
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(t => t.FirstName.ToLower().Contains(search) ||
                t.LastName.ToLower().Contains(search) || 
                t.Email.ToLower().Contains(search) || 
                t.Expertise.ToLower().Contains(search)
            );
        }
        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(t => t.Status == status);
        }

        int totalRecords = await query.CountAsync();
        List<MentorResponse> Mentors = await query.Skip((mentorsSearchParameters.PageNumber - 1) * mentorsSearchParameters.PageSize)
                            .Take(mentorsSearchParameters.PageSize).Select(t => new MentorResponse(t))
                            .ToListAsync();
        return new PagedResponse<MentorResponse>(Mentors, totalRecords, mentorsSearchParameters.PageNumber, mentorsSearchParameters.PageSize);
    }
  
    public async Task<MentorResponse?> GetById(int Id)
    {
        Mentor? mentor = await _databaseContext.Mentors.FindAsync(Id);
        if(mentor == null)
        {
            _logger.LogInformation("Mentor not found with {Id}", Id);
            return null;
        }
        return new MentorResponse(mentor);
    }

    public async Task<MentorResponse> Create(MentorCreateRequest mentorCreateRequest)
    {
        Mentor mentor = new Mentor(mentorCreateRequest);
        await _databaseContext.Mentors.AddAsync(mentor);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Trainee: {Id} ", mentor.Id);
        return new MentorResponse(mentor);
    }

    public async Task<MentorResponse?> Update(int Id, MentorUpdateRequest mentorUpdateRequest)
    {
        Mentor? mentor = await _databaseContext.Mentors.FindAsync(Id);
        if(mentor == null)
        {
            _logger.LogInformation("mentor not found with Id: {Id}", Id);
            return null;
        }
        mentor.FirstName = mentorUpdateRequest.FirstName;
        mentor.LastName = mentorUpdateRequest.LastName;
        mentor.Email = mentorUpdateRequest.Email;
        mentor.Expertise = mentorUpdateRequest.Expertise;
        mentor.Status = mentorUpdateRequest.Status;
        DateTime dt = DateTime.Now;
        DateTime cleanDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        mentor.UpdatedDate = cleanDt;
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Updated Mentor: {Id} ", mentor.Id);
        return new MentorResponse(mentor);
    }

    public async Task<bool> Delete(int Id)
    {
        Mentor? mentor = await _databaseContext.Mentors.FindAsync(Id);
        if(mentor == null)
        {
            _logger.LogInformation("Mentor not found with Id: {}", Id);
            return false;
        }
        _databaseContext.Mentors.Remove(mentor);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Deleted Mentor: {} ", mentor.Id);
        return true;
    }
}