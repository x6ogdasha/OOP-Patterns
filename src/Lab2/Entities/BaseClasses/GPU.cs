using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class GPU : Prototype
{
    public GPU(int height, int width, int versionOfPcie, int videoMemory, int chipFrequency, int power)
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
    public override Prototype Clone()
    {
        return new GPU(Height, Width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public Prototype CloneWithNewSize(int height, int width)
    {
        return new GPU(height, width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public Prototype CloneWithNewVideoMemory(int newMemory)
    {
        return new GPU(Height, Width, VersionOfPCIE, newMemory, ChipFrequency, Power);
    }
}