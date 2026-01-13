using AudioProcessingService.Models;

namespace AudioProcessingService.Api.Interfaces.Services;

public interface IAudioService
{
    /// <summary>
    /// Normalize Audio using pre-processing steps:
    /// </summary>
    AudioData ProcessAudioAsync(Stream audioStream);
}