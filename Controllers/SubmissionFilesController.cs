using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Services;

namespace TraineeManagement.Controllers;

[Authorize]
[ApiController]
[Route("/api/submission-files")]
public class SubmissionFilesController : ControllerBase
{

    public ISubmissionService _submissionService;

    public SubmissionFilesController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }


    [HttpGet("{Id:int}")]
    public async Task<IActionResult> DownloadFile(int Id)
    {
        FileStream stream = await _submissionService.DownloadFile(Id);
        string fileName = Path.GetFileName(stream.Name);
        string extension = Path.GetExtension(fileName);
        string contentType = $"application/{extension.Substring(1)}";
        return File(stream, contentType, fileName);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> DeleteFile(int Id)
    {
        bool res = await _submissionService.DeleteFile(Id);
        return NoContent();
    }


}
