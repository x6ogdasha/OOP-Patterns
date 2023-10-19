namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseVideoCard
{
    public BaseVideoCard(int height, int width, int versionOfPcie, int videoMemory, int chipFrequency, int power)
    {
        Height = height;
        Width = width;
        VersionOfPCIE = versionOfPcie;
        VideoMemory = videoMemory;
        ChipFrequency = chipFrequency;
        Power = power;
    }

    public int Height { get; protected set; }
    public int Width { get; protected set; }
    public int VersionOfPCIE { get; protected set; }
    public int VideoMemory { get; protected set; }
    public int ChipFrequency { get; protected set; }
    public int Power { get; protected set; }
}