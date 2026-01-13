using NAudio.Wave;

namespace AudioProcessingService.Api.Extensions;

public static class WaveFileWriterExtensions
{
    public static void WriteFileToStream(this MemoryStream memoryStream, ISampleProvider sampleProviderInput)
    {
        using var writer = new WaveFileWriter(memoryStream, sampleProviderInput.WaveFormat);
        float[] buffer = new float[1024];
        int read;

        while ((read = sampleProviderInput.Read(buffer, 0, buffer.Length)) > 0)
        {
            writer.WriteSamples(buffer, 0, read);
        }
        
        memoryStream.Position = 0;
    }
}