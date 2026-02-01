using AudioProcessingService.Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AudioProcessingService.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AudioController(IAudioService audioService, IFileService fileService) : Controller
{
    // POST /api/v1/audio
    [HttpPost]
    public async Task<IActionResult> ProcessAudio([FromForm] IFormFile audioInputFile)
    {
        var fileMemoryStream = await fileService.SaveFileToMemoryAsync(audioInputFile);
        // Will eventually be sent to the next service API
        var normalizedAudio = audioService.ProcessAudio(fileMemoryStream);

        return NoContent();
    }
}