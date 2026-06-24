using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/processing-jobs")]
public class ProcessingJobController : ControllerBase
{

    public IProcessingJobService _processingJobService;

    public ProcessingJobController(IProcessingJobService processingJobService)
    {
        _processingJobService = processingJobService;
    }


    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        ProcessingJobResponse processingJobResponse = await _processingJobService.GetById(Id);
        return Ok(processingJobResponse);
    }


}
