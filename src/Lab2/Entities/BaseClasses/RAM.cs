using System;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class RAM : BaseComponent, IPrototype, IEquatable<RAM>
{
    public RAM(string name, int memorySize, int frequency, int voltage, RAMFormFactor formFactor, int standardOfDdr, int power, XMP? profileXmp)
    {
        Name = name;
        MemorySize = memorySize;
        Frequency = frequency;
        Voltage = voltage;
        FormFactor = formFactor;
        StandardOfDDR = standardOfDdr;
        Power = power;
        ProfileXMP = profileXmp;
    }

    public RAM()
    {
        Name = "null";
    }

    public int MemorySize { get; protected set; }
    public int Frequency { get; protected set; }
    public int Voltage { get; protected set; }
    public RAMFormFactor FormFactor { get; protected set; }
    public int StandardOfDDR { get; protected set; }
    public int Power { get; protected set; }
    public XMP? ProfileXMP { get; protected set; }
    public IPrototype Clone()
    {
        return new RAM(Name, MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewMemorySize(int newMemorySize, string newName)
    {
        return new RAM(newName, newMemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewFrequency(int newFrequency, string newName)
    {
        return new RAM(newName, MemorySize, newFrequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewStandardOfDdr(int newStandard, string newName)
    {
        return new RAM(newName, MemorySize, Frequency, Voltage, FormFactor, newStandard, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewProfileXmp(XMP? newXmp, string newName)
    {
        return new RAM(newName, MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, newXmp);
    }

    public bool Equals(RAM? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return MemorySize == other.MemorySize && Frequency == other.Frequency && Voltage == other.Voltage && FormFactor == other.FormFactor && StandardOfDDR == other.StandardOfDDR && Power == other.Power && Equals(ProfileXMP, other.ProfileXMP);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not RAM) return false;
        return Equals((RAM)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MemorySize, Frequency, Voltage, (int)FormFactor, StandardOfDDR, Power, ProfileXMP);
    }
}