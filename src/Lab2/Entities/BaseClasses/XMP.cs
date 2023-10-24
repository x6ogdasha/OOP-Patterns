using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class XMP : BaseComponent, IPrototype, IEquatable<XMP>
{
    public XMP(string name, string timing, int voltage, int frequency)
    {
        Name = name;
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }
    public IPrototype Clone()
    {
        return new XMP(Name, Timing, Voltage, Frequency);
    }

    public IPrototype CloneWithNewTiming(string timing, string newName)
    {
        return new XMP(newName, timing, Voltage, Frequency);
    }

    public bool Equals(XMP? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Timing == other.Timing && Voltage == other.Voltage && Frequency == other.Frequency;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not XMP) return false;
        return Equals((XMP)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Timing, Voltage, Frequency);
    }
}