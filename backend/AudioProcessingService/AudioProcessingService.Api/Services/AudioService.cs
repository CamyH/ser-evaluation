using AudioProcessingService.Api.Extensions;
using AudioProcessingService.Api.Interfaces.Pipeline;
using AudioProcessingService.Api.Interfaces.Services;
using AudioProcessingService.Models;
using NAudio.Wave;

namespace AudioProcessingService.Api.Services;

public class AudioService(IFormatNormalizer formatNormalizer, IVolumeNormalizer volumeNormalizer) : IAudioService
{
    /// <inheritdoc />
    public MemoryStream ProcessAudio(MemoryStream audioStream)
    {
        using var reader = new WaveFileReader(audioStream);
        ISampleProvider sampleProviderInput = reader.ToSampleProvider();
        
        var normalizedFormat = formatNormalizer.Normalize(sampleProviderInput, 44100);
        var normalizedVolume = volumeNormalizer.Normalize(normalizedFormat);
        
        var outputStream = new MemoryStream();
        outputStream.WriteFileToStream(normalizedVolume);
        outputStream.Position = 0;

        return outputStream;
    }
    
    
}