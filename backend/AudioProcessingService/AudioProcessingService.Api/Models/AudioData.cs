namespace AudioProcessingService.Models;

public class AudioData
{
    public float[] Samples { get; set; } = [];
    public int SampleRate { get; set; }
    public int Channels { get; set; }
}