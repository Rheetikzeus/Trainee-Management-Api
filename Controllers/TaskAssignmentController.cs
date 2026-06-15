using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Models;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/task-assignments")]
public class TaskAssignmentController : ControllerBase
{

    public ITaskAssignmentService _taskAssignmentService;

    public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
    {
        _taskAssignmentService = taskAssignmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        List<TaskAssignmentResponse> taskAssignmentResponses = await _taskAssignmentService.GetAll();
        return Ok(taskAssignmentResponses);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        TaskAssignmentResponse taskAssignmentResponse = await _taskAssignmentService.GetById(Id);
        return Ok(taskAssignmentResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskAssignmentCreateRequest taskAssignmentCreateRequest)
    {
        TaskAssignmentResponse taskAssignmentResponse = await _taskAssignmentService.Create(taskAssignmentCreateRequest);
        return Created("/api/task-assignments", taskAssignmentResponse);
    }

    [HttpPut("{Id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int Id, TaskAssignmentUpdateRequest taskAssignmentUpdateRequest)
    {
        TaskAssignmentResponse taskAssignmentResponse = await _taskAssignmentService.UpdateStatus(Id, taskAssignmentUpdateRequest);
        return Ok(taskAssignmentResponse);
    }


}
