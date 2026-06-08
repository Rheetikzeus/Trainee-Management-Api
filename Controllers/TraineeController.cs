using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[ApiController]
[Route("/api/trainee")]
public class TraineeController : ControllerBase
{

    public ITraineeService _traineeService;

    public TraineeController(ITraineeService traineeService)
    {
        _traineeService = traineeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search) 
    {
        List<TraineeResponse> response = await _traineeService.GetAll(search);
        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        TraineeResponse? traineeResponse = await _traineeService.GetById(Id);
        return traineeResponse == null ? NotFound() : Ok(traineeResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TraineeCreateRequest traineeCreateRequest)
    {
        TraineeResponse traineeResponse = await _traineeService.Create(traineeCreateRequest);
        return Created("/api/trainee", traineeResponse);
    }

    [HttpPut("{Id:int}")]
    public async Task<IActionResult> Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        TraineeResponse? traineeResponse = await _traineeService.Update(Id, traineeUpdateRequest);
        return traineeResponse == null ? NotFound() : Ok(traineeResponse);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> Delete(int Id)
    {
        bool res = await _traineeService.Delete(Id);
        return res ? NoContent() : NotFound();
    }

}
