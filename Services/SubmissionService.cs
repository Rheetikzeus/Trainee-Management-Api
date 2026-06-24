using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;
using TraineeManagement.Extensions;

namespace TraineeManagement.Services;

public class SubmissionService : ISubmissionService
{
    private readonly AppDbContext _databaseContext;
    private readonly ILogger<SubmissionService> _logger;
    private readonly IFileStorageService _fileStorageService;
    private readonly RabbitMqService _rabbitMqService;
    private readonly string[] _allowedFileExtensions = [".pdf", ".xlsx", ".docx", ".txt"];
    private readonly long _allowedFileSize = 10 *1024 * 1024;
    private readonly string _queueName= "submission-processing";

    private readonly RedisCacheService _cache;

    public SubmissionService(AppDbContext appDbContext, ILogger<SubmissionService> logger, IFileStorageService fileStorageService, RedisCacheService cache, RabbitMqService rabbitMqService)
    {
        _logger = logger;
        _databaseContext = appDbContext;
        _fileStorageService = fileStorageService;
        _cache = cache;
        _rabbitMqService = rabbitMqService;
    }
    

    public async Task<List<SubmissionResponse>> GetAll() 
    {
        return await _databaseContext.Submissions.Select(t => new SubmissionResponse(t)).ToListAsync();
    }
  
    public async Task<SubmissionResponse> GetById(int Id)
    {
        string cacheKey = $"Submission:{Id}";
        SubmissionResponse? cachedSubmissionResponse = await _cache.GetKeyAsync<SubmissionResponse>(cacheKey);
        if(cachedSubmissionResponse != null)
        {
            _logger.LogInformation($"Submission cache hit SubmissionId: {Id}");
            return cachedSubmissionResponse;
        }

        Submission? submission = await _databaseContext.Submissions.FindAsync(Id);
        if(submission == null)
        {
            _logger.LogInformation("Submission not found with {Id}", Id);
            throw new NotFoundException($"Submission not found with Id: {Id}");
        }
        SubmissionResponse submissionResponse = new SubmissionResponse(submission);
        await _cache.SetKeyAsync(cacheKey, submissionResponse);
        return submissionResponse;
    }

    public async Task<SubmissionResponse> Create(SubmissionCreateRequest submissionCreateRequest)
    {
        bool taskAssignmentExists = await _databaseContext.TaskAssignments.AnyAsync(t => t.Id == submissionCreateRequest.TaskAssignmentId);
        if(!taskAssignmentExists) throw new NotFoundException($"TaskAssignment not found with Id: {submissionCreateRequest.TaskAssignmentId}");

        Submission submission = new Submission(submissionCreateRequest);
        await _databaseContext.Submissions.AddAsync(submission);
        await _databaseContext.SaveChangesAsync();
        _logger.LogInformation("Successfully Created Submission: {Id} ", submission.Id);
        return new SubmissionResponse(submission);
    }

    public async Task<SubmissionFileResponse> UploadFile(int userId, int submissionId, SubmissionFileCreateRequest submissionFileCreateRequest)
    {
        bool submissionExists = await _databaseContext.Submissions.AnyAsync(s => s.Id == submissionId);
        if(!submissionExists) throw new NotFoundException($"Submission not found with Id: {submissionId}.");

        IFormFile file = submissionFileCreateRequest.File;

        if(!_allowedFileExtensions.Contains(Path.GetExtension(file.FileName))) throw new BadRequestException($"Invalid file type.");
        if(file.Length > _allowedFileSize) throw new RequestEntityTooLargeException($"File too large.");
        if(file.Length == 0) throw new BadRequestException($"File cannot be empty.");

        string generatedFileName = _fileStorageService.GenerateUniqueFileName(file.FileName);
        Stream stream = file.OpenReadStream();
        await _fileStorageService.SaveAsync(generatedFileName, stream);
        
        string contentType = file.ContentType;
        string? userName = await _databaseContext.Users.Where(u => u.Id == userId).Select(u => u.UserName).FirstOrDefaultAsync();
        string CheckSum = _fileStorageService.GetChecksum(stream);


        SubmissionFile submissionFile = new SubmissionFile
        {
            SubmissionId = submissionId,
            OriginalFileName = file.FileName,
            GeneratedStorageName = generatedFileName,
            CheckSum = CheckSum,
            Size = file.Length,
            ContentType = contentType,
            UploadedBy = userId,
            CreatedDate = DateTime.UtcNow.ToUtcSecondPrecision()
        };

        await _databaseContext.SubmissionFiles.AddAsync(submissionFile);
        await _databaseContext.SaveChangesAsync();

        string MessageId = Guid.NewGuid().ToString("N");
        string CorrelationId = Guid.NewGuid().ToString("N");

        SubmissionFileProcessingRequest submissionFileProcessingRequest = new SubmissionFileProcessingRequest
        {
            MessageId = MessageId,
            CorrelationId = CorrelationId,
            SubmissionId = submissionId,
            FileId = submissionFile.Id,
            RequestedAt = DateTime.UtcNow.ToUtcSecondPrecision(),
            ContractVersion = "1.0.0"
        };

        await _rabbitMqService.PublishAsync(_queueName, submissionFileProcessingRequest);

        ProcessingJob processingJob = new ProcessingJob
        {
            Status = "Queued",
            CorrelationId = CorrelationId
        };
        await _databaseContext.ProcessingJobs.AddAsync(processingJob);
        
        await _databaseContext.SaveChangesAsync();
        return new SubmissionFileResponse(submissionFile, userName!);
    }

    public async Task<FileStream> DownloadFile(int Id)
    {
        SubmissionFile submissionFile = await _databaseContext.SubmissionFiles.FindAsync(Id) ?? throw new NotFoundException($"SubmissionFile not found with Id: {Id}.");
        return await _fileStorageService.OpenReadAsync(submissionFile.GeneratedStorageName);
    }
    public async Task<bool> DeleteFile(int Id)
    {
        SubmissionFile submissionFile = await _databaseContext.SubmissionFiles.FindAsync(Id) ?? throw new NotFoundException($"SubmissionFile not found with Id: {Id}.");
        await _fileStorageService.DeleteAsync(submissionFile.GeneratedStorageName);
        _databaseContext.Remove(submissionFile);
        await _databaseContext.SaveChangesAsync();
        return true;
    }


}