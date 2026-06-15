using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Models;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/submissions")]
public class SubmissionController : ControllerBase
{

    public ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        List<SubmissionResponse> submissionResponses = await _submissionService.GetAll();
        return Ok(submissionResponses);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        SubmissionResponse submissionResponse = await _submissionService.GetById(Id);
        return Ok(submissionResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubmissionCreateRequest submissionCreateRequest)
    {
        SubmissionResponse submissionResponse = await _submissionService.Create(submissionCreateRequest);
        return Created("/api/submissions", submissionResponse);
    }

}
