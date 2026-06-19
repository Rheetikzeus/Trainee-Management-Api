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


    [HttpGet("{SubmissionId:int}")]
    public async Task<IActionResult> DownloadFile(int SubmissionId)
    {
        FileStream stream = await _submissionService.DownloadFile(SubmissionId);
        string fileName = Path.GetFileName(stream.Name);
        string extension = Path.GetExtension(fileName);
        string contentType = $"application/{extension.Substring(1)}";
        return File(stream, contentType, fileName);
    }

    [HttpDelete("{SubmissionId:int}")]
    public async Task<IActionResult> DeleteFile(int SubmissionId)
    {
        bool res = await _submissionService.DeleteFile(SubmissionId);
        return NoContent();
    }


}
