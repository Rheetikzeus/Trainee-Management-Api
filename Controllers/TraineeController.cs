using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Services;


namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/trainees")]
public class TraineeController : ControllerBase
{

    public ITraineeService _traineeService;

    public TraineeController(ITraineeService traineeService)
    {
        _traineeService = traineeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TraineesSearchParameters traineesSearchParameters) 
    {
        PagedResponse<TraineeResponse> response = await _traineeService.GetAll(traineesSearchParameters);
        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        TraineeResponse traineeResponse = await _traineeService.GetById(Id);
        return Ok(traineeResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TraineeCreateRequest traineeCreateRequest)
    {
        TraineeResponse traineeResponse = await _traineeService.Create(traineeCreateRequest);
        return Created("/api/trainees", traineeResponse);
    }

    [HttpPut("{Id:int}")]
    public async Task<IActionResult> Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        TraineeResponse traineeResponse = await _traineeService.Update(Id, traineeUpdateRequest);
        return Ok(traineeResponse);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> Delete(int Id)
    {
        await _traineeService.Delete(Id);
        return NoContent();
    }

}
