using AudioProcessingService.Api.Interfaces.Pipeline;
using AudioProcessingService.Api.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioProcessingService.Api.Pipeline;

public class VolumeNormalizer : IVolumeNormalizer
{
    private const float TargetRmsDb = -18f;
    
    /// <inheritdoc/>
    public ISampleProvider Normalize(ISampleProvider sampleProviderInput)
    {
        var cachedInput = new CachedSampleProvider(sampleProviderInput);
        var (rms, peak) = MeasureSamples(cachedInput);
        if (rms == 0 || peak == 0) return cachedInput;
        
        var rmsDb = 20f * MathF.Log10(rms);
        var gainDb = TargetRmsDb - rmsDb;
        var rmsGain = MathF.Pow(10f, gainDb / 20f);
        
        var maxAllowedGain = 1.0f / peak;
        var finalGain = Math.Min(rmsGain, maxAllowedGain);
        
        cachedInput.Reset();
        
        return new VolumeSampleProvider(cachedInput)
        {
            Volume = finalGain
        };
    }
    
    /// <inheritdoc/>
    public float CalculateRms(ISampleProvider sampleProviderInput, int bufferSize = 1024)
    {
        var buffer = new float[bufferSize];
        double sumSquares = 0.0;
        long sampleCount = 0;

        int samplesRead = 0;
        while ((samplesRead = sampleProviderInput.Read(buffer, 0, bufferSize)) > 0)
        {
            for (int i = 0; i < samplesRead; i++)
            {
                var sample = buffer[i];
                sumSquares += sample * sample;
            }
            
            sampleCount += samplesRead;
        }

        if (sampleCount == 0)
            return 0f;
        
        return (float)Math.Sqrt(sumSquares / sampleCount);
    }
    
    /// <summary>
    /// Measures RMS and peak values of a given sample provider
    /// </summary>
    private static (float rms, float peak) MeasureSamples(ISampleProvider provider, int bufferSize = 4096)
    {
        float sumSquares = 0f;
        float peak = 0f;
        int sampleCount = 0;
        var buffer = new float[bufferSize];

        int read;
        while ((read = provider.Read(buffer, 0, buffer.Length)) > 0)
        {
            for (int i = 0; i < read; i++)
            {
                var sample = buffer[i];
                peak = MathF.Max(peak, MathF.Abs(sample));
                sumSquares += sample * sample;
            }
            sampleCount += read;
        }

        float rms = sampleCount > 0 ? MathF.Sqrt(sumSquares / sampleCount) : 0f;

        return (rms, peak);
    }
}