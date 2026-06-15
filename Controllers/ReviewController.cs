using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/reviews")]
public class ReviewController : ControllerBase
{

    public IReviewService _reviewService;

    public ReviewController(IReviewService submissionService)
    {
        _reviewService = submissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        List<ReviewResponse> reviewResponses = await _reviewService.GetAll();
        return Ok(reviewResponses);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        ReviewResponse reviewResponse = await _reviewService.GetById(Id);
        return Ok(reviewResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReviewCreateRequest reviewCreateRequest)
    {
        ReviewResponse reviewResponse = await _reviewService.Create(reviewCreateRequest);
        return Created("/api/reviews", reviewResponse);
    }

}
