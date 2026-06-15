using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;

namespace TraineeManagement.Services;

public class TaskAssignmentService : ITaskAssignmentService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<TaskAssignmentService> _logger;


    public TaskAssignmentService(AppDbContext appDbContext, ILogger<TaskAssignmentService> logger)
    {
        _logger = logger;
        _databaseContext = appDbContext;
    }
    

    public async Task<List<TaskAssignmentResponse>> GetAll() 
    {
        return await _databaseContext.TaskAssignments.Select(t => new TaskAssignmentResponse(t)).ToListAsync();
    }
  
    public async Task<TaskAssignmentResponse> GetById(int Id)
    {
        TaskAssignment? taskAssignment = await _databaseContext.TaskAssignments.FindAsync(Id);
        if(taskAssignment == null)
        {
            _logger.LogInformation("TaskAssignment not found with {Id}", Id);
            throw new NotFoundException($"TaskAssignment not found with Id: {Id}");
        }
        return new TaskAssignmentResponse(taskAssignment);
    }

    public async Task<TaskAssignmentResponse> Create(TaskAssignmentCreateRequest taskAssignmentCreateRequest)
    {
        bool traineeExists = await _databaseContext.Trainees.AnyAsync(t => t.Id == taskAssignmentCreateRequest.TraineeId);
        if(!traineeExists) throw new NotFoundException($"Trainee not found with Id: {taskAssignmentCreateRequest.TraineeId}.");

        bool mentorExists = await _databaseContext.Mentors.AnyAsync(m => m.Id == taskAssignmentCreateRequest.MentorId);
        if(!mentorExists) throw new NotFoundException($"Mentor not found with Id: {taskAssignmentCreateRequest.MentorId}.");

        bool learningTaskExists = await _databaseContext.LearningTasks.AnyAsync(l => l.Id == taskAssignmentCreateRequest.LearningTaskId);
        if(!learningTaskExists) throw new NotFoundException($"LearningTask not found with Id: {taskAssignmentCreateRequest.LearningTaskId}.");

        if (taskAssignmentCreateRequest.DueDate < taskAssignmentCreateRequest.AssignedDate) throw new BadRequestException("DueDate should not be before AssignedDate.");

        TaskAssignment taskAssignment = new TaskAssignment(taskAssignmentCreateRequest);
        await _databaseContext.TaskAssignments.AddAsync(taskAssignment);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created TaskAssignment: {Id} ", taskAssignment.Id);
        return new TaskAssignmentResponse(taskAssignment);
    }

    public async Task<TaskAssignmentResponse> UpdateStatus(int Id, TaskAssignmentUpdateRequest taskAssignmentUpdateRequest)
    {
        TaskAssignment? taskAssignment = await _databaseContext.TaskAssignments.FindAsync(Id);
        if(taskAssignment == null)
        {
            _logger.LogInformation("TaskAssignment not found with Id: {Id}", Id);
            throw new NotFoundException($"TaskAssignment not found with Id: {Id}.");
        }
        taskAssignment.Status = taskAssignmentUpdateRequest.Status;
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Updated TaskAssignment: {Id} ", taskAssignment.Id);
        return new TaskAssignmentResponse(taskAssignment);
    }

}