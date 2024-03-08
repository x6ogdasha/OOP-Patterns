using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Gpu : BaseComponent, IPrototype, IEquatable<Gpu>
{
    public Gpu(string name, int height, int width, int versionOfPcie, int videoMemory, int chipFrequency, int power)
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
        return new Gpu(Name, Height, Width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public IPrototype CloneWithNewSize(int height, int width, string newName)
    {
        return new Gpu(newName, height, width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }

    public IPrototype CloneWithNewVideoMemory(int newMemory, string newName)
    {
        return new Gpu(newName, Height, Width, VersionOfPCIE, newMemory, ChipFrequency, Power);
    }

    public bool Equals(Gpu? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Height == other.Height && Width == other.Width && VersionOfPCIE == other.VersionOfPCIE && VideoMemory == other.VideoMemory && ChipFrequency == other.ChipFrequency && Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Gpu) return false;
        return Equals((Gpu)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Height, Width, VersionOfPCIE, VideoMemory, ChipFrequency, Power);
    }
}