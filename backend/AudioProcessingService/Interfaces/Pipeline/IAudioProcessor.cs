using AudioProcessingService.Models;

namespace AudioProcessingService.Interfaces.Pipeline;

public interface IAudioProcessor
{
    /// <summary>
    /// Processes audio and returns modified audio
    /// </summary>
    /// <param name="audio">Input audio data</param>
    /// <returns>Processed audio data</returns>
    AudioData Process(AudioData audio);
}