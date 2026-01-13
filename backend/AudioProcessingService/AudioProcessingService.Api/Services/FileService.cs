using AudioProcessingService.Api.Interfaces.Services;

namespace AudioProcessingService.Api.Services;

public class FileService : IFileService
{
    /// <inheritdoc/>
    public async Task<MemoryStream> SaveFileToMemoryAsync(IFormFile fileToSave)
    {
        var memoryStream = new MemoryStream();
        await fileToSave.CopyToAsync(memoryStream);

        memoryStream.Position = 0;
            
        return memoryStream;
    }
}