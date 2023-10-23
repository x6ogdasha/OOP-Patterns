using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class GPU : BaseComponent, IPrototype
{
    public GPU(string name, int height, int width, int versionOfPcie, int videoMemory, int chipFrequency, int power)
    {
        Name = name;
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
    public IPrototype Clone()
    {
        return new GPU(Name, Height, Width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public IPrototype CloneWithNewSize(int height, int width, string newName)
    {
        return new GPU(newName, height, width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public IPrototype CloneWithNewVideoMemory(int newMemory, string newName)
    {
        return new GPU(newName, Height, Width, VersionOfPCIE, newMemory, ChipFrequency, Power);
    }
}