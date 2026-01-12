using AudioProcessingService.Models;

namespace AudioProcessingService.Interfaces.Services;

public interface IAudioService
{
    /// <summary>
    /// Normalize Audio using pre-processing steps:
    /// </summary>
    AudioData ProcessAudioAsync(Stream audioStream);
}