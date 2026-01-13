using AudioProcessingService.Models;
using NAudio.Wave;

namespace AudioProcessingService.Api.Interfaces.Pipeline;

public interface IFormatNormalizer
{
    /// <summary>
    /// Ensures audio is in the correct format (Mono)
    /// </summary>
    /// <param name="sampleProviderInput">Input audio sample provider</param>
    /// <param name="expectedSampleRate">Expected audio sample rate</param>
    /// <returns>Processed audio provider</returns>
    public ISampleProvider Normalize(ISampleProvider sampleProviderInput,
        int expectedSampleRate);
}