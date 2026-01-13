using AudioProcessingService.Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AudioProcessingService.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AudioController(IAudioService audioService, IFileService fileService) : Controller
{
    // POST /api/v1/audio/processAudio
    [HttpPost]
    public async Task<IActionResult> ProcessAudio(IFormFile audioInputFile)
    {
        if (!audioInputFile.ContentType.Contains("audio/wav"))
        {
            return BadRequest("Unsupported audio type");
        }
        
        var fileMemoryStream = await fileService.SaveFileToMemoryAsync(audioInputFile);
        // Will eventually be sent to the next service API
        var normalizedAudio = audioService.ProcessAudio(fileMemoryStream);

        return NoContent();
    }
}