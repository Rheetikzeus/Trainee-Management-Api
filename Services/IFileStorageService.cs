

namespace TraineeManagement.Services;

public interface IFileStorageService
{
    public Task SaveAsync(string filePath, Stream stream);
    public Task<FileStream> OpenReadAsync(string filePath);
    public Task<bool> ExistsAsync(string filePath);
    public Task DeleteAsync(string filePath);
    public string GenerateUniqueFileName(string originalFileName);
    public string GetChecksum(Stream stream);


}
