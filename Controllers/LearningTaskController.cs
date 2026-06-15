using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Models;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/learning-tasks")]
public class LearningTaskController : ControllerBase
{

    public ILearningTaskService _learningTaskService;

    public LearningTaskController(ILearningTaskService learningTaskService)
    {
        _learningTaskService = learningTaskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] LearningTasksSearchParameters learningTasksSearchParameters) 
    {
        PagedResponse<LearningTaskResponse> response = await _learningTaskService.GetAll(learningTasksSearchParameters);
        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        LearningTaskResponse learningTaskResponse = await _learningTaskService.GetById(Id);
        return Ok(learningTaskResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(LearningTaskCreateRequest learningTaskCreateRequest)
    {
        LearningTaskResponse learningTaskResponse = await _learningTaskService.Create(learningTaskCreateRequest);
        return Created("/api/learning-tasks", learningTaskResponse);
    }

    [HttpPut("{Id:int}")]
    public async Task<IActionResult> Update(int Id, LearningTaskUpdateRequest learningTaskUpdateRequest)
    {
        LearningTaskResponse learningTaskResponse = await _learningTaskService.Update(Id, learningTaskUpdateRequest);
        return Ok(learningTaskResponse);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> Delete(int Id)
    { 
        await _learningTaskService.Delete(Id);
        return NoContent();
    }

}
