using AudioProcessingService.Interfaces.Services;
using AudioProcessingService.Models;
using NAudio.Wave;

namespace AudioProcessingService.Services;

public class AudioService : IAudioService
{
    /// <inheritdoc />
    public AudioData ProcessAudioAsync(Stream audioStream)
    {
        throw new NotImplementedException();
    }
    
    
}