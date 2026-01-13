using NAudio.Wave;

namespace AudioProcessingService.Api.Interfaces.Pipeline;

public interface IVolumeNormalizer
{
    /// <summary>
    /// Ensures audio volume is consistent
    /// </summary>
    /// <param name="sampleProviderInput">Input audio sample provider</param>
    /// <returns>Processed audio provider</returns>
    public ISampleProvider Normalize(ISampleProvider sampleProviderInput);

    /// <summary>
    /// Perform RMS (Root Mean Square) on given audio
    /// to measure average volume level
    /// <param name="sampleProviderInput">Audio to normalize</param>
    /// <param name="bufferSize">The buffer size to use, default to 1024</param>
    /// <returns>The mean audio value</returns>
    /// </summary>
    public float CalculateRms(ISampleProvider sampleProviderInput, int bufferSize);
}