using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Models;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/mentors")]
public class MentorController : ControllerBase
{

    public IMentorService _mentorService;

    public MentorController(IMentorService mentorService)
    {
        _mentorService = mentorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] MentorsSearchParameters mentorsSearchParameters) 
    {
        PagedResponse<MentorResponse> response = await _mentorService.GetAll(mentorsSearchParameters);
        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        MentorResponse mentorResponse = await _mentorService.GetById(Id);
        return Ok(mentorResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MentorCreateRequest mentorCreateRequest)
    {
        MentorResponse mentorResponse = await _mentorService.Create(mentorCreateRequest);
        return Created("/api/mentors", mentorResponse);
    }

    [HttpPut("{Id:int}")]
    public async Task<IActionResult> Update(int Id, MentorUpdateRequest mentorUpdateRequest)
    {
        MentorResponse mentorResponse = await _mentorService.Update(Id, mentorUpdateRequest);
        return Ok(mentorResponse);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> Delete(int Id)
    {
        await _mentorService.Delete(Id);
        return NoContent();
    }

}
