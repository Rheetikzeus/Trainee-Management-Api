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
    public IActionResult GetAll() 
    {
        var response =  _traineeService.GetAll();
        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public IActionResult GetById(int Id)
    {
        TraineeResponse? traineeResponse = _traineeService.GetById(Id);
        return traineeResponse == null ? NotFound() : Ok(traineeResponse);
    }

    [HttpPost]
    public IActionResult Create(TraineeCreateRequest traineeCreateRequest)
    {
        TraineeResponse traineeResponse = _traineeService.Create(traineeCreateRequest);
        return Created("/api/trainee", traineeResponse);
    }

    [HttpPut("{Id:int}")]
    public IActionResult Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        TraineeResponse? traineeResponse =  _traineeService.Update(Id, traineeUpdateRequest);
        return traineeResponse == null ? NotFound() : Ok(traineeResponse);
    }

    [HttpDelete("{Id:int}")]
    public IActionResult Delete(int Id)
    {
        bool res =  _traineeService.Delete(Id);
        return res ? NoContent() : NotFound();
    }

}
