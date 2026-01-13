using AudioProcessingService.Api.Pipeline;
using JetBrains.Annotations;
using NAudio.Wave.SampleProviders;
using Xunit;

namespace AudioProcessingService.Tests.Pipeline;

[TestSubject(typeof(FormatNormalizer))]
public class FormatNormalizerTest
{
        [Fact]
        public void Normalize_StereoToMono_ConvertsToMono()
        {
            var stereoSignal = new SignalGenerator(44100, 2)
            {
                Gain = 0.5,
                Frequency = 440
            };

            var normalizer = new FormatNormalizer();
            
            var mono = normalizer.Normalize(stereoSignal, 44100);
            
            Assert.Equal(1, mono.WaveFormat.Channels);
            Assert.Equal(44100, mono.WaveFormat.SampleRate);
        }

        [Fact]
        public void Normalize_ResamplesToTargetRate()
        {
            var stereoSignal = new SignalGenerator(44100, 2)
            {
                Gain = 0.5,
                Frequency = 440
            };

            var normalizer = new FormatNormalizer();
            int targetRate = 16000;
            
            var resampled = normalizer.Normalize(stereoSignal, targetRate);
            
            Assert.Equal(targetRate, resampled.WaveFormat.SampleRate);
        }

        [Fact]
        public void Normalize_MonoInput_NoChangeChannels()
        {
            var monoSignal = new SignalGenerator(44100, 1)
            {
                Gain = 0.5,
                Frequency = 440
            };

            var normalizer = new FormatNormalizer();
            
            var output = normalizer.Normalize(monoSignal, 44100);
            
            Assert.Equal(1, output.WaveFormat.Channels);
            Assert.Equal(44100, output.WaveFormat.SampleRate);
        }

        [Fact]
        public void Normalize_MonoInput_ResamplesSampleRate()
        {
            var monoSignal = new SignalGenerator(44100, 1)
            {
                Gain = 0.5,
                Frequency = 440
            };

            var normalizer = new FormatNormalizer();
            int targetRate = 16000;

            var output = normalizer.Normalize(monoSignal, targetRate);

            Assert.Equal(targetRate, output.WaveFormat.SampleRate);
            Assert.Equal(1, output.WaveFormat.Channels);
        }
}