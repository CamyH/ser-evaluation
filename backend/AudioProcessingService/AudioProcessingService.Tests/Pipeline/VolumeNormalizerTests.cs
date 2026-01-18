using System;

namespace AudioProcessingService.Tests.Pipeline;

using AudioProcessingService.Api.Pipeline;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Xunit;

public class VolumeNormalizerTests
{
    [Fact]
    public void Normalize_ShouldIncreaseVolumeForQuietSignal()
    {
        float amplitude = 0.1f;
        var sine = new SignalGenerator()
        {
            Gain = amplitude,
            Frequency = 1000,
            Type = SignalGeneratorType.Sin
        }.Take(TimeSpan.FromSeconds(1));

        var normalizer = new VolumeNormalizer();
        
        var normalized = normalizer.Normalize(sine);
        
        var originalRms = normalizer.CalculateRms(sine);
        var normalizedRms = normalizer.CalculateRms(normalized);
        
        Assert.True(normalizedRms > originalRms, "Normalized RMS should be higher than original RMS");
        Assert.InRange(normalizedRms, 0.1f, 1.0f); 
    }

    [Fact]
    public void Normalize_ShouldNotExceedPeak()
    {
        float amplitude = 0.8f;
        var sine = new SignalGenerator()
        {
            Gain = amplitude,
            Frequency = 1000,
            Type = SignalGeneratorType.Sin
        }.Take(TimeSpan.FromSeconds(1));

        var normalizer = new VolumeNormalizer();
        
        var normalized = normalizer.Normalize(sine);
        
        float[] buffer = new float[44100];
        int read = normalized.Read(buffer, 0, buffer.Length);
        float maxSample = 0f;
        for (int i = 0; i < read; i++)
            maxSample = MathF.Max(maxSample, MathF.Abs(buffer[i]));
        
        Assert.True(maxSample <= 1.0f, "Peak should not exceed 1.0");
    }
}