using NAudio.Wave;

namespace AudioProcessingService.Api.Utils;

public class CachedSampleProvider : ISampleProvider
{
    private readonly float[] _buffer;
    private int _position;
    public WaveFormat WaveFormat { get; }

    public CachedSampleProvider(ISampleProvider source)
    {
        WaveFormat = source.WaveFormat;

        // read samples into memory
        var temp = new List<float>();
        float[] readBuffer = new float[4096];
        int read;
        while ((read = source.Read(readBuffer, 0, readBuffer.Length)) > 0)
        {
            for (int i = 0; i < read; i++)
                temp.Add(readBuffer[i]);
        }

        _buffer = temp.ToArray();
        _position = 0;
    }

    public int Read(float[] buffer, int offset, int count)
    {
        int available = _buffer.Length - _position;
        int toCopy = Math.Min(count, available);

        if (toCopy <= 0) return 0;

        Array.Copy(_buffer, _position, buffer, offset, toCopy);
        _position += toCopy;

        return toCopy;
    }
    
    public void Reset() => _position = 0;
}