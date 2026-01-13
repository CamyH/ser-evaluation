namespace AudioProcessingService.Api.Interfaces.Services;

public interface IFileService
{
    /// <summary>
    /// Save an uploaded file to disk
    /// </summary>
    /// <param name="fileToSave">The file to save to memory</param>
    /// <returns>The memory stream containing the file</returns>
    public Task<MemoryStream> SaveFileToMemoryAsync(IFormFile fileToSave);
}