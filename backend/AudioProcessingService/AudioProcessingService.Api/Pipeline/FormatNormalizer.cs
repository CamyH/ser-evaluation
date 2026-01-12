using AudioProcessingService.Interfaces.Pipeline;
using AudioProcessingService.Models;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioProcessingService.Pipeline;

public class FormatNormalizer : IFormatNormalizer
{
    /// <inheritdoc/>
    public ISampleProvider Normalize(ISampleProvider sampleProviderInput, 
        int expectedSampleRate)
    {
        sampleProviderInput = ConvertToMono(sampleProviderInput);
        sampleProviderInput = Resample(sampleProviderInput, expectedSampleRate);
        
        return sampleProviderInput;
    }
    
    /// <summary>
    /// Convert an audio file to Mono format (single channel)
    /// </summary>
    /// <param name="sampleProviderInput">The sample provider to convert</param>
    /// <returns>The sample provider in mono format</returns>
    private ISampleProvider ConvertToMono(ISampleProvider sampleProviderInput)
    {
        if (sampleProviderInput.WaveFormat.Channels == 2)
        {
            return new StereoToMonoSampleProvider(sampleProviderInput)
            {
                LeftVolume = 0.5f,
                RightVolume = 0.5f,
            };
        }
        
        return sampleProviderInput;
    }
    
    /// <summary>
    /// Update a given audio file's sample rate
    /// </summary>
    /// <param name="audioData">The audio to resample</param>
    /// <param name="expectedSampleRate">The sample rate to resample audio to</param>
    /// <returns>The resampled audio</returns>
    private ISampleProvider Resample(ISampleProvider audioData, 
        int expectedSampleRate)
    {
        if (audioData.WaveFormat.SampleRate == expectedSampleRate)
            return audioData;
        
        return new WdlResamplingSampleProvider(audioData, expectedSampleRate);
    }
}